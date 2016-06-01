namespace baseprotect
{
    partial class ProjectProperties
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectProperties));
            this.projectName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.okBtn = new System.Windows.Forms.Button();
            this.dateAsName = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.schuldner = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.addBtn = new System.Windows.Forms.Button();
            this.templateList = new BrightIdeasSoftware.ObjectListView();
            this.filenameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.templateImageList = new System.Windows.Forms.ImageList(this.components);
            this.delBtn = new System.Windows.Forms.Button();
            this.penalty = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.paymentPeroid = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.ignorePeroid = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.templateList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentPeroid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ignorePeroid)).BeginInit();
            this.SuspendLayout();
            // 
            // projectName
            // 
            this.projectName.BackColor = System.Drawing.SystemColors.Info;
            this.projectName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.projectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.projectName.Location = new System.Drawing.Point(9, 33);
            this.projectName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.projectName.Name = "projectName";
            this.projectName.Size = new System.Drawing.Size(408, 26);
            this.projectName.TabIndex = 0;
            this.projectName.TextChanged += new System.EventHandler(this.projectName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Project name:";
            // 
            // okBtn
            // 
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Enabled = false;
            this.okBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.okBtn.Image = ((System.Drawing.Image)(resources.GetObject("okBtn.Image")));
            this.okBtn.Location = new System.Drawing.Point(378, 406);
            this.okBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(81, 35);
            this.okBtn.TabIndex = 2;
            this.okBtn.Text = "OK";
            this.okBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // dateAsName
            // 
            this.dateAsName.AccessibleDescription = "Set Current Date as Project Name";
            this.dateAsName.Image = ((System.Drawing.Image)(resources.GetObject("dateAsName.Image")));
            this.dateAsName.Location = new System.Drawing.Point(426, 33);
            this.dateAsName.Name = "dateAsName";
            this.dateAsName.Size = new System.Drawing.Size(33, 26);
            this.dateAsName.TabIndex = 3;
            this.dateAsName.UseVisualStyleBackColor = true;
            this.dateAsName.Click += new System.EventHandler(this.dateAsName_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(12, 330);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Schuldner:";
            // 
            // schuldner
            // 
            this.schuldner.BackColor = System.Drawing.SystemColors.Info;
            this.schuldner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.schuldner.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.schuldner.ForeColor = System.Drawing.SystemColors.MenuText;
            this.schuldner.Location = new System.Drawing.Point(16, 357);
            this.schuldner.MaxLength = 9;
            this.schuldner.Name = "schuldner";
            this.schuldner.Size = new System.Drawing.Size(100, 26);
            this.schuldner.TabIndex = 5;
            this.schuldner.Text = "100000";
            this.schuldner.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.schuldner.TextChanged += new System.EventHandler(this.schuldner_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(5, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Templates:";
            // 
            // addBtn
            // 
            this.addBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.addBtn.Image = ((System.Drawing.Image)(resources.GetObject("addBtn.Image")));
            this.addBtn.Location = new System.Drawing.Point(384, 97);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 8;
            this.addBtn.Text = "Add";
            this.addBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // templateList
            // 
            this.templateList.AllColumns.Add(this.filenameColumn);
            this.templateList.AlternateRowBackColor = System.Drawing.Color.PaleGoldenrod;
            this.templateList.BackColor = System.Drawing.SystemColors.Info;
            this.templateList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.filenameColumn});
            this.templateList.Cursor = System.Windows.Forms.Cursors.Default;
            this.templateList.EmptyListMsg = "No templates";
            this.templateList.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.templateList.FullRowSelect = true;
            this.templateList.GridLines = true;
            this.templateList.HasCollapsibleGroups = false;
            this.templateList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.templateList.Location = new System.Drawing.Point(9, 97);
            this.templateList.MultiSelect = false;
            this.templateList.Name = "templateList";
            this.templateList.ShowGroups = false;
            this.templateList.Size = new System.Drawing.Size(369, 218);
            this.templateList.SmallImageList = this.templateImageList;
            this.templateList.TabIndex = 12;
            this.templateList.UnfocusedHighlightBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.templateList.UseAlternatingBackColors = true;
            this.templateList.UseCompatibleStateImageBehavior = false;
            this.templateList.UseHotItem = true;
            this.templateList.UseTranslucentHotItem = true;
            this.templateList.View = System.Windows.Forms.View.Details;
            this.templateList.SelectedIndexChanged += new System.EventHandler(this.templateList_SelectedIndexChanged);
            // 
            // filenameColumn
            // 
            this.filenameColumn.AspectName = "Filename";
            this.filenameColumn.FillsFreeSpace = true;
            this.filenameColumn.Text = "Filename";
            // 
            // templateImageList
            // 
            this.templateImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("templateImageList.ImageStream")));
            this.templateImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.templateImageList.Images.SetKeyName(0, "1294271845_page_word.png");
            // 
            // delBtn
            // 
            this.delBtn.Image = ((System.Drawing.Image)(resources.GetObject("delBtn.Image")));
            this.delBtn.Location = new System.Drawing.Point(384, 126);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(75, 23);
            this.delBtn.TabIndex = 13;
            this.delBtn.Text = "Del";
            this.delBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.delBtn.UseVisualStyleBackColor = true;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // penalty
            // 
            this.penalty.BackColor = System.Drawing.SystemColors.Info;
            this.penalty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.penalty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.penalty.Location = new System.Drawing.Point(16, 416);
            this.penalty.Name = "penalty";
            this.penalty.Size = new System.Drawing.Size(100, 26);
            this.penalty.TabIndex = 14;
            this.penalty.Text = "550";
            this.penalty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.penalty.TextChanged += new System.EventHandler(this.penalty_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(12, 393);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Penalty:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(116, 414);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 26);
            this.label5.TabIndex = 16;
            this.label5.Text = "€";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(180, 393);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "Payment after:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(240, 416);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 20);
            this.label7.TabIndex = 19;
            this.label7.Text = "days";
            // 
            // paymentPeroid
            // 
            this.paymentPeroid.BackColor = System.Drawing.SystemColors.Info;
            this.paymentPeroid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paymentPeroid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.paymentPeroid.Location = new System.Drawing.Point(184, 414);
            this.paymentPeroid.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.paymentPeroid.Name = "paymentPeroid";
            this.paymentPeroid.Size = new System.Drawing.Size(52, 26);
            this.paymentPeroid.TabIndex = 20;
            this.paymentPeroid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.paymentPeroid.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(180, 330);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 20);
            this.label8.TabIndex = 21;
            this.label8.Tag = "";
            this.label8.Text = "Ignore after:";
            // 
            // ignorePeroid
            // 
            this.ignorePeroid.BackColor = System.Drawing.SystemColors.Info;
            this.ignorePeroid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ignorePeroid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ignorePeroid.Location = new System.Drawing.Point(184, 357);
            this.ignorePeroid.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ignorePeroid.Name = "ignorePeroid";
            this.ignorePeroid.Size = new System.Drawing.Size(52, 26);
            this.ignorePeroid.TabIndex = 22;
            this.ignorePeroid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ignorePeroid.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(240, 358);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 20);
            this.label9.TabIndex = 23;
            this.label9.Text = "days";
            // 
            // ProjectProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 454);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ignorePeroid);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.paymentPeroid);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.penalty);
            this.Controls.Add(this.delBtn);
            this.Controls.Add(this.templateList);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.schuldner);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateAsName);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.projectName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ProjectProperties";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Project Properties";
            this.Load += new System.EventHandler(this.ProjectProperties_Load);
            ((System.ComponentModel.ISupportInitialize)(this.templateList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentPeroid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ignorePeroid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox projectName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button dateAsName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox schuldner;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button addBtn;
        private BrightIdeasSoftware.ObjectListView templateList;
        private BrightIdeasSoftware.OLVColumn filenameColumn;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.ImageList templateImageList;
        private System.Windows.Forms.TextBox penalty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown paymentPeroid;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown ignorePeroid;
        private System.Windows.Forms.Label label9;
    }
}