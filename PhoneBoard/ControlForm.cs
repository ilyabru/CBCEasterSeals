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

/* April 07, 2016
 * This code was modified by Lok-Tin Leung and Ilya Brusnitsyn in order to enable
 * the program to monitor VoIP phones using SIP protocol.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SharpPcap;

namespace PhoneBoard
{
    public partial class ControlForm : Form
    {
        private static SIPController SIPC = new SIPController();
        private static Display displayForm;

        private const int INTERVAL = 30;

        List<Phone> allPhones;
        private static readonly string[] ImgTypes = { "*.jpg", "*.jpeg", "*.gif", "*.png" }; //this array contains the file extentions to be searched for
        private static int ImgIndex = 0;
        private static DirectoryInfo ImgDir;
        private static FileInfo[] ImgInfo;
        private static Image[] SponsorImages = { global::PhoneBoard.Properties.Resources.es_logo };
        private static Image[] SponsorImagesTmp1;
        private static Image[] SponsorImagesTmp2;
        public Image CmdCurrSponsor
        {
            set { pbCurrSponsor.Image = value; }
        }

        public ControlForm(ICaptureDevice selectedDevice)
        {
            // create Sponsors folder if not exist
            Directory.CreateDirectory("Sponsors");

            InitializeComponent();

            allPhones = SIPC.allPhones;
            displayForm = new Display(SIPC);
            SIPC.CallStartStop += new SIPController.CallStartStopEventHandler(SIPC_CallStartStop);         
            InitializeControlGrid();
            load_imgs();
            pbCurrSponsor.Image = displayForm.Sponsor.Image;

            // Show main display form 
            displayForm.Show();

            // start packet monitoring
            SIPC.StartCapture(selectedDevice);
        }

        private void InitializeControlGrid()
        {
            this.lblGrid = new System.Windows.Forms.Label[allPhones.Count];
            for (int i = 0; i < allPhones.Count; i++)
            {
                //Labels
                this.lblGrid[i] = new System.Windows.Forms.Label();
                this.lblGrid[i].Location = new System.Drawing.Point((15 + (i * 30)), 0);//old y coords: 474
                this.lblGrid[i].Size = new System.Drawing.Size(25, 20);
                this.lblGrid[i].Text = (i + 1).ToString();
                this.lblGrid[i].BackColor = System.Drawing.Color.LightGreen;
                this.lblGrid[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                lblGrid[i].DoubleClick += lblGrid_DoubleClick;
            }

            this.Controls.AddRange(lblGrid);
        }

        private void lblGrid_DoubleClick(object sender, EventArgs e)
        {
            var l = (Label)sender;
            int pIndex = (Convert.ToInt32(l.Text) - 1);

            if (allPhones[pIndex].State == PhoneState.Idle)
            {
                allPhones[pIndex].State = PhoneState.Dialog;
                allPhones[pIndex].StartTime = DateTime.Now;
                this.lblGrid[pIndex].BackColor = System.Drawing.Color.LightBlue;
                displayForm.Phones[pIndex].Image = SIPC.allPhones[pIndex].Image;
                displayForm.IdlePhones--;
            }
            else
            {
                allPhones[pIndex].State = PhoneState.Idle;
                this.lblGrid[pIndex].BackColor = System.Drawing.Color.LightGreen;
                displayForm.Phones[pIndex].Image = SIPC.allPhones[pIndex].Image;

                displayForm.IdlePhones++;
            }
        }

        private void btnPickUpAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < allPhones.Count; i++)
            {
                this.lblGrid[i].BackColor = System.Drawing.Color.LightBlue;
                allPhones[i].State = PhoneState.Dialog;
                displayForm.Phones[i].Image = SIPC.allPhones[i].Image;
                displayForm.IdlePhones = 0; // Celebrate
            }
        }

        private void btnHangUpAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < allPhones.Count; i++)
            {
                this.lblGrid[i].BackColor = System.Drawing.Color.LightGreen;
                allPhones[i].State = PhoneState.Idle;
                displayForm.Phones[i].Image = SIPC.allPhones[i].Image;
                displayForm.IdlePhones = allPhones.Count;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ControlForm_FormClosing(sender, null);
        }

        private void ControlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you really want to quit?", "Quit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SIPC.StopCapture();
                Environment.Exit(1);
            }
            else if (e != null)
            {
                e.Cancel = true;
            }
        }

        private void btnSetDefaultImg_Click(object sender, EventArgs e)
        {
            //Canvas.sponsor = global::CBCEasterSeals.Properties.Resources.es_logo;
            pbSponsor.Image = global::PhoneBoard.Properties.Resources.es_logo;
            pbCurrSponsor.Image = global::PhoneBoard.Properties.Resources.es_logo;
            displayForm.Sponsor.Image = global::PhoneBoard.Properties.Resources.es_logo;
            ImgIndex = 0;
        }

        private void btnReloadImgs_Click(object sender, EventArgs e)
        {
            load_imgs();
            SIPC.ReadAddressFile(SIPC.AddressFilePath);
        }

        private void btnSetImg_Click(object sender, EventArgs e)
        {
            try
            {
                pbCurrSponsor.Image = pbSponsor.Image;
                displayForm.Sponsor.Image = pbSponsor.Image;
            }
            catch
            {
                displayForm.Sponsor.Image = global::PhoneBoard.Properties.Resources.es_logo;
                pbSponsor.Image = global::PhoneBoard.Properties.Resources.es_logo;
                load_imgs();
            }
        }

        private void btnNextImg_Click(object sender, EventArgs e)
        {
            if (++ImgIndex >= SponsorImages.Length)
            {
                ImgIndex = 0;
            }
            pbSponsor.Image = SponsorImages[ImgIndex];
        }

        private void btnPrevImg_Click(object sender, EventArgs e)
        {
            if (--ImgIndex < 0)
            {
                ImgIndex = (SponsorImages.Length - 1);
            }
            pbSponsor.Image = SponsorImages[ImgIndex];
        }

        private void load_imgs()
        {
            try
            {
                Directory.CreateDirectory("Sponsors");
                ImgDir = new DirectoryInfo("Sponsors//");

                //Scans directory above for each file type and adds any found files to image array
                foreach (String CurrFileType in ImgTypes)
                {
                    ImgIndex = 0;
                    ImgInfo = ImgDir.GetFiles(CurrFileType);
                    SponsorImagesTmp1 = new Image[ImgInfo.Length];
                    foreach (FileInfo CurrImg in ImgInfo)
                    {
                        SponsorImagesTmp1[ImgIndex++] = Image.FromFile(CurrImg.FullName);
                    }

                    SponsorImagesTmp2 = SponsorImages;
                    SponsorImages = new Image[SponsorImagesTmp1.Length + SponsorImagesTmp2.Length];
                    Array.Copy(SponsorImagesTmp2, SponsorImages, SponsorImagesTmp2.Length);
                    Array.Copy(SponsorImagesTmp1, 0, SponsorImages, SponsorImagesTmp2.Length, SponsorImagesTmp1.Length);
                }

                //Clean up memory
                SponsorImagesTmp1 = null;
                SponsorImagesTmp2 = null;
                ImgInfo = null;
                GC.Collect();

                ImgIndex = 0;

                if (SponsorImages.Length > 0)
                {
                    pbSponsor.Image = SponsorImages[0];
                    btnNextImg.Enabled = true;
                    btnPrevImg.Enabled = true;
                    btnSetImg.Enabled = true;
                }
                else
                {
                    displayForm.Sponsor.Image = global::PhoneBoard.Properties.Resources.es_logo;
                    pbSponsor.Image = global::PhoneBoard.Properties.Resources.es_logo;
                    btnNextImg.Enabled = false;
                    btnPrevImg.Enabled = false;
                    btnSetImg.Enabled = false;
                }
            }
            catch //disable browsing if image scan causes error
            {
                displayForm.Sponsor.Image = global::PhoneBoard.Properties.Resources.es_logo;
                pbSponsor.Image = global::PhoneBoard.Properties.Resources.es_logo;
                btnNextImg.Enabled = false;
                btnPrevImg.Enabled = false;
                btnSetImg.Enabled = false;
            }
        }

        private void btnSH_Click(object sender, EventArgs e) //shows and hides the sponsor's logo
        {
            if (btnSH.Text == "Hide Sponsor")
            {
                btnSH.Text = "Show Sponsor";
                pbCurrSponsor.Visible = false;
                displayForm.Sponsor.Hide();
            }
            else
            {
                btnSH.Text = "Hide Sponsor";
                pbCurrSponsor.Visible = true;
                displayForm.Sponsor.Show();
            }
        }

        private void radMACMethod_CheckedChanged(object sender, EventArgs e)
        {
            SIPC.CompareMethod = 0;
        }

        private void radIPMethod_CheckedChanged(object sender, EventArgs e)
        {
            SIPC.CompareMethod = 1;
        }

        private void SIPC_CallStartStop(object sender, SIPController.CallStartStopEventArgs e)
        {
            if (this.InvokeRequired)
            {
                SIPController.CallStartStopEventHandler d = new SIPController.CallStartStopEventHandler(SIPC_CallStartStop);
                this.Invoke(d, new object[] { sender, e });
                return;
            }
            else
            {
                switch (e.PhoneState)
                {
                    case PhoneState.Idle:
                        lblGrid[e.Queue].BackColor = System.Drawing.Color.LightGreen;
                        break;
                    case PhoneState.Dialog:
                        lblGrid[e.Queue].BackColor = System.Drawing.Color.LightBlue;
                        break;
                }
            }
        }
    }
}
