﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Gambler.Model
{
    public abstract class Connectee
    {
        public Connectee(IPAddress address, int portNo)
        {
            this.address = address;
            this.portNo = portNo;
        }

        public void setID(string id)
        {
            this.iD = id;
        }
        public IPAddress address { get; private set; }
        public int portNo { get; private set; }
        public string iD { get; private set; }
    }
}