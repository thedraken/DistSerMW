using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Gambler.Model
{
    public class Bookie:Connectee
    {
        public Bookie(Gambler connectingGambler, IPAddress address, int portNo)
            : base(address, portNo)
        {
            _listOfBets = new ObservableCollection<Bet>();
            _listOfMatches = new ObservableCollection<Match>();
            _listOfWinnings = new ObservableCollection<Winnings>();
            this._connectingGambler = connectingGambler;
            Mode = JSON_RPC_Server.ServiceMode.RELIABLE;
            Connection = new RPC.BookieConnection(connectingGambler, address.ToString(), portNo);
            //Subscribe to the collection, so any new messages are processed
            this._connectingGambler.Connection.Service.getList().CollectionChanged += handleUpdates;
            Connection.establishSocketConnection();
            this.ID = Connection.sendConnect();
            if (this.ID == string.Empty)
                throw new Controller.ConnectionFailed();
            Connected = true;
            //We'll retrieve data from the bookie, let's make sure we're up to date and collect any previous winnings
            this.refreshMatches();
            this._connectingGambler.addMoney(this.Connection.getPreviousWinnings());
        }
        private Gambler _connectingGambler;
        /// <summary>
        /// Is the bookie in a connected state or not?
        /// </summary>
        public bool Connected { get; private set; }
        private object lockObj = new object();
        private ObservableCollection<Bet> _listOfBets;
        private ObservableCollection<Match> _listOfMatches;
        private ObservableCollection<Winnings> _listOfWinnings;
        /// <summary>
        /// Gets a list of matches associated with this Bookie
        /// </summary>
        public ObservableCollection<Match> ListOfMatches
        {
            get
            {
                lock(lockObj)
                {
                    return this._listOfMatches;
                }
            }
        }
        /// <summary>
        /// Gets a list of bets associated with matchs that this Bookie owns
        /// </summary>
        public ObservableCollection<Bet> ListOfBets
        {
            get
            {
                lock (lockObj)
                {
                    return this._listOfBets;
                }
            }
        }
        /// <summary>
        /// Gets a list of any winnings that a gambler may have won from this Bookie
        /// </summary>
        public ObservableCollection<Winnings> ListOfWinnings
        {
            get
            {
                lock (lockObj)
                {
                    return this._listOfWinnings;
                }
            }
        }
        /// <summary>
        /// Attempts to place a bet against this bookie
        /// If it fails, an exception is thrown with the reason for failure
        /// </summary>
        /// <param name="bet">The bet to place</param>
        public void addBet(Bet bet)
        {
            if (this.Connected)
            {
                string result = Connection.placeBet(bet);
                if (result.Equals(Model.RPC.Common.PlaceBetResult.ACCEPTED.ToString()))
                {
                    lock (lockObj)
                    {
                        this._listOfBets.Add(bet);
                    }
                }
                else
                {
                    if (result.StartsWith(Model.RPC.Common.PlaceBetResult.REJECTED_UNKNOWN_MATCH.ToString()))
                        throw new Controller.UnknownMatch(bet.MatchID);
                    if (result.StartsWith(Model.RPC.Common.PlaceBetResult.REJECTED_UNKNOWN_TEAM.ToString()))
                        throw new Controller.UnknownTeam(bet.TeamID);
                    if (result.StartsWith(Model.RPC.Common.PlaceBetResult.REJECTED_ALREADY_PLACED_BET.ToString()))
                        throw new Controller.BetAlreadyPlaced();
                    if (result.StartsWith(Model.RPC.Common.PlaceBetResult.REJECTED_LIMIT_EXCEEDED.ToString()))
                        throw new Controller.BetLimitExceeded(result);
                    if (result.StartsWith(Model.RPC.Common.PlaceBetResult.REJECTED_ODDS_MISMATCH.ToString()))
                        throw new Controller.OddsMismatch(bet.Odds, bet.TeamID);
                    if (result.StartsWith(Model.RPC.Common.PlaceBetResult.LOST_CONNECTION.ToString()))
                        throw new Controller.ConnectionDropped();
                }
            }
        }
        /// <summary>
        /// Handles any updates to the recieved message list, this is tied to the Observable collection in the Gambler server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void handleUpdates(object sender, NotifyCollectionChangedEventArgs e)
        {
            foreach (var ni in e.NewItems)
            {
                RecievedMessage rm = (RecievedMessage)ni;
                if (this.ID == rm.Result.BookieID)
                {
                    switch (rm.Type)
                    {
                        case RecievedMessage.MessageType.matchStarted:
                            recievedMessageToMatch(rm);
                            break;
                        case RecievedMessage.MessageType.endBet:
                            recievedMessageToBet(rm);
                            break;
                        case RecievedMessage.MessageType.setOdds:
                            SetOddsResult sor = (SetOddsResult)rm.Result;
                            var dataOdds = _listOfMatches.Where(t => t.ID.Equals(sor.MatchID));
                            try
                            {
                                Match matchToChangeOdds = dataOdds.First();
                                matchToChangeOdds.updateOdds(sor.TeamName, sor.NewOdds);
                            }
                            catch
                            {
                                Console.WriteLine("Couldn't update the match of ID " + sor.MatchID + " for Bookie " + sor.BookieID);
                            }
                            break;
                        case RecievedMessage.MessageType.bookieExiting:
                            BookieExitingResult ber = (BookieExitingResult)rm.Result;
                            if (this.ID.Equals(ber.BookieID))
                            {
                                this.Connected = false;
                                foreach (Match m in this.ListOfMatches)
                                    m.closeMatch();
                            }
                            break;
                    }
                }
            }

        }
        private void recievedMessageToBet(RecievedMessage rm)
        {
            EndBetResult ebr = (EndBetResult)rm.Result;
            lock (lockObj)
            {
                var data = _listOfMatches.Where(t => t.ID.Equals(ebr.MatchID));
                try
                {
                    Match matchToUpdate = data.First();
                    matchToUpdate.closeMatch();
                    Model.Winnings winnings = new Winnings(ebr.AmountWon, ebr.BookieID, ebr.MatchID, matchToUpdate.BetPlaced);
                    this._listOfWinnings.Add(winnings);
                }
                catch
                {
                    Console.WriteLine("Closing match - Unable to find match of ID " + ebr.MatchID + " for the bookie " + ebr.BookieID);
                    Model.Winnings winnings = new Winnings(ebr.AmountWon, ebr.BookieID, ebr.MatchID, false);
                    this._listOfWinnings.Add(winnings);
                }
                var listOfBetsToUpdate = _listOfBets.Where(t => t.MatchID.Equals(ebr.MatchID) && t.BookieID.Equals(this.ID));
                foreach(var betToUpdate in listOfBetsToUpdate)
                    betToUpdate.closeBet();
                
            }
        }
        private void recievedMessageToMatch(RecievedMessage rm)
        {
            MatchStartedResult msr = (MatchStartedResult)rm.Result;
            Match matchToAdd = new Match(msr.MatchID, msr.TeamA, msr.OddsA, msr.TeamB, msr.OddsB, msr.OddsDraw, msr.Limit, this);
            if (!_listOfMatches.Contains(matchToAdd))
            {
                lock (lockObj)
                {
                    this._listOfMatches.Add(matchToAdd);
                }
            }
        }
        public Model.RPC.BookieConnection Connection { get; private set; }
        /// <summary>
        /// Say hello to the bookie
        /// </summary>
        public void sayHello()
        {
            if (this.Connected)
                Connection.sayHello();
        }
        /// <summary>
        /// Get an updated list of matches from the bookie
        /// </summary>
        public void refreshMatches()
        {
            if (this.Connected)
            {
                lock (lockObj)
                {
                    this._listOfMatches.Clear();
                }
                List<Match> listOfMatches = Connection.showMatches(this);
                if (listOfMatches != null && listOfMatches.Count > 0)
                {
                    foreach (Match m in listOfMatches)
                    {
                        lock (lockObj)
                        {
                            if (!_listOfMatches.Contains(m))
                                _listOfMatches.Add(m);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Close the connection with the bookie
        /// </summary>
        public void closeConnection()
        {
            if (this.Connected)
                this.Connection.closeConnection();
        }
        /// <summary>
        /// Get the Bookie's currently set mode
        /// </summary>
        public JSON_RPC_Server.ServiceMode Mode { get; private set; }
        /// <summary>
        /// Set the bookie's mode of connection
        /// </summary>
        /// <param name="mode">The mode to set it to</param>
        public void setMode(JSON_RPC_Server.ServiceMode mode)
        {
            if (this.Connected)
            {
                Connection.setModeOfHost(mode, this._connectingGambler.getNextMessageID());
                this.Mode = mode;
            }
        }
        /// <summary>
        /// Get the bookie's ID
        /// </summary>
        /// <returns>The bookie's ID</returns>
        public override string ToString()
        {
            return this.ID;
        }
        /// <summary>
        /// Get any bets placed for an open match, allows the gambler to try and bet more wisely
        /// </summary>
        /// <param name="m">The match of which you want the current bets set</param>
        /// <returns>A list of bets that have been placed agains the match (It can be empty)</returns>
        public List<Bet> getBetsPlacedForMatch(Match m)
        {
            return Connection.getOtherBetsPlaced(m);
        }
    }
}
