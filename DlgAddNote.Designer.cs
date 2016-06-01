namespace baseprotect
{
    partial class DlgAddNote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgAddNote));
            this.label1 = new System.Windows.Forms.Label();
            this.authorName = new System.Windows.Forms.TextBox();
            this.noteText = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.daysPicker = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.peroidTypeReminder = new System.Windows.Forms.RadioButton();
            this.dateTypeReminder = new System.Windows.Forms.RadioButton();
            this.reminderCreate = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.daysPicker)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Author:";
            // 
            // authorName
            // 
            this.authorName.BackColor = System.Drawing.SystemColors.Info;
            this.authorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.authorName.Location = new System.Drawing.Point(16, 34);
            this.authorName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.authorName.Name = "authorName";
            this.authorName.Size = new System.Drawing.Size(483, 26);
            this.authorName.TabIndex = 1;
            // 
            // noteText
            // 
            this.noteText.BackColor = System.Drawing.SystemColors.Info;
            this.noteText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.noteText.Location = new System.Drawing.Point(16, 107);
            this.noteText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.noteText.Multiline = true;
            this.noteText.Name = "noteText";
            this.noteText.Size = new System.Drawing.Size(487, 214);
            this.noteText.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(385, 426);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 32);
            this.button1.TabIndex = 3;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(11, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Note:";
            // 
            // datePicker
            // 
            this.datePicker.Enabled = false;
            this.datePicker.Location = new System.Drawing.Point(129, 23);
            this.datePicker.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(187, 22);
            this.datePicker.TabIndex = 5;
            // 
            // daysPicker
            // 
            this.daysPicker.Location = new System.Drawing.Point(129, 52);
            this.daysPicker.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.daysPicker.Name = "daysPicker";
            this.daysPicker.Size = new System.Drawing.Size(44, 22);
            this.daysPicker.TabIndex = 6;
            this.daysPicker.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.peroidTypeReminder);
            this.groupBox1.Controls.Add(this.dateTypeReminder);
            this.groupBox1.Controls.Add(this.datePicker);
            this.groupBox1.Controls.Add(this.daysPicker);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(16, 364);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(345, 94);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reminder:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(181, 58);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "days";
            // 
            // peroidTypeReminder
            // 
            this.peroidTypeReminder.AutoSize = true;
            this.peroidTypeReminder.Checked = true;
            this.peroidTypeReminder.Location = new System.Drawing.Point(8, 55);
            this.peroidTypeReminder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.peroidTypeReminder.Name = "peroidTypeReminder";
            this.peroidTypeReminder.Size = new System.Drawing.Size(74, 21);
            this.peroidTypeReminder.TabIndex = 8;
            this.peroidTypeReminder.TabStop = true;
            this.peroidTypeReminder.Text = "Peroid:";
            this.peroidTypeReminder.UseVisualStyleBackColor = true;
            this.peroidTypeReminder.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // dateTypeReminder
            // 
            this.dateTypeReminder.AutoSize = true;
            this.dateTypeReminder.Location = new System.Drawing.Point(8, 27);
            this.dateTypeReminder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTypeReminder.Name = "dateTypeReminder";
            this.dateTypeReminder.Size = new System.Drawing.Size(63, 21);
            this.dateTypeReminder.TabIndex = 7;
            this.dateTypeReminder.Text = "Date:";
            this.dateTypeReminder.UseVisualStyleBackColor = true;
            this.dateTypeReminder.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // reminderCreate
            // 
            this.reminderCreate.AutoSize = true;
            this.reminderCreate.Location = new System.Drawing.Point(16, 336);
            this.reminderCreate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reminderCreate.Name = "reminderCreate";
            this.reminderCreate.Size = new System.Drawing.Size(137, 21);
            this.reminderCreate.TabIndex = 8;
            this.reminderCreate.Text = "Create Reminder";
            this.reminderCreate.UseVisualStyleBackColor = true;
            this.reminderCreate.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // DlgAddNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 471);
            this.Controls.Add(this.reminderCreate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.noteText);
            this.Controls.Add(this.authorName);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DlgAddNote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New note";
            ((System.ComponentModel.ISupportInitialize)(this.daysPicker)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox authorName;
        private System.Windows.Forms.TextBox noteText;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.NumericUpDown daysPicker;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton peroidTypeReminder;
        private System.Windows.Forms.RadioButton dateTypeReminder;
        private System.Windows.Forms.CheckBox reminderCreate;
    }
}