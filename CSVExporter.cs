using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Transactions;

namespace baseprotect
{
    class CSVExporter
    {
        string[] emptyColumns = { "FirstName", "SecondName", "Plugin", "Publish"};

        const int TRANSLATED_NAME = 1;
        const int ORIGINAL_NAME = 0;

        string filename;
        BaseprotectDB db;
        StreamWriter writer;
        List<string[]> translator = new List<string[]>();
        Dictionary<String, Func<String, String>> Converters = new Dictionary<string, Func<string, string>>();

        public CSVExporter(BaseprotectDB _db, string _filename)
        {
            db = _db;
            filename = _filename;
            writer = new StreamWriter(filename, false, Encoding.GetEncoding("iso-8859-1"));
        }

        public CSVExporter( BaseprotectDB _db, string filename, string translateFile)
            : this(_db, filename)
        {
            LoadTranslateFile(translateFile);
        }

        private void LoadTranslateFile(string filename)
        {
            StreamReader reader = new StreamReader(filename,Encoding.Default);
            try
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine().Trim();
                    
                    if (line.Length == 0)
                        break;
                    
                    string[] tokens = line.Trim().Split('=');
                    string oName = tokens[ORIGINAL_NAME].Trim();
                    string trName = tokens[TRANSLATED_NAME].Trim();
                    
                    Encoding encoding = Encoding.GetEncoding("iso-8859-1");
                    trName = encoding.GetString(Encoding.Convert(Encoding.Default, encoding, Encoding.Default.GetBytes(trName)));

                    translator.Add(new string[]{oName, trName});
                }
            }
            finally
            {
                reader.Close();
            }
        }

        public IEnumerable<string> GetTranslatedHeaders()
        {
            foreach (object[] names in translator)
            {
                yield return (string)names[TRANSLATED_NAME];
            }
        }

        public object TryGetValue(object target, string name)
        {
            Type targetType = target.GetType();
            PropertyInfo pinfo = targetType.GetProperty(name);
            if (pinfo == null)
                return null;
            return pinfo.GetValue(target, null);
        }

        public void RegisterConverter(String key, Func<String, String> cvt)
        {
            Converters.Add(key, cvt);
        }

        public int Export(IEnumerable<Person> persons, Action progressReporter)
        {
            int exported = 0;

            try
            {
                writer.WriteLine(string.Join(Config.GetSeparator(),
                                 GetTranslatedHeaders().ToArray()));

                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, TimeSpan.Zero))
                {
                    foreach (var person in persons)
                    {
                        var personEvents = from ep in db.PersonsToEvents
                                           join e in db.Events on ep.EventID equals e.ID
                                           where ep.PersonID == person.ID && 
                                                 e.Project == Config.ActiveProject
                                           select e;

                        NetEvent ev = personEvents.FirstOrDefault();

                        if (ev != null)
                        {
                            Notify export = new Notify();
                            export.PersonID = person.ID;
                            export.Date = DateTime.Now;
                            export.Type = NotifyType.Export;
                            export.Project = Config.ActiveProject;

                            string Comment = string.Format("Export to CSV file[{0}]", filename);
                            person.ChangeState(State.Exported, Comment, null, Config.ActiveProject);

                            db.Notifies.InsertOnSubmit(export);
                            db.SubmitChanges();

                            bool add = false;
                            List<string> data = new List<string>();

                            foreach (string[] c in translator)
                            {
                                string oName = c[ORIGINAL_NAME];
                                object value = TryGetValue(ev, oName);

                                if (value == null)
                                {
                                    value = TryGetValue(person, oName);
                                    if (value == null)
                                    {
                                        value = TryGetValue(export, oName);
                                        if (value == null)
                                        {
                                            value = TryGetValue(Config.ActiveProject, oName);
                                        }
                                    }
                                }

                                if (value != null && !string.IsNullOrEmpty(value.ToString()))
                                {
                                    add = true;
                                    string StrValue = Utils.String(value);

                                    if (Converters.ContainsKey(oName))
                                    {
                                        StrValue = Converters[oName](StrValue);
                                    }

                                    data.Add(StrValue);
                                }
                                else if (emptyColumns.Contains(oName))
                                {
                                    add = true;
                                    data.Add("");
                                }
                                else
                                {
                                    add = false;
                                    break;
                                }
                            }

                            if (add)
                            {
                                writer.WriteLine(string.Join(Config.GetSeparator(), data.ToArray()));
                                exported++;
                            }
                        }
                        if (progressReporter != null)
                            progressReporter.Invoke();
                    }

                    //db.Exports.InsertOnSubmit(new ExportProcess(exported));
                    db.SubmitChanges();

                    scope.Complete();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                writer.Close();
            }

            return exported;
        }

    }
}
