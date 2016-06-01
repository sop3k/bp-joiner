using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace baseprotect
{
    public partial class RemindersList : Form
    {
        private List<Reminder> reminders;
        private List<Reminder> handled;

        public RemindersList(IEnumerable<Reminder> rems)
        {
            InitializeComponent();
            
            reminders = rems.ToList();
            handled = rems.ToList();
        }

        private void RemindersList_Load(object sender, EventArgs e)
        {
            remList.SetObjects(reminders);
            remList.BuildList();
        }

        private void remList_ItemActivate(object sender, EventArgs e)
        {
            Reminder reminder = (Reminder)remList.SelectedObject;
            DlgPersonDetails dlg = new DlgPersonDetails(reminder.Person);
            dlg.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var chkd = remList.CheckedObjectsEnumerable.Cast<Reminder>();
            handled.RemoveAll((Reminder r) => !chkd.Contains(r));

            Close();
        }

        public IEnumerable<Reminder> Handled
        {
            get{ return handled; }
        }
    }
}
