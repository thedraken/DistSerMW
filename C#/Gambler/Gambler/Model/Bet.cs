﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gambler.Model
{
    class Bet
    {
        public Bet(int bookieID, int matchID, int teamID, double stake, int odds) {
            this.bookieID = bookieID;
            this.matchID = matchID;
            this.teamID = teamID;
            this.stake = stake;
            this.odds = odds;
        }
        public double stake{get; private set;}
        public int bookieID { get; private set; }
        public int matchID { get; private set; }
        public int teamID { get; private set; }
        public int odds { get; private set; }
        public bool validBet { get; private set; }
    }
}
