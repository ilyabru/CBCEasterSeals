using SharpPcap;
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
    public partial class Display : Form
    {
        private  SIPController SIPC;

        public int TOTALPHONES = 30;
        private int idlePhones = 30;
        List<PictureBox> phones = new List<PictureBox>();      
        private int tmr_cnt = 0;

        public List<PictureBox> Phones
        {
            get { return phones; }
            set { phones = value; }
        }

        public int IdlePhones
        {
            get { return idlePhones; }
            set
            {
                idlePhones = value;
                if (idlePhones == 0)
                {
                    timerCelebrate.Enabled = true;
                }
                lblAvailableNum.Text = idlePhones.ToString();
            }
        }

        public Display(SIPController SIPC)
        {
            InitializeComponent();

            this.SIPC = SIPC;

            TOTALPHONES = SIPC.allPhones.Count;
            IdlePhones = TOTALPHONES;

            // Event listener
            SIPC.CallStartStop += new SIPController.CallStartStopEventHandler(SIPC_CallStartStop);

            // Coordinates for Phone icons
            Point[] phonePoints =
            {
                new Point(890, 634),   //line 1
                new Point(280, 634),
                new Point(1500, 634),
                new Point(1430, 294),
                new Point(210, 294),
                new Point(1030, 634),
                new Point(1030, 464),
                new Point(750, 464),
                new Point(750, 634),
                new Point(1170, 464),
            
                new Point(1240, 294), //line 11
                new Point(1570, 294),
                new Point(1710, 294),
                new Point(1100, 294),
                new Point(680, 294),
                new Point(960, 294),
                new Point(610, 464),
                new Point(890, 464),
                new Point(1430, 464),
                new Point(140, 634),
            
                new Point(70, 294),   //line 21
                new Point(1640, 634),
                new Point(1710, 464),
                new Point(70, 464),
                new Point(210, 464),
                new Point(350, 464),
                new Point(540, 294),
                new Point(1570, 464),
                new Point(820, 294),
                new Point(350, 294)
            };

            // Paint phones
            for (int i = 0; i < TOTALPHONES; i++)
            {
                PictureBox newPhone = new PictureBox();

                newPhone.BackColor = System.Drawing.Color.Transparent;
                newPhone.Image = SIPC.allPhones[i].Image;
                newPhone.Location = phonePoints[i];
                newPhone.Name = "phone" + (i + 1);
                newPhone.Size = new System.Drawing.Size(140, 140);
                newPhone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                newPhone.TabIndex = 2;
                newPhone.TabStop = false;

                phones.Add(newPhone);
                this.Controls.Add(newPhone);
            }

            // Center Celebrate text
            lblCelebrateThanks.Hide();
            lblCelebrateCalling.Hide();
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
                        phones[e.Queue].Image = SIPC.allPhones[e.Queue].Image;
                        IdlePhones++;
                        break;
                    case PhoneState.Dialog:
                        phones[e.Queue].Image = SIPC.allPhones[e.Queue].Image;
                        IdlePhones--;
                        break;
                }
            }
        }

        private void timerCelebrate_Tick(object sender, EventArgs e)
        {
            if(tmr_cnt == 0)
            {
                foreach (PictureBox phone in phones)
                {
                    phone.Hide();
                }
                lblAvailableText.Hide();
                lblAvailableNum.Hide();
                lblCelebrateThanks.Show();
            }
            else
            {
                // Alternate celebration text
                if (lblCelebrateThanks.Visible == true)
                {
                    lblCelebrateThanks.Hide();
                    lblCelebrateCalling.Show();
                }
                else
                {
                    lblCelebrateThanks.Show();
                    lblCelebrateCalling.Hide();
                }
            }
            tmr_cnt++;
                  
            // ensure celebration screen lasts 5 seconds         
            if (tmr_cnt >= 5 && IdlePhones != 0)
            {
                tmr_cnt = 0;
                foreach (PictureBox phone in phones)
                {
                    phone.Show();
                }
                lblAvailableText.Show();
                lblAvailableNum.Show();
                lblCelebrateThanks.Hide();
                lblCelebrateCalling.Hide();

                timerCelebrate.Enabled = false;
            }
            else if (tmr_cnt >= 5 && IdlePhones == 0)
            {
                tmr_cnt = 1;
            }
        }
    }
}
