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

        public ObservableCollection<Model.Bookie> listOfBookies { get; private set; }
        public List<Model.Bet> listOfAllBets
        {
            get
            {
                List<Model.Bet> list = new List<Model.Bet>();
                foreach (Model.Bookie b in listOfBookies.Where(t=> t.listOfBets.Count > 0))
                    list.AddRange(b.listOfBets);
                return list;
            }
        }
        public List<Model.Bet> listOfAllOpenBets
        {
            get
            {
                return listOfAllBets.Where(t => t.validBet && t.openBet).ToList();
            }
        }
        public List<Model.Match> listOfAllMatches
        {
            get
            {
                List<Model.Match> list = new List<Model.Match>();
                foreach (Model.Bookie b in listOfBookies.Where(t => t.listOfMatches.Count > 0))
                    list.AddRange(b.listOfMatches);
                return list;
            }
        }
        public List<Model.Match> listOfOpenMatches
        {
            get
            {
                return listOfAllMatches.Where(t => t.openMatch).ToList();
            }
        }
        public Model.Bookie connectBookie(Model.Gambler gambler, IPAddress address, int portNo)
        {
            Model.Bookie b = new Model.Bookie(gambler, address, portNo);
            listOfBookies.Add(b);
            return b;
        }
        public bool updatePending()
        {
            bool toReturn = listOfBookies.Any(t => t.updatePending);
            foreach (Model.Bookie b in listOfBookies.Where(t => t.updatePending))
                b.processedUpdate();
            return toReturn;
        }
    }
}
