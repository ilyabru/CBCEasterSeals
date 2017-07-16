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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CBCEasterSeals
{
    class Canvas : Panel //this class controls the onscreen graphics
    {
        protected static bool CelebrateEnable = false;

        //Image handles
        protected static readonly Image img_on = global::CBCEasterSeals.Properties.Resources.on;
        protected static readonly Image img_off = global::CBCEasterSeals.Properties.Resources.off;
        protected static readonly Image img_bg = global::CBCEasterSeals.Properties.Resources.bg;
        protected static readonly Image img_logo = global::CBCEasterSeals.Properties.Resources.telethon_logo;
        protected static Image img_ad = global::CBCEasterSeals.Properties.Resources.es_logo;

        static public Image sponsor
        {
            get { return img_ad; }
            set { img_ad = value; }
        }

        protected static bool showsposor = true;
        public static bool showSponsor
        {
            set { showsposor = value; }
        }

        protected static BufferedGraphics CanvasBuffer; //Graphics are drawn on buffer before the buffer is rendered to the screen. This prevents tearing and flickering
        protected static int lines_remaining = 30;

        //Rectangles for each drawing area
        protected static readonly Rectangle rec_logo = new Rectangle(220, 40, 482, 217);
        protected static readonly Rectangle rec_ad_space = new Rectangle(1218, 40, 482, 217);
        protected static readonly Rectangle rec_background = new Rectangle(0, 0, 1920, 1080);
        protected static readonly Rectangle rec_remaining = new Rectangle(1608, 29, 280, 140);
        protected static readonly Rectangle[] rec_lines =
        {
            new Rectangle(890,634, 140, 140),   //line 1
            new Rectangle(280, 634, 140, 140),
            new Rectangle(1500, 634, 140, 140),
            new Rectangle(1430, 294, 140, 140),
            new Rectangle(210, 294, 140, 140),
            new Rectangle(1030, 634, 140, 140),
            new Rectangle(1030, 464, 140, 140),
            new Rectangle(750, 464, 140, 140),
            new Rectangle(750, 634, 140, 140),
            new Rectangle(1170, 464, 140, 140),

            new Rectangle(1240, 294, 140, 140), //line 11
            new Rectangle(1570, 294, 140, 140),
            new Rectangle(1710, 294, 140, 140),
            new Rectangle(1100, 294, 140, 140),
            new Rectangle(680, 294, 140, 140),
            new Rectangle(960, 294, 140, 140),
            new Rectangle(610, 464, 140, 140),
            new Rectangle(890, 464, 140, 140),
            new Rectangle(1430, 464, 140, 140),
            new Rectangle(140, 634, 140, 140),

            new Rectangle(70, 294, 140, 140),   //line 21
            new Rectangle(1640, 634, 140, 140),
            new Rectangle(1710, 464, 140, 140),
            new Rectangle(70, 464, 140, 140),
            new Rectangle(210, 464, 140, 140),
            new Rectangle(350, 464, 140, 140),
            new Rectangle(540, 294, 140, 140),
            new Rectangle(1570, 464, 140, 140),
            new Rectangle(820, 294, 140, 140),
            new Rectangle(350, 294, 140, 140)
        };

        // properties for drawing text
        protected static readonly System.Drawing.Brush Colour = new SolidBrush(System.Drawing.Color.Yellow);

        protected static readonly System.Drawing.Font RemainNumFont = new System.Drawing.Font("Trebuchet MS", 120F, System.Drawing.FontStyle.Bold);
        protected static readonly System.Drawing.Point RemainNumLocation = new System.Drawing.Point(845, 866);

        protected static readonly System.Drawing.Font RemainFont = new System.Drawing.Font("Trebuchet MS", 23F, System.Drawing.FontStyle.Bold);
        protected static readonly System.Drawing.Point RemainLocation = new System.Drawing.Point(848, 831);

        protected static readonly System.Drawing.Point ThanksLocation = new System.Drawing.Point(400, 470);
        protected static readonly System.Drawing.Point CallingLocation = new System.Drawing.Point(330, 470);

        protected static int tmr_cnt = 0;
        protected static bool celebrate_flash = true;

        protected override void OnPaintBackground(PaintEventArgs e) { } //disables OnPaintBackground

        protected override void OnPaint(PaintEventArgs e)
        {
            if (CelebrateEnable == true)    //Ensures celebration text lasts at least 5 refresh cycles (5 sec)
            {
                tmr_cnt++;
                if (tmr_cnt >= 5)
                {
                    tmr_cnt = 0;
                    CelebrateEnable = false;
                }
            }

            if (celebrate_flash == true)    //alternates each true/false on refresh
            {
                celebrate_flash = false;
            }
            else
            {
                celebrate_flash = true;
            }

            lines_remaining = 30;
            for (int i = 0; i < 30; i++)    //counts number of remaining phones
            {
                if (Program.MasterPhones[i] == true)
                {
                    lines_remaining--;
                }
            }
            if (lines_remaining <= 0) //if none remain, set celebrate flag
            {
                CelebrateEnable = true;
            }

            CanvasBuffer = BufferedGraphicsManager.Current.Allocate(e.Graphics, this.DisplayRectangle);
            //Configure graphics settings
            CanvasBuffer.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            CanvasBuffer.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            CanvasBuffer.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            CanvasBuffer.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;//for use with text
            
            //Draw in buffer
            CanvasBuffer.Graphics.DrawImage(img_bg, rec_background);
            CanvasBuffer.Graphics.DrawImage(img_logo, rec_logo);

            if (showsposor == true)
            {
                CanvasBuffer.Graphics.DrawImage(img_ad, rec_ad_space);
            }


            if (CelebrateEnable == false)
            {
                //Draw phone array
                for (int i = 0; i < 30; i++)
                {
                    if (Program.MasterPhones[i] == false)
                    {
                        CanvasBuffer.Graphics.DrawImage(img_on, rec_lines[i]);
                    }
                    else
                    {
                        CanvasBuffer.Graphics.DrawImage(img_off, rec_lines[i]);
                    }
                }
                //Draw text
                CanvasBuffer.Graphics.DrawString(String.Format("{0,2}", lines_remaining), RemainNumFont, Colour, RemainNumLocation);
                CanvasBuffer.Graphics.DrawString("Phones Available", RemainFont, Colour, RemainLocation);
            }
            else
            {
                if (celebrate_flash == true)
                {
                    CanvasBuffer.Graphics.DrawString("Thank You!", RemainNumFont, Colour, ThanksLocation);
                }
                else
                {
                    CanvasBuffer.Graphics.DrawString("Keep Calling!", RemainNumFont, Colour, CallingLocation);
                }
            }

            //Render buffer on screen
            CanvasBuffer.Render(e.Graphics);

            //Free memory
            CanvasBuffer.Dispose();
            GC.Collect();
        }
    }
}
