using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gambler.Model
{
    public class Match
    {
        public Match(int id, string teamA, float oddsA, string teamB, float oddsB, int limit)
        {
            this.ID = id;
            this.TeamA = teamA;
            this.OddsA = oddsA;
            this.OddsB = oddsB;
            this.TeamB = teamB;
            this.Limit = limit;
            OpenMatch = true;
        }
        public void updateOdds(float oddsA, float oddsB, int limit)
        {
            this.OddsA = oddsA;
            this.OddsB = oddsB;
            this.Limit = limit;
        }

        public int ID { get; private set; }
        public string TeamA { get; private set; }
        public float OddsA { get; private set; }
        public string TeamB { get; private set; }
        public float OddsB { get; private set; }
        public int Limit { get; private set; }
        public bool OpenMatch { get; set; }
    }
}
