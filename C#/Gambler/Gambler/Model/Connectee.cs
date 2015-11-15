using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Gambler.Model
{
    public abstract class Connectee
    {
        public Connectee(IPAddress address, int portNo, string name) : this(address, portNo)
        {   
            this.ID = name;
        }
        public Connectee(IPAddress address, int portNo)
        {
            this.Address = address;
            this.PortNo = portNo;
        }

        public IPAddress Address { get; private set; }
        public int PortNo { get; private set; }
        public string ID { get; protected set; }
    }
}
