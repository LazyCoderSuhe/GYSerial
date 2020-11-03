using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SerialHelper.Fins
{
    public class FinsConfig
    {
        public FinsConfig(IPAddress iP, int port, short unitNu)
        {
            IP = iP;
            Port = port;
            UnitNu = unitNu;
        }

        public IPAddress IP { get; set; }
        public int Port { get; set; } = 9600;
        public Int16 UnitNu { get; set; }
    }
}
