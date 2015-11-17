using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Gambler.Model
{
    public class Gambler : Connectee
    {
        public Gambler(string name, IPAddress address, int portNo) : base(address, portNo, name)
        {
            money = 0;
            Connection = new RPC.GamblerServer(this, this.Address.ToString(), this.PortNo);
            Connection.createGamblerServerInterface();
        }
        public Model.RPC.GamblerServer Connection { get; private set; }
        public double money { get; private set; }
        public void addMoney(double amountToAdd)
        {
            this.money += amountToAdd;
        }
        

        
    }
}
