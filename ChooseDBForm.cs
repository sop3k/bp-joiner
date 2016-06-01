using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.Sql;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlServerCe;

namespace baseprotect
{
    public partial class ChooseDBForm : Form
    {
        public ChooseDBForm()
        {
            InitializeComponent();
            okBtn.Focus();
        }

        private void testBtn_Click(object sender, EventArgs e)
        {
            try
            {
                new SqlConnection(ConnectionString).Open();
                MessageBox.Show("Connection OK!", Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void remoteServer_CheckedChanged(object sender, EventArgs e)
        {
            dbAdress.Enabled = dbName.Enabled = dbUser.Enabled = 
                dbPwd.Enabled = testBtn.Enabled = remoteServer.Checked;
        }

        private void singleFile_CheckedChanged(object sender, EventArgs e)
        {
            dbPath.Enabled = browseBtn.Enabled = singleFile.Checked;
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
                dbPath.Text = dlg.FileName;
        }

        public String ConnectionString
        {
            get
            {
                if (singleFile.Checked)
                    return String.Format("Data Source={0}; Max Database Size=4000;", dbPath.Text);
                else
                    return String.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3};",
                        dbAdress.Text, dbName.Text, dbUser.Text, dbPwd.Text);
            }
        }

        public DbConnection Connection
        {
            get
            {
                if (singleFile.Checked)
                {
                    using (var engine = new System.Data.SqlServerCe.SqlCeEngine(ConnectionString))
                        Utils.IgnoreExceptions(()=>engine.Upgrade());
                    
                    return new SqlCeConnection(ConnectionString);
                }
                else
                    return new SqlConnection(ConnectionString);
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
