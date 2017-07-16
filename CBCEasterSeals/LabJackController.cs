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
using LabJack.LabJackUD;
using System.Windows.Forms;
using System.Threading;

namespace CBCEasterSeals
{
    class LabJackController //This class controls interface to labjack
    {
        U3 u3 = new U3(); //Labjack object

        bool[] phonestatus1 = new bool[30]; //These arrays store the phone status.
        bool[] phonestatus2 = new bool[30];

        public LabJackController() //Constructor initializes labjack object on a USB connection. This will throw an exception and close the program if no labjack is detected.
        {
            try
            {
                u3 = new U3(LJUD.CONNECTION.USB, "0", true);
                u3.u3Config();
            }
            catch
            {
                MessageBox.Show("LabJack error. Cannot connect to LabJack. Please check connections.");
                Environment.Exit(-1);
            }
        }

        public void LJRefresh()
        {
            int i = 0;
            GetStatus(phonestatus1);    //phone lines are checked twice with a delay between them. This prevents status errors when line is ringing (line oscillates)
            Thread.Sleep(30);
            GetStatus(phonestatus2);

            for (i = 0; i <= 29; i++)
            {
                Program.MasterPhones[i] = phonestatus1[i] & phonestatus2[i]; //elements of master phone array are only set to true if given line tested true both times.
            }
        }
    
        private void GetStatus(bool[] phone)
        {
            int i = 0;  //line index
            int d = 0;  //decoder index
            int m = 0;  //multiplexor index
            int temp = 0;

            for (d = 1; d <= 4; d++)
            {
                BoardSelect(d); //sets decoder to correct board
                for (m = 1; m <= 8; m++)
                {
                    if (i <= 29) //limits lines checked to 30 (29 + 1)
                    {
                        LineSelect(m); //sets multiplexor to correct line on current board
                        LJUD.eDI(u3.ljhandle, 15, ref temp);    //reads line status for current line into "temp"
                        phone[i] = Convert.ToBoolean(temp); //Temp is an int (1 or 0) so it is converted to a bool and stored in phone array
                    }
                    i++;
                }
            }
        }

        private void BoardSelect(int i) // set current board (1-8)
        {
            switch (i)
            {
                case 1:
                    LJUD.eDO(u3.ljhandle, 8, 0);
                    LJUD.eDO(u3.ljhandle, 9, 0);
                    LJUD.eDO(u3.ljhandle, 10, 0);
                    break;
                case 2:
                    LJUD.eDO(u3.ljhandle, 8, 1);
                    LJUD.eDO(u3.ljhandle, 9, 0);
                    LJUD.eDO(u3.ljhandle, 10, 0);
                    break;
                case 3:
                    LJUD.eDO(u3.ljhandle, 8, 0);
                    LJUD.eDO(u3.ljhandle, 9, 1);
                    LJUD.eDO(u3.ljhandle, 10, 0);
                    break;
                case 4:
                    LJUD.eDO(u3.ljhandle, 8, 1);
                    LJUD.eDO(u3.ljhandle, 9, 1);
                    LJUD.eDO(u3.ljhandle, 10, 0);
                    break;
                case 5:
                    LJUD.eDO(u3.ljhandle, 8, 0);
                    LJUD.eDO(u3.ljhandle, 9, 0);
                    LJUD.eDO(u3.ljhandle, 10, 1);
                    break;
                case 6:
                    LJUD.eDO(u3.ljhandle, 8, 1);
                    LJUD.eDO(u3.ljhandle, 9, 0);
                    LJUD.eDO(u3.ljhandle, 10, 1);
                    break;
                case 7:
                    LJUD.eDO(u3.ljhandle, 8, 0);
                    LJUD.eDO(u3.ljhandle, 9, 1);
                    LJUD.eDO(u3.ljhandle, 10, 1);
                    break;
                case 8:
                    LJUD.eDO(u3.ljhandle, 8, 1);
                    LJUD.eDO(u3.ljhandle, 9, 1);
                    LJUD.eDO(u3.ljhandle, 10, 1);
                    break;
            }
        }

        private void LineSelect(int i) // set current line (1-8)
        {
            switch (i)
            {
                case 1:
                    LJUD.eDO(u3.ljhandle, 11, 0);
                    LJUD.eDO(u3.ljhandle, 12, 0);
                    LJUD.eDO(u3.ljhandle, 13, 0);
                    break;
                case 2:
                    LJUD.eDO(u3.ljhandle, 11, 1);
                    LJUD.eDO(u3.ljhandle, 12, 0);
                    LJUD.eDO(u3.ljhandle, 13, 0);
                    break;
                case 3:
                    LJUD.eDO(u3.ljhandle, 11, 0);
                    LJUD.eDO(u3.ljhandle, 12, 1);
                    LJUD.eDO(u3.ljhandle, 13, 0);
                    break;
                case 4:
                    LJUD.eDO(u3.ljhandle, 11, 1);
                    LJUD.eDO(u3.ljhandle, 12, 1);
                    LJUD.eDO(u3.ljhandle, 13, 0);
                    break;
                case 5:
                    LJUD.eDO(u3.ljhandle, 11, 0);
                    LJUD.eDO(u3.ljhandle, 12, 0);
                    LJUD.eDO(u3.ljhandle, 13, 1);
                    break;
                case 6:
                    LJUD.eDO(u3.ljhandle, 11, 1);
                    LJUD.eDO(u3.ljhandle, 12, 0);
                    LJUD.eDO(u3.ljhandle, 13, 1);
                    break;
                case 7:
                    LJUD.eDO(u3.ljhandle, 11, 0);
                    LJUD.eDO(u3.ljhandle, 12, 1);
                    LJUD.eDO(u3.ljhandle, 13, 1);
                    break;
                case 8:
                    LJUD.eDO(u3.ljhandle, 11, 1);
                    LJUD.eDO(u3.ljhandle, 12, 1);
                    LJUD.eDO(u3.ljhandle, 13, 1);
                    break;
            }
        }
    }
}
