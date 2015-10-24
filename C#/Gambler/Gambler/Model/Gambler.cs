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
        public Gambler(string name, IPAddress address, int portNo) : base(address, portNo)
        {
            money = 0;
            iD = name;
        }
        
        public double money { get; private set; }
        public void addMoney(double amountToAdd)
        {
            this.money += amountToAdd;
        }
        
    }
}