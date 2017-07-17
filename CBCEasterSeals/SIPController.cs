/* April 07, 2016
 * This code was created by Lok-Tin Leung and Ilya Brusnitsyn in order to enable
 * the program to monitor VoIP phones using SIP protocol.
 */

using System;
using SharpPcap;
using PacketDotNet;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Media;

namespace CBCEasterSeals
{
    public enum PhoneState
    {
        Idle,
        Dialog
    }

    public class SIPController
    {
        private const int  MAXPHONES = 30;

        private string addressFilePath = "address.txt";

        public class CallStartStopEventArgs : EventArgs
        {
            public PhoneState PhoneState { get; set; }
            public int Queue { get; set; }
        }

        public delegate void CallStartStopEventHandler(object sender, CallStartStopEventArgs e);

        // events that clients can use to be notified whenever a
        // phone is picked up or put down
        public event CallStartStopEventHandler CallStartStop;

        protected virtual void OnCallStartStop(CallStartStopEventArgs e)
        {
            if (CallStartStop != null)
                CallStartStop(this, e);
        }

        public List<Phone> allPhones = new List<Phone>();
        Thread captureThread;
        private int compareMethod = 0; // default MAC

        public int CompareMethod
        {
            get { return compareMethod; }
            set { compareMethod = value; }
        }

        public string AddressFilePath
        {
            get { return addressFilePath; }
            set { addressFilePath = value; }
        }

