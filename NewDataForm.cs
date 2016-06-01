using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Transactions;
using System.IO;

namespace baseprotect
{
     partial class NewDataForm : Form
     {
         BaseprotectDB db;
         Table providerTable;
         Table eventsTable;
         ProviderFormatInfo providerFormater;

        public NewDataForm(BaseprotectDB _db)
        {
            db = _db;
            InitializeComponent();
        }

        private void providerLookupBtn_Click(object sender, EventArgs e)
        {
           OpenFileDialog dlg = new OpenFileDialog();
           if (dlg.ShowDialog() == DialogResult.OK)
           {
                providerFilePath.Clear();
                providerFilePath.AppendText(dlg.FileName);
                providerTable = ReadTable(dlg.FileName, providerFormater);
           }

           eventLookupBtn.Enabled = true;
        }

        private void eventLookupBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                eventFilePath.Clear();
                eventFilePath.AppendText(dlg.FileName);
                eventsTable = ReadTable(dlg.FileName, providerFormater);
            }
        }

        private Table ReadTable(string filename, ProviderFormatInfo pfi)
        {
            using (ExcelCleaner cl = new ExcelCleaner())
            {
                string file = cl.CleanExcelFile(filename, String.Join("|", pfi.Sheets));
                string worksheet = cl.FindWorksheet(file, pfi.Sheets);

                using (ExcelReader reader = new ExcelReader())
                {
                    reader.Open(file);
                    return reader.ReadWorksheet(worksheet, pfi);
                }
            }           
        }

        private void loadBtn_Click( object sender, EventArgs e )
        {
            try
            {
                joinProgress.Maximum = providerTable.Count + eventsTable.Count;
                worker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                String message = ex.InnerException == null 
                    ? ex.InnerException.StackTrace 
                    : String.Empty;

                MessageBox.Show(String.Format("Wrong file format. Change format or try to add new .isp file for this file. \n\n\n {0} ", message), "Joiner", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, TimeSpan.FromHours(1)))
                {
                    SQLiteTableWriter<Person> personWriter = new SQLiteTableWriter<Person>(db);
                    SQLiteTableWriter<NetEvent> eventWriter = new SQLiteTableWriter<NetEvent>(db);

                    int personsWritten = personWriter.WriteTable(db.Persons, providerTable, () => { worker.ReportProgress(0); });
                    int eventsWritten = eventWriter.WriteTable(db.Events, eventsTable, () => worker.ReportProgress(0));

                    Table joinedTable = providerTable.Join(eventsTable, Config.GetJoinColumns());

                    SQLiteTableWriter<PersonToEvent> relationWriter = new SQLiteTableWriter<PersonToEvent>(db);
                    relationWriter.WriteTable(db.PersonsToEvents, joinedTable, () => { worker.ReportProgress(0); });

                    JoinProcesses.AddJoinProcess(Config.DB, personsWritten, providerTable, eventsTable);

                    scope.Complete();
                }
            }
            finally
            {
                worker.ReportProgress(100);
            }
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            joinProgress.PerformStep();
            if(e.ProgressPercentage == 100)
                joinProgress.Value = joinProgress.Maximum;
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                DialogResult = DialogResult.Cancel;

                DialogResult r = MessageBox.Show("Wrong file format. Change format or try to add new .isp file for this file. Click 'No' for details.", "Joiner",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                if (r == DialogResult.Cancel)
                {
                    MessageBox.Show(string.Format("Error while joining. Wrong file format! ({0})", e.Error.StackTrace), "Error Details", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                DialogResult = DialogResult.OK;

            Close();
        }

        private void NewDataForm_Load(object sender, EventArgs e)
        {
            var formats = ProviderFormatInfoMgr.LoadAllFormats(Path.Combine(Directory.GetCurrentDirectory(), "isp"));
            provider.Items.AddRange(formats.Select(p => { return new { Text = p.ProviderName, Tag = p }; }).ToArray());
        }

        private void provider_SelectedIndexChanged(object sender, EventArgs e)
        {
            providerFormater = (ProviderFormatInfo)(new Munger("Tag").GetValue(((ComboBox)sender).SelectedItem));
            providerLookupBtn.Enabled = providerFormater != null;
        }
    }
}
