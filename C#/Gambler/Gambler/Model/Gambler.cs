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
            _money = 0;
            Connection = new RPC.GamblerServer(this);
            Connection.createGamblerServerInterface();
        }
        private object lockObj = new object();
        private int _messageID = 0;
        public Model.RPC.GamblerServer Connection { get; private set; }
        private double _money;
        /// <summary>
        /// The amount of money currently in the gambler's wallet
        /// </summary>
        public double Money
        {
            get
            {
                lock (lockObj)
                {
                    return _money;
                }
            }
        }
        /// <summary>
        /// Add money to the wallet of the gambler (It can be a negative amount)
        /// </summary>
        /// <param name="amountToAdd">The amount of money to add</param>
        public void addMoney(double amountToAdd)
        {
            lock (lockObj)
            {
                this._money += amountToAdd;
            }
        }
        /// <summary>
        /// Gets the next message ID for this gambler, we only ever create one gambler per executable, so this is a good place to store it
        /// </summary>
        /// <returns>A string of the next message ID which consists of gambler name and message number</returns>
        public string getNextMessageID()
        {
            return this.ID + (++_messageID);
        }
        /// <summary>
        /// Tells the gambler to close all RPC connections
        /// </summary>
        public void destroyConnection()
        {
            Connection.destroyGamblerServerInterface();
        }
    }
}
