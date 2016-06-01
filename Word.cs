using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using System.Windows.Forms;
using MSWord = Microsoft.Office.Interop.Word;

namespace baseprotect
{
    class Word : IDisposable
    {
        MSWord.Application WordApp;
        List<WordDoc> Documents = new List<WordDoc>();
        String FullPath;

        public delegate void DocCloseHandler(MSWord.Document doc);
        public event DocCloseHandler OnDocClose;

        public Word(bool Visible)
        {
            WordApp = new MSWord.Application();
            WordApp.Visible = Visible;
            if ( Visible )
                WordApp.Activate();

            WordApp.DocumentBeforeClose += new MSWord.ApplicationEvents4_DocumentBeforeCloseEventHandler(WordApp_DocumentBeforeClose);
        }

        void WordApp_DocumentBeforeClose(MSWord.Document Doc, ref bool Cancel)
        {
            if(OnDocClose != null)
                OnDocClose(Doc);
        }

        public WordDoc Open( String Path )
        {
            MSWord.Documents docs = WordApp.Documents;
            MSWord.Document doc;

            try
            {
                Object Filename = Path;
                Object ReadOnly = false;

                doc = docs.Open( ref Filename, ref Utils.Missing, ref ReadOnly, ref Utils.Missing, ref Utils.Missing, ref Utils.Missing,
                                ref Utils.Missing, ref Utils.Missing, ref Utils.Missing, ref Utils.Missing, ref Utils.Missing, ref Utils.Missing,
                                ref Utils.Missing, ref Utils.Missing, ref Utils.Missing, ref Utils.Missing );

                Documents.Add( new WordDoc( doc, Path ) );
                return Documents.Last();
            }
            catch ( Exception )
            {
                docs.Close( ref Utils.Missing, ref Utils.Missing, ref Utils.Missing );
                throw;
            }
        }

        public void Dispose()
        {
            try
            {
                foreach (WordDoc doc in Documents)
                {
                    doc.Dispose();
                }
            }
            catch (Exception e) { }

            WordApp.Quit(ref Utils.Missing, ref Utils.Missing, ref Utils.Missing);
        }
    }

    class WordDoc : IDisposable
    {
        private MSWord.Document document;
        public String FullPath;

        public WordDoc( MSWord.Document doc, string path )
        {
            FullPath = path;
            document = doc;
            document.Activate();
        }

        public IEnumerable<Placeholder> FindAllPlaceholders()
        {
            return Utils.EnumeratorJoin<Placeholder>.Join(FindAllBlockPlaceholders(),
                FindAllFieldPlaceholders(), FindAllSinglePlaceholders());
        }

        public IEnumerable<Placeholder> FindMatchedPlaceholders(String regex, Type type)
        {
            String Regex = String.Format(@"(&{0}&)", regex);
            MSWord.Range WholeDoc = document.Content;

            WholeDoc.Find.ClearFormatting();

            //WholeDoc.Find.Forward = true;
            WholeDoc.Find.MatchWildcards = true;
            WholeDoc.Find.Wrap = MSWord.WdFindWrap.wdFindStop;

            WholeDoc.Find.Text = Regex;

            WholeDoc.Find.Execute(ref Utils.Missing, ref Utils.Missing, ref Utils.Missing, ref Utils.Missing, ref Utils.Missing,
                                   ref Utils.Missing, ref Utils.Missing, ref Utils.Missing, ref Utils.Missing, ref Utils.Missing,
                                   ref Utils.Missing, ref Utils.Missing, ref Utils.Missing, ref Utils.Missing, ref Utils.Missing);

            while (WholeDoc.Find.Found)
            {
                Object Start = WholeDoc.Start;
                Object End = WholeDoc.End;

                MSWord.Range FoundRange = document.Range(ref Start, ref End);

                WholeDoc.Find.Execute(ref Utils.Missing, ref Utils.Missing, ref Utils.Missing, ref Utils.Missing, ref Utils.Missing,
                                       ref Utils.Missing, ref Utils.Missing, ref Utils.Missing, ref Utils.Missing, ref Utils.Missing,
                                       ref Utils.Missing, ref Utils.Missing, ref Utils.Missing, ref Utils.Missing, ref Utils.Missing);

                var m = type.GetConstructor(new Type[]{typeof(MSWord.Range)});
                yield return (Placeholder)m.Invoke(new Object[]{FoundRange});
            }
        }

        public IEnumerable<Placeholder> FindAllBlockPlaceholders()
        {
            return FindMatchedPlaceholders(@"[0-9]@", typeof(BlockPlaceholder));
        }

        public IEnumerable<Placeholder> FindAllSinglePlaceholders()
        {
            return FindMatchedPlaceholders(@"[a-zA-Z_]@", typeof(Placeholder));
        }
            
        public IEnumerable<Placeholder> FindAllFieldPlaceholders()
        {
            foreach (MSWord.Field field in  document.Fields)
            {
                MSWord.Range rngFieldCode = field.Code;
                String fieldText = rngFieldCode.Text;

                if (fieldText.StartsWith(" MERGEFIELD"))
                {
                    Int32 endMerge = fieldText.IndexOf("\\");
                    String fieldName;

                    if (endMerge > 0)
                    {
                        Int32 fieldNameLength = fieldText.Length - endMerge;
                        fieldName = fieldText.Substring(11, endMerge - 11);
                        fieldName = fieldName.Trim();
                    }
                    else
                    {
                        fieldName = fieldText.Remove(0, " MERGEFIELD".Length);
                        fieldName = fieldName.Trim().Trim('\\').Trim('\"');
                    }

                    yield return new FieldPlaceholder(field, fieldName);
                } 
            }
        }

        public void Save()
        {
            document.Save();
        }

