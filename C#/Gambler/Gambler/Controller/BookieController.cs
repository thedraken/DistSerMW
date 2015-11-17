using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        }

        public ObservableCollection<Model.Bookie> ListOfBookies { get; private set; }
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
        public List<Model.Match> ListOfAllMatches
        {
            get
            {
                List<Model.Match> list = new List<Model.Match>();
                foreach (Model.Bookie b in ListOfBookies.Where(t => t.ListOfMatches.Count > 0))
                    list.AddRange(b.ListOfMatches);
                return list;
            }
        }
        public List<Model.Match> ListOfOpenMatches
        {
            get
            {
                return ListOfAllMatches.Where(t => t.OpenMatch).ToList();
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
        }
        public bool updatePending()
        {
            bool toReturn = ListOfBookies.Any(t => t.UpdatePending);
            foreach (Model.Bookie b in ListOfBookies.Where(t => t.UpdatePending))
                b.processedUpdate();
            return toReturn;
        }
    }
}
