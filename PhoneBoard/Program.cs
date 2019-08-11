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
/* March 31,  2016
 * Ilya made the display a windows form instead of a drawing being refreshed once per second.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PhoneBoard
{
    // needed for showing the Console
    internal static class NativeMethods
    {
        [DllImport("kernel32.dll")]
        internal static extern Boolean AllocConsole();
    }

    static class Program
    {
        [STAThread]
        static void Main()
        {
            string[] args = Environment.GetCommandLineArgs();
            
            if (args.Length <= 1) // when executing using a shortcut
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new NICSelection());
            }
            else // adding arguments means we are summarizing a previous log
            {
                NativeMethods.AllocConsole();

                try
                {
                    switch (args.Length)
                    {
                        case 2:
                            LogSummary.Summarize(args[1]);
                            break;
                        case 3:
                            if (int.TryParse(args[2], out int result))
                            {
                                LogSummary.Summarize(args[1], result);
                            }
                            else
                            {
                                throw new Exception("interval must be a number.\n");
                            }
                            break;
                        default:
                            throw new Exception("Too many command line arhuments");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Something went wrong during log summary process: " + ex.Message);
                    Console.WriteLine("Usage:\nCBCEasterSeals.exe LogFileName [intervalNumber]");
                    Console.ReadLine();
                }
            }
        }
    }
}
