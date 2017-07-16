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
using System.Linq;
using System.Text;

namespace CBCEasterSeals
{
    class StatsController //This class controls stat calculation and saving stats to file
    {
        private static bool[] pastLines = new bool[30];
        private static int[] calls = new int[12];
        public static int[] Calls
        {
            get { return calls; }
        }
        private static int[] totalLength = new int[12];     //in seconds
        private static int[] avgCallLength = new int[12];   //in seconds
        private static float[] callsMin = new float[12];
        public static float[] CallsMin
        {
            get { return callsMin; }
        }

        static StatsController()//Initialize all data members
        {
            for(int i = 0; i<=29; i++)
            {
                pastLines[i] = false;
            }
            for (int x = 0; x <= 11; x++)
            {
                    calls[x] = 0;
                    totalLength[x] = 0;
                    avgCallLength[x] = 0;
                    callsMin[x] = 0F;
            }
        }

        public void stats_refresh()
        {
            int h = getHalfHour();
            for (int i = 0; i <= 29; i++)
            {
                if (Program.MasterPhones[i] == true) //Phone in use
                {
                    totalLength[h]++;   //Increment this half hour call length counter
                    totalLength[11]++;  //Increment total call length counter

                    if (pastLines[i] == false)   //Phone was just picked up
                    {
                        calls[h]++;     //Increment this half hour call counter
                        calls[11]++;    //Increment total call counter
                    }
                    pastLines[i] = true;
                }
                else
                {
                    pastLines[i] = false;
                }
            }

            if (calls[11] != 0)
            {
                avgCallLength[11] = Convert.ToInt32(totalLength[11] / calls[11]);   //Calculate average length of call total
                if (calls[h] != 0)
                {
                    avgCallLength[h] = Convert.ToInt32(totalLength[h] / calls[h]);  //Calculate average length of call this half hour
                }
            }

            callsMin[h] = (calls[h] / (float)getMinFromHalfHour());
            callsMin[11] = (calls[11] / (float)getMinFromHalfHour());
        }

        private int getHalfHour() //returns current half hour of show based on system clock
        {
            int hour = Convert.ToInt32(DateTime.Now.ToString("HH"));
            int min = Convert.ToInt32(DateTime.Now.ToString("mm"));

            if (hour == 9)
            {
                return 0;
            }
            else if (hour == 10)
            {
                if(min < 30)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            else if (hour == 11)
            {
                if (min < 30)
                {
                    return 3;
                }
                else
                {
                    return 4;
                }
            }
            else if (hour == 12)
            {
                if (min < 30)
                {
                    return 5;
                }
                else
                {
                    return 6;
                }
            }
            else if (hour == 13)
            {
                if (min < 30)
                {
                    return 7;
                }
                else
                {
                    return 8;
                }
            }
            else if (hour == 14)
            {
                if (min < 30)
                {
                    return 9;
                }
                else
                {
                    return 10;
                }
            }
            return 10;
        }

        private int getMinFromHalfHour() //returns number of minutes since start of last half hour
        {
            int min = Convert.ToInt32(DateTime.Now.ToString("mm"));
            if (min > 30)
            {
                return (min - 29);
            }
            else
            {
                return (min + 1);
            }
        }

        public static void SaveToFile() //writes call stats to text file in program root. If file does not exist it is created. If it does exist info is appended
        {
            System.IO.File.AppendAllText("CallLog.txt", "\t\tCalls/Min\t\tAvg. Call Length\tCalls\n\r");
            System.IO.File.AppendAllText("CallLog.txt", "9:30\t\t" + callsMin[0].ToString("0000.00") + "\t\t" + MinSec(0) + "\t\t\t\t" + calls[0].ToString("0000") + "\n\r");
            System.IO.File.AppendAllText("CallLog.txt", "10:00\t\t" + callsMin[1].ToString("0000.00") + "\t\t" + MinSec(1) + "\t\t\t\t" + calls[1].ToString("0000") + "\n\r");
            System.IO.File.AppendAllText("CallLog.txt", "10:30\t\t" + callsMin[2].ToString("0000.00") + "\t\t" + MinSec(2) + "\t\t\t\t" + calls[2].ToString("0000") + "\n\r");
            System.IO.File.AppendAllText("CallLog.txt", "11:00\t\t" + callsMin[3].ToString("0000.00") + "\t\t" + MinSec(3) + "\t\t\t\t" + calls[3].ToString("0000") + "\n\r");
            System.IO.File.AppendAllText("CallLog.txt", "11:30\t\t" + callsMin[4].ToString("0000.00") + "\t\t" + MinSec(4) + "\t\t\t\t" + calls[4].ToString("0000") + "\n\r");
            System.IO.File.AppendAllText("CallLog.txt", "12:00\t\t" + callsMin[5].ToString("0000.00") + "\t\t" + MinSec(5) + "\t\t\t\t" + calls[5].ToString("0000") + "\n\r");
            System.IO.File.AppendAllText("CallLog.txt", "12:30\t\t" + callsMin[6].ToString("0000.00") + "\t\t" + MinSec(6) + "\t\t\t\t" + calls[6].ToString("0000") + "\n\r");
            System.IO.File.AppendAllText("CallLog.txt", "13:00\t\t" + callsMin[7].ToString("0000.00") + "\t\t" + MinSec(7) + "\t\t\t\t" + calls[7].ToString("0000") + "\n\r");
            System.IO.File.AppendAllText("CallLog.txt", "13:30\t\t" + callsMin[8].ToString("0000.00") + "\t\t" + MinSec(8) + "\t\t\t\t" + calls[8].ToString("0000") + "\n\r");
            System.IO.File.AppendAllText("CallLog.txt", "14:00\t\t" + callsMin[9].ToString("0000.00") + "\t\t" + MinSec(9) + "\t\t\t\t" + calls[9].ToString("0000") + "\n\r");
            System.IO.File.AppendAllText("CallLog.txt", "14:30\t\t" + callsMin[10].ToString("0000.00") + "\t\t" + MinSec(10) + "\t\t\t\t" + calls[10].ToString("0000") + "\n\r");
            System.IO.File.AppendAllText("CallLog.txt", "Totals\t" + callsMin[11].ToString("0000.00") + "\t\t" + MinSec(11) + "\t\t\t\t" + calls[11].ToString("000000") + "\n\r");
        }

        public static string MinSec(int TimeSlot) //returns string of minutes and seconds for given time slot
        {
            return (avgCallLength[TimeSlot] / 60).ToString("00") + ":" + (avgCallLength[TimeSlot] - ((Convert.ToInt32(avgCallLength[TimeSlot] / 60) * 60))).ToString("00");
        }
    }
}