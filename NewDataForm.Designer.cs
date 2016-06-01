namespace baseprotect
{
    partial class NewDataForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewDataForm));
            this.eventLookupBtn = new System.Windows.Forms.Button();
            this.providerFilePath = new System.Windows.Forms.TextBox();
            this.eventFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.loadBtn = new System.Windows.Forms.Button();
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.joinProgress = new System.Windows.Forms.ProgressBar();
            this.providerLookupBtn = new System.Windows.Forms.Button();
            this.provider = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // eventLookupBtn
            // 
            this.eventLookupBtn.Enabled = false;
            this.eventLookupBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.eventLookupBtn.Image = ((System.Drawing.Image)(resources.GetObject("eventLookupBtn.Image")));
            this.eventLookupBtn.Location = new System.Drawing.Point(766, 201);
            this.eventLookupBtn.Margin = new System.Windows.Forms.Padding(4);
            this.eventLookupBtn.Name = "eventLookupBtn";
            this.eventLookupBtn.Size = new System.Drawing.Size(112, 38);
            this.eventLookupBtn.TabIndex = 1;
            this.eventLookupBtn.Text = "Browse";
            this.eventLookupBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.eventLookupBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.eventLookupBtn.UseVisualStyleBackColor = true;
            this.eventLookupBtn.Click += new System.EventHandler(this.eventLookupBtn_Click);
            // 
            // providerFilePath
            // 
            this.providerFilePath.BackColor = System.Drawing.SystemColors.Info;
            this.providerFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.providerFilePath.Location = new System.Drawing.Point(14, 126);
            this.providerFilePath.Margin = new System.Windows.Forms.Padding(4);
            this.providerFilePath.Name = "providerFilePath";
            this.providerFilePath.Size = new System.Drawing.Size(744, 37);
            this.providerFilePath.TabIndex = 2;
            // 
            // eventFilePath
            // 
            this.eventFilePath.BackColor = System.Drawing.SystemColors.Info;
            this.eventFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.eventFilePath.Location = new System.Drawing.Point(14, 202);
            this.eventFilePath.Margin = new System.Windows.Forms.Padding(4);
            this.eventFilePath.Name = "eventFilePath";
            this.eventFilePath.Size = new System.Drawing.Size(744, 37);
            this.eventFilePath.TabIndex = 3;
            this.eventFilePath.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(7, 167);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "Baseprotect file:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(7, 91);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 31);
            this.label2.TabIndex = 5;
            this.label2.Text = "Provider file:";
            // 
            // loadBtn
            // 
            this.loadBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.loadBtn.Image = ((System.Drawing.Image)(resources.GetObject("loadBtn.Image")));
            this.loadBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.loadBtn.Location = new System.Drawing.Point(769, 253);
            this.loadBtn.Margin = new System.Windows.Forms.Padding(4);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(111, 45);
            this.loadBtn.TabIndex = 6;
            this.loadBtn.Text = "Join";
            this.loadBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.loadBtn.UseVisualStyleBackColor = true;
            this.loadBtn.Click += new System.EventHandler(this.loadBtn_Click);
            // 
            // worker
            // 
            this.worker.WorkerReportsProgress = true;
            this.worker.WorkerSupportsCancellation = true;
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_DoWork);
            this.worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.worker_ProgressChanged);
            this.worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
            // 
            // joinProgress
            // 
            this.joinProgress.Location = new System.Drawing.Point(13, 268);
            this.joinProgress.Margin = new System.Windows.Forms.Padding(4);
            this.joinProgress.Name = "joinProgress";
            this.joinProgress.Size = new System.Drawing.Size(745, 30);
            this.joinProgress.Step = 1;
            this.joinProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.joinProgress.TabIndex = 7;
            // 
            // providerLookupBtn
            // 
            this.providerLookupBtn.Enabled = false;
            this.providerLookupBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.providerLookupBtn.Image = ((System.Drawing.Image)(resources.GetObject("providerLookupBtn.Image")));
            this.providerLookupBtn.Location = new System.Drawing.Point(766, 125);
            this.providerLookupBtn.Margin = new System.Windows.Forms.Padding(4);
            this.providerLookupBtn.Name = "providerLookupBtn";
            this.providerLookupBtn.Size = new System.Drawing.Size(112, 38);
            this.providerLookupBtn.TabIndex = 8;
            this.providerLookupBtn.Text = "Browse";
            this.providerLookupBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.providerLookupBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.providerLookupBtn.UseVisualStyleBackColor = true;
            this.providerLookupBtn.Click += new System.EventHandler(this.providerLookupBtn_Click);
            // 
            // provider
            // 
            this.provider.BackColor = System.Drawing.SystemColors.Info;
            this.provider.DisplayMember = "Tag";
            this.provider.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.provider.FormattingEnabled = true;
            this.provider.Location = new System.Drawing.Point(14, 43);
            this.provider.Name = "provider";
            this.provider.Size = new System.Drawing.Size(864, 39);
            this.provider.TabIndex = 9;
            this.provider.ValueMember = "Tag";
            this.provider.SelectedIndexChanged += new System.EventHandler(this.provider_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(7, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 31);
            this.label3.TabIndex = 10;
            this.label3.Text = "Provider name:";
            // 
            // NewDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 307);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.provider);
            this.Controls.Add(this.providerLookupBtn);
            this.Controls.Add(this.joinProgress);
            this.Controls.Add(this.loadBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.eventFilePath);
            this.Controls.Add(this.providerFilePath);
            this.Controls.Add(this.eventLookupBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "NewDataForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Import new data";
            this.Load += new System.EventHandler(this.NewDataForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button eventLookupBtn;
        private System.Windows.Forms.TextBox providerFilePath;
        private System.Windows.Forms.TextBox eventFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button loadBtn;
        private System.ComponentModel.BackgroundWorker worker;
        private System.Windows.Forms.ProgressBar joinProgress;
        private System.Windows.Forms.Button providerLookupBtn;
        private System.Windows.Forms.ComboBox provider;
        private System.Windows.Forms.Label label3;
    }
}