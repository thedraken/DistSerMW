using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gambler.Model
{
    public class Bet
    {
        public Bet(string bookieID, int matchID, string teamID, float stake, float odds)
        {
            this.BookieID = bookieID;
            this.MatchID = matchID;
            this.TeamID = teamID;
            this.Stake = stake;
            this.Odds = odds;
            OpenBet = true;
        }
        public float Stake { get; private set; }
        public string BookieID { get; private set; }
        public int MatchID { get; private set; }
        public string TeamID { get; private set; }
        public float Odds { get; private set; }
        public bool OpenBet { get; private set; }
        public void closeBet()
        {
            this.OpenBet = false;
        }
    }
}
