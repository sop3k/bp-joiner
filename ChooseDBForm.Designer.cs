namespace baseprotect
{
    partial class ChooseDBForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseDBForm));
            this.okBtn = new System.Windows.Forms.Button();
            this.testBtn = new System.Windows.Forms.Button();
            this.dbAdress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.singleFile = new System.Windows.Forms.RadioButton();
            this.remoteServer = new System.Windows.Forms.RadioButton();
            this.dbUser = new System.Windows.Forms.TextBox();
            this.dbPwd = new System.Windows.Forms.TextBox();
            this.dbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.browseBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dbPath = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // okBtn
            // 
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Image = ((System.Drawing.Image)(resources.GetObject("okBtn.Image")));
            this.okBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.okBtn.Location = new System.Drawing.Point(97, 341);
            this.okBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(123, 37);
            this.okBtn.TabIndex = 9;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // testBtn
            // 
            this.testBtn.Enabled = false;
            this.testBtn.Image = ((System.Drawing.Image)(resources.GetObject("testBtn.Image")));
            this.testBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.testBtn.Location = new System.Drawing.Point(247, 117);
            this.testBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(56, 28);
            this.testBtn.TabIndex = 3;
            this.testBtn.Text = "Test";
            this.testBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.testBtn.UseVisualStyleBackColor = true;
            this.testBtn.Click += new System.EventHandler(this.testBtn_Click);
            // 
            // dbAdress
            // 
            this.dbAdress.BackColor = System.Drawing.SystemColors.Info;
            this.dbAdress.Enabled = false;
            this.dbAdress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dbAdress.Location = new System.Drawing.Point(9, 121);
            this.dbAdress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dbAdress.Name = "dbAdress";
            this.dbAdress.Size = new System.Drawing.Size(234, 26);
            this.dbAdress.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 105);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Database adress:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.singleFile);
            this.groupBox1.Controls.Add(this.remoteServer);
            this.groupBox1.Location = new System.Drawing.Point(9, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(263, 67);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // singleFile
            // 
            this.singleFile.AutoSize = true;
            this.singleFile.Checked = true;
            this.singleFile.Location = new System.Drawing.Point(8, 39);
            this.singleFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.singleFile.Name = "singleFile";
            this.singleFile.Size = new System.Drawing.Size(92, 14);
            this.singleFile.TabIndex = 1;
            this.singleFile.TabStop = true;
            this.singleFile.Text = "Single File Database";
            this.singleFile.UseVisualStyleBackColor = true;
            this.singleFile.CheckedChanged += new System.EventHandler(this.singleFile_CheckedChanged);
            // 
            // remoteServer
            // 
            this.remoteServer.AutoSize = true;
            this.remoteServer.Location = new System.Drawing.Point(8, 17);
            this.remoteServer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.remoteServer.Name = "remoteServer";
            this.remoteServer.Size = new System.Drawing.Size(109, 14);
            this.remoteServer.TabIndex = 0;
            this.remoteServer.Text = "Remote Database Server";
            this.remoteServer.UseVisualStyleBackColor = true;
            this.remoteServer.CheckedChanged += new System.EventHandler(this.remoteServer_CheckedChanged);
            // 
            // dbUser
            // 
            this.dbUser.BackColor = System.Drawing.SystemColors.Info;
            this.dbUser.Enabled = false;
            this.dbUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dbUser.Location = new System.Drawing.Point(9, 224);
            this.dbUser.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dbUser.Name = "dbUser";
            this.dbUser.Size = new System.Drawing.Size(150, 26);
            this.dbUser.TabIndex = 5;
            // 
            // dbPwd
            // 
            this.dbPwd.BackColor = System.Drawing.SystemColors.Info;
            this.dbPwd.Enabled = false;
            this.dbPwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dbPwd.Location = new System.Drawing.Point(167, 224);
            this.dbPwd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dbPwd.Name = "dbPwd";
            this.dbPwd.Size = new System.Drawing.Size(137, 26);
            this.dbPwd.TabIndex = 6;
            // 
            // dbName
            // 
            this.dbName.BackColor = System.Drawing.SystemColors.Info;
            this.dbName.Enabled = false;
            this.dbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dbName.Location = new System.Drawing.Point(9, 172);
            this.dbName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dbName.Name = "dbName";
            this.dbName.Size = new System.Drawing.Size(150, 26);
            this.dbName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 156);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Database name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(165, 208);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 207);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "User:";
            // 
            // browseBtn
            // 
            this.browseBtn.Enabled = false;
            this.browseBtn.Image = ((System.Drawing.Image)(resources.GetObject("browseBtn.Image")));
            this.browseBtn.Location = new System.Drawing.Point(272, 305);
            this.browseBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(31, 24);
            this.browseBtn.TabIndex = 8;
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 288);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Path";
            // 
            // dbPath
            // 
            this.dbPath.BackColor = System.Drawing.SystemColors.Info;
            this.dbPath.Enabled = false;
            this.dbPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dbPath.Location = new System.Drawing.Point(11, 305);
            this.dbPath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dbPath.Name = "dbPath";
            this.dbPath.Size = new System.Drawing.Size(258, 26);
            this.dbPath.TabIndex = 7;
            this.dbPath.Text = "storage.sdf";
            // 
            // ChooseDBForm
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 382);
            this.Controls.Add(this.browseBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dbPath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dbName);
            this.Controls.Add(this.dbPwd);
            this.Controls.Add(this.dbUser);
            this.Controls.Add(this.testBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.dbAdress);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ChooseDBForm";
            this.Text = "Choose Database";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button testBtn;
        private System.Windows.Forms.TextBox dbAdress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton singleFile;
        private System.Windows.Forms.RadioButton remoteServer;
        private System.Windows.Forms.TextBox dbUser;
        private System.Windows.Forms.TextBox dbPwd;
        private System.Windows.Forms.TextBox dbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox dbPath;
    }
}