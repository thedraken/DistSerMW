using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gambler.Model
{
    public class Winnings
    {
        public Winnings(float amount)
        {
            this.Amount = amount;
        }
        public float Amount { get; private set; }
    }
}
