using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gambler.Controller
{
    public abstract class BaseException : Exception
    {
        public BaseException(string message)
        {
            this._message = message;
        }
        private string _message;

        public override string Message
        {
            get
            {
                return this._message;
            }
        }
    }

    public class GamblerAlreadyExists :BaseException
    {
        public GamblerAlreadyExists()
            : base("The gambler already exisits, please use another name")
        {

        }
    }
    public class UnknownMatch : BaseException
    {
        public UnknownMatch(int matchID)
            : base("The match " + matchID +" was not recognised by the Bookie")
        {

        }
    }
    public class UnknownTeam : BaseException
    {
        public UnknownTeam(string teamName)
            : base("The team " + teamName + " was not recognised by the Bookie")
        {

        }
    }
    public class BetAlreadyPlaced : BaseException
    {
        public BetAlreadyPlaced()
            : base("You've already placed a bet for that match")
        {

        }
    }
    public class BetLimitExceeded : BaseException
    {
        public BetLimitExceeded()
            : base("The bet limit has been exceeded for this match")
        {

        }
    }
    public class OddsMismatch : BaseException
    {
        public OddsMismatch(float odds, string teamName)
            : base("The odds "+odds+" for the team "+ teamName+" are incorrect")
        {

        }
    }
}
