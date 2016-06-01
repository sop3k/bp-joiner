using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using PathOp = System.IO.Path;
using MSWord = Microsoft.Office.Interop.Word;

namespace baseprotect
{
    class DocumentCreator : IDisposable
    {
        private TempFile TemplateDoc = null;
        private String pdfPath;

        public DocumentCreator(Template template, Object FillerObject, String PdfDirectory)
        {
            TemplateDoc = new TempFile(".doc");
            using (FileStream stream = new FileStream(TemplateDoc.Path, FileMode.OpenOrCreate))
            {
                Utils.WriteFully(stream, template.RawTemplate.ToArray());
                stream.Close();
            }

            Word word = new Word(false);

            try
            {
                using (WordDoc doc = word.Open(TemplateDoc.Path))
                {
                    foreach (BlockPlaceholder block in doc.FindAllBlockPlaceholders())
                    {
                        block.Replace(null);
                    }

                    foreach (Placeholder holder in doc.FindAllPlaceholders())
                    {
                        try
                        {
                            holder.Replace(FillerObject);
                            holder.Dispose();
                        }
                        catch (KeyNotFoundException)
                        {
                            TemplateDoc.Dispose();

                            String Message = "Cannot fill '{0}' placeholder in #{1} template";
                            throw new KeyNotFoundException(string.Format(Message,
                                holder.PlaceholderName, template.Order));
                        }
                    }

                    Munger FilesNoMunger = new Munger("FilesNo");
                    String PdfFileName = PathValidation.CleanFileName(String.Format("{0}.pdf",
                        FilesNoMunger.GetValue(FillerObject)));
                    pdfPath = PathOp.Combine(PdfDirectory, PdfFileName);

                    Directory.CreateDirectory(PdfDirectory);

                    //doc.Save();
                    doc.SaveAsPDF(string.Format(PdfPath));
                }
            }
            finally
            {
                word.Dispose();
            }
        }

        public void Dispose()
        {
            if (TemplateDoc != null)
                TemplateDoc.Dispose();
        }

        public String Path
        {
            get { return TemplateDoc.Path; }
        }

        public String PdfPath
        {
            get { return pdfPath; }
        }
    }
}
