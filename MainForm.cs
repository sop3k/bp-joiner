using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Reflection;
using System.IO;
using Microsoft.Win32;
using System.Linq;
using System.Transactions;

using BrightIdeasSoftware;
using IntelleSoft.BugTrap;

namespace baseprotect
{
    public partial class JoinerForm : Form
    {
        SplashScreen splash = new SplashScreen();
        StateChanger stateGuard; 
        StreamWriter errorLogger;
        StreamWriter sqlLogger;

        public JoinerForm()
        {
            /*
            ExceptionHandler.AppName = "Baseprotect Joiner 2.0";
            ExceptionHandler.Flags = FlagsType.AttachReport;
            ExceptionHandler.DumpType = MinidumpType.Normal;
            ExceptionHandler.SupportEMail = "cto@baseprotect.com";
            ExceptionHandler.ReportFormat = ReportFormatType.Xml;
            ExceptionHandler.Activity = ActivityType.ShowUI;
            */
            
            //ExceptionHandler.InstallHandler();

            InitializeComponent();

            mainList.ShowGroups = true;
            mainList.PrimarySortColumn = stateColumn;
            mainList.SortGroupItemsByPrimaryColumn = true;
            mainList.SpaceBetweenGroups = 0;
            mainList.UseCellFormatEvents = true;

            mainList.FormatCell += new EventHandler<FormatCellEventArgs>(mainList_FormatCell);

            Converter<Person>.RegisterConverter(typeof(TableToPerson));
            Converter<NetEvent>.RegisterConverter(typeof(TableToEvent));
            Converter<PersonToEvent>.RegisterConverter(typeof(TableToPersonEventRelation));
            Converter<Info>.RegisterConverter(typeof(TableToInfo));

            sqlLogger = new StreamWriter("SQLLog.log");
            errorLogger = new StreamWriter("ErrorLog.log");

            SetRegistry();
        }

