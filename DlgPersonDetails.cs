using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Collections;

using BrightIdeasSoftware;

namespace baseprotect
{
    public partial class DlgPersonDetails : Form
    {
        private Person person;
        private static Hashtable iconHash = FileTypeAndIcon.RegisteredFileType.GetFileTypeAndIcon();

        public DlgPersonDetails(Person p)
        {
            InitializeComponent();
            person = p;
        }

        private void DlgPersonDetails_Load( object sender, EventArgs e )
        {
            dateEventColumn.GroupKeyGetter = delegate( object rowObject )
            {
                NetEvent ev = (NetEvent)rowObject;
                return new DateTime( ev.Date.Year, ev.Date.Month, 1);
            };

            dateEventColumn.GroupKeyToTitleConverter = delegate( object groupKey )
            {
                return ( (DateTime)groupKey ).ToString( "MMMM yyyy" );
            };

            DescStateColumn.ImageGetter = delegate(object rowObject)
            {
                return (Utils.Getter<Type>.Get(rowObject, "Type") == typeof(Notify)) ? "notify" : "state";
            };

            DocumentStateColumn.ImageGetter = delegate(object rowObject)
            {
                Document doc = Utils.Getter<Document>.Get(rowObject, "Document");

                if (doc != null)
                {
                    String key = doc.Type.ToLower();
                    if (!notifiesStatesList.SmallImageList.Images.ContainsKey(key))
                    {
                        Icon icon = FileTypeAndIcon.RegisteredFileType.ExtractIconFromFile((string)iconHash[key], true);
                        Image img = icon.ToBitmap();

                        if (img == null)
                            return "default";
                        
                        notifiesStatesList.SmallImageList.Images.Add(key, img);
                        return key;
                    }
                    return key;
                }
                return String.Empty;
                
            };

            notifiesStatesList.HyperlinkClicked += new EventHandler<HyperlinkClickedEventArgs>(notifiesStatesList_HyperlinkClicked);

            notesList.CellToolTipShowing += new EventHandler<ToolTipShowingEventArgs>( notesList_CellToolTipShowing );
            NameEdit.Text = string.Format( "{0} {1}", person.FirstName, person.SecondName );
            
            StateLabel.Text = person.CurrentState.State.ToString();

            CityEdit.Text = person.City;
            PostalEdit.Text = person.Postal;
            StrasseEdit.Text = person.Details;

            var events = person.Events.ToEnumerable();

            eventsList.SetObjects(events);
            notesList.SetObjects(person.Notes);
            notifiesStatesList.SetObjects(GetNotifiesAndStates(person));

            projectsTree.CanExpandGetter = delegate(object x)
            {
                try
                {
                    int Count = (int)new Munger("Count").GetValue(x);
                    return Count > 0;
                }
                catch (Exception)
                {
                    return false;
                }
            };

            projectsTree.ChildrenGetter = delegate(Object x)
            {
                IEnumerable<NetEvent> Events = (IEnumerable<NetEvent>)new Munger("Events").GetValue(x);
                return Events.Select((NetEvent ev) => new { Name = ev.Date, Count = ev.Hash, IP = ev.IP });
            };

            projectsTree.SetObjects(GetProjectAndEvents(person));
            lawyersList.SetObjects(person.GetLawyers());

            RefreshPayments();
        }

        void notifiesStatesList_HyperlinkClicked(object sender, HyperlinkClickedEventArgs e)
        {
            e.Handled = true;

            Document SelectedDocument = Utils.Getter<Document>.Get(e.Model, "Document");
            using(TempFile Temporary = new TempFile(SelectedDocument.Type))
            {
                using (FileStream stream = new FileStream(Temporary.Path, FileMode.OpenOrCreate))
                {
                    if(SelectedDocument.RawDocument != null)
                        Utils.WriteFully(stream, SelectedDocument.RawDocument.ToArray());
                }
                System.Diagnostics.Process.Start(Temporary.Path);
            }
        }

        private IEnumerable<Object> GetNotifiesAndStates(Person person)
        {
            String SaveAs = "Open...";

            var StatesAssocatiedWithNotifies = person.Notifies.Select( s => s.StateID );
            foreach(PersonState state in person.States.Where( s => !StatesAssocatiedWithNotifies.Contains(s.ID)))
            {
                yield return new { Type = typeof(PersonState),
                                   Date = state.Date,
                                   Description = state.Comment,
                                   Document = state.Document,
                                   DocStr = (state.Document == null) ? String.Empty : SaveAs,
                                   NotifyNo = String.Empty,
                                   Original = state,
                                   Project = state.Project != null ? state.Project.Name : String.Empty,

                                 };
            }

            int NotifyNo = 0;
            foreach (Notify notify in person.Notifies.OrderBy(n => n.Date))
            {
                yield return new { Type = typeof(Notify),
                                   Date = notify.Date,
                                   Description = String.Empty,
                                   Document = notify.Document,
                                   DocStr = (notify.Document == null) ? String.Empty : SaveAs,
                                   NotifyNo = ++NotifyNo,
                                   Original = notify,
                                   Project = notify.Project.Name
                                 };
            }
        }

        void notesList_CellToolTipShowing( object sender, ToolTipShowingEventArgs e )
        {
            Note note = (Note)e.Item.RowObject;

            e.BackColor = Color.Blue;
            e.Font = new Font( "Times", 14 );
            e.IsBalloon = true;

            string title = string.Format( "{0} [{1}]", note.Date, note.Author );
            e.Title = title;
            e.Text = string.Format("\r\n{0}", note.Text);
            e.StandardIcon = ToolTipControl.StandardIcons.Info;
            e.ToolTipControl.SetMaxWidth( 650 );
            e.ToolTipControl.AutoPopDelay = 30000;
        }

