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
    public partial class DlgAddNote : Form
    {
        Person person;

        public DlgAddNote(Person person)
        {
            InitializeComponent();
            this.person = person;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Note note = new Note();

            note.Author = authorName.Text;
            note.Date = DateTime.Now;
            note.Text = noteText.Text;
            note.Owner = person;
            note.PersonID = person.ID;


            person.Notes.Add(note); 
            Config.DB.Notes.InsertOnSubmit(note);

            if(reminderCreate.Checked)
                Config.DB.Reminders.InsertOnSubmit(CreateReminder(person, Config.ActiveProject, note));

            Config.DB.SubmitChanges();
        }

        private Reminder CreateReminder(Person person, Project project, Note note)
        {
            Reminder reminder = new Reminder();

            if (dateTypeReminder.Checked)
                reminder.Peroid = (int)Math.Ceiling(datePicker.Value.Subtract(DateTime.Today).TotalDays);
            else
                reminder.Peroid = (int)daysPicker.Value;

            reminder.CreationDate = DateTime.Today;
            reminder.Person = person;
            reminder.Project = project;
            reminder.Note = note;
            reminder.LastPost = DateTime.Today;
            
            return reminder;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            datePicker.Enabled = dateTypeReminder.Checked;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            daysPicker.Enabled = peroidTypeReminder.Checked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = reminderCreate.Checked;
        }
    }
}
