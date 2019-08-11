using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBoard
{
    public class Phone
    {
        private int queue;
        private string ipAddress;
        private string macAddress;
        private PhoneState state = PhoneState.Idle;
        private DateTime startTime = new DateTime();
        private DateTime stopTime = new DateTime();
        private Bitmap image = new Bitmap(global::PhoneBoard.Properties.Resources.on);

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
                switch (state)
                {
                    case PhoneState.Idle:
                        image = global::PhoneBoard.Properties.Resources.on;
                        break;
                    case PhoneState.Dialog:
                        image = global::PhoneBoard.Properties.Resources.off;
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
            get { return image; }
        }

        public Phone(int Queue, string Mac, string Ip)
        {
            queue = Queue;
            macAddress = Mac;
            ipAddress = Ip;
        }
    }
}
