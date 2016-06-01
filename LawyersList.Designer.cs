namespace baseprotect
{
    partial class LawyersList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LawyersList));
            this.list = new BrightIdeasSoftware.ObjectListView();
            this.nameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.snameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.officeColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.emailColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.telColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.projectsColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.addBtn = new System.Windows.Forms.Button();
            this.delBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.list)).BeginInit();
            this.SuspendLayout();
            // 
            // list
            // 
            this.list.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.list.AllColumns.Add(this.nameColumn);
            this.list.AllColumns.Add(this.snameColumn);
            this.list.AllColumns.Add(this.officeColumn);
            this.list.AllColumns.Add(this.emailColumn);
            this.list.AllColumns.Add(this.telColumn);
            this.list.AllColumns.Add(this.projectsColumn);
            this.list.AllowColumnReorder = true;
            this.list.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.list.BackColor = System.Drawing.SystemColors.Info;
            this.list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumn,
            this.snameColumn,
            this.officeColumn,
            this.emailColumn,
            this.telColumn,
            this.projectsColumn});
            this.list.Cursor = System.Windows.Forms.Cursors.Default;
            this.list.FullRowSelect = true;
            this.list.HasCollapsibleGroups = false;
            this.list.Location = new System.Drawing.Point(12, 12);
            this.list.Name = "list";
            this.list.ShowGroups = false;
            this.list.Size = new System.Drawing.Size(599, 293);
            this.list.TabIndex = 0;
            this.list.UseAlternatingBackColors = true;
            this.list.UseCompatibleStateImageBehavior = false;
            this.list.UseHotItem = true;
            this.list.UseHyperlinks = true;
            this.list.UseTranslucentHotItem = true;
            this.list.UseTranslucentSelection = true;
            this.list.View = System.Windows.Forms.View.Details;
            this.list.HyperlinkClicked += new System.EventHandler<BrightIdeasSoftware.HyperlinkClickedEventArgs>(this.list_HyperlinkClicked);
            this.list.SelectedIndexChanged += new System.EventHandler(this.list_SelectedIndexChanged);
            // 
            // nameColumn
            // 
            this.nameColumn.AspectName = "Name";
            this.nameColumn.Text = "Name";
            this.nameColumn.Width = 100;
            // 
            // snameColumn
            // 
            this.snameColumn.AspectName = "SName";
            this.snameColumn.Text = "Surname";
            this.snameColumn.Width = 120;
            // 
            // officeColumn
            // 
            this.officeColumn.FillsFreeSpace = true;
            this.officeColumn.Text = "Office";
            // 
            // emailColumn
            // 
            this.emailColumn.AspectName = "EMail";
            this.emailColumn.Hyperlink = true;
            this.emailColumn.IsEditable = false;
            this.emailColumn.Text = "EMail";
            this.emailColumn.Width = 120;
            // 
            // telColumn
            // 
            this.telColumn.Text = "Telephone";
            this.telColumn.Width = 100;
            // 
            // projectsColumn
            // 
            this.projectsColumn.AspectName = "ProjectsList";
            this.projectsColumn.Text = "Projects";
            this.projectsColumn.Width = 160;
            // 
            // addBtn
            // 
            this.addBtn.Image = ((System.Drawing.Image)(resources.GetObject("addBtn.Image")));
            this.addBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addBtn.Location = new System.Drawing.Point(617, 12);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(82, 33);
            this.addBtn.TabIndex = 1;
            this.addBtn.Text = "Add";
            this.addBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // delBtn
            // 
            this.delBtn.Enabled = false;
            this.delBtn.Image = ((System.Drawing.Image)(resources.GetObject("delBtn.Image")));
            this.delBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.delBtn.Location = new System.Drawing.Point(617, 51);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(82, 34);
            this.delBtn.TabIndex = 2;
            this.delBtn.Text = "Delete";
            this.delBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.delBtn.UseVisualStyleBackColor = true;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // LawyersList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 317);
            this.Controls.Add(this.delBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.list);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LawyersList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LawyersList";
            ((System.ComponentModel.ISupportInitialize)(this.list)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView list;
        private BrightIdeasSoftware.OLVColumn nameColumn;
        private BrightIdeasSoftware.OLVColumn snameColumn;
        private BrightIdeasSoftware.OLVColumn officeColumn;
        private BrightIdeasSoftware.OLVColumn emailColumn;
        private BrightIdeasSoftware.OLVColumn telColumn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button delBtn;
        private BrightIdeasSoftware.OLVColumn projectsColumn;
    }
}