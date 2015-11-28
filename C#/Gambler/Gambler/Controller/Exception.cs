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
    public class ConnectionFailed : BaseException
    {
        public ConnectionFailed()
            : base("The connection failed, did you type in the correct address?") { }
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
        public BetLimitExceeded(string extraMessage)
            : base("The bet limit has been exceeded for this match: " + extraMessage)
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
    public class NotEnoughFunds : BaseException
    {
        public NotEnoughFunds(double attemptedBet)
            : base("You do not have enough funds to place a bet of " + attemptedBet)
        {

        }
    }
    public class NoConnectedBookie : BaseException
    {
        public NoConnectedBookie()
            :base("There are no connected bookies to set the mode of")
        {

        }
    }
    public class ConnectionDropped : BaseException
    {
        public ConnectionDropped()
            : base("The connection failed 3 times, maybe the bookie is no longer online?")
        {

        }
    }
}
