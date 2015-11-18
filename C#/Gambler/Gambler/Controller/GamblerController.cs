using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Gambler.Controller
{
    class GamblerController
    {
        public GamblerController(string nameOfGambler, IPAddress address, int portNo)
        {
            gmblr = new Model.Gambler(nameOfGambler, address, portNo);
        }
        public Model.Gambler gmblr { get; private set; }
        public void fillWallet(double amountToAdd)
        {
            if (amountToAdd > 0)
                gmblr.addMoney(Math.Round(amountToAdd, 2));
        }
        public double getMoney()
        {
            return this.gmblr.money;
        }
        public string getID()
        {
            return this.gmblr.ID;
        }
    }
}