        private void SetRegistry()
        {
            try
            {
                Registry.LocalMachine.OpenSubKey("SOFTWARE", true)
                    .OpenSubKey("Microsoft", true)
                    .OpenSubKey("Jet", true)
                    .OpenSubKey("4.0", true)
                    .OpenSubKey("Engines", true)
                    .OpenSubKey("Excel", true).
                    SetValue("TypeGuessRows", 0);

                Registry.LocalMachine.OpenSubKey("SOFTWARE", true)
                    .OpenSubKey("Microsoft", true)
                    .OpenSubKey("Jet", true)
                    .OpenSubKey("4.0")
                    .OpenSubKey("Engines", true)
                    .OpenSubKey("Excel", true)
                    .SetValue("ImportMixedTypes", "Text");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void  ShowNewProjectDialog()
        {
            ProjectProperties dlg = new ProjectProperties();
            if (dlg.ShowDialog() == DialogResult.OK){
                SetProject(dlg.Project);
            }
        }

        private void ShowEditProjectDialog(Project project)
        {
            ProjectProperties dlg = new ProjectProperties(project);
            dlg.ShowDialog();
        }

        private bool ChooseDB()
        {
            ChooseDBForm dlg = new ChooseDBForm();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Config.CreateDBConnection(dlg.Connection);
                return true;
            }
            return false;
        }
        
        private void JoinerForm_Load(object sender, EventArgs e)
        {
            if (DateTime.Now > DateTime.Parse("2013-12-10"))
            {
                Close();
            }

            if (ChooseDB())
            {
                revLabel.Text = String.Format("{0} ({1:g})", Version.Revision(),
                    Version.RetrieveLinkerTimestamp());

                if (Config.DB.Projects.Count() == 0)
                    ShowNewProjectDialog();
                else
                    ShowSelectProjectDialog();
            }
            else
                Application.Exit();
        }

        private void PrefetchEvents(IEnumerable<Person> collection, bool refresh)
        {
            foreach (Person p in collection){
                p.GetEvents(Config.ActiveProject, refresh);
            }
        }

        private void populateList(bool full)
        {
            paymentColumn.GroupKeyGetter = delegate(object rowObject)
            {
                Person person = (Person)rowObject;
                return person.PaymentsAmount();
            };

            paymentColumn.GroupKeyToTitleConverter = delegate(object groupKey)
            {
                decimal amount = (decimal)groupKey;
                if (amount == 0)
                    return "No payments at all.";
                return "Persons who made some payments";
            };

            penaltyColumn.GroupKeyGetter = delegate(object rowObject)
            {
                Person person = (Person)rowObject;
                return person.PenaltyAmount() != Config.ActiveProject.Penalty; 
            };

            penaltyColumn.GroupKeyToTitleConverter = delegate(object groupKey)
            {
                bool mod = (bool)groupKey;
                if (!mod)
                    return "Non modified penalty";
                return "Modified penalty";
            };

            cityColumn.GroupKeyGetter = delegate(object rowObject)
            {
                Person person = (Person)rowObject;
                return person.City[0];
            };

            cityColumn.GroupKeyToTitleConverter = delegate(object groupKey)
            {
                if (groupKey != null)
                    return String.Format("{0}", groupKey);
                else
                    return "";
            };

            stateColumn.GroupKeyGetter = delegate( object rowObject )
            {
                Person person = (Person)rowObject;
                return person.CurrentState.State;
            };
            
            stateColumn.GroupKeyToTitleConverter = delegate( object groupKey )
            {
                return StateInfo.GetInfo((State)groupKey).Description;
            };

            stateColumn.ImageGetter = delegate( object rowObject )
            {
                    Person p = (Person)rowObject;
                    String key = p.CurrentState.State.ToString();
                    Image image = StateInfo.GetInfo(p.CurrentState.State).Image;

                    if (image != null && !mainList.SmallImageList.Images.ContainsKey(key))
                    {
                        mainList.SmallImageList.Images.Add(key, image);
                    }

                    return key;
            };

            dateColumn.GroupKeyGetter = delegate(object rowObject)
            {
                Person person = (Person)rowObject;
                DateTime StateDate = person.CurrentState.Date;
                return new DateTime(StateDate.Year, StateDate.Month, 1);
            };

            dateColumn.ImageGetter = delegate( object rowObject )
            {
                PersonState state = ( (Person)rowObject ).CurrentState;
                Document document = state.Document;

                if ( document != null )
                    return "attachment";
                return String.Empty;
            };

            dateColumn.GroupKeyToTitleConverter = delegate(object groupKey)
            {
                DateTime groupDate = (DateTime)groupKey;
                return groupDate.ToString("MMMM yyyy");
            };

            var persons = (List<Person>)Config.ActiveProject.Persons;

            if (full) stateGuard.BatchChange(persons);
              
            mainList.SetObjects(persons);
        }

        void mainList_FormatCell(object sender, FormatCellEventArgs e)
        {
            if (e.Column == paymentColumn)
            {
                Person p = (Person)e.Model;
                e.SubItem.ForeColor = p.PaymentsAmount() == 0
                    ? Color.Red : p.PenaltyAmount() > p.PaymentsAmount() 
                    ? Color.Green : Color.Blue; 
            }
        }

        private void populateList()
        {
            populateList(false);
        }

        private void SetProject(Project project)
        {
            if (project == null)
                return;

            Config.ActiveProject = project;
            stateGuard = new StateChanger(TimeSpan.FromDays(Config.ActiveProject.IgnoreAfter), 
                new State[1]{State.Notified});

            activeProjectLabel.Text = project.Name;
            personCount.Text = project.Persons.ToEnumerable().Count().ToString();
            populateList(true); 
            
            NotifyButton.Enabled = (Config.ActiveProject.Templates.AsEnumerable().Count() != 0);

            RefreshPayments();
            CheckReminders();
        }

        void CheckReminders()
        {
            Reminders r = new Reminders();
            var to_post = r.Check(Config.ActiveProject);

            r.Post(to_post);
        }

        void RefreshPayments()
        {
            var project = Config.ActiveProject;
            var persons = Config.ActiveProject.Persons.ToEnumerable().ToList();

            sumLabel.Text = String.Format("{0:N}€", persons.Sum(p => p.PenaltyAmount()));
            paidLabel.Text = String.Format("{0:N}€", persons.Sum(p => p.PaymentsAmount()));
            notPaidLabel.Text = String.Format("{0:N}€", persons.Sum(p => { return p.PenaltyAmount() - p.PaymentsAmount(); }));
        }

        private void newProject_Click(object sender, EventArgs e)
        {
            ProjectProperties projProps = new ProjectProperties();
            if (projProps.ShowDialog() == DialogResult.OK)
            {
               using (new LoadingIndicator(new DlgWait(), this))
               {
                    SetProject(projProps.Project);
               }
            }
        }

        private void openProject_Click(object sender, EventArgs e)
        {
            ShowSelectProjectDialog();
        }

        private void ShowSelectProjectDialog()
        {
            SelectProjectForm projectSelection = new SelectProjectForm();
            DialogResult result = projectSelection.ShowDialog();

            if (result == DialogResult.OK)
            {
                using (new LoadingIndicator(new DlgWait(), this))
                {
                    if (projectSelection.Project != null)
                        SetProject(projectSelection.Project);
                }
            }
            else if (result == DialogResult.Ignore)
            {
                ShowNewProjectDialog();
            }
            else
            {
                Close();
            }
        }

        private void importBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int CountBefore = Config.ActiveProject.Persons.ToEnumerable().Count();

                NewDataForm newDataForm = new NewDataForm(Config.DB);
                newDataForm.ShowDialog();
                using(new LoadingIndicator(new DlgWait(), this)){
                    populateList();
                    
                }

                int CountAfter = Config.ActiveProject.Persons.ToEnumerable().Count();
                MessageBox.Show(String.Format("Imported {0} rows", CountAfter - CountBefore),
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Information );
            }
            catch (Exception ex)
            {
                Utils.HandleException(ex, errorLogger);
            }
        }