        private void button1_Click( object sender, EventArgs e )
        {
            DlgAddNote dlg = new DlgAddNote(person);
            if(dlg.ShowDialog() == DialogResult.OK)
                notesList.SetObjects(person.Notes);
        }

        private void NameEditable_Click(object sender, EventArgs e)
        {
            //NameEdit.Enabled = !NameEdit.Enabled;
            //NameEdit.ReadOnly = !NameEdit.ReadOnly;
            //NameEditable.ImageIndex = NameEdit.ReadOnly ? 0 : 1;
        }

        private void CityEditable_Click(object sender, EventArgs e)
        {
            CityEdit.Enabled = !CityEdit.Enabled;
            CityEdit.ReadOnly = !CityEdit.ReadOnly;

            if (!CityEdit.Enabled)
            {
                person.City = CityEdit.Text;
                Config.DB.SubmitChanges();
            }

            CityEditable.ImageIndex = CityEdit.Enabled ? 1 : 0;
        }

        private void StrasseEditable_Click(object sender, EventArgs e)
        {
            StrasseEdit.ReadOnly = !StrasseEdit.ReadOnly;
            StrasseEdit.Enabled = !StrasseEdit.Enabled;

            if (!StrasseEdit.Enabled)
            {
                person.Details = StrasseEdit.Text;
                Config.DB.SubmitChanges();
            }

            StrasseEditable.ImageIndex = StrasseEdit.Enabled ? 1: 0;
        }

        private void PostalEditable_Click(object sender, EventArgs e)
        {
            PostalEdit.Enabled = !PostalEdit.Enabled;
            PostalEdit.ReadOnly = !PostalEdit.ReadOnly;

            if (!PostalEdit.Enabled)
            {
                person.Postal = PostalEdit.Text;
                Config.DB.SubmitChanges();
            }

            PostalEditable.ImageIndex = PostalEdit.Enabled ? 1 : 0;
        }

        private IEnumerable<Object> GetProjectAndEvents(Person person)
        {
            var projects = person.Projects;
            foreach(var project in projects)
            {
                var Events = (List<NetEvent>)person.GetEvents(project, false);
                var Count = Events.Count;

                yield return new 
                { 
                    Name = project.Name, 
                    Events = Events, 
                    Count = Count, 
                    IP = String.Empty 
                };
            }
        }

        private void addLawyerBtn_Click(object sender, EventArgs e)
        {
            SelectLawyerDlg dlg = new SelectLawyerDlg();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.SelectedLawyer != null)
                {
                    person.AddLawyer(dlg.SelectedLawyer);
                    lawyersList.SetObjects(person.GetLawyers());
                }

                Config.DB.SubmitChanges();
            }
            lawyersList.BuildList();
        }

        private void lawyersList_HyperlinkClicked(object sender, HyperlinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(((Lawyer)e.Item.RowObject).EMailLink);
        }

        private void unlinkLawyerBtn_Click(object sender, EventArgs e)
        {
            foreach (PersonToLawyer ptol in lawyersList.SelectedObjects.Cast<PersonToLawyer>())
            {
                person.RemoveLawyer(ptol.Lawyer);
            }

            Config.DB.SubmitChanges();
            lawyersList.SetObjects(person.GetLawyers());
        }

        private void addPayment_Click(object sender, EventArgs e)
        {
            DlgAddPersonPayment dlg = new DlgAddPersonPayment(person, Config.ActiveProject);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                person.Payments.Add(dlg.Payment);
                Config.DB.Payments.InsertOnSubmit(dlg.Payment);

                Config.DB.SubmitChanges();
            }
            RefreshPayments();
        }

        private void changePenalty_Click(object sender, EventArgs e)
        {
            try
            {
                if (person.Penalty == null)
                {
                    PersonPenalty penalty = new PersonPenalty
                    {
                        Date = DateTime.Now,
                        Penalty = decimal.Parse(this.penalty.Text),
                        Person = person,
                        Project = Config.ActiveProject,
                        Comment = String.Empty,
                        ID = new Random().Next()
                    };

                    person.Penalty = penalty;
                    Config.DB.Penalties.InsertOnSubmit(penalty);
                }
                else
                {
                    person.Penalty.Date = DateTime.Now;
                    person.Penalty.Penalty = decimal.Parse(this.penalty.Text);
                }

                Config.DB.SubmitChanges();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Invalid penalty value!", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        void RefreshPayments()
        {
            paymentsList.SetObjects(person.Payments.Where(p => p.Project == Config.ActiveProject));
            paymentsSoFar.Text = String.Format("Sum: {0:N} €", person.ProjectPayments().Sum(p => p.Amount));
            penalty.Text = String.Format("{0:N}", person.PenaltyAmount());
        }

        private void deletePayment_Click(object sender, EventArgs e)
        {
            if (paymentsList.SelectedObject != null)
            {
                person.Payments.Remove((PersonPayment)paymentsList.SelectedObject);
                Config.DB.Payments.DeleteOnSubmit((PersonPayment)paymentsList.SelectedObject);
                Config.DB.SubmitChanges();

                paymentsList.RemoveObject(paymentsList.SelectedObject);
                paymentsList.BuildList();
            }
        }
    }
}
