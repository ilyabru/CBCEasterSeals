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
    partial class ControlForm
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnNextImg = new System.Windows.Forms.Button();
            this.btnPrevImg = new System.Windows.Forms.Button();
            this.btnSetImg = new System.Windows.Forms.Button();
            this.btnSetDefaultImg = new System.Windows.Forms.Button();
            this.btnReloadImgs = new System.Windows.Forms.Button();
            this.lblCurrSponsor = new System.Windows.Forms.Label();
            this.lblSponserBrowse = new System.Windows.Forms.Label();
            this.btnSH = new System.Windows.Forms.Button();
            this.pbCurrSponsor = new System.Windows.Forms.PictureBox();
            this.pbSponsor = new System.Windows.Forms.PictureBox();
            this.lbl930 = new System.Windows.Forms.Label();
            this.lbl1400 = new System.Windows.Forms.Label();
            this.lbl1430 = new System.Windows.Forms.Label();
            this.lbl1300 = new System.Windows.Forms.Label();
            this.lbl1230 = new System.Windows.Forms.Label();
            this.lbl1130 = new System.Windows.Forms.Label();
            this.lbl1100 = new System.Windows.Forms.Label();
            this.lbl1030 = new System.Windows.Forms.Label();
            this.lbl1000 = new System.Windows.Forms.Label();
            this.lbl1330 = new System.Windows.Forms.Label();
            this.lbl1200 = new System.Windows.Forms.Label();
            this.lblCallMin = new System.Windows.Forms.Label();
            this.lblAvg = new System.Windows.Forms.Label();
            this.lblCalls = new System.Windows.Forms.Label();
            this.txt1430C = new System.Windows.Forms.TextBox();
            this.txt1000C = new System.Windows.Forms.TextBox();
            this.txt1100C = new System.Windows.Forms.TextBox();
            this.txt1230C = new System.Windows.Forms.TextBox();
            this.txt1300C = new System.Windows.Forms.TextBox();
            this.txt1400C = new System.Windows.Forms.TextBox();
            this.txtTotalC = new System.Windows.Forms.TextBox();
            this.txt1030C = new System.Windows.Forms.TextBox();
            this.txt1130C = new System.Windows.Forms.TextBox();
            this.txt930C = new System.Windows.Forms.TextBox();
            this.txt1200C = new System.Windows.Forms.TextBox();
            this.txt1330C = new System.Windows.Forms.TextBox();
            this.txt1330CM = new System.Windows.Forms.TextBox();
            this.txt1200CM = new System.Windows.Forms.TextBox();
            this.txt930CM = new System.Windows.Forms.TextBox();
            this.txt1130CM = new System.Windows.Forms.TextBox();
            this.txt1030CM = new System.Windows.Forms.TextBox();
            this.txtTotalCM = new System.Windows.Forms.TextBox();
            this.txt1400CM = new System.Windows.Forms.TextBox();
            this.txt1300CM = new System.Windows.Forms.TextBox();
            this.txt1230CM = new System.Windows.Forms.TextBox();
            this.txt1100CM = new System.Windows.Forms.TextBox();
            this.txt1000CM = new System.Windows.Forms.TextBox();
            this.txt1430CM = new System.Windows.Forms.TextBox();
            this.txt1330ACL = new System.Windows.Forms.TextBox();
            this.txt1200ACL = new System.Windows.Forms.TextBox();
            this.txt930ACL = new System.Windows.Forms.TextBox();
            this.txt1130ACL = new System.Windows.Forms.TextBox();
            this.txt1030ACL = new System.Windows.Forms.TextBox();
            this.txtTotalACL = new System.Windows.Forms.TextBox();
            this.txt1400ACL = new System.Windows.Forms.TextBox();
            this.txt1300ACL = new System.Windows.Forms.TextBox();
            this.txt1230ACL = new System.Windows.Forms.TextBox();
            this.txt1100ACL = new System.Windows.Forms.TextBox();
            this.txt1000ACL = new System.Windows.Forms.TextBox();
            this.txt1430ACL = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.radMACMethod = new System.Windows.Forms.RadioButton();
            this.radIPMethod = new System.Windows.Forms.RadioButton();
            this.grpMethodSelect = new System.Windows.Forms.GroupBox();
            this.btnHangUpAll = new System.Windows.Forms.Button();
            this.btnPickUpAll = new System.Windows.Forms.Button();
            this.lblHangUpAll = new System.Windows.Forms.Label();
            this.lblPickUpAll = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbCurrSponsor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSponsor)).BeginInit();
            this.grpMethodSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(808, 381);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 35);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnNextImg
            // 
            this.btnNextImg.Enabled = false;
            this.btnNextImg.Location = new System.Drawing.Point(558, 381);
            this.btnNextImg.Margin = new System.Windows.Forms.Padding(4);
            this.btnNextImg.Name = "btnNextImg";
            this.btnNextImg.Size = new System.Drawing.Size(100, 35);
            this.btnNextImg.TabIndex = 2;
            this.btnNextImg.Text = ">>";
            this.btnNextImg.UseVisualStyleBackColor = true;
            this.btnNextImg.Click += new System.EventHandler(this.btnNextImg_Click);
            // 
            // btnPrevImg
            // 
            this.btnPrevImg.Enabled = false;
            this.btnPrevImg.Location = new System.Drawing.Point(15, 381);
            this.btnPrevImg.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrevImg.Name = "btnPrevImg";
            this.btnPrevImg.Size = new System.Drawing.Size(100, 35);
            this.btnPrevImg.TabIndex = 3;
            this.btnPrevImg.Text = "<<";
            this.btnPrevImg.UseVisualStyleBackColor = true;
            this.btnPrevImg.Click += new System.EventHandler(this.btnPrevImg_Click);
            // 
            // btnSetImg
            // 
            this.btnSetImg.Enabled = false;
            this.btnSetImg.Location = new System.Drawing.Point(123, 381);
            this.btnSetImg.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetImg.Name = "btnSetImg";
            this.btnSetImg.Size = new System.Drawing.Size(116, 35);
            this.btnSetImg.TabIndex = 4;
            this.btnSetImg.Text = "Set Sponsor";
            this.btnSetImg.UseVisualStyleBackColor = true;
            this.btnSetImg.Click += new System.EventHandler(this.btnSetImg_Click);
            // 
            // btnSetDefaultImg
            // 
            this.btnSetDefaultImg.Location = new System.Drawing.Point(383, 381);
            this.btnSetDefaultImg.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetDefaultImg.Name = "btnSetDefaultImg";
            this.btnSetDefaultImg.Size = new System.Drawing.Size(167, 35);
            this.btnSetDefaultImg.TabIndex = 5;
            this.btnSetDefaultImg.Text = "Use Easter Seals Logo";
            this.btnSetDefaultImg.UseVisualStyleBackColor = true;
            this.btnSetDefaultImg.Click += new System.EventHandler(this.btnSetDefaultImg_Click);
            // 
            // btnReloadImgs
            // 
            this.btnReloadImgs.Location = new System.Drawing.Point(247, 381);
            this.btnReloadImgs.Margin = new System.Windows.Forms.Padding(4);
            this.btnReloadImgs.Name = "btnReloadImgs";
            this.btnReloadImgs.Size = new System.Drawing.Size(128, 35);
            this.btnReloadImgs.TabIndex = 7;
            this.btnReloadImgs.Text = "Reload Images\r\nupdate address.txt";
            this.btnReloadImgs.UseVisualStyleBackColor = true;
            this.btnReloadImgs.Click += new System.EventHandler(this.btnReloadImgs_Click);
            // 
            // lblCurrSponsor
            // 
            this.lblCurrSponsor.AutoSize = true;
            this.lblCurrSponsor.Location = new System.Drawing.Point(666, 138);
            this.lblCurrSponsor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrSponsor.Name = "lblCurrSponsor";
            this.lblCurrSponsor.Size = new System.Drawing.Size(86, 13);
            this.lblCurrSponsor.TabIndex = 9;
            this.lblCurrSponsor.Text = "Current Sponsor:";
            // 
            // lblSponserBrowse
            // 
            this.lblSponserBrowse.AutoSize = true;
            this.lblSponserBrowse.Location = new System.Drawing.Point(15, 87);
            this.lblSponserBrowse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSponserBrowse.Name = "lblSponserBrowse";
            this.lblSponserBrowse.Size = new System.Drawing.Size(90, 13);
            this.lblSponserBrowse.TabIndex = 10;
            this.lblSponserBrowse.Text = "Sponsor Browser:";
            // 
            // btnSH
            // 
            this.btnSH.Location = new System.Drawing.Point(666, 381);
            this.btnSH.Margin = new System.Windows.Forms.Padding(4);
            this.btnSH.Name = "btnSH";
            this.btnSH.Size = new System.Drawing.Size(135, 35);
            this.btnSH.TabIndex = 11;
            this.btnSH.Text = "Hide Sponsor";
            this.btnSH.UseVisualStyleBackColor = true;
            this.btnSH.Click += new System.EventHandler(this.btnSH_Click);
            // 
            // pbCurrSponsor
            // 
            this.pbCurrSponsor.ErrorImage = global::CBCEasterSeals.Properties.Resources.es_logo;
            this.pbCurrSponsor.Image = global::CBCEasterSeals.Properties.Resources.es_logo;
            this.pbCurrSponsor.InitialImage = global::CBCEasterSeals.Properties.Resources.es_logo;
            this.pbCurrSponsor.Location = new System.Drawing.Point(666, 157);
            this.pbCurrSponsor.Margin = new System.Windows.Forms.Padding(4);
            this.pbCurrSponsor.Name = "pbCurrSponsor";
            this.pbCurrSponsor.Size = new System.Drawing.Size(243, 97);
            this.pbCurrSponsor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCurrSponsor.TabIndex = 8;
            this.pbCurrSponsor.TabStop = false;
            // 
            // pbSponsor
            // 
            this.pbSponsor.ErrorImage = global::CBCEasterSeals.Properties.Resources.es_logo;
            this.pbSponsor.Image = global::CBCEasterSeals.Properties.Resources.es_logo;
            this.pbSponsor.InitialImage = global::CBCEasterSeals.Properties.Resources.es_logo;
            this.pbSponsor.Location = new System.Drawing.Point(15, 106);
            this.pbSponsor.Margin = new System.Windows.Forms.Padding(4);
            this.pbSponsor.Name = "pbSponsor";
            this.pbSponsor.Size = new System.Drawing.Size(643, 267);
            this.pbSponsor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSponsor.TabIndex = 6;
            this.pbSponsor.TabStop = false;
            // 
            // lbl930
            // 
            this.lbl930.AutoSize = true;
            this.lbl930.Location = new System.Drawing.Point(153, 425);
            this.lbl930.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl930.Name = "lbl930";
            this.lbl930.Size = new System.Drawing.Size(28, 13);
            this.lbl930.TabIndex = 13;
            this.lbl930.Text = "9:30";
            // 
            // lbl1400
            // 
            this.lbl1400.AutoSize = true;
            this.lbl1400.Location = new System.Drawing.Point(704, 426);
            this.lbl1400.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl1400.Name = "lbl1400";
            this.lbl1400.Size = new System.Drawing.Size(34, 13);
            this.lbl1400.TabIndex = 14;
            this.lbl1400.Text = "14:00";
            // 
            // lbl1430
            // 
            this.lbl1430.AutoSize = true;
            this.lbl1430.Location = new System.Drawing.Point(766, 426);
            this.lbl1430.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl1430.Name = "lbl1430";
            this.lbl1430.Size = new System.Drawing.Size(34, 13);
            this.lbl1430.TabIndex = 15;
            this.lbl1430.Text = "14:30";
            // 
            // lbl1300
            // 
            this.lbl1300.AutoSize = true;
            this.lbl1300.Location = new System.Drawing.Point(582, 426);
            this.lbl1300.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl1300.Name = "lbl1300";
            this.lbl1300.Size = new System.Drawing.Size(34, 13);
            this.lbl1300.TabIndex = 16;
            this.lbl1300.Text = "13:00";
            // 
            // lbl1230
            // 
            this.lbl1230.AutoSize = true;
            this.lbl1230.Location = new System.Drawing.Point(520, 426);
            this.lbl1230.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl1230.Name = "lbl1230";
            this.lbl1230.Size = new System.Drawing.Size(34, 13);
            this.lbl1230.TabIndex = 17;
            this.lbl1230.Text = "12:30";
            // 
            // lbl1130
            // 
            this.lbl1130.AutoSize = true;
            this.lbl1130.Location = new System.Drawing.Point(398, 426);
            this.lbl1130.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl1130.Name = "lbl1130";
            this.lbl1130.Size = new System.Drawing.Size(34, 13);
            this.lbl1130.TabIndex = 18;
            this.lbl1130.Text = "11:30";
            // 
            // lbl1100
            // 
            this.lbl1100.AutoSize = true;
            this.lbl1100.Location = new System.Drawing.Point(336, 426);
            this.lbl1100.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl1100.Name = "lbl1100";
            this.lbl1100.Size = new System.Drawing.Size(34, 13);
            this.lbl1100.TabIndex = 19;
            this.lbl1100.Text = "11:00";
            // 
            // lbl1030
            // 
            this.lbl1030.AutoSize = true;
            this.lbl1030.Location = new System.Drawing.Point(275, 426);
            this.lbl1030.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl1030.Name = "lbl1030";
            this.lbl1030.Size = new System.Drawing.Size(34, 13);
            this.lbl1030.TabIndex = 20;
            this.lbl1030.Text = "10:30";
            // 
            // lbl1000
            // 
            this.lbl1000.AutoSize = true;
            this.lbl1000.Location = new System.Drawing.Point(214, 426);
            this.lbl1000.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl1000.Name = "lbl1000";
            this.lbl1000.Size = new System.Drawing.Size(34, 13);
            this.lbl1000.TabIndex = 21;
            this.lbl1000.Text = "10:00";
            // 
            // lbl1330
            // 
            this.lbl1330.AutoSize = true;
            this.lbl1330.Location = new System.Drawing.Point(643, 426);
            this.lbl1330.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl1330.Name = "lbl1330";
            this.lbl1330.Size = new System.Drawing.Size(34, 13);
            this.lbl1330.TabIndex = 22;
            this.lbl1330.Text = "13:30";
            // 
            // lbl1200
            // 
            this.lbl1200.AutoSize = true;
            this.lbl1200.Location = new System.Drawing.Point(459, 426);
            this.lbl1200.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl1200.Name = "lbl1200";
            this.lbl1200.Size = new System.Drawing.Size(34, 13);
            this.lbl1200.TabIndex = 23;
            this.lbl1200.Text = "12:00";
            // 
            // lblCallMin
            // 
            this.lblCallMin.AutoSize = true;
            this.lblCallMin.Location = new System.Drawing.Point(97, 481);
            this.lblCallMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCallMin.Name = "lblCallMin";
            this.lblCallMin.Size = new System.Drawing.Size(51, 13);
            this.lblCallMin.TabIndex = 24;
            this.lblCallMin.Text = "Calls/Min";
            // 
            // lblAvg
            // 
            this.lblAvg.AutoSize = true;
            this.lblAvg.Location = new System.Drawing.Point(63, 513);
            this.lblAvg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAvg.Name = "lblAvg";
            this.lblAvg.Size = new System.Drawing.Size(85, 13);
            this.lblAvg.TabIndex = 25;
            this.lblAvg.Text = "Avg. Call Length";
            // 
            // lblCalls
            // 
            this.lblCalls.AutoSize = true;
            this.lblCalls.Location = new System.Drawing.Point(119, 449);
            this.lblCalls.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCalls.Name = "lblCalls";
            this.lblCalls.Size = new System.Drawing.Size(29, 13);
            this.lblCalls.TabIndex = 26;
            this.lblCalls.Text = "Calls";
            // 
            // txt1430C
            // 
            this.txt1430C.Location = new System.Drawing.Point(770, 446);
            this.txt1430C.Margin = new System.Windows.Forms.Padding(4);
            this.txt1430C.Name = "txt1430C";
            this.txt1430C.ReadOnly = true;
            this.txt1430C.Size = new System.Drawing.Size(59, 20);
            this.txt1430C.TabIndex = 27;
            // 
            // txt1000C
            // 
            this.txt1000C.Location = new System.Drawing.Point(218, 446);
            this.txt1000C.Margin = new System.Windows.Forms.Padding(4);
            this.txt1000C.Name = "txt1000C";
            this.txt1000C.ReadOnly = true;
            this.txt1000C.Size = new System.Drawing.Size(59, 20);
            this.txt1000C.TabIndex = 28;
            // 
            // txt1100C
            // 
            this.txt1100C.Location = new System.Drawing.Point(340, 446);
            this.txt1100C.Margin = new System.Windows.Forms.Padding(4);
            this.txt1100C.Name = "txt1100C";
            this.txt1100C.ReadOnly = true;
            this.txt1100C.Size = new System.Drawing.Size(59, 20);
            this.txt1100C.TabIndex = 29;
            // 
            // txt1230C
            // 
            this.txt1230C.Location = new System.Drawing.Point(524, 446);
            this.txt1230C.Margin = new System.Windows.Forms.Padding(4);
            this.txt1230C.Name = "txt1230C";
            this.txt1230C.ReadOnly = true;
            this.txt1230C.Size = new System.Drawing.Size(59, 20);
            this.txt1230C.TabIndex = 30;
            // 
            // txt1300C
            // 
            this.txt1300C.Location = new System.Drawing.Point(586, 446);
            this.txt1300C.Margin = new System.Windows.Forms.Padding(4);
            this.txt1300C.Name = "txt1300C";
            this.txt1300C.ReadOnly = true;
            this.txt1300C.Size = new System.Drawing.Size(59, 20);
            this.txt1300C.TabIndex = 31;
            // 
            // txt1400C
            // 
            this.txt1400C.Location = new System.Drawing.Point(708, 446);
            this.txt1400C.Margin = new System.Windows.Forms.Padding(4);
            this.txt1400C.Name = "txt1400C";
            this.txt1400C.ReadOnly = true;
            this.txt1400C.Size = new System.Drawing.Size(59, 20);
            this.txt1400C.TabIndex = 32;
            // 
            // txtTotalC
            // 
            this.txtTotalC.Location = new System.Drawing.Point(831, 446);
            this.txtTotalC.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalC.Name = "txtTotalC";
            this.txtTotalC.ReadOnly = true;
            this.txtTotalC.Size = new System.Drawing.Size(59, 20);
            this.txtTotalC.TabIndex = 33;
            // 
            // txt1030C
            // 
            this.txt1030C.Location = new System.Drawing.Point(279, 446);
            this.txt1030C.Margin = new System.Windows.Forms.Padding(4);
            this.txt1030C.Name = "txt1030C";
            this.txt1030C.ReadOnly = true;
            this.txt1030C.Size = new System.Drawing.Size(59, 20);
            this.txt1030C.TabIndex = 34;
            // 
            // txt1130C
            // 
            this.txt1130C.Location = new System.Drawing.Point(402, 446);
            this.txt1130C.Margin = new System.Windows.Forms.Padding(4);
            this.txt1130C.Name = "txt1130C";
            this.txt1130C.ReadOnly = true;
            this.txt1130C.Size = new System.Drawing.Size(59, 20);
            this.txt1130C.TabIndex = 35;
            // 
            // txt930C
            // 
            this.txt930C.Location = new System.Drawing.Point(154, 446);
            this.txt930C.Margin = new System.Windows.Forms.Padding(4);
            this.txt930C.Name = "txt930C";
            this.txt930C.ReadOnly = true;
            this.txt930C.Size = new System.Drawing.Size(60, 20);
            this.txt930C.TabIndex = 36;
            // 
            // txt1200C
            // 
            this.txt1200C.Location = new System.Drawing.Point(463, 446);
            this.txt1200C.Margin = new System.Windows.Forms.Padding(4);
            this.txt1200C.Name = "txt1200C";
            this.txt1200C.ReadOnly = true;
            this.txt1200C.Size = new System.Drawing.Size(59, 20);
            this.txt1200C.TabIndex = 37;
            // 
            // txt1330C
            // 
            this.txt1330C.Location = new System.Drawing.Point(647, 446);
            this.txt1330C.Margin = new System.Windows.Forms.Padding(4);
            this.txt1330C.Name = "txt1330C";
            this.txt1330C.ReadOnly = true;
            this.txt1330C.Size = new System.Drawing.Size(59, 20);
            this.txt1330C.TabIndex = 38;
            // 
            // txt1330CM
            // 
            this.txt1330CM.Location = new System.Drawing.Point(647, 478);
            this.txt1330CM.Margin = new System.Windows.Forms.Padding(4);
            this.txt1330CM.Name = "txt1330CM";
            this.txt1330CM.ReadOnly = true;
            this.txt1330CM.Size = new System.Drawing.Size(59, 20);
            this.txt1330CM.TabIndex = 50;
            // 
            // txt1200CM
            // 
            this.txt1200CM.Location = new System.Drawing.Point(463, 478);
            this.txt1200CM.Margin = new System.Windows.Forms.Padding(4);
            this.txt1200CM.Name = "txt1200CM";
            this.txt1200CM.ReadOnly = true;
            this.txt1200CM.Size = new System.Drawing.Size(59, 20);
            this.txt1200CM.TabIndex = 49;
            // 
            // txt930CM
            // 
            this.txt930CM.Location = new System.Drawing.Point(156, 478);
            this.txt930CM.Margin = new System.Windows.Forms.Padding(4);
            this.txt930CM.Name = "txt930CM";
            this.txt930CM.ReadOnly = true;
            this.txt930CM.Size = new System.Drawing.Size(59, 20);
            this.txt930CM.TabIndex = 48;
            // 
            // txt1130CM
            // 
            this.txt1130CM.Location = new System.Drawing.Point(402, 478);
            this.txt1130CM.Margin = new System.Windows.Forms.Padding(4);
            this.txt1130CM.Name = "txt1130CM";
            this.txt1130CM.ReadOnly = true;
            this.txt1130CM.Size = new System.Drawing.Size(59, 20);
            this.txt1130CM.TabIndex = 47;
            // 
            // txt1030CM
            // 
            this.txt1030CM.Location = new System.Drawing.Point(279, 478);
            this.txt1030CM.Margin = new System.Windows.Forms.Padding(4);
            this.txt1030CM.Name = "txt1030CM";
            this.txt1030CM.ReadOnly = true;
            this.txt1030CM.Size = new System.Drawing.Size(59, 20);
            this.txt1030CM.TabIndex = 46;
            // 
            // txtTotalCM
            // 
            this.txtTotalCM.Location = new System.Drawing.Point(831, 478);
            this.txtTotalCM.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalCM.Name = "txtTotalCM";
            this.txtTotalCM.ReadOnly = true;
            this.txtTotalCM.Size = new System.Drawing.Size(59, 20);
            this.txtTotalCM.TabIndex = 45;
            // 
            // txt1400CM
            // 
            this.txt1400CM.Location = new System.Drawing.Point(708, 478);
            this.txt1400CM.Margin = new System.Windows.Forms.Padding(4);
            this.txt1400CM.Name = "txt1400CM";
            this.txt1400CM.ReadOnly = true;
            this.txt1400CM.Size = new System.Drawing.Size(59, 20);
            this.txt1400CM.TabIndex = 44;
            // 
            // txt1300CM
            // 
            this.txt1300CM.Location = new System.Drawing.Point(586, 478);
            this.txt1300CM.Margin = new System.Windows.Forms.Padding(4);
            this.txt1300CM.Name = "txt1300CM";
            this.txt1300CM.ReadOnly = true;
            this.txt1300CM.Size = new System.Drawing.Size(59, 20);
            this.txt1300CM.TabIndex = 43;
            // 
            // txt1230CM
            // 
            this.txt1230CM.Location = new System.Drawing.Point(524, 478);
            this.txt1230CM.Margin = new System.Windows.Forms.Padding(4);
            this.txt1230CM.Name = "txt1230CM";
            this.txt1230CM.ReadOnly = true;
            this.txt1230CM.Size = new System.Drawing.Size(59, 20);
            this.txt1230CM.TabIndex = 42;
            // 
            // txt1100CM
            // 
            this.txt1100CM.Location = new System.Drawing.Point(340, 478);
            this.txt1100CM.Margin = new System.Windows.Forms.Padding(4);
            this.txt1100CM.Name = "txt1100CM";
            this.txt1100CM.ReadOnly = true;
            this.txt1100CM.Size = new System.Drawing.Size(59, 20);
            this.txt1100CM.TabIndex = 41;
            // 
            // txt1000CM
            // 
            this.txt1000CM.Location = new System.Drawing.Point(218, 478);
            this.txt1000CM.Margin = new System.Windows.Forms.Padding(4);
            this.txt1000CM.Name = "txt1000CM";
            this.txt1000CM.ReadOnly = true;
            this.txt1000CM.Size = new System.Drawing.Size(59, 20);
            this.txt1000CM.TabIndex = 40;
            // 
            // txt1430CM
            // 
            this.txt1430CM.Location = new System.Drawing.Point(770, 478);
            this.txt1430CM.Margin = new System.Windows.Forms.Padding(4);
            this.txt1430CM.Name = "txt1430CM";
            this.txt1430CM.ReadOnly = true;
            this.txt1430CM.Size = new System.Drawing.Size(59, 20);
            this.txt1430CM.TabIndex = 39;
            // 
            // txt1330ACL
            // 
            this.txt1330ACL.Location = new System.Drawing.Point(647, 510);
            this.txt1330ACL.Margin = new System.Windows.Forms.Padding(4);
            this.txt1330ACL.Name = "txt1330ACL";
            this.txt1330ACL.ReadOnly = true;
            this.txt1330ACL.Size = new System.Drawing.Size(59, 20);
            this.txt1330ACL.TabIndex = 62;
            // 
            // txt1200ACL
            // 
            this.txt1200ACL.Location = new System.Drawing.Point(463, 510);
            this.txt1200ACL.Margin = new System.Windows.Forms.Padding(4);
            this.txt1200ACL.Name = "txt1200ACL";
            this.txt1200ACL.ReadOnly = true;
            this.txt1200ACL.Size = new System.Drawing.Size(59, 20);
            this.txt1200ACL.TabIndex = 61;
            // 
            // txt930ACL
            // 
            this.txt930ACL.Location = new System.Drawing.Point(156, 510);
            this.txt930ACL.Margin = new System.Windows.Forms.Padding(4);
            this.txt930ACL.Name = "txt930ACL";
            this.txt930ACL.ReadOnly = true;
            this.txt930ACL.Size = new System.Drawing.Size(59, 20);
            this.txt930ACL.TabIndex = 60;
            // 
            // txt1130ACL
            // 
            this.txt1130ACL.Location = new System.Drawing.Point(402, 510);
            this.txt1130ACL.Margin = new System.Windows.Forms.Padding(4);
            this.txt1130ACL.Name = "txt1130ACL";
            this.txt1130ACL.ReadOnly = true;
            this.txt1130ACL.Size = new System.Drawing.Size(59, 20);
            this.txt1130ACL.TabIndex = 59;
            // 
            // txt1030ACL
            // 
            this.txt1030ACL.Location = new System.Drawing.Point(279, 510);
            this.txt1030ACL.Margin = new System.Windows.Forms.Padding(4);
            this.txt1030ACL.Name = "txt1030ACL";
            this.txt1030ACL.ReadOnly = true;
            this.txt1030ACL.Size = new System.Drawing.Size(59, 20);
            this.txt1030ACL.TabIndex = 58;
            // 
            // txtTotalACL
            // 
            this.txtTotalACL.Location = new System.Drawing.Point(831, 510);
            this.txtTotalACL.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalACL.Name = "txtTotalACL";
            this.txtTotalACL.ReadOnly = true;
            this.txtTotalACL.Size = new System.Drawing.Size(59, 20);
            this.txtTotalACL.TabIndex = 57;
            // 
            // txt1400ACL
            // 
            this.txt1400ACL.Location = new System.Drawing.Point(708, 510);
            this.txt1400ACL.Margin = new System.Windows.Forms.Padding(4);
            this.txt1400ACL.Name = "txt1400ACL";
            this.txt1400ACL.ReadOnly = true;
            this.txt1400ACL.Size = new System.Drawing.Size(59, 20);
            this.txt1400ACL.TabIndex = 56;
            // 
            // txt1300ACL
            // 
            this.txt1300ACL.Location = new System.Drawing.Point(586, 510);
            this.txt1300ACL.Margin = new System.Windows.Forms.Padding(4);
            this.txt1300ACL.Name = "txt1300ACL";
            this.txt1300ACL.ReadOnly = true;
            this.txt1300ACL.Size = new System.Drawing.Size(59, 20);
            this.txt1300ACL.TabIndex = 55;
            // 
            // txt1230ACL
            // 
            this.txt1230ACL.Location = new System.Drawing.Point(524, 510);
            this.txt1230ACL.Margin = new System.Windows.Forms.Padding(4);
            this.txt1230ACL.Name = "txt1230ACL";
            this.txt1230ACL.ReadOnly = true;
            this.txt1230ACL.Size = new System.Drawing.Size(59, 20);
            this.txt1230ACL.TabIndex = 54;
            // 
            // txt1100ACL
            // 
            this.txt1100ACL.Location = new System.Drawing.Point(340, 510);
            this.txt1100ACL.Margin = new System.Windows.Forms.Padding(4);
            this.txt1100ACL.Name = "txt1100ACL";
            this.txt1100ACL.ReadOnly = true;
            this.txt1100ACL.Size = new System.Drawing.Size(59, 20);
            this.txt1100ACL.TabIndex = 53;
            // 
            // txt1000ACL
            // 
            this.txt1000ACL.Location = new System.Drawing.Point(218, 510);
            this.txt1000ACL.Margin = new System.Windows.Forms.Padding(4);
            this.txt1000ACL.Name = "txt1000ACL";
            this.txt1000ACL.ReadOnly = true;
            this.txt1000ACL.Size = new System.Drawing.Size(59, 20);
            this.txt1000ACL.TabIndex = 52;
            // 
            // txt1430ACL
            // 
            this.txt1430ACL.Location = new System.Drawing.Point(770, 510);
            this.txt1430ACL.Margin = new System.Windows.Forms.Padding(4);
            this.txt1430ACL.Name = "txt1430ACL";
            this.txt1430ACL.ReadOnly = true;
            this.txt1430ACL.Size = new System.Drawing.Size(59, 20);
            this.txt1430ACL.TabIndex = 51;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(827, 426);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(31, 13);
            this.lblTotal.TabIndex = 63;
            this.lblTotal.Text = "Total";
            // 
            // radMACMethod
            // 
            this.radMACMethod.AutoSize = true;
            this.radMACMethod.Checked = true;
            this.radMACMethod.Location = new System.Drawing.Point(16, 19);
            this.radMACMethod.Name = "radMACMethod";
            this.radMACMethod.Size = new System.Drawing.Size(89, 17);
            this.radMACMethod.TabIndex = 64;
            this.radMACMethod.TabStop = true;
            this.radMACMethod.Text = "MAC Address";
            this.radMACMethod.UseVisualStyleBackColor = true;
            this.radMACMethod.CheckedChanged += new System.EventHandler(this.radMACMethod_CheckedChanged);
            // 
            // radIPMethod
            // 
            this.radIPMethod.AutoSize = true;
            this.radIPMethod.Location = new System.Drawing.Point(132, 19);
            this.radIPMethod.Name = "radIPMethod";
            this.radIPMethod.Size = new System.Drawing.Size(76, 17);
            this.radIPMethod.TabIndex = 65;
            this.radIPMethod.Text = "IP Address";
            this.radIPMethod.UseVisualStyleBackColor = true;
            this.radIPMethod.CheckedChanged += new System.EventHandler(this.radIPMethod_CheckedChanged);
            // 
            // grpMethodSelect
            // 
            this.grpMethodSelect.Controls.Add(this.radMACMethod);
            this.grpMethodSelect.Controls.Add(this.radIPMethod);
            this.grpMethodSelect.Location = new System.Drawing.Point(665, 329);
            this.grpMethodSelect.Name = "grpMethodSelect";
            this.grpMethodSelect.Size = new System.Drawing.Size(235, 44);
            this.grpMethodSelect.TabIndex = 66;
            this.grpMethodSelect.TabStop = false;
            this.grpMethodSelect.Text = "Phone Identfication Method";
            // 
            // btnHangUpAll
            // 
            this.btnHangUpAll.Location = new System.Drawing.Point(15, 25);
            this.btnHangUpAll.Name = "btnHangUpAll";
            this.btnHangUpAll.Size = new System.Drawing.Size(46, 20);
            this.btnHangUpAll.TabIndex = 67;
            this.btnHangUpAll.Text = "ON";
            this.btnHangUpAll.UseVisualStyleBackColor = true;
            this.btnHangUpAll.Click += new System.EventHandler(this.btnHangUpAll_Click);
            // 
            // btnPickUpAll
            // 
            this.btnPickUpAll.Location = new System.Drawing.Point(67, 25);
            this.btnPickUpAll.Name = "btnPickUpAll";
            this.btnPickUpAll.Size = new System.Drawing.Size(46, 20);
            this.btnPickUpAll.TabIndex = 68;
            this.btnPickUpAll.Text = "OFF";
            this.btnPickUpAll.UseVisualStyleBackColor = true;
            this.btnPickUpAll.Click += new System.EventHandler(this.btnPickUpAll_Click);
            // 
            // lblHangUpAll
            // 
            this.lblHangUpAll.AutoSize = true;
            this.lblHangUpAll.Location = new System.Drawing.Point(15, 50);
            this.lblHangUpAll.Name = "lblHangUpAll";
            this.lblHangUpAll.Size = new System.Drawing.Size(128, 13);
            this.lblHangUpAll.TabIndex = 69;
            this.lblHangUpAll.Text = "ON - Hang Up All Phones";
            // 
            // lblPickUpAll
            // 
            this.lblPickUpAll.AutoSize = true;
            this.lblPickUpAll.Location = new System.Drawing.Point(159, 50);
            this.lblPickUpAll.Name = "lblPickUpAll";
            this.lblPickUpAll.Size = new System.Drawing.Size(127, 13);
            this.lblPickUpAll.TabIndex = 70;
            this.lblPickUpAll.Text = "OFF - Pick Up All Phones";
            // 
            // ControlForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(916, 421);
            this.Controls.Add(this.lblPickUpAll);
            this.Controls.Add(this.lblHangUpAll);
            this.Controls.Add(this.btnPickUpAll);
            this.Controls.Add(this.btnHangUpAll);
            this.Controls.Add(this.grpMethodSelect);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.txt1330ACL);
            this.Controls.Add(this.txt1200ACL);
            this.Controls.Add(this.txt930ACL);
            this.Controls.Add(this.txt1130ACL);
            this.Controls.Add(this.txt1030ACL);
            this.Controls.Add(this.txtTotalACL);
            this.Controls.Add(this.txt1400ACL);
            this.Controls.Add(this.txt1300ACL);
            this.Controls.Add(this.txt1230ACL);
            this.Controls.Add(this.txt1100ACL);
            this.Controls.Add(this.txt1000ACL);
            this.Controls.Add(this.txt1430ACL);
            this.Controls.Add(this.txt1330CM);
            this.Controls.Add(this.txt1200CM);
            this.Controls.Add(this.txt930CM);
            this.Controls.Add(this.txt1130CM);
            this.Controls.Add(this.txt1030CM);
            this.Controls.Add(this.txtTotalCM);
            this.Controls.Add(this.txt1400CM);
            this.Controls.Add(this.txt1300CM);
            this.Controls.Add(this.txt1230CM);
            this.Controls.Add(this.txt1100CM);
            this.Controls.Add(this.txt1000CM);
            this.Controls.Add(this.txt1430CM);
            this.Controls.Add(this.txt1330C);
            this.Controls.Add(this.txt1200C);
            this.Controls.Add(this.txt930C);
            this.Controls.Add(this.txt1130C);
            this.Controls.Add(this.txt1030C);
            this.Controls.Add(this.txtTotalC);
            this.Controls.Add(this.txt1400C);
            this.Controls.Add(this.txt1300C);
            this.Controls.Add(this.txt1230C);
            this.Controls.Add(this.txt1100C);
            this.Controls.Add(this.txt1000C);
            this.Controls.Add(this.txt1430C);
            this.Controls.Add(this.lblCalls);
            this.Controls.Add(this.lblAvg);
            this.Controls.Add(this.lblCallMin);
            this.Controls.Add(this.lbl1200);
            this.Controls.Add(this.lbl1330);
            this.Controls.Add(this.lbl1000);
            this.Controls.Add(this.lbl1030);
            this.Controls.Add(this.lbl1100);
            this.Controls.Add(this.lbl1130);
            this.Controls.Add(this.lbl1230);
            this.Controls.Add(this.lbl1300);
            this.Controls.Add(this.lbl1430);
            this.Controls.Add(this.lbl1400);
            this.Controls.Add(this.lbl930);
            this.Controls.Add(this.btnSH);
            this.Controls.Add(this.lblSponserBrowse);
            this.Controls.Add(this.lblCurrSponsor);
            this.Controls.Add(this.pbCurrSponsor);
            this.Controls.Add(this.btnReloadImgs);
            this.Controls.Add(this.pbSponsor);
            this.Controls.Add(this.btnSetDefaultImg);
            this.Controls.Add(this.btnSetImg);
            this.Controls.Add(this.btnPrevImg);
            this.Controls.Add(this.btnNextImg);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "ControlForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Easter Seals Controller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ControlForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pbCurrSponsor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSponsor)).EndInit();
            this.grpMethodSelect.ResumeLayout(false);
            this.grpMethodSelect.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnNextImg;
        private System.Windows.Forms.Button btnPrevImg;
        private System.Windows.Forms.Button btnSetImg;
        private System.Windows.Forms.Button btnSetDefaultImg;
        private System.Windows.Forms.PictureBox pbSponsor;
        private System.Windows.Forms.Button btnReloadImgs;
        private System.Windows.Forms.PictureBox pbCurrSponsor;
        private System.Windows.Forms.Label lblCurrSponsor;
        private System.Windows.Forms.Label lblSponserBrowse;
        //private Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer;
        //private Microsoft.VisualBasic.PowerPacks.RectangleShape[] ControlGrid;
        private System.Windows.Forms.Button btnSH;
        private System.Windows.Forms.Label lbl930;
        private System.Windows.Forms.Label lbl1400;
        private System.Windows.Forms.Label lbl1430;
        private System.Windows.Forms.Label lbl1300;
        private System.Windows.Forms.Label lbl1230;
        private System.Windows.Forms.Label lbl1130;
        private System.Windows.Forms.Label lbl1100;
        private System.Windows.Forms.Label lbl1030;
        private System.Windows.Forms.Label lbl1000;
        private System.Windows.Forms.Label lbl1330;
        private System.Windows.Forms.Label lbl1200;
        private System.Windows.Forms.Label lblCallMin;
        private System.Windows.Forms.Label lblAvg;
        private System.Windows.Forms.Label lblCalls;
        private System.Windows.Forms.TextBox txt1430C;
        private System.Windows.Forms.TextBox txt1000C;
        private System.Windows.Forms.TextBox txt1100C;
        private System.Windows.Forms.TextBox txt1230C;
        private System.Windows.Forms.TextBox txt1300C;
        private System.Windows.Forms.TextBox txt1400C;
        private System.Windows.Forms.TextBox txtTotalC;
        private System.Windows.Forms.TextBox txt1030C;
        private System.Windows.Forms.TextBox txt1130C;
        private System.Windows.Forms.TextBox txt930C;
        private System.Windows.Forms.TextBox txt1200C;
        private System.Windows.Forms.TextBox txt1330C;
        private System.Windows.Forms.TextBox txt1330CM;
        private System.Windows.Forms.TextBox txt1200CM;
        private System.Windows.Forms.TextBox txt930CM;
        private System.Windows.Forms.TextBox txt1130CM;
        private System.Windows.Forms.TextBox txt1030CM;
        private System.Windows.Forms.TextBox txtTotalCM;
        private System.Windows.Forms.TextBox txt1400CM;
        private System.Windows.Forms.TextBox txt1300CM;
        private System.Windows.Forms.TextBox txt1230CM;
        private System.Windows.Forms.TextBox txt1100CM;
        private System.Windows.Forms.TextBox txt1000CM;
        private System.Windows.Forms.TextBox txt1430CM;
        private System.Windows.Forms.TextBox txt1330ACL;
        private System.Windows.Forms.TextBox txt1200ACL;
        private System.Windows.Forms.TextBox txt930ACL;
        private System.Windows.Forms.TextBox txt1130ACL;
        private System.Windows.Forms.TextBox txt1030ACL;
        private System.Windows.Forms.TextBox txtTotalACL;
        private System.Windows.Forms.TextBox txt1400ACL;
        private System.Windows.Forms.TextBox txt1300ACL;
        private System.Windows.Forms.TextBox txt1230ACL;
        private System.Windows.Forms.TextBox txt1100ACL;
        private System.Windows.Forms.TextBox txt1000ACL;
        private System.Windows.Forms.TextBox txt1430ACL;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label[] lblGrid;
        private System.Windows.Forms.RadioButton radMACMethod;
        private System.Windows.Forms.RadioButton radIPMethod;
        private System.Windows.Forms.GroupBox grpMethodSelect;
        private System.Windows.Forms.Button btnHangUpAll;
        private System.Windows.Forms.Button btnPickUpAll;
        private System.Windows.Forms.Label lblHangUpAll;
        private System.Windows.Forms.Label lblPickUpAll;
    }
}