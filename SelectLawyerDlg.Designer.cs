namespace baseprotect
{
    partial class SelectLawyerDlg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectLawyerDlg));
            this.lawyerSelector = new System.Windows.Forms.ComboBox();
            this.OKBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lawyerSelector
            // 
            this.lawyerSelector.BackColor = System.Drawing.SystemColors.Info;
            this.lawyerSelector.DisplayMember = "Text";
            this.lawyerSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lawyerSelector.FormattingEnabled = true;
            this.lawyerSelector.Location = new System.Drawing.Point(13, 12);
            this.lawyerSelector.Name = "lawyerSelector";
            this.lawyerSelector.Size = new System.Drawing.Size(520, 33);
            this.lawyerSelector.TabIndex = 0;
            this.lawyerSelector.SelectedIndexChanged += new System.EventHandler(this.lawyerSelector_SelectedIndexChanged);
            // 
            // OKBtn
            // 
            this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKBtn.Location = new System.Drawing.Point(435, 51);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(98, 34);
            this.OKBtn.TabIndex = 1;
            this.OKBtn.Text = "OK";
            this.OKBtn.UseVisualStyleBackColor = true;
            // 
            // SelectLawyerDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 93);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(this.lawyerSelector);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SelectLawyerDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select lawyer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox lawyerSelector;
        private System.Windows.Forms.Button OKBtn;
    }
}