﻿using System;
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
            Connection = new RPC.GamblerServer(this, this.Address.ToString(), this.PortNo);
            Connection.createGamblerServerInterface();
        }
        private object lockObj = new object();
        public Model.RPC.GamblerServer Connection { get; private set; }
        private double _money;
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
        public void addMoney(double amountToAdd)
        {
            lock (lockObj)
            {
                this._money += amountToAdd;
            }
        }
    }
}
