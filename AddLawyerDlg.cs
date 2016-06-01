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
    public partial class AddLawyerDlg : Form
    {
        public AddLawyerDlg()
        {
            InitializeComponent();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            Lawyer newLawyer = new Lawyer
            {
                EMail = mailEdit.Text,
                Name = nameEdit.Text,
                SName = snameEdit.Text,

                Adress = officEedit.Text
                //Telephone = telEdit.Text
            };

            Config.DB.Lawyers.InsertOnSubmit(newLawyer);
            Config.DB.SubmitChanges();
        }
    }
}
