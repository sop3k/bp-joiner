namespace baseprotect
{
    partial class JoinerForm
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
            this.newDataBtn = new System.Windows.Forms.Button();
            this.exportBtn = new System.Windows.Forms.Button();
            this.mainList = new BrightIdeasSoftware.TreeListView();
            this.FirstName = new BrightIdeasSoftware.OLVColumn();
            this.SecondName = new BrightIdeasSoftware.OLVColumn();
            this.Notified = new BrightIdeasSoftware.OLVColumn();
            this.City = new BrightIdeasSoftware.OLVColumn();
            this.NumOfEvents = new BrightIdeasSoftware.OLVColumn();
            ((System.ComponentModel.ISupportInitialize)(this.mainList)).BeginInit();
            this.SuspendLayout();
            // 
            // newDataBtn
            // 
            this.newDataBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.newDataBtn.Location = new System.Drawing.Point(12, 12);
            this.newDataBtn.Name = "newDataBtn";
            this.newDataBtn.Size = new System.Drawing.Size(182, 62);
            this.newDataBtn.TabIndex = 1;
            this.newDataBtn.Text = "New data";
            this.newDataBtn.UseVisualStyleBackColor = true;
            this.newDataBtn.Click += new System.EventHandler(this.newDataBtn_Click);
            // 
            // exportBtn
            // 
            this.exportBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.exportBtn.Location = new System.Drawing.Point(644, 12);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(156, 62);
            this.exportBtn.TabIndex = 2;
            this.exportBtn.Text = "Export";
            this.exportBtn.UseVisualStyleBackColor = true;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // mainList
            // 
            this.mainList.AllColumns.Add(this.FirstName);
            this.mainList.AllColumns.Add(this.SecondName);
            this.mainList.AllColumns.Add(this.Notified);
            this.mainList.AllColumns.Add(this.City);
            this.mainList.AllColumns.Add(this.NumOfEvents);
            this.mainList.AllowDrop = true;
            this.mainList.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.mainList.BackColor = System.Drawing.SystemColors.Info;
            this.mainList.CheckBoxes = true;
            this.mainList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FirstName,
            this.SecondName,
            this.Notified,
            this.City,
            this.NumOfEvents});
            this.mainList.EmptyListMsg = "No data";
            this.mainList.EmptyListMsgFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mainList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mainList.FullRowSelect = true;
            this.mainList.GridLines = true;
            this.mainList.GroupWithItemCountFormat = "";
            this.mainList.Location = new System.Drawing.Point(12, 80);
            this.mainList.Name = "mainList";
            this.mainList.OwnerDraw = true;
            this.mainList.RenderNonEditableCheckboxesAsDisabled = true;
            this.mainList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mainList.SelectedColumnTint = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.mainList.ShowCommandMenuOnRightClick = true;
            this.mainList.ShowGroups = false;
            this.mainList.ShowImagesOnSubItems = true;
            this.mainList.ShowItemCountOnGroups = true;
            this.mainList.Size = new System.Drawing.Size(788, 389);
            this.mainList.TabIndex = 4;
            this.mainList.TintSortColumn = true;
            this.mainList.UseAlternatingBackColors = true;
            this.mainList.UseCompatibleStateImageBehavior = false;
            this.mainList.UseExplorerTheme = true;
            this.mainList.UseOverlays = false;
            this.mainList.View = System.Windows.Forms.View.Details;
            this.mainList.VirtualMode = true;
            // 
            // FirstName
            // 
            this.FirstName.AspectName = "FirstName";
            this.FirstName.FillsFreeSpace = true;
            this.FirstName.IsEditable = false;
            this.FirstName.Text = "First Name";
            this.FirstName.UseInitialLetterForGroup = true;
            // 
            // SecondName
            // 
            this.SecondName.AspectName = "SecondName";
            this.SecondName.FillsFreeSpace = true;
            this.SecondName.IsEditable = false;
            this.SecondName.Text = "Second Name";
            // 
            // Notified
            // 
            this.Notified.AspectName = "Notified";
            this.Notified.FillsFreeSpace = true;
            this.Notified.IsEditable = false;
            this.Notified.Text = "Notified";
            // 
            // City
            // 
            this.City.AspectName = "City";
            this.City.FillsFreeSpace = true;
            this.City.IsEditable = false;
            this.City.Text = "City";
            // 
            // NumOfEvents
            // 
            this.NumOfEvents.AspectName = "NumOfEvents";
            this.NumOfEvents.FillsFreeSpace = true;
            this.NumOfEvents.IsEditable = false;
            this.NumOfEvents.Text = "Number Of Events";
            // 
            // JoinerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(812, 481);
            this.Controls.Add(this.mainList);
            this.Controls.Add(this.exportBtn);
            this.Controls.Add(this.newDataBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "JoinerForm";
            this.Load += new System.EventHandler(this.JoinerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button newDataBtn;
        private System.Windows.Forms.Button exportBtn;
        private BrightIdeasSoftware.TreeListView mainList;
        private BrightIdeasSoftware.OLVColumn FirstName;
        private BrightIdeasSoftware.OLVColumn SecondName;
        private BrightIdeasSoftware.OLVColumn Notified;
        private BrightIdeasSoftware.OLVColumn City;
        private BrightIdeasSoftware.OLVColumn NumOfEvents;


    }
}

