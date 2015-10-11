using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gambler.Controller
{
    class GamblerController
    {
        public GamblerController()
        {
            gmblr = new Model.Gambler();
        }
        private Model.Gambler gmblr;
        public void addMoney(double amountToAdd)
        {
            if (amountToAdd > 0)
                gmblr.addMoney(amountToAdd);
        }
        public double getMoney()
        {
            return this.gmblr.money;
        }
    }
}
