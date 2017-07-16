/*
 * Title: CBC Easter Seals Telethon Telephone Monitoring System
 * Author: Willem Hinzmann (whinzmann@gmail.com)
 * Copyright notice:
 * All code contained in this project was written by Willem Hinzmann unless otherwise specified below.
 * The author retains sole ownership of this code and grants licence for its use and modification only
 * for academic or charitable work. No commercial use of this code (compiled or un-compiled) is
 * authorized unless explicitly granted by the author. This code is provided as-is and the author
 * assumes no liability or risk for its functioning. Any and all liability and risk rests with the end
 * user(s).
 * 
 * All logos are property of their respective owners. LabJack driver is property of LabJack Corporation.
 * C# and Visual Studio are property of Microsoft Corporation. Code contained in files with the
 * extension “.Designer.cs” was generated using Visual Studio’s designer interface.
 * 
 * The images “on.png” and “off.png” were created and are owned by Sarah Shestowsky
 * (sarah.shestowsky@gmail.com). Their use is authorized only for the CBC Easter Seals Telethon.
 * 
 * The author acknowledges Ken Wong’s work as an initial reference for writing the LabJackController class.
 * 
 * To the best of the author’s knowledge no additional sources have been omitted.
 * 
 * Any distribution of this code (whole or partial) must be accompanied by this notice.
 */
namespace CBCEasterSeals
{
    partial class MainDisplay
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
            this.Tmr_Refresh = new System.Windows.Forms.Timer(this.components);
            this.MainCanvas = new CBCEasterSeals.Canvas();
            this.SuspendLayout();
            // 
            // Tmr_Refresh
            // 
            this.Tmr_Refresh.Enabled = true;
            this.Tmr_Refresh.Interval = 1000;
            this.Tmr_Refresh.Tick += new System.EventHandler(this.Tmr_Refresh_Tick);
            // 
            // MainCanvas
            // 
            this.MainCanvas.Location = new System.Drawing.Point(0, 0);
            this.MainCanvas.Name = "MainCanvas";
            this.MainCanvas.Size = new System.Drawing.Size(1920, 1080);
            this.MainCanvas.TabIndex = 0;
            this.MainCanvas.Click += new System.EventHandler(this.MainCanvas_Click);
            // 
            // MainDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.MainCanvas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainDisplay";
            this.Text = "Easter Seals Display";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainDisplay_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private Canvas MainCanvas;
        private System.Windows.Forms.Timer Tmr_Refresh;
    }
}

