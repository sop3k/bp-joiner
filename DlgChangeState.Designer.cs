namespace baseprotect
{
    partial class DlgChangeState
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgChangeState));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CurrentState = new System.Windows.Forms.Label();
            this.StateGroup = new System.Windows.Forms.GroupBox();
            this.CerditSignedModified = new System.Windows.Forms.RadioButton();
            this.CreditSigned = new System.Windows.Forms.RadioButton();
            this.CreditNotSigned = new System.Windows.Forms.RadioButton();
            this.NotPaid = new System.Windows.Forms.RadioButton();
            this.PaidNotSigned = new System.Windows.Forms.RadioButton();
            this.PaidSignedModified = new System.Windows.Forms.RadioButton();
            this.PaidSigned = new System.Windows.Forms.RadioButton();
            this.Ignoring = new System.Windows.Forms.RadioButton();
            this.Comment = new System.Windows.Forms.TextBox();
            this.SelectDocBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.OKBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Document = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PersonInfo = new System.Windows.Forms.Label();
            this.Negotiation = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.StateGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CurrentState);
            this.groupBox1.Location = new System.Drawing.Point(242, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(239, 73);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current state";
            // 
            // CurrentState
            // 
            this.CurrentState.AutoSize = true;
            this.CurrentState.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CurrentState.ForeColor = System.Drawing.Color.Red;
            this.CurrentState.Location = new System.Drawing.Point(56, 29);
            this.CurrentState.Name = "CurrentState";
            this.CurrentState.Size = new System.Drawing.Size(136, 29);
            this.CurrentState.TabIndex = 0;
            this.CurrentState.Text = "Not notified";
            // 
            // StateGroup
            // 
            this.StateGroup.Controls.Add(this.Negotiation);
            this.StateGroup.Controls.Add(this.CerditSignedModified);
            this.StateGroup.Controls.Add(this.CreditSigned);
            this.StateGroup.Controls.Add(this.CreditNotSigned);
            this.StateGroup.Controls.Add(this.NotPaid);
            this.StateGroup.Controls.Add(this.PaidNotSigned);
            this.StateGroup.Controls.Add(this.PaidSignedModified);
            this.StateGroup.Controls.Add(this.PaidSigned);
            this.StateGroup.Controls.Add(this.Ignoring);
            this.StateGroup.Location = new System.Drawing.Point(12, 90);
            this.StateGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StateGroup.Name = "StateGroup";
            this.StateGroup.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StateGroup.Size = new System.Drawing.Size(469, 174);
            this.StateGroup.TabIndex = 1;
            this.StateGroup.TabStop = false;
            this.StateGroup.Text = "Select new state";
            // 
            // CerditSignedModified
            // 
            this.CerditSignedModified.AutoSize = true;
            this.CerditSignedModified.Location = new System.Drawing.Point(191, 113);
            this.CerditSignedModified.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CerditSignedModified.Name = "CerditSignedModified";
            this.CerditSignedModified.Size = new System.Drawing.Size(163, 21);
            this.CerditSignedModified.TabIndex = 8;
            this.CerditSignedModified.TabStop = true;
            this.CerditSignedModified.Text = "CreditSignedModified";
            this.CerditSignedModified.UseVisualStyleBackColor = true;
            // 
            // CreditSigned
            // 
            this.CreditSigned.AutoSize = true;
            this.CreditSigned.Location = new System.Drawing.Point(191, 86);
            this.CreditSigned.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CreditSigned.Name = "CreditSigned";
            this.CreditSigned.Size = new System.Drawing.Size(110, 21);
            this.CreditSigned.TabIndex = 7;
            this.CreditSigned.TabStop = true;
            this.CreditSigned.Text = "CreditSigned";
            this.CreditSigned.UseVisualStyleBackColor = true;
            // 
            // CreditNotSigned
            // 
            this.CreditNotSigned.AutoSize = true;
            this.CreditNotSigned.Location = new System.Drawing.Point(191, 58);
            this.CreditNotSigned.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CreditNotSigned.Name = "CreditNotSigned";
            this.CreditNotSigned.Size = new System.Drawing.Size(132, 21);
            this.CreditNotSigned.TabIndex = 6;
            this.CreditNotSigned.TabStop = true;
            this.CreditNotSigned.Text = "CreditNotSigned";
            this.CreditNotSigned.UseVisualStyleBackColor = true;
            // 
            // NotPaid
            // 
            this.NotPaid.AutoSize = true;
            this.NotPaid.Location = new System.Drawing.Point(5, 31);
            this.NotPaid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NotPaid.Name = "NotPaid";
            this.NotPaid.Size = new System.Drawing.Size(79, 21);
            this.NotPaid.TabIndex = 5;
            this.NotPaid.TabStop = true;
            this.NotPaid.Text = "NotPaid";
            this.NotPaid.UseVisualStyleBackColor = true;
            // 
            // PaidNotSigned
            // 
            this.PaidNotSigned.AutoSize = true;
            this.PaidNotSigned.Location = new System.Drawing.Point(191, 31);
            this.PaidNotSigned.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PaidNotSigned.Name = "PaidNotSigned";
            this.PaidNotSigned.Size = new System.Drawing.Size(123, 21);
            this.PaidNotSigned.TabIndex = 4;
            this.PaidNotSigned.TabStop = true;
            this.PaidNotSigned.Text = "PaidNotSigned";
            this.PaidNotSigned.UseVisualStyleBackColor = true;
            this.PaidNotSigned.CheckedChanged += new System.EventHandler(this.PaidNotSigned_CheckedChanged);
            // 
            // PaidSignedModified
            // 
            this.PaidSignedModified.AutoSize = true;
            this.PaidSignedModified.Location = new System.Drawing.Point(5, 112);
            this.PaidSignedModified.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PaidSignedModified.Name = "PaidSignedModified";
            this.PaidSignedModified.Size = new System.Drawing.Size(154, 21);
            this.PaidSignedModified.TabIndex = 3;
            this.PaidSignedModified.TabStop = true;
            this.PaidSignedModified.Text = "PaidSignedModified";
            this.PaidSignedModified.UseVisualStyleBackColor = true;
            // 
            // PaidSigned
            // 
            this.PaidSigned.AutoSize = true;
            this.PaidSigned.Location = new System.Drawing.Point(5, 85);
            this.PaidSigned.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PaidSigned.Name = "PaidSigned";
            this.PaidSigned.Size = new System.Drawing.Size(101, 21);
            this.PaidSigned.TabIndex = 2;
            this.PaidSigned.TabStop = true;
            this.PaidSigned.Text = "PaidSigned";
            this.PaidSigned.UseVisualStyleBackColor = true;
            // 
            // Ignoring
            // 
            this.Ignoring.AutoSize = true;
            this.Ignoring.Location = new System.Drawing.Point(5, 58);
            this.Ignoring.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Ignoring.Name = "Ignoring";
            this.Ignoring.Size = new System.Drawing.Size(80, 21);
            this.Ignoring.TabIndex = 1;
            this.Ignoring.TabStop = true;
            this.Ignoring.Text = "Ignoring";
            this.Ignoring.UseVisualStyleBackColor = true;
            // 
            // Comment
            // 
            this.Comment.BackColor = System.Drawing.SystemColors.Info;
            this.Comment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Comment.Location = new System.Drawing.Point(9, 285);
            this.Comment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Comment.Multiline = true;
            this.Comment.Name = "Comment";
            this.Comment.Size = new System.Drawing.Size(469, 80);
            this.Comment.TabIndex = 2;
            // 
            // SelectDocBtn
            // 
            this.SelectDocBtn.Image = ((System.Drawing.Image)(resources.GetObject("SelectDocBtn.Image")));
            this.SelectDocBtn.Location = new System.Drawing.Point(404, 398);
            this.SelectDocBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SelectDocBtn.Name = "SelectDocBtn";
            this.SelectDocBtn.Size = new System.Drawing.Size(83, 28);
            this.SelectDocBtn.TabIndex = 4;
            this.SelectDocBtn.Text = "Open";
            this.SelectDocBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SelectDocBtn.UseVisualStyleBackColor = true;
            this.SelectDocBtn.Click += new System.EventHandler(this.SelectDocBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 266);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Comment";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 378);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Document";
            // 
            // OKBtn
            // 
            this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKBtn.Location = new System.Drawing.Point(412, 460);
            this.OKBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(75, 30);
            this.OKBtn.TabIndex = 7;
            this.OKBtn.Text = "OK";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(331, 460);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 30);
            this.CancelBtn.TabIndex = 8;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Info;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 400);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // Document
            // 
            this.Document.BackColor = System.Drawing.SystemColors.Info;
            this.Document.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Document.Location = new System.Drawing.Point(12, 398);
            this.Document.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Document.Multiline = false;
            this.Document.Name = "Document";
            this.Document.ReadOnly = true;
            this.Document.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Document.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.Document.Size = new System.Drawing.Size(385, 29);
            this.Document.TabIndex = 9;
            this.Document.Text = "";
            this.Document.WordWrap = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.PersonInfo);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(224, 73);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Person";
            // 
            // PersonInfo
            // 
            this.PersonInfo.AutoSize = true;
            this.PersonInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PersonInfo.Location = new System.Drawing.Point(6, 29);
            this.PersonInfo.Name = "PersonInfo";
            this.PersonInfo.Size = new System.Drawing.Size(184, 25);
            this.PersonInfo.TabIndex = 0;
            this.PersonInfo.Text = "Tomasz Sobkowiak";
            // 
            // Negotiation
            // 
            this.Negotiation.AutoSize = true;
            this.Negotiation.Location = new System.Drawing.Point(5, 138);
            this.Negotiation.Name = "Negotiation";
            this.Negotiation.Size = new System.Drawing.Size(101, 21);
            this.Negotiation.TabIndex = 9;
            this.Negotiation.TabStop = true;
            this.Negotiation.Text = "Negotiation";
            this.Negotiation.UseVisualStyleBackColor = true;
            this.Negotiation.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // DlgChangeState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 502);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Document);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SelectDocBtn);
            this.Controls.Add(this.Comment);
            this.Controls.Add(this.StateGroup);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DlgChangeState";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change State";
            this.Load += new System.EventHandler(this.DlgChangeState_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.StateGroup.ResumeLayout(false);
            this.StateGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox StateGroup;
        private System.Windows.Forms.TextBox Comment;
        private System.Windows.Forms.Button SelectDocBtn;
        private System.Windows.Forms.Label CurrentState;
        private System.Windows.Forms.RadioButton PaidSigned;
        private System.Windows.Forms.RadioButton Ignoring;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton CerditSignedModified;
        private System.Windows.Forms.RadioButton CreditSigned;
        private System.Windows.Forms.RadioButton CreditNotSigned;
        private System.Windows.Forms.RadioButton NotPaid;
        private System.Windows.Forms.RadioButton PaidNotSigned;
        private System.Windows.Forms.RadioButton PaidSignedModified;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox Document;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label PersonInfo;
        private System.Windows.Forms.RadioButton Negotiation;
    }
}