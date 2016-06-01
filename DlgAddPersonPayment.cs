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
    public partial class DlgAddPersonPayment : Form
    {
        private PersonPayment payment;
        private Person person;
        private Project project;

        public DlgAddPersonPayment(Person person, Project project)
        {
            InitializeComponent();

            this.person = person;
            this.project = project;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                payment = new PersonPayment();

                payment.ID = new Random().Next();
                payment.Amount = decimal.Parse(amount.Text);
                payment.Date = DateTime.Now;
                payment.PersonID = person.ID;
                payment.ProjectID = project.ID;
                payment.Comment = comment.Text;

                payment.Project = project;
                payment.Person = person;

                payment.Type = (PaymentType)Enum.Parse(typeof(PaymentType), (string)type.SelectedItem);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch
            {
                //do nothing
            }
        }

        public PersonPayment Payment
        {
            get { return payment; }
        }

        private void DlgAddPersonPayment_Load(object sender, EventArgs e)
        {
            var types = Enum.GetNames(typeof(PaymentType));
            type.Items.AddRange(types);

            type.SelectedItem = type.Items[1];
        }
    }
}
