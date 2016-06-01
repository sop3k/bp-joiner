using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Transactions;

namespace baseprotect
{
    public partial class SelectProjectForm : Form
    {
        #region Members
        private Project project;
        #endregion

        #region Methods
        public SelectProjectForm()
        {
            InitializeComponent();

            importWorker.DoWork += new DoWorkEventHandler(importWorker_DoWork);
            importWorker.ProgressChanged += new ProgressChangedEventHandler(importWorker_ProgressChanged);
            importWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(importWorker_RunWorkerCompleted);
        }

        private IEnumerable<Project> LoadProjects()
        {
            var Projects = Config.DB.Projects;
            foreach (Project project in Projects)
            {
                yield return project;
            }
        }

        private void SelectProject_Load(object sender, EventArgs e)
        {
            ReloadProjects();
        }

        private void ReloadProjects()
        {
            try
            {
                projectsList.SetObjects(LoadProjects());
            }
            catch (Exception ex)
            {
                string err = string.Format("Error while loading project: {0}", ex.Message);
                MessageBox.Show(err, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadProject_Click(object sender, EventArgs e)
        {
            project = (Project)projectsList.SelectedObject;
        }

        private void projectsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadProject.Enabled = true;
            project = (Project)projectsList.SelectedObject;
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Ignore;
            Close();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            #region Import
            /*FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                importProgress.Visible = true;
                String ProjectName = System.IO.Path.GetDirectoryName(dlg.SelectedPath);
                var importer = new ProjectImporter(Config.DB, (Project)projectsList.SelectedObject, ProjectName);

                if (importer.CanImport())
                    importWorker.RunWorkerAsync(new { Importer = importer, Path = dlg.SelectedPath });
                else
                    MessageBox.Show("Import only in empty projects!", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */
            #endregion

            if (project != null)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;

                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, TimeSpan.FromHours(1)))
                    {
                        Config.ActiveProject = project;

                        var notifies = project.Persons.ToEnumerable().SelectMany(x => x.Notifies).ToList();
                        var events = project.Events.ToEnumerable().ToList();
                        var events_ids = events.Select(x => x.ID).ToList();
                        var states = Config.DB.States.Where(s => s.ProjectID == project.ID && s.Comment != "Person added");
                        var rel = Config.DB.PersonsToEvents.Where(x => events_ids.Contains(x.EventID)).ToList();
                        var pip = Config.DB.PersonInProject.Where(x => x.Project == project);
                        var templates = project.Templates;

                        /*Config.DB.States.DeleteAllOnSubmit(states);
                        Config.DB.Notifies.DeleteAllOnSubmit(notifies);
                        Config.DB.PersonInProject.DeleteAllOnSubmit(pip);
                        Config.DB.PersonsToEvents.DeleteAllOnSubmit(rel);
                        Config.DB.Events.DeleteAllOnSubmit(events);
                        Config.DB.Templates.DeleteAllOnSubmit(templates);
                        Config.DB.Payments.DeleteAllOnSubmit(project.Payments);
                        */

                        Config.DB.PersonInProject.DeleteAllOnSubmit(pip);
                        Config.DB.PersonsToEvents.DeleteAllOnSubmit(rel);
                        Config.DB.Projects.DeleteOnSubmit(project);
                        
                        Config.DB.SubmitChanges();

                        Config.ActiveProject = null;
                        scope.Complete();
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }

                Cursor = Cursors.Default;
            }

            ReloadProjects();
        }
        #endregion

        #region Properties
        public Project Project
        {
            get { return project; }
        }
        #endregion

        #region ImportWorker
        void importWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ProjectImporter importer = Utils.Getter<ProjectImporter>.Get(e.Argument, "Importer");
            String Path = Utils.Getter<String>.Get(e.Argument, "Path");

            importer.Import(Path, (int max, int p) => 
                {
                    importWorker.ReportProgress(p, new { Max = max, Progress = p }); 
                });
        }

        void importWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            importProgress.Maximum = Utils.Getter<int>.Get(e.UserState, "Max") + 1;
            importProgress.Value += Utils.Getter<int>.Get(e.UserState, "Progress");
        }

        void importWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show(String.Format("Import completed. Imported {0} records.", importProgress.Maximum),
                Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            importProgress.Value = importProgress.Minimum;
        }
        #endregion

        private void projectsList_ItemActivate(object sender, EventArgs e)
        {
            project = (Project)projectsList.SelectedObject;
            
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
