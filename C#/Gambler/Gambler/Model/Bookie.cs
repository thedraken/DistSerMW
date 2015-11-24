﻿using System;
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
            Connection = new RPC.BookieConnection(connectingGambler, address.ToString(), portNo);
            Connection.establishSocketConnection();
            this.ID = Connection.sendConnect();
            this._connectingGambler = connectingGambler;
            this._connectingGambler.Connection.Service.getList().CollectionChanged += handleUpdates;
            Mode = JSON_RPC_Server.ServiceMode.RELIABLE;
        }
        private Gambler _connectingGambler;
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
                            MatchStartedResult msr = (MatchStartedResult)rm.Result;
                            Match matchToAdd = new Match(msr.MatchID, msr.TeamA, msr.OddsA, msr.TeamB, msr.OddsB, msr.Limit, this);
                            lock (lockObj)
                            {
                                this._listOfMatches.Add(matchToAdd);
                            }
                            break;
                        case RecievedMessage.MessageType.endBet:
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
                            break;
                        case RecievedMessage.MessageType.setOdds:
                            SetOddsResult sor = (SetOddsResult)rm.Result;
                            var dataOdds = _listOfMatches.Where(t => t.ID.Equals(sor.MatchID));
                            Match matchToChangeOdds = dataOdds.First();
                            matchToChangeOdds.updateOdds(sor.TeamName, sor.NewOdds);
                            break;
                    }
                }
            }

        }
        public Model.RPC.BookieConnection Connection { get; private set; }
        public void sayHello()
        {
            Connection.sayHello();
        }
        public void refreshMatches()
        {
            Connection.showMatches();
        }
        public void closeConnection()
        {
            this.Connection.closeConnection();
        }
        public JSON_RPC_Server.ServiceMode Mode { get; private set; }
        public void setMode(JSON_RPC_Server.ServiceMode mode)
        {
            Connection.setModeOfHost(mode);
            this.Mode = mode;
        }
        public override string ToString()
        {
            return this.ID;
        }
    }
}
