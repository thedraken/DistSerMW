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
        }

        public ObservableCollection<Model.Bookie> ListOfBookies { get; private set; }
        public ObservableCollection<Model.Match> ListOfMatches { get; private set; }

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
        
        public List<Model.Bet> ListOfAllBets
        {
            get
            {
                List<Model.Bet> list = new List<Model.Bet>();
                foreach (Model.Bookie b in ListOfBookies.Where(t=> t.ListOfBets.Count > 0))
                    list.AddRange(b.ListOfBets);
                return list;
            }
        }
        public List<Model.Bet> ListOfAllOpenBets
        {
            get
            {
                return ListOfAllBets.Where(t => t.validBet && t.openBet).ToList();
            }
        }
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
        }
        public void refreshMatches()
        {
            foreach (Model.Bookie b in ListOfBookies)
                b.refreshMatches();
        }
    }
}