        public SIPController()
        {
            ReadAddressFile(AddressFilePath);
        }
        /// <summary>
        /// Reads the reference MAC and IP address file into the program.
        /// </summary>
        /// <param name="AddressFilePath">Filepath to reference file.</param>
        public void ReadAddressFile(string AddressFilePath)
        {
            StreamReader addressFile;
            try
            {
                addressFile = new StreamReader(AddressFilePath);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File not found. File may be missing or filepath may be incorrect. Creating address.txt in the root directory.");
                TextWriter tw = new StreamWriter(AddressFilePath, true);
                tw.WriteLine("#Enter mac address and IP address for each phone like in this example (also remove the pound symbol):");
                tw.WriteLine("#C47295A8773C,192.168.1.2");
                tw.Close();
                addressFile = null;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Filepath is invalid.");
                addressFile = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unknown error has occurred while reading the address reference file.\n" + ex.Message);
                addressFile = null;
            }

            if (addressFile != null)
            {
                int queue = 0;
                while (!addressFile.EndOfStream)
                {
                    try
                    {
                        string line = addressFile.ReadLine();
                        if (!line.StartsWith("#"))
                        {
                            string[] entries = line.Split(',');

                            // Initial phone creation
                            if (queue == allPhones.Count && queue < MAXPHONES)
                            {
                                allPhones.Add(new Phone(queue, entries[0], entries[1]));
                            }
                            else if (allPhones[queue].Mac != entries[0] || allPhones[queue].Ip != entries[1])
                            {
                                allPhones[queue].Mac = entries[0];
                                allPhones[queue].Ip = entries[1];
                            }                        
                            queue++;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("address.txt improperly written.");
                        Environment.Exit(1);
                    }
                }

                addressFile.Close();
                queue = 0;

                if (allPhones.Count == 0)
                {
                    MessageBox.Show("There are no phones added to address.txt in the root directory.");
                }
                else if (allPhones.Count > MAXPHONES)
                {
                    MessageBox.Show(string.Format("You cannot have more than {0} phones in address.txt", MAXPHONES));
                    Environment.Exit(1);
                }
            }
            else
            {
                Environment.Exit(1);
            }
        }

        private void device_OnPacketArrival(object sender, CaptureEventArgs e)
        {
            Packet packet = Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);
            UdpPacket udpPacket = (UdpPacket)packet.Extract(typeof(UdpPacket));

            if (udpPacket != null)
            {
                IpPacket ipPacket = (IpPacket)udpPacket.ParentPacket;
                string dstIp = ipPacket.DestinationAddress.ToString();
                int srcPort = udpPacket.SourcePort;
                int dstPort = udpPacket.DestinationPort;

                if (dstPort == 5060 || srcPort == 5060 || dstPort == 5061 || srcPort == 5061) //SIP port 5060, SIP and TLC 5061 
                {
                    string str = System.Text.Encoding.ASCII.GetString(udpPacket.Bytes);
                    string[] separators = { "\r\n" };
                    string[] packetLines = str.Split(separators, StringSplitOptions.None);

                    foreach (Phone p in allPhones)
                    {
                        // 0 = by MAC, 1 = by IP address
                        switch (compareMethod)
                        {
                            case 0:
                                EthernetPacket ePacket = (EthernetPacket)packet.Extract(typeof(EthernetPacket));
                                string destMacAddress = ePacket.DestinationHwAddress.ToString();
                                string srcMacAddress = ePacket.SourceHwAddress.ToString();
                                if (p.Mac == srcMacAddress || p.Mac == destMacAddress)
                                {
                                    ProcessSIPpacket(packetLines, p);
                                    break;
                                }
                                break;
                            case 1:
                                string destIPAddress = ipPacket.DestinationAddress.ToString();
                                string srcIPAddress = ipPacket.SourceAddress.ToString();
                                if (p.Ip == srcIPAddress || p.Ip == destIPAddress)
                                {
                                    ProcessSIPpacket(packetLines, p);
                                    break;
                                }
                                break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Initializes and starts the packet capture thread. 
        /// </summary>
        /// <param name="device">The NIC device that SIP packets will be captured from.</param>
        public void StartCapture(ICaptureDevice device)
        {
            //Register our handler function to the 'packet arrival' event
            device.OnPacketArrival += new PacketArrivalEventHandler(device_OnPacketArrival);

            // Open the device for capturing
            int readTimeoutMilliseconds = 1000;
            device.Open(DeviceMode.Promiscuous, readTimeoutMilliseconds);

            //udpdump filter to capture only TCP/IP packets
            string filter = "udp";
            device.Filter = filter;

            captureThread = new Thread(device.Capture);
            // Start capture 'INFINTE' number of packets
            captureThread.Start();
        }
        /// <summary>
        /// Stops the packet capture thread and prints the remaining packets on the OffHookPhones list.
        /// </summary>
        public void StopCapture()
        {
            captureThread.Abort();
            Phone.log.Stop();
        }

        public void ProcessSIPpacket(string[] packet, Phone p)
        {
            CallStartStopEventArgs e = new CallStartStopEventArgs();

            switch (p.State)
            {
                case PhoneState.Idle:
                    if (packet[0].Contains("200") && GetCseq(packet).Contains("INVITE"))
                    {
                        p.StartTime = DateTime.Now;

                        p.State = PhoneState.Dialog;

                        e.PhoneState = p.State;
                        e.Queue = p.Queue; 
                        OnCallStartStop(e);
                    }
                    if (packet[0].Contains("180"))
                    {
                        ThreadStart soundThreadStart = new ThreadStart(playSound);
                        Thread soundThread = new Thread(soundThreadStart);
                        soundThread.Start();
                    }
                    break;
                case PhoneState.Dialog:
                    if (packet[0].Contains("BYE"))
                    {
                        p.StopTime = DateTime.Now;
                        TimeSpan duration = p.StopTime.Subtract(p.StartTime);
                        Phone.log.Log(string.Format("{0, -10} | {1:hh:mm:ss.fff tt} | {2:hh:mm:ss.fff tt} | {3:hh\\:mm\\:ss\\.fff}", (p.Queue + 1).ToString(), p.StartTime, p.StopTime, duration));

                        p.State = PhoneState.Idle;

                        e.PhoneState = p.State;
                        e.Queue = p.Queue;

                        OnCallStartStop(e);
                    }
                    break;
            }
        }

        private static void playSound()
        {
            MediaPlayer player = new MediaPlayer();
            player.Open(new Uri(Environment.CurrentDirectory + "//ring.wav"));
            player.Play();
        }

        private static string GetCseq(string[] sipPacket)
        {
            foreach (string line in sipPacket)
            {
                string[] temp = line.Split(':');
                if (temp[0] == "CSeq")
                    return temp[1];
            }
            return null;
        }
    }

    /// <summary>
    /// Class for reference phone data.
    /// </summary>
    public class Phone
    {
        public static PacketLog log = new PacketLog();

        private int queue;
        private string ipAddress;
        private string macAddress;
        private PhoneState state = PhoneState.Idle;
        private DateTime startTime = new DateTime();
        private DateTime stopTime = new DateTime();
        private Bitmap image = new Bitmap(global::CBCEasterSeals.Properties.Resources.on);

        public int Queue
        {
            get { return queue; }
        }
        public string Ip
        {
            get { return ipAddress; }
            set { ipAddress = value; }
        }
        public string Mac
        {
            get { return macAddress; }
            set { macAddress = value; }
        }

        public bool FromTo
        {
            get { return FromTo; }

            set { FromTo = value; }
        }

        public PhoneState State
        {
            get { return state; }
            set
            {
                state = value;
                switch(state)
                {
                    case PhoneState.Idle:
                        image = global::CBCEasterSeals.Properties.Resources.on;
                        break;
                    case PhoneState.Dialog:
                        image = global::CBCEasterSeals.Properties.Resources.off;
                        break;
                }
            }
        }

        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }

        public DateTime StopTime
        {
            get { return stopTime; }
            set { stopTime = value; }
        }

        public Bitmap Image
        {
            get
            {
                return image;
            }
        }

        public Phone(int Queue, string Mac, string Ip)
        {
            queue = Queue;
            macAddress = Mac;
            ipAddress = Ip;            
        }
    }

    /// <summary>
    /// Packet logging for stress testing and troubleshooting.
    /// </summary>
    public class PacketLog
    {
        private string logfilepath = "logs\\Rx_" + DateTime.Now.ToString("yyyy-MM-dd-hh.mm.ss") + ".txt";
        private StreamWriter filelog;

        public PacketLog()
        {
            Directory.CreateDirectory("logs");
            filelog = new StreamWriter(logfilepath, true);
            filelog.WriteLine("{0, -10} | {1, -15} | {2, -15} | {3}", "Phone#", "StartTime", "StopTime", "Call Duration");
        }
        /// <summary>
        /// Outputs a line of text to a file.
        /// </summary>
        /// <param name="Line">Line of text to be output to the file.</param>
        public void Log(string Line)
        {
            lock (filelog)
            {
                filelog.WriteLine(Line);
            };
        }
        /// <summary>
        /// Closes the file.
        /// </summary>
        public void Stop()
        {
            filelog.Close();
        }
    }
}