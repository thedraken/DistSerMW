using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gambler.Model
{
    public class Winnings
    {
        public Winnings(float amount, string bookieID, int matchID, bool betPlaced)
        {
            this.Amount = amount;
            this.BookieID = bookieID;
            this.MatchID = matchID;
            this.BetPlaced = betPlaced;
        }
        public bool BetPlaced { get; private set; }
        public int MatchID { get; private set; }
        public string BookieID { get; private set; }
        public float Amount { get; private set; }
    }
}
