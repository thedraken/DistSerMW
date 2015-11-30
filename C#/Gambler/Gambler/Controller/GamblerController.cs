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
        /// <summary>
        /// Adds money to the wallet of the gambler, if the new total is less then zero, it will throw an exception
        /// </summary>
        /// <param name="amountToAdd">Amount to add to the wallet (Can be negative)</param>
        public void fillWallet(double amountToAdd)
        {
            double amountToAddRounded = Math.Round(amountToAdd, 2);
            if (gmblr.Money + amountToAddRounded < 0)
                throw new WalletCantGoBelowZero(amountToAddRounded, gmblr.Money);
            gmblr.addMoney(amountToAddRounded);
        }
        /// <summary>
        /// Gets the current amount in the gambler's wallet
        /// </summary>
        /// <returns>Amount in the gambler's wallet</returns>
        public double getMoney()
        {
            return this.gmblr.Money;
        }
        /// <summary>
        /// Gets the gambler's ID
        /// </summary>
        /// <returns>The string ID, often their name</returns>
        public string getID()
        {
            return this.gmblr.ID;
        }
        /// <summary>
        /// Destroys the gambler connections, including the listening server
        /// </summary>
        public void destroyConnection()
        {
            this.gmblr.destroyConnection();
        }
    }
}
