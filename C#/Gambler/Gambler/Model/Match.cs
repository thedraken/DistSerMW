using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gambler.Model
{
    public class Match
    {
        public Match(int id, string teamA, float oddsA, string teamB, float oddsB, int limit, Bookie owningBookie)
        {
            this.ID = id;
            this.TeamA = teamA;
            this.OddsA = oddsA;
            this.OddsB = oddsB;
            this.TeamB = teamB;
            this.Limit = limit;
            OpenMatch = true;
            this._owningBookie = owningBookie;
        }
        private Model.Bookie _owningBookie;
        public void updateOdds(string teamName, float odds)
        {
            if (TeamA.Equals(teamName))
                OddsA = odds;
            else if (TeamB.Equals(teamName))
                OddsB = odds;
        }
        public string OwningBookieID
        {
            get
            {
                return this._owningBookie.ID;
            }
        }
        public int ID { get; private set; }
        public string TeamA { get; private set; }
        public float OddsA { get; private set; }
        public string TeamB { get; private set; }
        public float OddsB { get; private set; }
        public int Limit { get; private set; }
        public bool OpenMatch { get; private set; }
        private Bet _betPlaced;
        public bool BetPlaced
        {
            get
            {
                return _betPlaced != null;
            }
        }
        public void closeMatch()
        {
            this.OpenMatch = false;
        }
        public void placeBet(Bet b)
        {
            this._betPlaced = b;
        }
        public override string ToString()
        {
            return this.OwningBookieID + " - " + this.ID;
        }
    }
}
