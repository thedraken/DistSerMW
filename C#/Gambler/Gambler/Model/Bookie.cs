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
            Connection = new RPC.BookieConnection(connectingGambler, address.ToString(), portNo);
            Connection.establishSocketConnection();
            this.ID = Connection.sendConnect();
            this._connectingGambler = connectingGambler;
            this._connectingGambler.Connection.Service.getList().CollectionChanged += handleUpdates;
        }
        private Gambler _connectingGambler;
        private object lockObj = new object();
        private ObservableCollection<Bet> _listOfBets;
        private ObservableCollection<Match> _listOfMatches;
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
        private void addMatch(Match m)
        {
            lock (lockObj)
            {
                this._listOfMatches.Add(m);
            }
        }
        private void handleUpdates(object sender, NotifyCollectionChangedEventArgs e)
        {
            for (int i = 0; i < e.NewItems.Count; i++)
            {
                RecievedMessage rm = (RecievedMessage)e.NewItems[i];
                string data = rm.Result.ToString().Trim('{');
                data = data.Trim('}');
                data = data.Replace("\r\n", "");
                data = data.Replace("\"", "");
                data = data.Replace(" ", "");
                string[] array = data.Split(',');
                switch (rm.Type)
                {
                    case RecievedMessage.MessageType.matchStarted:
                        int id = int.MinValue;
                        string teamA = string.Empty;
                        string teamB = string.Empty;
                        float oddsA = float.MinValue;
                        float oddsB = float.MinValue;
                        int limit = int.MinValue;
                        foreach (string s in array)
                        {
                            if (s.StartsWith("bookieID"))
                            {
                                if (s.Split(':')[1] != this.ID)
                                    break;
                            }
                            else if (s.StartsWith("id"))
                                id = int.Parse(s.Split(':')[1]);
                            else if (s.StartsWith("teamA"))
                                teamA = s.Split(':')[1];
                            else if (s.StartsWith("teamB"))
                                teamB = s.Split(':')[1];
                            else if (s.StartsWith("oddsA"))
                                oddsA = float.Parse(s.Split(':')[1]);
                            else if (s.StartsWith("oddsB"))
                                oddsB = float.Parse(s.Split(':')[1]);
                            else if (s.StartsWith("limit"))
                                limit = int.Parse(s.Split(':')[1]);
                        }
                        if (teamA != string.Empty && teamB != string.Empty)
                        {
                            Match m = new Match(id, teamA, oddsA, teamB, oddsB, limit, this);
                            addMatch(m);
                        }
                        break;
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

    }
}
