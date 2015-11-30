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
            double amountToAddRounded = Math.Round(amountToAdd, 2);
            if (gmblr.Money + amountToAddRounded < 0)
                throw new WalletCantGoBelowZero(amountToAddRounded, gmblr.Money);
            gmblr.addMoney(amountToAddRounded);
        }
        public double getMoney()
        {
            return this.gmblr.Money;
        }
        public string getID()
        {
            return this.gmblr.ID;
        }
        public void destroyConnection()
        {
            this.gmblr.destroyConnection();
        }
    }
}
