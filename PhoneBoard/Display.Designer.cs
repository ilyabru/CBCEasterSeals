using System.Windows.Forms;

namespace PhoneBoard
{
    partial class Display
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
            this.logo = new System.Windows.Forms.PictureBox();
            this.sponsor = new System.Windows.Forms.PictureBox();
            this.lblAvailableText = new System.Windows.Forms.Label();
            this.lblAvailableNum = new System.Windows.Forms.Label();
            this.lblCelebrateThanks = new System.Windows.Forms.Label();
            this.timerCelebrate = new System.Windows.Forms.Timer(this.components);
            this.lblCelebrateCalling = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sponsor)).BeginInit();
            this.SuspendLayout();
            // 
            // logo
            // 
            this.logo.BackColor = System.Drawing.Color.Transparent;
            this.logo.Image = global::PhoneBoard.Properties.Resources.telethon_logo;
            this.logo.Location = new System.Drawing.Point(220, 40);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(482, 217);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logo.TabIndex = 0;
            this.logo.TabStop = false;
            // 
            // sponsor
            // 
            this.sponsor.BackColor = System.Drawing.Color.Transparent;
            this.sponsor.Image = global::PhoneBoard.Properties.Resources.es_logo;
            this.sponsor.Location = new System.Drawing.Point(1218, 40);
            this.sponsor.Name = "sponsor";
            this.sponsor.Size = new System.Drawing.Size(482, 217);
            this.sponsor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.sponsor.TabIndex = 1;
            this.sponsor.TabStop = false;
            // 
            // lblAvailableText
            // 
            this.lblAvailableText.BackColor = System.Drawing.Color.Transparent;
            this.lblAvailableText.Font = new System.Drawing.Font("Trebuchet MS", 23F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableText.ForeColor = System.Drawing.Color.Yellow;
            this.lblAvailableText.Location = new System.Drawing.Point(823, 814);
            this.lblAvailableText.Name = "lblAvailableText";
            this.lblAvailableText.Size = new System.Drawing.Size(328, 48);
            this.lblAvailableText.TabIndex = 2;
            this.lblAvailableText.Text = "Phones Available";
            this.lblAvailableText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAvailableNum
            // 
            this.lblAvailableNum.BackColor = System.Drawing.Color.Transparent;
            this.lblAvailableNum.Font = new System.Drawing.Font("Trebuchet MS", 120F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableNum.ForeColor = System.Drawing.Color.Yellow;
            this.lblAvailableNum.Location = new System.Drawing.Point(821, 840);
            this.lblAvailableNum.Name = "lblAvailableNum";
            this.lblAvailableNum.Size = new System.Drawing.Size(339, 250);
            this.lblAvailableNum.TabIndex = 3;
            this.lblAvailableNum.Text = "30";
            this.lblAvailableNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCelebrateThanks
            // 
            this.lblCelebrateThanks.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCelebrateThanks.BackColor = System.Drawing.Color.Transparent;
            this.lblCelebrateThanks.Font = new System.Drawing.Font("Trebuchet MS", 120F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCelebrateThanks.ForeColor = System.Drawing.Color.Yellow;
            this.lblCelebrateThanks.Location = new System.Drawing.Point(400, 470);
            this.lblCelebrateThanks.Name = "lblCelebrateThanks";
            this.lblCelebrateThanks.Size = new System.Drawing.Size(1146, 250);
            this.lblCelebrateThanks.TabIndex = 4;
            this.lblCelebrateThanks.Text = "Thank You!";
            this.lblCelebrateThanks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerCelebrate
            // 
            this.timerCelebrate.Interval = 1000;
            this.timerCelebrate.Tick += new System.EventHandler(this.timerCelebrate_Tick);
            // 
            // lblCelebrateCalling
            // 
            this.lblCelebrateCalling.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCelebrateCalling.BackColor = System.Drawing.Color.Transparent;
            this.lblCelebrateCalling.Font = new System.Drawing.Font("Trebuchet MS", 120F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCelebrateCalling.ForeColor = System.Drawing.Color.Yellow;
            this.lblCelebrateCalling.Location = new System.Drawing.Point(330, 470);
            this.lblCelebrateCalling.Name = "lblCelebrateCalling";
            this.lblCelebrateCalling.Size = new System.Drawing.Size(1333, 250);
            this.lblCelebrateCalling.TabIndex = 5;
            this.lblCelebrateCalling.Text = "Keep Calling!";
            this.lblCelebrateCalling.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Display
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.BackgroundImage = global::PhoneBoard.Properties.Resources.bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.lblAvailableText);
            this.Controls.Add(this.lblCelebrateCalling);
            this.Controls.Add(this.lblCelebrateThanks);
            this.Controls.Add(this.lblAvailableNum);
            this.Controls.Add(this.sponsor);
            this.Controls.Add(this.logo);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Display";
            this.Text = "Display";
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sponsor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.PictureBox sponsor;
        private System.Windows.Forms.Label lblAvailableText;
        private System.Windows.Forms.Label lblAvailableNum;
        private System.Windows.Forms.Label lblCelebrateThanks;
        private System.Windows.Forms.Timer timerCelebrate;
        private System.Windows.Forms.Label lblCelebrateCalling;

        public PictureBox Sponsor
        {
            get
            {
                return sponsor;
            }

            set
            {
                sponsor = value;
            }
        }
    }
}