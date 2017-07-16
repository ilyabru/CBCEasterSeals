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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CBCEasterSeals
{
    public partial class MainDisplay : Form //This class contains all other class objects, it contains the main refresh timer used to refresh all classes
    {
        //private static LabJackController LJC = new LabJackController();
        private static StatsController StatsC = new StatsController();
        private static ControlForm ctrlfrm = new ControlForm();

        private static bool ExitFromCmd = false; //prevents double prompting to confirm quit if order was issued from control panel
        public static bool ExitFromCommand
        {
            set { ExitFromCmd = value; }
        }

        public MainDisplay()
        {
            InitializeComponent();
            ctrlfrm.Show();  //show control panel on start up
        }

        private void Tmr_Refresh_Tick(object sender, EventArgs e)   //This timer is used to refresh and sync all child classes
        {
            //LJC.LJRefresh();                              //Refresh LJ readings
            StatsC.stats_refresh();                       //Refresh Statistical Data
            this.MainCanvas.Refresh();                    //Refresh MainDisplay
            ctrlfrm.CtrlRefresh();                        //Refresh Control Form
            ctrlfrm.StatsRefresh();                       //Refresh stats display
        }

        private void MainCanvas_Click(object sender, EventArgs e)   //Clicking on main display shows control panel (and recreates it if it was disposed)
        {
            if(ctrlfrm.IsDisposed == true)
            {
                ctrlfrm = new ControlForm();
            }
            ctrlfrm.Show();
        }

        private void MainDisplay_FormClosing(object sender, FormClosingEventArgs e) //prompt to confirm if user closes form. Stat file saved on close.
        {
            if (ExitFromCmd == false)
            {
                if (MessageBox.Show("Do you really want to quit?\nStat", "Quit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    StatsController.SaveToFile();
                }
            }
            else
            {
                StatsController.SaveToFile();
            }
        }
    }
}
