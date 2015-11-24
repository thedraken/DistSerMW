using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gambler.Model.RPC.Common
{
    // These are some of the different states that a place bet can result in.
    public enum PlaceBetResult
    {
        ACCEPTED,
        REJECTED_UNKNOWN_MATCH,
        REJECTED_UNKNOWN_TEAM,
        REJECTED_ALREADY_PLACED_BET,
        REJECTED_LIMIT_EXCEEDED,
        REJECTED_ODDS_MISMATCH,
        LOST_CONNECTION
    }
}

