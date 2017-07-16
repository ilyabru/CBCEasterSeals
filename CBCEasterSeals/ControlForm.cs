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
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace CBCEasterSeals
{
    public partial class ControlForm : Form
    {
        private static readonly string[] ImgTypes = { "*.jpg", "*.jpeg", "*.gif", "*.png" }; //this array contains the file extentions to be searched for
        private static int ImgIndex = 0;
        private static DirectoryInfo ImgDir;
        private static FileInfo[] ImgInfo;
        private static Image[] SponsorImages = { Properties.Resources.es_logo };
        private static Image[] SponsorImagesTmp1;
        private static Image[] SponsorImagesTmp2;
        public Image CmdCurrSponsor
        {
            set { pbCurrSponsor.Image = value;  }
        }

        public ControlForm()
        {
            InitializeComponent();
            InitializeControlGrid();
            LoadImgs();
            pbCurrSponsor.Image = Canvas.Sponsor;
        }

        private void InitializeControlGrid()
        {
            ShapeContainer = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            Controls.Add(ShapeContainer);
            lblGrid = new Label[30];
            for(int i = 0; i <= 29; i++)
            {
                //Labels
                lblGrid[i] = new Label()
                {
                    Location = new Point((15 + (i * 30)), 474),
                    Size = new Size(25, 20),
                    Text = (i + 1).ToString(),
                    BackColor = Color.LightGreen,
                    TextAlign = ContentAlignment.MiddleCenter
                };
            }

            Controls.AddRange(lblGrid);

            ShapeContainer.Location = new Point(0, 0);
            ShapeContainer.Size = ClientSize;
        }

        public void CtrlRefresh() //refreshes line indicators
        {
            for(int i = 0; i <= 29; i++)
            {
                if (Program.MasterPhones[i] == true)
                {
                    lblGrid[i].BackColor = Color.Green;
                }
                else
                {
                    lblGrid[i].BackColor = Color.LightGreen;
                }
            }
            CmdCurrSponsor = Canvas.Sponsor;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you really want to quit?","Quit",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MainDisplay.ExitFromCommand = true;
                Application.Exit();
            }
        }

        private void BtnSetDefaultImg_Click(object sender, EventArgs e)
        {
            Canvas.Sponsor = Properties.Resources.es_logo;
            pbSponsor.Image = Properties.Resources.es_logo;
            ImgIndex = 0;
        }

        private void BtnReloadImgs_Click(object sender, EventArgs e)
        {
            LoadImgs();
        }

        private void BtnSetImg_Click(object sender, EventArgs e)
        {
            try
            {
                Canvas.Sponsor = pbSponsor.Image;
            }
            catch
            {
                Canvas.Sponsor = Properties.Resources.es_logo;
                pbSponsor.Image = Properties.Resources.es_logo;
                LoadImgs();
            }
        }

        private void BtnNextImg_Click(object sender, EventArgs e)
        {
            if (++ImgIndex >= SponsorImages.Length)
            {
                ImgIndex = 0;
            }
            pbSponsor.Image = SponsorImages[ImgIndex];
        }

        private void BtnPrevImg_Click(object sender, EventArgs e)
        {
            if (--ImgIndex < 0)
            {
                ImgIndex = (SponsorImages.Length - 1);
            }
            pbSponsor.Image = SponsorImages[ImgIndex];
        }

        private void LoadImgs()
        {
            try
            {
                ImgDir = new DirectoryInfo("Sponsors//");
                
                //Scans directory above for each file type and adds any found files to image array
                foreach(String CurrFileType in ImgTypes)
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
                    Canvas.Sponsor = Properties.Resources.es_logo;
                    pbSponsor.Image = Properties.Resources.es_logo;
                    btnNextImg.Enabled = false;
                    btnPrevImg.Enabled = false;
                    btnSetImg.Enabled = false;
                }
            }
            catch //disable browsing if image scan causes error
            {
                Canvas.Sponsor = Properties.Resources.es_logo;
                pbSponsor.Image = Properties.Resources.es_logo;
                btnNextImg.Enabled = false;
                btnPrevImg.Enabled = false;
                btnSetImg.Enabled = false;
            }
        }

        private void BtnSH_Click(object sender, EventArgs e) //shows and hides the sponsor's logo
        {
            if (btnSH.Text == "Hide Sponsor")
            {
                btnSH.Text = "Show Sponsor";
                pbCurrSponsor.Visible = false;
                Canvas.ShowSponsor = false;
            }
            else
            {
                btnSH.Text = "Hide Sponsor";
                pbCurrSponsor.Visible = true;
                Canvas.ShowSponsor = true;
            }
        }

        public void StatsRefresh() //refreshes counters from data stored in stats controller
        {
            //Call counters
            txt930C.Text = StatsController.Calls[0].ToString();
            txt1000C.Text = StatsController.Calls[1].ToString();
            txt1030C.Text = StatsController.Calls[2].ToString();
            txt1100C.Text = StatsController.Calls[3].ToString();
            txt1130C.Text = StatsController.Calls[4].ToString();
            txt1200C.Text = StatsController.Calls[5].ToString();
            txt1230C.Text = StatsController.Calls[6].ToString();
            txt1300C.Text = StatsController.Calls[7].ToString();
            txt1330C.Text = StatsController.Calls[8].ToString();
            txt1400C.Text = StatsController.Calls[9].ToString();
            txt1430C.Text = StatsController.Calls[10].ToString();
            txtTotalC.Text = StatsController.Calls[11].ToString();
            //Average call lengths
            txt930ACL.Text = StatsController.MinSec(0);
            txt1000ACL.Text = StatsController.MinSec(1);
            txt1030ACL.Text = StatsController.MinSec(2);
            txt1100ACL.Text = StatsController.MinSec(3);
            txt1130ACL.Text = StatsController.MinSec(4);
            txt1200ACL.Text = StatsController.MinSec(5);
            txt1230ACL.Text = StatsController.MinSec(6);
            txt1300ACL.Text = StatsController.MinSec(7);
            txt1330ACL.Text = StatsController.MinSec(8);
            txt1400ACL.Text = StatsController.MinSec(9);
            txt1430ACL.Text = StatsController.MinSec(10);
            txtTotalACL.Text = StatsController.MinSec(11);
            //Calls/Min
            txt930CM.Text = StatsController.CallsMin[0].ToString("0.0");
            txt1000CM.Text = StatsController.CallsMin[1].ToString("0.0");
            txt1030CM.Text = StatsController.CallsMin[2].ToString("0.0");
            txt1100CM.Text = StatsController.CallsMin[3].ToString("0.0");
            txt1130CM.Text = StatsController.CallsMin[4].ToString("0.0");
            txt1200CM.Text = StatsController.CallsMin[5].ToString("0.0");
            txt1230CM.Text = StatsController.CallsMin[6].ToString("0.0");
            txt1300CM.Text = StatsController.CallsMin[7].ToString("0.0");
            txt1330CM.Text = StatsController.CallsMin[8].ToString("0.0");
            txt1400CM.Text = StatsController.CallsMin[9].ToString("0.0");
            txt1430CM.Text = StatsController.CallsMin[10].ToString("0.0");
            txtTotalCM.Text = StatsController.CallsMin[11].ToString("0.0");
        }


    }
}
