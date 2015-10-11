using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gambler.Model
{
    class Gambler
    {
        public Gambler()
        {
            money = 0;
            iD = Guid.NewGuid();
        }
        public Guid iD { get; private set; }
        public double money { get; private set; }
        public void addMoney(double amountToAdd)
        {
            this.money += amountToAdd;
        }

    }
}
