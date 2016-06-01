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
    public partial class DlgChangeState : Form
    {
        private Person person;

        public DlgChangeState(Person person)
        {
            this.person = person;
            InitializeComponent();
        }

        public State NewState
        {
            get;
            private set;
        }

        public String StateComment
        {
            get;
            private set;
        }

        public String AttachedDocumentPath
        {
            get;
            private set;
        }

        private void SelectDocBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string ident = "    ";
                Document.Text = ident + dlg.FileName;
                Document.ScrollToCaret();
            }
        }

        private void DlgChangeState_Load(object sender, EventArgs e)
        {
            CurrentState.Text = person.States.OrderBy(p => p.Date).First().State.ToString();
            PersonInfo.Text = String.Format("{0} {1}", person.FirstName, person.SecondName);
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            RadioButton checkedState = StateGroup.GetChecked();
            if (checkedState != null)
            {
                NewState = (State)System.Enum.Parse(typeof(State), checkedState.Text);
                StateComment = Comment.Text;
                AttachedDocumentPath = Document.Text;
            }
        }

        private void PaidNotSigned_CheckedChanged( object sender, EventArgs e )
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
