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
    public partial class SelectLawyerDlg : Form
    {
        private Lawyer lawyer;

        public SelectLawyerDlg()
        {
            InitializeComponent();
            FillSelector();
        }

        private IEnumerable<Lawyer> LoadLawyers()
        {
            return Config.DB.Lawyers;
        }

        private void FillSelector()
        {
            foreach(Lawyer lawyer in LoadLawyers())
            {
                String desc = String.Format("{0} {1}", lawyer.Name, lawyer.SName); 
                lawyerSelector.Items.Add(new { Text = desc, Item = lawyer });
            }
        }

        private void lawyerSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            lawyer = (Lawyer)new Munger("Item").GetValue(lawyerSelector.SelectedItem);
        }

        public Lawyer SelectedLawyer
        {
            get { return lawyer; }
        }
    }
}
