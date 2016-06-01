namespace baseprotect
{
    partial class AddLawyerDlg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddLawyerDlg));
            this.nameEdit = new System.Windows.Forms.TextBox();
            this.snameEdit = new System.Windows.Forms.TextBox();
            this.officEedit = new System.Windows.Forms.TextBox();
            this.mailEdit = new System.Windows.Forms.TextBox();
            this.telEdit = new System.Windows.Forms.TextBox();
            this.okBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nameEdit
            // 
            this.nameEdit.BackColor = System.Drawing.SystemColors.Info;
            this.nameEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nameEdit.Location = new System.Drawing.Point(12, 29);
            this.nameEdit.Name = "nameEdit";
            this.nameEdit.Size = new System.Drawing.Size(286, 30);
            this.nameEdit.TabIndex = 0;
            // 
            // snameEdit
            // 
            this.snameEdit.BackColor = System.Drawing.SystemColors.Info;
            this.snameEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.snameEdit.Location = new System.Drawing.Point(339, 29);
            this.snameEdit.Name = "snameEdit";
            this.snameEdit.Size = new System.Drawing.Size(339, 30);
            this.snameEdit.TabIndex = 1;
            // 
            // officEedit
            // 
            this.officEedit.BackColor = System.Drawing.SystemColors.Info;
            this.officEedit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.officEedit.Location = new System.Drawing.Point(12, 97);
            this.officEedit.Name = "officEedit";
            this.officEedit.Size = new System.Drawing.Size(666, 30);
            this.officEedit.TabIndex = 2;
            // 
            // mailEdit
            // 
            this.mailEdit.BackColor = System.Drawing.SystemColors.Info;
            this.mailEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mailEdit.Location = new System.Drawing.Point(12, 163);
            this.mailEdit.Name = "mailEdit";
            this.mailEdit.Size = new System.Drawing.Size(286, 30);
            this.mailEdit.TabIndex = 3;
            // 
            // telEdit
            // 
            this.telEdit.BackColor = System.Drawing.SystemColors.Info;
            this.telEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.telEdit.Location = new System.Drawing.Point(339, 163);
            this.telEdit.Name = "telEdit";
            this.telEdit.Size = new System.Drawing.Size(206, 30);
            this.telEdit.TabIndex = 4;
            // 
            // okBtn
            // 
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Image = ((System.Drawing.Image)(resources.GetObject("okBtn.Image")));
            this.okBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.okBtn.Location = new System.Drawing.Point(606, 151);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(72, 42);
            this.okBtn.TabIndex = 5;
            this.okBtn.Text = "OK";
            this.okBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(336, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Surname";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Office";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "EMail";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(339, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Telephone";
            // 
            // AddLawyerDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 214);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.telEdit);
            this.Controls.Add(this.mailEdit);
            this.Controls.Add(this.officEedit);
            this.Controls.Add(this.snameEdit);
            this.Controls.Add(this.nameEdit);
            this.Name = "AddLawyerDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add new lawyer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameEdit;
        private System.Windows.Forms.TextBox snameEdit;
        private System.Windows.Forms.TextBox officEedit;
        private System.Windows.Forms.TextBox mailEdit;
        private System.Windows.Forms.TextBox telEdit;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}