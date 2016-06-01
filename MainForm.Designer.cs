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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JoinerForm));
            this.menuBar = new System.Windows.Forms.ToolStrip();
            this.changeDBBtn = new System.Windows.Forms.ToolStripButton();
            this.newProject = new System.Windows.Forms.ToolStripButton();
            this.openProject = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.importBtn = new System.Windows.Forms.ToolStripButton();
            this.exportBtn = new System.Windows.Forms.ToolStripSplitButton();
            this.checkedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.showSearchPanel = new System.Windows.Forms.ToolStripButton();
            this.changeStateBtn = new System.Windows.Forms.ToolStripButton();
            this.NotifyButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.lawyerBtn = new System.Windows.Forms.ToolStripButton();
            this.sumLabel = new System.Windows.Forms.ToolStripLabel();
            this.notPaidLabel = new System.Windows.Forms.ToolStripLabel();
            this.paidLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.personCount = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.activeProjectLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.statusImageList = new System.Windows.Forms.ImageList(this.components);
            this.secondNameSearchInput = new System.Windows.Forms.TextBox();
            this.firstNameSearchInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.citySearchInput = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.StatesGroup = new System.Windows.Forms.GroupBox();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.ch = new System.Windows.Forms.CheckBox();
            this.Notified = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.postalSearchInput = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.akzSearchInput = new System.Windows.Forms.TextBox();
            this.mainList = new BrightIdeasSoftware.ObjectListView();
            this.schuldnerColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.nameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.subnameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.stateColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.cityColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.postalColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.adressColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.BennKenn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.projectsColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.dateColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.lawyerColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.paymentColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.penaltyColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.notifyWorker = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.overallProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.revLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.exportWorker = new System.ComponentModel.BackgroundWorker();
            this.projectLoadWorker = new System.ComponentModel.BackgroundWorker();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.menuBar.SuspendLayout();
            this.searchPanel.SuspendLayout();
            this.StatesGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainList)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuBar
            // 
            this.menuBar.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeDBBtn,
            this.newProject,
            this.openProject,
            this.toolStripSeparator2,
            this.importBtn,
            this.exportBtn,
            this.toolStripSeparator3,
            this.showSearchPanel,
            this.changeStateBtn,
            this.NotifyButton,
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.lawyerBtn,
            this.sumLabel,
            this.notPaidLabel,
            this.paidLabel,
            this.toolStripSeparator5,
            this.personCount,
            this.toolStripSeparator4,
            this.activeProjectLabel,
            this.toolStripLabel1});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuBar.Size = new System.Drawing.Size(1252, 39);
            this.menuBar.TabIndex = 7;
            this.menuBar.Text = "menu";
            // 
            // changeDBBtn
            // 
            this.changeDBBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.changeDBBtn.Image = ((System.Drawing.Image)(resources.GetObject("changeDBBtn.Image")));
            this.changeDBBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.changeDBBtn.Name = "changeDBBtn";
            this.changeDBBtn.Size = new System.Drawing.Size(36, 36);
            this.changeDBBtn.Text = "Reconnect database";
            this.changeDBBtn.Click += new System.EventHandler(this.changeDBBtn_Click);
            // 
            // newProject
            // 
            this.newProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newProject.Image = ((System.Drawing.Image)(resources.GetObject("newProject.Image")));
            this.newProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newProject.Name = "newProject";
            this.newProject.Size = new System.Drawing.Size(36, 36);
            this.newProject.Text = "New Project";
            this.newProject.Click += new System.EventHandler(this.newProject_Click);
            // 
            // openProject
            // 
            this.openProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openProject.Image = ((System.Drawing.Image)(resources.GetObject("openProject.Image")));
            this.openProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openProject.Name = "openProject";
            this.openProject.Size = new System.Drawing.Size(36, 36);
            this.openProject.Text = "Open Project";
            this.openProject.Click += new System.EventHandler(this.openProject_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // importBtn
            // 
            this.importBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.importBtn.Image = ((System.Drawing.Image)(resources.GetObject("importBtn.Image")));
            this.importBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.importBtn.Name = "importBtn";
            this.importBtn.Size = new System.Drawing.Size(36, 36);
            this.importBtn.Text = "Add new data";
            this.importBtn.Click += new System.EventHandler(this.importBtn_Click);
            // 
            // exportBtn
            // 
            this.exportBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.exportBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkedToolStripMenuItem});
            this.exportBtn.Image = ((System.Drawing.Image)(resources.GetObject("exportBtn.Image")));
            this.exportBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(48, 36);
            this.exportBtn.Text = "Export joined";
            this.exportBtn.ButtonClick += new System.EventHandler(this.exportBtn_ButtonClick);
            // 
            // checkedToolStripMenuItem
            // 
            this.checkedToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.checkedToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("checkedToolStripMenuItem.Image")));
            this.checkedToolStripMenuItem.Name = "checkedToolStripMenuItem";
            this.checkedToolStripMenuItem.Size = new System.Drawing.Size(198, 32);
            this.checkedToolStripMenuItem.Text = "Only checked";
            this.checkedToolStripMenuItem.Click += new System.EventHandler(this.checkedToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // showSearchPanel
            // 
            this.showSearchPanel.CheckOnClick = true;
            this.showSearchPanel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.showSearchPanel.Image = ((System.Drawing.Image)(resources.GetObject("showSearchPanel.Image")));
            this.showSearchPanel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.showSearchPanel.Name = "showSearchPanel";
            this.showSearchPanel.Size = new System.Drawing.Size(36, 36);
            this.showSearchPanel.Text = "Search";
            this.showSearchPanel.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // changeStateBtn
            // 
            this.changeStateBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.changeStateBtn.Image = ((System.Drawing.Image)(resources.GetObject("changeStateBtn.Image")));
            this.changeStateBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.changeStateBtn.Name = "changeStateBtn";
            this.changeStateBtn.Size = new System.Drawing.Size(36, 36);
            this.changeStateBtn.Text = "toolStripButton1";
            this.changeStateBtn.ToolTipText = "Change State";
            this.changeStateBtn.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // NotifyButton
            // 
            this.NotifyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.NotifyButton.Image = ((System.Drawing.Image)(resources.GetObject("NotifyButton.Image")));
            this.NotifyButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NotifyButton.Name = "NotifyButton";
            this.NotifyButton.Size = new System.Drawing.Size(36, 36);
            this.NotifyButton.Text = "toolStripButton1";
            this.NotifyButton.ToolTipText = "Notify";
            this.NotifyButton.Click += new System.EventHandler(this.toolStripButton1_Click_2);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton1.Text = "Project Settings";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_3);
            // 
            // lawyerBtn
            // 
            this.lawyerBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lawyerBtn.Image = ((System.Drawing.Image)(resources.GetObject("lawyerBtn.Image")));
            this.lawyerBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lawyerBtn.Name = "lawyerBtn";
            this.lawyerBtn.Size = new System.Drawing.Size(36, 36);
            this.lawyerBtn.Text = "Lawyers";
            this.lawyerBtn.Click += new System.EventHandler(this.lawyerBtn_Click);
            // 
            // sumLabel
            // 
            this.sumLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.sumLabel.Name = "sumLabel";
            this.sumLabel.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.sumLabel.Size = new System.Drawing.Size(17, 36);
            this.sumLabel.Text = "0";
            this.sumLabel.ToolTipText = "Sum of all penalties";
            // 
            // notPaidLabel
            // 
            this.notPaidLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.notPaidLabel.ForeColor = System.Drawing.Color.Red;
            this.notPaidLabel.Name = "notPaidLabel";
            this.notPaidLabel.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.notPaidLabel.Size = new System.Drawing.Size(17, 36);
            this.notPaidLabel.Text = "0";
            this.notPaidLabel.ToolTipText = "Sum of all not paid penalties";
            // 
            // paidLabel
            // 
            this.paidLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.paidLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.paidLabel.ForeColor = System.Drawing.Color.SeaGreen;
            this.paidLabel.Margin = new System.Windows.Forms.Padding(0);
            this.paidLabel.Name = "paidLabel";
            this.paidLabel.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.paidLabel.Size = new System.Drawing.Size(17, 39);
            this.paidLabel.Text = "0";
            this.paidLabel.ToolTipText = "Sum of all already paid penalties";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 39);
            // 
            // personCount
            // 
            this.personCount.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.personCount.Name = "personCount";
            this.personCount.Size = new System.Drawing.Size(17, 36);
            this.personCount.Text = "0";
            this.personCount.ToolTipText = "All person count";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
            // 
            // activeProjectLabel
            // 
            this.activeProjectLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.activeProjectLabel.AutoToolTip = true;
            this.activeProjectLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.activeProjectLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.activeProjectLabel.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.activeProjectLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.activeProjectLabel.Name = "activeProjectLabel";
            this.activeProjectLabel.Size = new System.Drawing.Size(24, 34);
            this.activeProjectLabel.Text = "[]";
            this.activeProjectLabel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.activeProjectLabel.ToolTipText = "Active project";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(104, 36);
            this.toolStripLabel1.Text = "Active project:";
            // 
            // statusImageList
            // 
            this.statusImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("statusImageList.ImageStream")));
            this.statusImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.statusImageList.Images.SetKeyName(0, "attachment");
            // 
            // secondNameSearchInput
            // 
            this.secondNameSearchInput.BackColor = System.Drawing.SystemColors.Info;
            this.secondNameSearchInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.secondNameSearchInput.Location = new System.Drawing.Point(129, 47);
            this.secondNameSearchInput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.secondNameSearchInput.Name = "secondNameSearchInput";
            this.secondNameSearchInput.Size = new System.Drawing.Size(238, 24);
            this.secondNameSearchInput.TabIndex = 11;
            this.secondNameSearchInput.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // firstNameSearchInput
            // 
            this.firstNameSearchInput.BackColor = System.Drawing.SystemColors.Info;
            this.firstNameSearchInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.firstNameSearchInput.Location = new System.Drawing.Point(129, 9);
            this.firstNameSearchInput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.firstNameSearchInput.Name = "firstNameSearchInput";
            this.firstNameSearchInput.Size = new System.Drawing.Size(238, 24);
            this.firstNameSearchInput.TabIndex = 10;
            this.firstNameSearchInput.TextChanged += new System.EventHandler(this.firstNameSearchInput_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(419, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 18);
            this.label3.TabIndex = 14;
            this.label3.Text = "City:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "Second name:";
            // 
            // citySearchInput
            // 
            this.citySearchInput.BackColor = System.Drawing.SystemColors.Info;
            this.citySearchInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.citySearchInput.Location = new System.Drawing.Point(463, 9);
            this.citySearchInput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.citySearchInput.Name = "citySearchInput";
            this.citySearchInput.Size = new System.Drawing.Size(247, 24);
            this.citySearchInput.TabIndex = 15;
            this.citySearchInput.TextChanged += new System.EventHandler(this.citySearchInput_TextChanged);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(8, 11);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(82, 18);
            this.nameLabel.TabIndex = 8;
            this.nameLabel.Text = "First name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(375, 49);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 16;
            this.label4.Text = "BennKenn:";
            // 
            // searchPanel
            // 
            this.searchPanel.AutoSize = true;
            this.searchPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.searchPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchPanel.Controls.Add(this.StatesGroup);
            this.searchPanel.Controls.Add(this.postalSearchInput);
            this.searchPanel.Controls.Add(this.label5);
            this.searchPanel.Controls.Add(this.akzSearchInput);
            this.searchPanel.Controls.Add(this.label4);
            this.searchPanel.Controls.Add(this.nameLabel);
            this.searchPanel.Controls.Add(this.citySearchInput);
            this.searchPanel.Controls.Add(this.label1);
            this.searchPanel.Controls.Add(this.label3);
            this.searchPanel.Controls.Add(this.firstNameSearchInput);
            this.searchPanel.Controls.Add(this.secondNameSearchInput);
            this.searchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.searchPanel.Location = new System.Drawing.Point(4, 4);
            this.searchPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.searchPanel.Size = new System.Drawing.Size(1244, 147);
            this.searchPanel.TabIndex = 10;
            this.searchPanel.Visible = false;
            // 
            // StatesGroup
            // 
            this.StatesGroup.Controls.Add(this.checkBox11);
            this.StatesGroup.Controls.Add(this.checkBox10);
            this.StatesGroup.Controls.Add(this.checkBox9);
            this.StatesGroup.Controls.Add(this.checkBox8);
            this.StatesGroup.Controls.Add(this.checkBox2);
            this.StatesGroup.Controls.Add(this.checkBox1);
            this.StatesGroup.Controls.Add(this.checkBox7);
            this.StatesGroup.Controls.Add(this.checkBox6);
            this.StatesGroup.Controls.Add(this.checkBox5);
            this.StatesGroup.Controls.Add(this.checkBox3);
            this.StatesGroup.Controls.Add(this.ch);
            this.StatesGroup.Controls.Add(this.Notified);
            this.StatesGroup.Controls.Add(this.checkBox4);
            this.StatesGroup.Location = new System.Drawing.Point(717, 2);
            this.StatesGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StatesGroup.Name = "StatesGroup";
            this.StatesGroup.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StatesGroup.Size = new System.Drawing.Size(515, 135);
            this.StatesGroup.TabIndex = 26;
            this.StatesGroup.TabStop = false;
            this.StatesGroup.Text = "State:";
            // 
            // checkBox11
            // 
            this.checkBox11.AutoSize = true;
            this.checkBox11.Location = new System.Drawing.Point(4, 107);
            this.checkBox11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(140, 27);
            this.checkBox11.TabIndex = 34;
            this.checkBox11.Text = "Negotiation";
            this.checkBox11.UseVisualStyleBackColor = true;
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.Location = new System.Drawing.Point(319, 80);
            this.checkBox10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(111, 27);
            this.checkBox10.TabIndex = 33;
            this.checkBox10.Text = "NotPaid";
            this.checkBox10.UseVisualStyleBackColor = true;
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(319, 59);
            this.checkBox9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(184, 27);
            this.checkBox9.TabIndex = 32;
            this.checkBox9.Text = "CreditNotSigned";
            this.checkBox9.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(319, 37);
            this.checkBox8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(227, 27);
            this.checkBox8.TabIndex = 31;
            this.checkBox8.Text = "CreditSignedModified";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(319, 16);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(152, 27);
            this.checkBox2.TabIndex = 30;
            this.checkBox2.Text = "CreditSigned";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(139, 80);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(171, 27);
            this.checkBox1.TabIndex = 29;
            this.checkBox1.Text = "PaidNotSigned";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(139, 59);
            this.checkBox7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(213, 27);
            this.checkBox7.TabIndex = 28;
            this.checkBox7.Text = "PaidSignedModified";
            this.checkBox7.UseVisualStyleBackColor = true;
            this.checkBox7.CheckedChanged += new System.EventHandler(this.stateSearchList_SelectedIndexChanged);
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(5, 81);
            this.checkBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(139, 27);
            this.checkBox6.TabIndex = 27;
            this.checkBox6.Text = "PaidSigned";
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.stateSearchList_SelectedIndexChanged);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(5, 59);
            this.checkBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(155, 27);
            this.checkBox5.TabIndex = 26;
            this.checkBox5.Text = "NotifiedAgain";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.stateSearchList_SelectedIndexChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(139, 16);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(109, 27);
            this.checkBox3.TabIndex = 24;
            this.checkBox3.Text = "Ignoring";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.stateSearchList_SelectedIndexChanged);
            // 
            // ch
            // 
            this.ch.AutoSize = true;
            this.ch.Location = new System.Drawing.Point(5, 16);
            this.ch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ch.Name = "ch";
            this.ch.Size = new System.Drawing.Size(107, 27);
            this.ch.TabIndex = 22;
            this.ch.Text = "Notified";
            this.ch.UseVisualStyleBackColor = true;
            this.ch.CheckedChanged += new System.EventHandler(this.stateSearchList_SelectedIndexChanged);
            // 
            // Notified
            // 
            this.Notified.AccessibleDescription = "";
            this.Notified.AutoSize = true;
            this.Notified.Location = new System.Drawing.Point(5, 37);
            this.Notified.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Notified.Name = "Notified";
            this.Notified.Size = new System.Drawing.Size(139, 27);
            this.Notified.TabIndex = 23;
            this.Notified.Text = "NotNotified";
            this.Notified.UseVisualStyleBackColor = true;
            this.Notified.CheckedChanged += new System.EventHandler(this.stateSearchList_SelectedIndexChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(139, 37);
            this.checkBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(119, 27);
            this.checkBox4.TabIndex = 25;
            this.checkBox4.Text = "Exported";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.stateSearchList_SelectedIndexChanged);
            // 
            // postalSearchInput
            // 
            this.postalSearchInput.BackColor = System.Drawing.SystemColors.Info;
            this.postalSearchInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.postalSearchInput.Location = new System.Drawing.Point(129, 82);
            this.postalSearchInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.postalSearchInput.Name = "postalSearchInput";
            this.postalSearchInput.Size = new System.Drawing.Size(238, 24);
            this.postalSearchInput.TabIndex = 21;
            this.postalSearchInput.TextChanged += new System.EventHandler(this.postalSearchInput_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 18);
            this.label5.TabIndex = 20;
            this.label5.Text = "Postal:";
            // 
            // akzSearchInput
            // 
            this.akzSearchInput.BackColor = System.Drawing.SystemColors.Info;
            this.akzSearchInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.akzSearchInput.Location = new System.Drawing.Point(463, 47);
            this.akzSearchInput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.akzSearchInput.Name = "akzSearchInput";
            this.akzSearchInput.Size = new System.Drawing.Size(247, 24);
            this.akzSearchInput.TabIndex = 17;
            this.akzSearchInput.TextChanged += new System.EventHandler(this.akzSearchInput_TextChanged);
            // 
            // mainList
            // 
            this.mainList.AllColumns.Add(this.schuldnerColumn);
            this.mainList.AllColumns.Add(this.nameColumn);
            this.mainList.AllColumns.Add(this.subnameColumn);
            this.mainList.AllColumns.Add(this.stateColumn);
            this.mainList.AllColumns.Add(this.cityColumn);
            this.mainList.AllColumns.Add(this.postalColumn);
            this.mainList.AllColumns.Add(this.adressColumn);
            this.mainList.AllColumns.Add(this.BennKenn);
            this.mainList.AllColumns.Add(this.projectsColumn);
            this.mainList.AllColumns.Add(this.dateColumn);
            this.mainList.AllColumns.Add(this.lawyerColumn);
            this.mainList.AllColumns.Add(this.paymentColumn);
            this.mainList.AllColumns.Add(this.penaltyColumn);
            this.mainList.AllowColumnReorder = true;
            this.mainList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mainList.CheckBoxes = true;
            this.mainList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.schuldnerColumn,
            this.nameColumn,
            this.subnameColumn,
            this.stateColumn,
            this.cityColumn,
            this.postalColumn,
            this.BennKenn,
            this.paymentColumn,
            this.penaltyColumn});
            this.mainList.Cursor = System.Windows.Forms.Cursors.Default;
            this.mainList.EmptyListMsg = "No data";
            this.mainList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mainList.FullRowSelect = true;
            this.mainList.GridLines = true;
            this.mainList.HeaderMaximumHeight = 25;
            this.mainList.Location = new System.Drawing.Point(4, 159);
            this.mainList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mainList.Name = "mainList";
            this.mainList.OwnerDraw = true;
            this.mainList.ShowGroups = false;
            this.mainList.ShowImagesOnSubItems = true;
            this.mainList.ShowItemCountOnGroups = true;
            this.mainList.Size = new System.Drawing.Size(1244, 461);
            this.mainList.SmallImageList = this.statusImageList;
            this.mainList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.mainList.TabIndex = 9;
            this.mainList.UnfocusedHighlightBackgroundColor = System.Drawing.Color.White;
            this.mainList.UseCompatibleStateImageBehavior = false;
            this.mainList.UseHotItem = true;
            this.mainList.UseTranslucentHotItem = true;
            this.mainList.UseTranslucentSelection = true;
            this.mainList.View = System.Windows.Forms.View.Details;
            this.mainList.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.mainList_CellEditFinishing);
            this.mainList.ItemActivate += new System.EventHandler(this.mainList_ItemActivate);
            // 
            // schuldnerColumn
            // 
            this.schuldnerColumn.AspectName = "SchuldnerNo";
            this.schuldnerColumn.AutoCompleteEditor = false;
            this.schuldnerColumn.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
            this.schuldnerColumn.Groupable = false;
            this.schuldnerColumn.IsEditable = false;
            this.schuldnerColumn.Text = "SchuldnerNr";
            this.schuldnerColumn.Width = 120;
            // 
            // nameColumn
            // 
            this.nameColumn.AspectName = "FirstName";
            this.nameColumn.AutoCompleteEditor = false;
            this.nameColumn.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
            this.nameColumn.Groupable = false;
            this.nameColumn.GroupWithItemCountFormat = "{0}     [{1} Persons]";
            this.nameColumn.GroupWithItemCountSingularFormat = "{0}     [{1} Persons]";
            this.nameColumn.IsEditable = false;
            this.nameColumn.Text = "Name";
            this.nameColumn.Width = 150;
            // 
            // subnameColumn
            // 
            this.subnameColumn.AspectName = "SecondName";
            this.subnameColumn.AutoCompleteEditor = false;
            this.subnameColumn.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
            this.subnameColumn.GroupWithItemCountFormat = "{0}    [{1} Persons]";
            this.subnameColumn.GroupWithItemCountSingularFormat = "{0}    [{1} Persons]";
            this.subnameColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.subnameColumn.IsEditable = false;
            this.subnameColumn.IsHeaderVertical = true;
            this.subnameColumn.Text = "Subname";
            this.subnameColumn.UseInitialLetterForGroup = true;
            this.subnameColumn.Width = 160;
            // 
            // stateColumn
            // 
            this.stateColumn.AspectName = "CurrentState.State";
            this.stateColumn.GroupWithItemCountFormat = "{0}    [{1} Persons]";
            this.stateColumn.GroupWithItemCountSingularFormat = "{0}    [{1} Persons]";
            this.stateColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.stateColumn.IsEditable = false;
            this.stateColumn.MaximumWidth = 200;
            this.stateColumn.MinimumWidth = 160;
            this.stateColumn.Text = "State";
            this.stateColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.stateColumn.Width = 200;
            // 
            // cityColumn
            // 
            this.cityColumn.AspectName = "City";
            this.cityColumn.GroupWithItemCountFormat = "{0}    [{1} Persons]";
            this.cityColumn.GroupWithItemCountSingularFormat = "{0}    [{1} Persons]";
            this.cityColumn.IsEditable = false;
            this.cityColumn.Text = "City";
            this.cityColumn.UseInitialLetterForGroup = true;
            this.cityColumn.Width = 160;
            // 
            // postalColumn
            // 
            this.postalColumn.AspectName = "Postal";
            this.postalColumn.Groupable = false;
            this.postalColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.postalColumn.IsEditable = false;
            this.postalColumn.Text = "Postal";
            this.postalColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // adressColumn
            // 
            this.adressColumn.AspectName = "Details";
            this.adressColumn.DisplayIndex = 6;
            this.adressColumn.Groupable = false;
            this.adressColumn.IsEditable = false;
            this.adressColumn.IsVisible = false;
            this.adressColumn.Text = "Adress";
            this.adressColumn.Width = 190;
            // 
            // BennKenn
            // 
            this.BennKenn.AspectName = "FilesNo";
            this.BennKenn.Groupable = false;
            this.BennKenn.Text = "BennKenn";
            this.BennKenn.Width = 190;
            // 
            // projectsColumn
            // 
            this.projectsColumn.AspectName = "ProjectsCount";
            this.projectsColumn.DisplayIndex = 7;
            this.projectsColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.projectsColumn.Hyperlink = true;
            this.projectsColumn.IsEditable = false;
            this.projectsColumn.IsVisible = false;
            this.projectsColumn.Text = "No. Projects";
            this.projectsColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.projectsColumn.UseInitialLetterForGroup = true;
            // 
            // dateColumn
            // 
            this.dateColumn.AspectName = "CurrentState.Date";
            this.dateColumn.AspectToStringFormat = "{0:g}";
            this.dateColumn.DisplayIndex = 9;
            this.dateColumn.GroupWithItemCountFormat = "{0}    [{1} Persons]";
            this.dateColumn.GroupWithItemCountSingularFormat = "{0}    [{1} Persons]";
            this.dateColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateColumn.IsEditable = false;
            this.dateColumn.IsVisible = false;
            this.dateColumn.MaximumWidth = 160;
            this.dateColumn.MinimumWidth = 160;
            this.dateColumn.Text = "Date of last state change";
            this.dateColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateColumn.Width = 160;
            // 
            // lawyerColumn
            // 
            this.lawyerColumn.AspectName = "LawyersNames";
            this.lawyerColumn.DisplayIndex = 10;
            this.lawyerColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lawyerColumn.IsVisible = false;
            this.lawyerColumn.Text = "Lawyer";
            this.lawyerColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lawyerColumn.UseInitialLetterForGroup = true;
            // 
            // paymentColumn
            // 
            this.paymentColumn.AspectName = "PaymentsAmount";
            this.paymentColumn.AspectToStringFormat = "{0:N} € ";
            this.paymentColumn.GroupWithItemCountFormat = "{0}    [{1} Persons]";
            this.paymentColumn.GroupWithItemCountSingularFormat = "{0}    [{1} Persons]";
            this.paymentColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.paymentColumn.Text = "Payments";
            this.paymentColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.paymentColumn.Width = 100;
            // 
            // penaltyColumn
            // 
            this.penaltyColumn.AspectName = "PenaltyAmount";
            this.penaltyColumn.AspectToStringFormat = "{0:N} €";
            this.penaltyColumn.GroupWithItemCountFormat = "{0}    [{1} Persons]";
            this.penaltyColumn.GroupWithItemCountSingularFormat = "{0}    [{1} Persons]";
            this.penaltyColumn.Text = "Penalty";
            this.penaltyColumn.Width = 100;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.searchPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.mainList, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 52);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1252, 624);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // notifyWorker
            // 
            this.notifyWorker.WorkerReportsProgress = true;
            this.notifyWorker.WorkerSupportsCancellation = true;
            this.notifyWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.notifyWorker_DoWork);
            this.notifyWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.notifyWorker_ProgressChanged);
            this.notifyWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.notifyWorker_RunWorkerCompleted);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.overallProgress,
            this.toolStripStatusLabel1,
            this.revLabel});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 678);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1252, 26);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // overallProgress
            // 
            this.overallProgress.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.overallProgress.MarqueeAnimationSpeed = 10;
            this.overallProgress.Maximum = 10;
            this.overallProgress.Name = "overallProgress";
            this.overallProgress.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.overallProgress.Size = new System.Drawing.Size(533, 20);
            this.overallProgress.Step = 1;
            this.overallProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(61, 21);
            this.toolStripStatusLabel1.Text = "Version:";
            // 
            // revLabel
            // 
            this.revLabel.Name = "revLabel";
            this.revLabel.Size = new System.Drawing.Size(0, 21);
            // 
            // exportWorker
            // 
            this.exportWorker.WorkerReportsProgress = true;
            this.exportWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.exportWorker_DoWork);
            this.exportWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.exportWorker_ProgressChanged);
            this.exportWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.exportWorker_RunWorkerCompleted);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 39);
            this.splitter1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 639);
            this.splitter1.TabIndex = 13;
            this.splitter1.TabStop = false;
            // 
            // JoinerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 704);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "JoinerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Baseprotect Joiner 2.0";
            this.Load += new System.EventHandler(this.JoinerForm_Load);
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.StatesGroup.ResumeLayout(false);
            this.StatesGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainList)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip menuBar;
        private System.Windows.Forms.ToolStripButton openProject;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel activeProjectLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton importBtn;
        private System.Windows.Forms.ToolStripButton newProject;
        private System.Windows.Forms.ToolStripSplitButton exportBtn;
        private System.Windows.Forms.ToolStripMenuItem checkedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton showSearchPanel;
        private System.Windows.Forms.ToolStripButton changeStateBtn;
        private System.Windows.Forms.ImageList statusImageList;
        private System.Windows.Forms.ToolStripButton NotifyButton;
        private System.Windows.Forms.TextBox secondNameSearchInput;
        private System.Windows.Forms.TextBox firstNameSearchInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox citySearchInput;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel searchPanel;
        private BrightIdeasSoftware.OLVColumn nameColumn;
        private BrightIdeasSoftware.OLVColumn subnameColumn;
        private BrightIdeasSoftware.OLVColumn cityColumn;
        private BrightIdeasSoftware.OLVColumn stateColumn;
        private BrightIdeasSoftware.OLVColumn dateColumn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.ComponentModel.BackgroundWorker notifyWorker;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar overallProgress;
        private BrightIdeasSoftware.ObjectListView mainList;
        private System.Windows.Forms.TextBox akzSearchInput;
        private System.ComponentModel.BackgroundWorker exportWorker;
        private System.ComponentModel.BackgroundWorker projectLoadWorker;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel revLabel;
        private BrightIdeasSoftware.OLVColumn postalColumn;
        private BrightIdeasSoftware.OLVColumn schuldnerColumn;
        private BrightIdeasSoftware.OLVColumn adressColumn;
        private System.Windows.Forms.TextBox postalSearchInput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox Notified;
        private System.Windows.Forms.CheckBox ch;
        private System.Windows.Forms.GroupBox StatesGroup;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox10;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private BrightIdeasSoftware.OLVColumn projectsColumn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Splitter splitter1;
        private BrightIdeasSoftware.OLVColumn lawyerColumn;
        private System.Windows.Forms.ToolStripButton lawyerBtn;
        private System.Windows.Forms.ToolStripButton changeDBBtn;
        private BrightIdeasSoftware.OLVColumn BennKenn;
        private BrightIdeasSoftware.OLVColumn paymentColumn;
        private System.Windows.Forms.ToolStripLabel sumLabel;
        private System.Windows.Forms.ToolStripLabel notPaidLabel;
        private System.Windows.Forms.ToolStripLabel paidLabel;
        private System.Windows.Forms.CheckBox checkBox11;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private BrightIdeasSoftware.OLVColumn penaltyColumn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripLabel personCount;


    }
}

