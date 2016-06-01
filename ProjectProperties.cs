using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Transactions;
using System.Threading;

using BrightIdeasSoftware;

namespace baseprotect
{
    public partial class ProjectProperties : Form
    {
        private Project project;
        private Word word;
        AutoResetEvent wordClosed;

        public ProjectProperties()
        {
            InitializeComponent(); 
        }

        public ProjectProperties(Project prj)
        {
            InitializeComponent(); 

            project = prj;
            FillControls(project);
        }

        private void FillControls(Project project)
        {
            penalty.Text = String.Format("{0}", project.Penalty);
            schuldner.Text = String.Format("{0}", project.Schuldner);

            paymentPeroid.Value = project.PaymentAfter;
            ignorePeroid.Value = project.IgnoreAfter;

            projectName.Text = project.Name;
        }

        private void dateAsName_Click(object sender, EventArgs e)
        {
            projectName.Text += DateTime.Now.ToString();
        }

        private void fillProjectTemplates(System.Collections.IEnumerable templates)
        {
            if (templates == null)
                return;

            var tmpl = Project.Templates.OrderBy(p => p.Order).LastOrDefault();

            int order = tmpl != null ? tmpl.Order : 0;
            foreach (var t in templates)
            {
                if (TypeUtils.GetValueFromAnonymousType<String>(t, "Path") == default(String))
                    continue;

                Template template = new Template();
                string path = Utils.Getter<string>.Get(t, "Path");

                template.RawTemplate = Utils.ReadFully(new FileStream(path, FileMode.Open));
                template.Project = Project;
                template.Order = ++order;

                Project.Templates.Add(template);
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = true;
            dlg.Filter = "WORD(97-2003) files|*.doc|WORD(2007-) files|*.docx";
            
            if ( dlg.ShowDialog() == DialogResult.OK )
            {
                foreach ( string file in dlg.FileNames )
                {
                    string filename = System.IO.Path.GetFileName(file);
                    string path = System.IO.Path.GetFullPath(file);

                    templateList.AddObject( new { Filename = filename, Path = path } );
                }
            }
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            var template = TypeUtils.GetValueFromAnonymousType<Template>(templateList.SelectedObject, "Template");
            templateList.RemoveObject(templateList.SelectedObject);
            Project.Templates.Remove(template);
            Config.DB.Templates.DeleteOnSubmit(template);
            Config.DB.SubmitChanges();
        }

        private void ProjectProperties_Load(object sender, EventArgs e)
        {
            templateList.DragSource = new SimpleDragSource();
            templateList.DropSink = new RearrangingDropSink(false);

            filenameColumn.ImageGetter = delegate(object rowObject) { return 0; };

            loadProjectsTemplates(project);
            wordClosed = new AutoResetEvent(false);
        }

        private void loadProjectsTemplates(Project project)
        {
            if (project == null)
                return;

            foreach (Template template in project.Templates)
            {
                templateList.AddObject(new { Filename = template.Order.ToString(), Template = template });
            }
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            if (Project != null)
            {
                project.Name = projectName.Text;
                project.IgnoreAfter = Convert.ToInt32(ignorePeroid.Value);
                project.Penalty = decimal.Parse(penalty.Text);
                project.PaymentAfter = Convert.ToInt32(paymentPeroid.Value);

                if (!String.IsNullOrEmpty(schuldner.Text))
                    project.Schuldner = int.Parse(schuldner.Text);

                fillProjectTemplates(templateList.Objects);
            }
            else
            {
                project = new Project();

                project.Name = projectName.Text;
                project.IgnoreAfter = Convert.ToInt32(ignorePeroid.Value);
                project.Penalty = decimal.Parse(penalty.Text);
                project.PaymentAfter = Convert.ToInt32(paymentPeroid.Value);
                project.CreationDate = DateTime.Now;

                fillProjectTemplates(templateList.Objects);
                Config.DB.Projects.InsertOnSubmit(project);
            }

            Config.DB.SubmitChanges();
        }

        private void schuldner_TextChanged(object sender, EventArgs e)
        {
            int dummy;
            okBtn.Enabled = int.TryParse(schuldner.Text, out dummy);
        }

        private void projectName_TextChanged(object sender, EventArgs e)
        {
            okBtn.Enabled = !String.IsNullOrEmpty(projectName.Text);   
        }

        private void penalty_TextChanged(object sender, EventArgs e)
        {
            int dummy;
            okBtn.Enabled = int.TryParse(penalty.Text, out dummy);
        }

        public Project Project
        {
            get { return project; }
        }

        private void templateList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Template template = (Template)new Munger("Template").GetValue(templateList.SelectedObject);

                using (var temp = new TempFile(".doc"))
                {
                    using (FileStream stream = new FileStream(temp.Path, FileMode.OpenOrCreate))
                    {
                        Utils.WriteFully(stream, template.RawTemplate.ToArray());
                        stream.Close();
                    }

                    using (word = new Word(true))
                    {
                        word.Open(temp.Path);
                        word.OnDocClose += new Word.DocCloseHandler(word_OnDocClose);

                        wordClosed.WaitOne();
                    }

                    try
                    {
                        template.RawTemplate = Utils.ReadFully(new FileStream(temp.Path, FileMode.Open));
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("First save then close!", Text);
                    }
                }
            }
            catch(Exception ex)
            {
                return;
            }
        }

        void word_OnDocClose(Microsoft.Office.Interop.Word.Document doc)
        {
            wordClosed.Set();
        }
    }
}
