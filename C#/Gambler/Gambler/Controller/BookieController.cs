using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Gambler.Controller
{
    public class BookieController
    {
        public BookieController()
        {
            ListOfMatches = new ObservableCollection<Model.Match>();
            ListOfAllBets = new ObservableCollection<Model.Bet>();
            ListOfAllWinnings = new ObservableCollection<Model.Winnings>();
        }
        private object lockObj = new object();
        private ObservableCollection<Model.Bookie> _listOfBookies = new ObservableCollection<Model.Bookie>();
        /// <summary>
        /// Observable list of bookies, if this list changes, will fire the list updated event
        /// </summary>
        public ObservableCollection<Model.Bookie> ListOfBookies { get { lock(lockObj){return this._listOfBookies;}} }
        /// <summary>
        /// Observable list of mathces, if this list changes, will fire the list updated event
        /// </summary>
        public ObservableCollection<Model.Match> ListOfMatches { get; private set; }
        /// <summary>
        /// Returns a clone of the list of matches, this will prevent the system using the latest updates pushed up by messages recieved and allows testing of certain functions
        /// </summary>
        /// <returns>A clone list of the matches</returns>
        public List<Model.Match> getCloneOfMatches()
        {
            List<Model.Match> retList = new List<Model.Match>();
            lock (lockObj)
            {
                foreach (Model.Match m in ListOfMatches)
                {
                    Model.Bookie b = _listOfBookies.Where(t=> t.ID.Equals(m.OwningBookieID)).FirstOrDefault();
                    retList.Add(new Model.Match(m.ID, m.TeamA, m.OddsA, m.TeamB, m.OddsB, m.OddsDraw, m.Limit, b));
                }
            }
            return retList;
        }
        /// <summary>
        /// Observable list of bets, if this list changes, will fire the list updated event
        /// </summary>
        public ObservableCollection<Model.Bet> ListOfAllBets { get; private set; }
        /// <summary>
        /// Observable list of winnings, if this list changes, will fire the list updated event
        /// </summary>
        public ObservableCollection<Model.Winnings> ListOfAllWinnings { get; private set; }
        /// <summary>
        /// Runs the hellow function against the bookie specified
        /// </summary>
        /// <param name="bookieName">The name of the bookie to whom we wish to say hello</param>
        public void sayHello(string bookieName)
        {
            foreach (Model.Bookie b in ListOfBookies.Where(t => t.ID == bookieName))
                b.sayHello();
        }
        /// <summary>
        /// Connects to the bookie with the address and port number specified
        /// </summary>
        /// <param name="gambler">The connecting gambler</param>
        /// <param name="address">The address of the bookie to connect to</param>
        /// <param name="portNo">The port number of the bookie to connect to</param>
        public void connectBookie(Model.Gambler gambler, IPAddress address, int portNo)
        {
            Model.Bookie b = new Model.Bookie(gambler, address, portNo);
            lock (lockObj)
            {
                _listOfBookies.Add(b);
            }
            b.ListOfMatches.CollectionChanged += handleNewMatch;
            b.ListOfBets.CollectionChanged += handleNewBet;
            b.ListOfWinnings.CollectionChanged += handleNewWinnings;
        }
        /// <summary>
        /// Gets an update of all matches currently open on each bookie
        /// </summary>
        public void refreshMatches()
        {
            foreach (Model.Bookie b in ListOfBookies)
                b.refreshMatches();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="teamName"></param>
        /// <param name="amount"></param>
        /// <param name="odds"></param>
        public void placeBet(Model.Match m, string teamName, float amount, float odds)
        {
            Model.Bet b = new Model.Bet(m.OwningBookieID, m.ID, teamName, amount, odds);
            Model.Bookie bookie = ListOfBookies.Where(t => t.ID.Equals(m.OwningBookieID)).FirstOrDefault();
            bookie.addBet(b);
        }
        public List<Model.Bet> getMatchBets(Model.Match m)
        {
            Model.Bookie bookie = ListOfBookies.Where(t => t.ID.Equals(m.OwningBookieID)).FirstOrDefault();
            return bookie.getBetsPlacedForMatch(m);
        }
        public void closeConnection()
        {
            foreach (Model.Bookie bk in ListOfBookies)
                bk.closeConnection();
        }
        private void handleNewMatch(object sender, NotifyCollectionChangedEventArgs e)
        {
            updateMatches();
        }
        public void updateMatches()
        {
            ListOfMatches.Clear();
            foreach (Model.Bookie b in ListOfBookies.Where(t => t.Connected))
            {
                foreach (Model.Match m in b.ListOfMatches.Where(t => t.OpenMatch))
                {
                    ListOfMatches.Add(m);
                }
            }
        }
        private void handleNewBet(object sender, NotifyCollectionChangedEventArgs e)
        {
            ListOfAllBets.Clear();
            foreach (Model.Bookie b in ListOfBookies)
            {
                foreach (Model.Bet bet in b.ListOfBets)
                {
                    ListOfAllBets.Add(bet);
                    foreach(Model.Match m in b.ListOfMatches.Where(t=> t.ID.Equals(bet.MatchID) && t.OwningBookieID.Equals(b.ID)))
                        m.placeBet(bet);
                }
            }
        }
        private void handleNewWinnings(object sender, NotifyCollectionChangedEventArgs e)
        {
            foreach(var ni in e.NewItems)
                ListOfAllWinnings.Add((Model.Winnings)ni);
        }
        public void setMode(string bookieName, JSON_RPC_Server.ServiceMode mode)
        {
            foreach (Model.Bookie b in ListOfBookies.Where(t => t.ID.Equals(bookieName)))
                b.setMode(mode);
        }
        public void removeClosedBookies()
        {
            lock(lockObj)
            {
                for (int i = _listOfBookies.Count - 1; i >= 0; i--)
                    _listOfBookies.RemoveAt(i);
            }
        }
    }
}
