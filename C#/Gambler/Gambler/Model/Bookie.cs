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
            this._connectingGambler.Connection.Service.getList().CollectionChanged += handleUpdates;
            Connection.establishSocketConnection();
            this.ID = Connection.sendConnect();
            if (this.ID == string.Empty)
                throw new Controller.ConnectionFailed();
            Connected = true;
            this.refreshMatches();
            this._connectingGambler.addMoney(this.Connection.getPreviousWinnings());
        }
        private Gambler _connectingGambler;
        public bool Connected { get; private set; }
        private object lockObj = new object();
        private ObservableCollection<Bet> _listOfBets;
        private ObservableCollection<Match> _listOfMatches;
        private ObservableCollection<Winnings> _listOfWinnings;
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
        public void addBet(Bet bet)
        {
            if (this.Connected)
            {
                switch (Connection.placeBet(bet))
                {
                    case global::Gambler.Model.RPC.Common.PlaceBetResult.ACCEPTED:
                        lock (lockObj)
                        {
                            this._listOfBets.Add(bet);
                        }
                        break;
                    case global::Gambler.Model.RPC.Common.PlaceBetResult.REJECTED_UNKNOWN_MATCH:
                        throw new Controller.UnknownMatch(bet.MatchID);
                    case global::Gambler.Model.RPC.Common.PlaceBetResult.REJECTED_UNKNOWN_TEAM:
                        throw new Controller.UnknownTeam(bet.TeamID);
                    case global::Gambler.Model.RPC.Common.PlaceBetResult.REJECTED_ALREADY_PLACED_BET:
                        throw new Controller.BetAlreadyPlaced();
                    case global::Gambler.Model.RPC.Common.PlaceBetResult.REJECTED_LIMIT_EXCEEDED:
                        throw new Controller.BetLimitExceeded();
                    case global::Gambler.Model.RPC.Common.PlaceBetResult.REJECTED_ODDS_MISMATCH:
                        throw new Controller.OddsMismatch(bet.Odds, bet.TeamID);
                    case RPC.Common.PlaceBetResult.LOST_CONNECTION:
                        throw new Controller.ConnectionDropped();
                }
            }
        }
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
                            Match matchToChangeOdds = dataOdds.First();
                            matchToChangeOdds.updateOdds(sor.TeamName, sor.NewOdds);
                            break;
                        case RecievedMessage.MessageType.bookieExiting:
                            this.Connected = false;

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
                Match matchToUpdate = data.First();
                matchToUpdate.closeMatch();
                Bet betToUpdate = _listOfBets.Where(t => t.MatchID.Equals(ebr.MatchID)).First();
                betToUpdate.closeBet();
                Model.Winnings winnings = new Winnings(ebr.AmountWon);
                this._listOfWinnings.Add(winnings);
            }
        }
        private void recievedMessageToMatch(RecievedMessage rm)
        {
            MatchStartedResult msr = (MatchStartedResult)rm.Result;
            Match matchToAdd = new Match(msr.MatchID, msr.TeamA, msr.OddsA, msr.TeamB, msr.OddsB, msr.OddsDraw, msr.Limit, this);
            lock (lockObj)
            {
                this._listOfMatches.Add(matchToAdd);
            }
        }
        public Model.RPC.BookieConnection Connection { get; private set; }
        public void sayHello()
        {
            if (this.Connected)
                Connection.sayHello();
        }
        public void refreshMatches()
        {
            if (this.Connected)
            {
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
        public void closeConnection()
        {
            if (this.Connected)
                this.Connection.closeConnection();
        }
        public JSON_RPC_Server.ServiceMode Mode { get; private set; }
        public void setMode(JSON_RPC_Server.ServiceMode mode)
        {
            if (this.Connected)
            {
                Connection.setModeOfHost(mode, this._connectingGambler.getNextMessageID());
                this.Mode = mode;
            }
        }
        public override string ToString()
        {
            return this.ID;
        }
        public List<Bet> getBetsPlacedForMatch(Match m)
        {
            return Connection.getOtherBetsPlaced(m);
        }
    }
}
