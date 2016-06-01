using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using Bullzip.PdfWriter;

namespace baseprotect
{
    class DocToPdf
    {
        const string PRINTERNAME = "Bullzip PDF Printer";

        public static void Convert(WordDoc doc, string filename)
        {
            string outfilename = string.Format(filename);
            
            PdfSettings pdfSettings = new PdfSettings();

            pdfSettings.PrinterName = PRINTERNAME;
            pdfSettings.SetValue("output", outfilename);    
            pdfSettings.SetValue("showpdf", "no");
            pdfSettings.SetValue("showsettings", "never");
            pdfSettings.SetValue("showsaveas", "never");
            pdfSettings.SetValue("showprogress", "never");
            pdfSettings.SetValue("showprogressfinished", "no");
            pdfSettings.SetValue("confirmoverwrite", "no");
            pdfSettings.SetValue("openfolder", "no");
            pdfSettings.SetValue("GhostscriptTimeout", "3600");
            pdfSettings.WriteSettings(PdfSettingsFileType.RunOnce);

            doc.Document.Application.ActivePrinter = PRINTERNAME;
            doc.Document.Application.Visible = false;

            Config.LogWrite(String.Format("Priting file: {0}", filename));
            
            doc.Document.PrintOut(ref Utils.Missing, ref Utils.Missing, ref Utils.Missing, 
                                  ref Utils.Missing, ref Utils.Missing, ref Utils.Missing, 
                                  ref Utils.Missing, ref Utils.Missing, ref Utils.Missing, 
                                  ref Utils.Missing, ref Utils.Missing, ref Utils.Missing, 
                                  ref Utils.Missing, ref Utils.Missing, ref Utils.Missing,
                                  ref Utils.Missing, ref Utils.Missing, ref Utils.Missing);

            Config.LogWrite("Printed");

            try{
                //PdfUtil.PrintFile(doc.FullPath, PRINTERNAME);
                int i=0;
                while(PdfUtil.WaitForFile(outfilename, 1000) && i < 10)
                {
                    Config.LogWrite(String.Format("[{0}]: WaitForFile", i++));
                }

            }catch (Exception e){
                MessageBox.Show(e.Message);
            }
        }

        public static void Merge(String[] filenames, String outfilename)
        {
            string firstfile = string.Format(filenames.Last());
            string MergeOption = String.Join("|", filenames.Take(filenames.Length - 1).ToArray());

            PdfSettings pdfSettings = new PdfSettings();

            pdfSettings.PrinterName = PRINTERNAME;
            pdfSettings.SetValue("output", System.IO.Path.ChangeExtension(outfilename, "pdf"));
            pdfSettings.SetValue("showpdf", "no");
            pdfSettings.SetValue("openfolder", "no");
            pdfSettings.SetValue("showsettings", "never");
            pdfSettings.SetValue("showsaveas", "never");
            pdfSettings.SetValue("showprogress", "no");
            pdfSettings.SetValue("showprogressfinished", "no");
            pdfSettings.SetValue("confirmoverwrite", "never");
            pdfSettings.SetValue("GhostscriptTimeout", "360000");
            pdfSettings.SetValue("mergefile", MergeOption);
            pdfSettings.WriteSettings(PdfSettingsFileType.RunOnce);

            Thread oThread = new Thread(new ParameterizedThreadStart((Object thr) =>
                {
                    while (true)
                    {
                        Process[] processes = Process.GetProcessesByName("AcroRd32");
                        foreach (Process proc in processes)
                        {
                            Thread.Sleep(20*1000);
                            proc.Kill();
                        }
                        Thread.Sleep(1);
                    }
                }
             ));

            oThread.Start(oThread);

            while (true)
            {
                try
                {
                    PdfUtil.PrintFile(firstfile, PRINTERNAME);
                    oThread.Abort();
                    break;
                }
                catch (Exception)
                {
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }
    }

}