        public void SaveAsPDF(object filename)
        {
            //MessageBox.Show((string)filename);
            document.ExportAsFixedFormat((string)filename, MSWord.WdExportFormat.wdExportFormatPDF);
        }

        public void Print()
        {
            Document.PrintOut(ref Utils.Missing, ref Utils.Missing, ref Utils.Missing,
                                  ref Utils.Missing, ref Utils.Missing, ref Utils.Missing,
                                  ref Utils.Missing, ref Utils.Missing, ref Utils.Missing,
                                  ref Utils.Missing, ref Utils.Missing, ref Utils.Missing,
                                  ref Utils.Missing, ref Utils.Missing, ref Utils.Missing,
                                  ref Utils.Missing, ref Utils.Missing, ref Utils.Missing);
        }

        public void Dispose()
        {
            try
            {
                document.Close(ref Utils.Missing, ref Utils.Missing, ref Utils.Missing);
            }
            catch (Exception e)
            {
                //best effort
            }
        }

        public String Filename
        {
            get { return System.IO.Path.GetFileName(document.FullName); }
        }

        public String Path
        {
            get { return document.FullName; }
        }

        public MSWord.Document Document
        {
            get { return document; }
        }
    }

    class Placeholder : IDisposable
    {
        protected MSWord.Range Range;
        public String PlaceholderName
        {
            get;
            protected set;
        }

        public Placeholder(String name)
        {
            PlaceholderName = name;
        }

        public Placeholder( MSWord.Range range )
        {
            Range = range;
            PlaceholderName = Range.Text.Trim( '&' );
        }

        public String GetAspect(Object target)
        {
            object value = null;
            object aspect = PlaceholderNameMapping.GetAspect(PlaceholderName);

            if (aspect is String)
            {
                Munger munger = new Munger((String)aspect);
                value = munger.GetValue(target);
            }

            if (value == null)
                return String.Empty;

            return value.ToString();
        }

        public virtual void Replace( Object data )
        {
            String value = GetAspect(data);

            Range.Find.ClearFormatting();
            Range.Find.Replacement.ClearFormatting();

            Range.Find.Forward = true;
            Range.Find.MatchWildcards = true;
            Range.Find.Wrap = MSWord.WdFindWrap.wdFindContinue;

            Range.Find.Text = Range.Text;
            Range.Find.Replacement.Text = string.Format("{0}", value);

            Object ReplaceOne = MSWord.WdReplace.wdReplaceOne;
            Range.Find.Execute( ref Utils.Missing, ref Utils.Missing, ref Utils.Missing, ref Utils.Missing, ref Utils.Missing,
                                ref Utils.Missing, ref Utils.Missing, ref Utils.Missing, ref Utils.Missing, ref Utils.Missing,
                                ref ReplaceOne, ref Utils.Missing, ref Utils.Missing, ref Utils.Missing, ref Utils.Missing );
        }

        public virtual void Dispose()
        {
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(Range);
        }
    }

    class FieldPlaceholder : Placeholder
    {
        private MSWord.Field Field;

        public FieldPlaceholder(MSWord.Field field, String fieldName)
            : base(fieldName)   
        {
            Field = field;
        }

        public override void Replace(Object data)
        {
            Field.Select();
            String value = GetAspect(data);

            if (String.IsNullOrEmpty(value))
                Field.Delete();
            else
                Field.Application.Selection.TypeText(value);
        }

        public override void Dispose()
        {
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(Field);
        }
    }

    class BlockPlaceholder : Placeholder
    {
        public BlockPlaceholder(MSWord.Range range)
            : base(range)
        {}

        public override void Replace(object data)
        {
            String fname = String.Format("{0}.doc", PlaceholderName);
            String blocksDir = "blocks"; //Move to config !!!
            String path = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), blocksDir);
            String srcPath = System.IO.Path.Combine(path, fname);

            using (Word word = new Word(false))
            {
                WordDoc doc = word.Open(srcPath);

                MSWord.Document d = doc.Document;
                MSWord.Range r = d.Content;

                r.Copy();
                Range.Paste();
            }
        }
    }

    class PlaceholderNameMapping
    {
        static Dictionary<string, object> map = new Dictionary<string, object>()
            {
                {"VORNAME",             "FirstName"},
                {"NACHNAME",            "SecondName"},
                {"ORT",                 "City"},
                {"STRASSE",             "Details"},
                {"PLZ",                 "Postal"},
                {"ANREDE",              null},
                {"TITEL",               "Events.First.Title"},
                {"PENALTY",             "PenaltyString"},
                {"PENALTYDATUM",        "PenaltyDate"},
                {"AKTENZEICHEN",        "FilesNo"},
                {"DATUM",               "Events.First.Date.ToShortDateString"},
                {"UHRZEIT",             "Events.First.Time.ToShortTimeString"},
                {"DATEINAME",           "Events.First.Title"},
                {"IP",                  "Events.First.IP"},
                {"IP_ADRESSE",          "Events.First.IP"},
                {"DATEIHASH",           "Events.First.Hash"},
                {"BENUTZERKENNUNG",     "ISPName"},
                {"CURRENTDATE",         DateTime.Now},
                {"FIRMA",               null},
                {"LAWYER.VORNAME",      "Lawyer.FirstName"},
                {"LAWYER.NACHNAME",     "Lawyer.SecondName"},
                {"LAWYER.ORT",          "Lawyer.City"},
                {"LAWYER.PLZ",          "Lawyer.PostalCode"},
                {"LAWYER.STRASSE",      "Lawyer.Details"},
                {"LAWYER.EMAIL",        "Lawyer.Email"}
            };

        public static Object GetAspect(String name)
        {
            String upper = name.ToUpper();
            if (map.ContainsKey(upper))
                return map[upper];
            return name;
        }
    }
}