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
    class BookieController
    {
        public BookieController()
        {
            ListOfBookies = new ObservableCollection<Model.Bookie>();
            ListOfMatches = new ObservableCollection<Model.Match>();
            ListOfAllBets = new ObservableCollection<Model.Bet>();
            ListOfAllWinnings = new ObservableCollection<Model.Winnings>();
        }
        public ObservableCollection<Model.Bookie> ListOfBookies { get; private set; }
        public ObservableCollection<Model.Match> ListOfMatches { get; private set; }
        public ObservableCollection<Model.Bet> ListOfAllBets { get; private set; }
        public ObservableCollection<Model.Winnings> ListOfAllWinnings { get; private set; }
        public void sayHello(string bookieName)
        {
            foreach (Model.Bookie b in ListOfBookies.Where(t => t.ID == bookieName))
                b.sayHello();
        }
        public void connectBookie(Model.Gambler gambler, IPAddress address, int portNo)
        {
            Model.Bookie b = new Model.Bookie(gambler, address, portNo);
            ListOfBookies.Add(b);
            b.ListOfMatches.CollectionChanged += handleNewMatch;
            b.ListOfBets.CollectionChanged += handleNewBet;
            b.ListOfWinnings.CollectionChanged += handleNewWinnings;
        }
        public void refreshMatches()
        {
            foreach (Model.Bookie b in ListOfBookies)
                b.refreshMatches();
        }
        public void placeBet(Model.Match m, string teamName, float amount, float odds)
        {
            Model.Bet b = new Model.Bet(m.OwningBookieID, m.ID, teamName, amount, odds);
            Model.Bookie bookie = ListOfBookies.Where(t => t.ID.Equals(m.OwningBookieID)).FirstOrDefault();
            bookie.addBet(b);
        }
        public void closeConnection()
        {
            foreach (Model.Bookie bk in ListOfBookies)
                bk.closeConnection();
        }
        private void handleNewMatch(object sender, NotifyCollectionChangedEventArgs e)
        {
            ListOfMatches.Clear();
            foreach (Model.Bookie b in ListOfBookies)
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
    }
}
