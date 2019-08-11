namespace PhoneBoard
{
    partial class NICSelection
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
            this.lstNICSelector = new System.Windows.Forms.ListBox();
            this.lblNICSelector = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstNICSelector
            // 
            this.lstNICSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstNICSelector.FormattingEnabled = true;
            this.lstNICSelector.HorizontalScrollbar = true;
            this.lstNICSelector.Location = new System.Drawing.Point(12, 33);
            this.lstNICSelector.Name = "lstNICSelector";
            this.lstNICSelector.Size = new System.Drawing.Size(630, 160);
            this.lstNICSelector.TabIndex = 0;
            this.lstNICSelector.SelectedIndexChanged += new System.EventHandler(this.lstNICSelector_SelectedIndexChanged);
            this.lstNICSelector.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstNICSelector_KeyDown);
            // 
            // lblNICSelector
            // 
            this.lblNICSelector.AutoSize = true;
            this.lblNICSelector.Location = new System.Drawing.Point(12, 9);
            this.lblNICSelector.Name = "lblNICSelector";
            this.lblNICSelector.Size = new System.Drawing.Size(135, 13);
            this.lblNICSelector.TabIndex = 1;
            this.lblNICSelector.Text = "Please select a NIC to use:";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.Location = new System.Drawing.Point(567, 199);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "OK";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(12, 199);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // NICSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 230);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lblNICSelector);
            this.Controls.Add(this.lstNICSelector);
            this.MaximizeBox = false;
            this.Name = "NICSelection";
            this.Text = "Easter Seals Telethon VoIP Call Tracker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstNICSelector;
        private System.Windows.Forms.Label lblNICSelector;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
    }
}