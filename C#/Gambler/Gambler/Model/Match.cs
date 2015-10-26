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
            this.id = id;
            this.teamA = teamA;
            this.oddsA = oddsA;
            this.oddsB = oddsB;
            this.teamB = teamB;
            this.limit = limit;
            openMatch = true;
        }
        public void updateOdds(float oddsA, float oddsB, int limit)
        {
            this.oddsA = oddsA;
            this.oddsB = oddsB;
            this.limit = limit;
        }

        public int id { get; private set; }
        public string teamA { get; private set; }
        public float oddsA { get; private set; }
        public string teamB { get; private set; }
        public float oddsB { get; private set; }
        public int limit { get; private set; }
        public bool openMatch { get; set; }
    }
}
