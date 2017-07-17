/* April 07, 2016
 * This code was created by Lok-Tin Leung and Ilya Brusnitsyn in order to enable
 * the program to monitor VoIP phones using SIP protoco
 */
using System;
using System.Windows.Forms;
using SharpPcap;
using System.Collections.Generic;

namespace CBCEasterSeals
{
    public partial class NICSelection : Form
    {
        CaptureDeviceList nicDevicesList = CaptureDeviceList.Instance; /* Retrieve the device list */
        ICaptureDevice device;
        int selectedDevice = 0;

        public NICSelection()
        {
            InitializeComponent();

            /*If no device exists, print error */
            if (nicDevicesList.Count < 1)
                lstNICSelector.Items.Add("No device found on this machine.");

            /* Scan the list printing every entry */
            foreach (var dev in nicDevicesList)
                lstNICSelector.Items.Add(dev.Description);  /* Description */
            lstNICSelector.SelectedIndex = 0;
        }

        private void lstNICSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedDevice = lstNICSelector.SelectedIndex;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (nicDevicesList.Count < 1)
                MessageBox.Show("No device found on this machine.");
            else
            {
                device = nicDevicesList[selectedDevice];  //Ethernet
                //MainDisplay main = new MainDisplay(device);
                ControlForm controlForm = new ControlForm(device);
                //main.Show();
                controlForm.Show();
                Hide();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lstNICSelector_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSubmit.PerformClick();
            }
        }
    }
}
