namespace baseprotect
{
    partial class RemindersList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemindersList));
            this.remList = new BrightIdeasSoftware.ObjectListView();
            this.Created = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Person = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Info = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.remList)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // remList
            // 
            this.remList.AllColumns.Add(this.Created);
            this.remList.AllColumns.Add(this.Person);
            this.remList.AllColumns.Add(this.Info);
            this.remList.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.remList.BackColor = System.Drawing.SystemColors.Info;
            this.remList.CheckBoxes = true;
            this.remList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Created,
            this.Person,
            this.Info});
            this.remList.Cursor = System.Windows.Forms.Cursors.Default;
            this.remList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.remList.EmptyListMsg = "No Alarms";
            this.remList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.remList.FullRowSelect = true;
            this.remList.HasCollapsibleGroups = false;
            this.remList.Location = new System.Drawing.Point(4, 4);
            this.remList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.remList.MultiSelect = false;
            this.remList.Name = "remList";
            this.remList.ShowGroups = false;
            this.remList.Size = new System.Drawing.Size(903, 325);
            this.remList.SortGroupItemsByPrimaryColumn = false;
            this.remList.TabIndex = 0;
            this.remList.UseCompatibleStateImageBehavior = false;
            this.remList.UseHotItem = true;
            this.remList.UseTranslucentHotItem = true;
            this.remList.UseTranslucentSelection = true;
            this.remList.View = System.Windows.Forms.View.Details;
            this.remList.ItemActivate += new System.EventHandler(this.remList_ItemActivate);
            // 
            // Created
            // 
            this.Created.AspectName = "CreationDate";
            this.Created.AspectToStringFormat = "{0:d}";
            this.Created.CheckBoxes = true;
            this.Created.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Created.IsEditable = false;
            this.Created.Text = "Created";
            this.Created.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Created.Width = 120;
            // 
            // Person
            // 
            this.Person.AspectName = "Person.FullName";
            this.Person.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Person.IsEditable = false;
            this.Person.Text = "Person";
            this.Person.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Person.Width = 150;
            // 
            // Info
            // 
            this.Info.AspectName = "Note.Text";
            this.Info.FillsFreeSpace = true;
            this.Info.IsEditable = false;
            this.Info.IsTileViewColumn = true;
            this.Info.Text = "Info";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.remList, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(16, 15);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(911, 385);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(381, 337);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 44);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RemindersList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 405);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "RemindersList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Alarms!";
            this.Load += new System.EventHandler(this.RemindersList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.remList)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView remList;
        private BrightIdeasSoftware.OLVColumn Created;
        private BrightIdeasSoftware.OLVColumn Person;
        private BrightIdeasSoftware.OLVColumn Info;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button1;
    }
}