        private void toolStripButton1_Click( object sender, EventArgs e )
        {
            searchPanel.Visible = showSearchPanel.Checked;
            mainList.UseFiltering = showSearchPanel.Checked;
            mainList.ShowGroups = !mainList.UseFiltering;
            
            if (mainList.ShowGroups)
                mainList.Sort();
        }

        private void firstNameSearchInput_TextChanged( object sender, EventArgs e )
        {
            mainList.ModelFilter = new ModelFilter( delegate( object x )
            {
                return ( (Person)x ).FirstName.ToUpper().StartsWith(firstNameSearchInput.Text.ToUpper());
            } );
        }

        private void textBox2_TextChanged( object sender, EventArgs e )
        {
            mainList.ModelFilter = new ModelFilter( delegate( object x )
            {
                return ( (Person)x ).SecondName.ToUpper().StartsWith( secondNameSearchInput.Text.ToUpper() );
            } );
        }

        private void citySearchInput_TextChanged( object sender, EventArgs e )
        {
            mainList.ModelFilter = new ModelFilter( delegate( object x )
            {
                return ( (Person)x ).City.ToUpper().StartsWith( citySearchInput.Text.ToUpper() );
            } );
        }

        private void mainList_ItemActivate( object sender, EventArgs e )
        {
            Person person = (Person)mainList.SelectedObject;
            DlgPersonDetails dlg = new DlgPersonDetails(person);
            dlg.ShowDialog();

            mainList.RefreshObject(person);
            RefreshPayments();

        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            if (mainList.CheckedItems.Count != 1)
                return;

            Person person = (Person)mainList.CheckedObjects[0];
            if (person != null)
            {
                DlgChangeState dlg = new DlgChangeState(person);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    person.ChangeState(dlg.NewState, dlg.StateComment, dlg.AttachedDocumentPath, Config.ActiveProject);
                    Config.DB.SubmitChanges();
                    mainList.BuildList();
                }
            }
        }

        private IEnumerable<CheckBox> GetStatesChecked()
        {
            foreach(Control box in StatesGroup.Controls)
            {
                if(box is CheckBox)
                    yield return (CheckBox)box;
            }
        }

        private void stateSearchList_SelectedIndexChanged( object sender, EventArgs e )
        {
            mainList.ModelFilter = new ModelFilter( delegate( object x )
            {
                bool show = false;
                Person person = (Person)x;

                foreach (CheckBox item in GetStatesChecked())
                {
                    if(item.Checked)
                        show ^= (person.CurrentState.State == (State)Enum.Parse(typeof(State), item.Text));
                }

                return show;
            });
        }

        private void toolStripButton1_Click_2( object sender, EventArgs e )
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            DateTime dt = DateTime.Now;
     
            notifyWorker.RunWorkerAsync(Path.Combine(dlg.SelectedPath, 
                String.Format("{0}", dt.ToString("yyddmmhhMM"))));
        }


        private IEnumerable<List<T>> GetBatch<T>(IEnumerable<T> collection, int batchSize)
        {
            List<T> batch = new List<T>();
            foreach (T obj in collection)
            {
                batch.Add(obj);
                if (batch.Count == batchSize)
                {
                    yield return batch;
                    batch.Clear();
                }
            }

            yield return batch;
        }

        private void BulkNotify(IEnumerable<Person> AllPersons, String PdfDirectory, 
            Action<Person> progressReporter, Project Project)
        {
            int begin = 0;

            foreach (var batch in GetBatch<Person>(AllPersons, Config.BatchSize()))
            {
                Config.LogWrite(String.Format("Batch Size: {0}", batch.Count()));

                List<String> toMerge = new List<String>();
                
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, TimeSpan.Zero))
                {
                    foreach (Person CurrentPerson in batch)
                    {
                        Config.LogWrite(String.Format("1: {0}", CurrentPerson.ToString()));

                        String pdfFile = NotifyPerson(CurrentPerson, PdfDirectory, Project);
                        if (!String.IsNullOrEmpty(pdfFile))
                            toMerge.Add(pdfFile);
                        progressReporter.Invoke(CurrentPerson);

                        Config.LogWrite(String.Format("2: {0}", pdfFile));
                    }

                    if (toMerge.Count != 0)
                    {
                        String filename = string.Format("{0}_{1}-{2}", DateTime.Now.ToString("yyMMdd"), begin, begin + Config.BatchSize());

                        Config.LogWrite(String.Format("3: {0}", filename));

                        DocToPdf.Merge(toMerge.ToArray(), System.IO.Path.Combine(PdfDirectory, filename));

                        begin += Config.BatchSize();
                    }

                    Config.LogWrite("4: Storing to database");
                    Config.DB.SubmitChanges();

                    Config.LogWrite("5: Transaction commit");
                    scope.Complete();
                }
            }
        }

        private String NotifyPerson(Person PersonToBeNotified, String PdfDirectory, Project Project)
        {
            List<String> files = new List<string>();
            Notify NewNotify = new Notify();
            Notify LastNotify = PersonToBeNotified.Notifies.OrderBy(n => n.Date).Reverse().FirstOrDefault();
            
            int Order = 1;
            if (LastNotify != null && LastNotify.Document != null)
                Order = LastNotify.Document.Order;

            var defaultDoc = Config.DB.Templates.Where(t => t.ProjectID == Project.ID).Where(t => t.Order == Order).FirstOrDefault();
            if(defaultDoc == null)
                defaultDoc = Config.DB.Templates.Where(t => t.ProjectID == Project.ID).OrderBy(p => p.Order).First();

            if (defaultDoc == null)
            {
                MessageBox.Show("There is no templates");
                return null;
            }

            var DocumentTemplate = Config.DB.Templates.Where(t => t.ProjectID == Project.ID).Where(t => t.Order > Order).FirstOrDefault();
            if (DocumentTemplate == null)
            {
                //if (MessageBox.Show("There is no further templates. Print with last used template?", "Joiner",
                //    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                //{
                    DocumentTemplate = defaultDoc;
                //} 
                
            }
            
            using (var Creator = new DocumentCreator(DocumentTemplate, PersonToBeNotified, PdfDirectory))
            {
                    String TemporaryFile = Creator.Path;
                    PersonState NewState = PersonToBeNotified.ChangeState(State.Notified, String.Empty, TemporaryFile, Config.ActiveProject);

                    NewNotify.State = NewState;
                    NewNotify.Date = DateTime.Now;
                    NewNotify.Document = NewState.Document;
                    NewNotify.PersonID = PersonToBeNotified.ID;
                    NewNotify.Project = Project;

                    PersonToBeNotified.Notifies.Add(NewNotify);
                    Config.LogWrite(String.Format("Document created: {0}", Creator.PdfPath));
                    return Creator.PdfPath;
            }

            return String.Empty;
        }

        private void exportBtn_ButtonClick(object sender, EventArgs e)
        {
            var notified = Config.DB.Notifies.Where(x => x.Project == Config.ActiveProject).Select(x => x.PersonID);

            List<Person> toExport = new List<Person>();
            foreach (Person p in Config.DB.Persons){
                if (!notified.Contains(p.ID))
                    toExport.Add(p);
            }

            overallProgress.Maximum = toExport.Count();
            Export(toExport);
        }

        private void checkedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var toExport = mainList.CheckedObjects.Cast<Person>();
            overallProgress.Maximum = toExport.Count();
            Export(toExport);
        }

        private void Export(IEnumerable<Person> set)
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.DefaultExt = ".csv";
                dlg.Filter = "CSV files|*.csv";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    CSVExporter exporter = new CSVExporter(Config.DB, dlg.FileName, Config.GetHeaderTranslateFile());

                    exporter.RegisterConverter("BennKenn",
                        (string s) =>
                        {
                            if (string.IsNullOrEmpty(s))
                                return s;

                            int pivot = s.LastIndexOf('-');
                            pivot = pivot < 0 ? s.Trim().LastIndexOf(' ') : pivot;
                            return s.Substring(0, pivot);
                        });

                    exportWorker.RunWorkerAsync(new { Exporter = exporter, ToExport=set });
                }
            }
            catch (Exception ex)
            {
                errorLogger.Write(ex.StackTrace);
                errorLogger.Flush();
                MessageBox.Show(ex.Message);
            }
        }

        private void akzSearchInput_TextChanged(object sender, EventArgs e)
        {
            mainList.ModelFilter = new ModelFilter(delegate(object x)
            {
                Person person = (Person)x;
                //return person.Events.ToEnumerable().Count(ev => ev.BennKenn.StartsWith(akzSearchInput.Text.ToUpper())) != 0;
                return person.Events.ToEnumerable().Count(ev => ev.BennKenn.ToUpper().Contains(akzSearchInput.Text.ToUpper())) != 0;
            });
        }

        private void notifyWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                String PdfDirectory = (string)e.Argument;
                IEnumerable<Person> ToNotified = new List<Person>();

                IEnumerable<Person> CheckedPersons = null;
                IEnumerable<Person> AllPersons = null;

                this.InvokeEx(f =>
                {
                    CheckedPersons = mainList.CheckedObjects.Cast<Person>();
                    if (CheckedPersons.Count() == 0 && mainList.SelectedObjects.Count > 1)
                    {
                        CheckedPersons = mainList.SelectedObjects.Cast<Person>();
                    }
                    AllPersons = mainList.Objects.Cast<Person>();
                });

                int Count = CheckedPersons.Count();
                if (Count > 0)
                {
                    String Message = String.Format("Will notify only {0} checked person(s). Continue?", Count);

                    if (MessageBox.Show(Message,
                            "Joiner Bulk Notiy",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ToNotified = CheckedPersons;
                    }
                }
                else
                {
                    State[] StateToNotify = new State[] { State.NotNotified, State.NotPaid, State.Ignoring };
                    ToNotified = AllPersons.Where(p => StateToNotify.Contains(p.CurrentState.State));
                }

                this.InvokeEx(f => { overallProgress.Maximum = ToNotified.Count(); });
                BulkNotify(ToNotified, PdfDirectory, 
                    (Person p) => 
                    { 
                        notifyWorker.ReportProgress(0);
                        mainList.RefreshObject(p);
                    }, 
                    Config.ActiveProject);
            }
            finally
            {
                EndWorker(notifyWorker);
            }
        }

        private void exportWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var Exporter = Utils.Getter<CSVExporter>.Get(e.Argument, "Exporter");
                var toExport = Utils.Getter<IEnumerable<Person>>.Get(e.Argument, "ToExport");

                 Exporter.Export(toExport, () => { exportWorker.ReportProgress(0); });
            }
            finally
            {
                EndWorker(exportWorker);
            }
        }

        private void EndWorker(BackgroundWorker worker)
        {
            this.InvokeEx(f =>
            {
                overallProgress.Value = overallProgress.Maximum;
                worker.ReportProgress(100);
            }); ;
        }

        private void exportWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            overallProgress.PerformStep();
        }

        private void notifyWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            overallProgress.PerformStep();
        }

        private void notifyWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else
            {
                MessageBox.Show("Generating notifies ended.", Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                overallProgress.Value = overallProgress.Minimum;

                mainList.BuildList();
            }
        }

        private void exportWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Export ended succesfully.", Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
            overallProgress.Value = overallProgress.Minimum;
            mainList.BuildList();
        }

        private void importData_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                using (new LoadingIndicator(new DlgWait(), this))
                {
                    InfoImporter importer = new InfoImporter();
                    importer.Import(dlg.FileName);
                }
            }
        }

        private void mainList_CellEditFinishing(object sender, CellEditEventArgs e)
        { 
            Person x = (Person)e.RowObject;
            Munger m = new Munger(e.Column.AspectName);
            if(m.GetValue(x) != e.NewValue) 
                Config.DB.SubmitChanges();
        }

        private void postalSearchInput_TextChanged(object sender, EventArgs e)
        {
            mainList.ModelFilter = new ModelFilter(delegate(object x)
            {
                return ((Person)x).Postal.ToUpper().StartsWith(postalSearchInput.Text.ToUpper());
            });
        }

        private void toolStripButton1_Click_3(object sender, EventArgs e)
        {
            ShowEditProjectDialog(Config.ActiveProject);
            NotifyButton.Enabled = (Config.ActiveProject.Templates.AsEnumerable().Count() != 0);
        }

        private void lawyerBtn_Click(object sender, EventArgs e)
        {
            LawyersList dlg = new LawyersList();
            dlg.ShowDialog();
        }

        private void changeDBBtn_Click(object sender, EventArgs e)
        {
            ChooseDBForm dlg = new ChooseDBForm();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Config.CreateDBConnection(dlg.Connection);
            }
        }
    }
}
