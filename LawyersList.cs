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
    public partial class LawyersList : Form
    {
        public LawyersList()
        {
            InitializeComponent();
            list.SetObjects(Config.DB.Lawyers);
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            new AddLawyerDlg().ShowDialog();
            list.SetObjects(Config.DB.Lawyers);
        }

        private void list_SelectedIndexChanged(object sender, EventArgs e)
        {
            delBtn.Enabled = list.SelectedObject != null;
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            foreach( Lawyer lawyer in list.SelectedObjects.Cast<Lawyer>())
            {
                foreach (Person p in lawyer.Persons)
                {
                    p.RemoveLawyer(lawyer);
                    lawyer.Persons.Remove(p);
                }

                Config.DB.Lawyers.DeleteOnSubmit(lawyer);
            }

            Config.DB.SubmitChanges();
            list.SetObjects(Config.DB.Lawyers);
        }

        private void list_HyperlinkClicked(object sender, BrightIdeasSoftware.HyperlinkClickedEventArgs e)
        {
            Lawyer sel = (Lawyer)e.Item.RowObject;
            System.Diagnostics.Process.Start(sel.EMailLink);
        }
    }
}
