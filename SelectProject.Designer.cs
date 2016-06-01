namespace baseprotect
{
    partial class SelectProjectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectProjectForm));
            this.loadProject = new System.Windows.Forms.Button();
            this.projectsList = new BrightIdeasSoftware.ObjectListView();
            this.NameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.newBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.importWorker = new System.ComponentModel.BackgroundWorker();
            this.importProgress = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.projectsList)).BeginInit();
            this.SuspendLayout();
            // 
            // loadProject
            // 
            this.loadProject.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.loadProject.Enabled = false;
            this.loadProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.loadProject.Image = ((System.Drawing.Image)(resources.GetObject("loadProject.Image")));
            this.loadProject.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.loadProject.Location = new System.Drawing.Point(518, 11);
            this.loadProject.Name = "loadProject";
            this.loadProject.Size = new System.Drawing.Size(86, 29);
            this.loadProject.TabIndex = 0;
            this.loadProject.Text = "Load";
            this.loadProject.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.loadProject.UseVisualStyleBackColor = true;
            this.loadProject.Click += new System.EventHandler(this.loadProject_Click);
            // 
            // projectsList
            // 
            this.projectsList.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.projectsList.AllColumns.Add(this.NameColumn);
            this.projectsList.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.projectsList.BackColor = System.Drawing.SystemColors.Info;
            this.projectsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameColumn});
            this.projectsList.Cursor = System.Windows.Forms.Cursors.Default;
            this.projectsList.EmptyListMsg = "No projects";
            this.projectsList.EmptyListMsgFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.projectsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.projectsList.FullRowSelect = true;
            this.projectsList.GridLines = true;
            this.projectsList.HasCollapsibleGroups = false;
            this.projectsList.Location = new System.Drawing.Point(12, 12);
            this.projectsList.MultiSelect = false;
            this.projectsList.Name = "projectsList";
            this.projectsList.ShowGroups = false;
            this.projectsList.ShowItemToolTips = true;
            this.projectsList.Size = new System.Drawing.Size(502, 269);
            this.projectsList.SortGroupItemsByPrimaryColumn = false;
            this.projectsList.TabIndex = 1;
            this.projectsList.UseAlternatingBackColors = true;
            this.projectsList.UseCompatibleStateImageBehavior = false;
            this.projectsList.UseHotItem = true;
            this.projectsList.UseTranslucentHotItem = true;
            this.projectsList.View = System.Windows.Forms.View.Details;
            this.projectsList.ItemActivate += new System.EventHandler(this.projectsList_ItemActivate);
            this.projectsList.SelectedIndexChanged += new System.EventHandler(this.projectsList_SelectedIndexChanged);
            // 
            // NameColumn
            // 
            this.NameColumn.AspectName = "Name";
            this.NameColumn.FillsFreeSpace = true;
            this.NameColumn.IsEditable = false;
            this.NameColumn.Text = "Name ";
            // 
            // newBtn
            // 
            this.newBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.newBtn.Image = ((System.Drawing.Image)(resources.GetObject("newBtn.Image")));
            this.newBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.newBtn.Location = new System.Drawing.Point(518, 46);
            this.newBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.newBtn.Name = "newBtn";
            this.newBtn.Size = new System.Drawing.Size(87, 28);
            this.newBtn.TabIndex = 2;
            this.newBtn.Text = "New";
            this.newBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.newBtn.UseVisualStyleBackColor = true;
            this.newBtn.Click += new System.EventHandler(this.newBtn_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DeleteBtn.Image = ((System.Drawing.Image)(resources.GetObject("DeleteBtn.Image")));
            this.DeleteBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DeleteBtn.Location = new System.Drawing.Point(518, 78);
            this.DeleteBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(87, 28);
            this.DeleteBtn.TabIndex = 3;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // importWorker
            // 
            this.importWorker.WorkerReportsProgress = true;
            // 
            // importProgress
            // 
            this.importProgress.Location = new System.Drawing.Point(12, 288);
            this.importProgress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.importProgress.Name = "importProgress";
            this.importProgress.Size = new System.Drawing.Size(501, 19);
            this.importProgress.TabIndex = 4;
            this.importProgress.Visible = false;
            // 
            // SelectProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 317);
            this.Controls.Add(this.importProgress);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.newBtn);
            this.Controls.Add(this.projectsList);
            this.Controls.Add(this.loadProject);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SelectProjectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Project";
            this.Load += new System.EventHandler(this.SelectProject_Load);
            ((System.ComponentModel.ISupportInitialize)(this.projectsList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button loadProject;
        private BrightIdeasSoftware.ObjectListView projectsList;
        private BrightIdeasSoftware.OLVColumn NameColumn;
        private System.Windows.Forms.Button newBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.ComponentModel.BackgroundWorker importWorker;
        private System.Windows.Forms.ProgressBar importProgress;
    }
}