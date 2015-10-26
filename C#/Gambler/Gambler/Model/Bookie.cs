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
            connection = new RPC.BookieConnection(connectingGambler, address.ToString(), portNo);
            connection.establishSocketConnection();
            this.iD = connection.sendConnect();
            updatePending = true;
            listOfBets.CollectionChanged += handleListChange;
            listOfMatches.CollectionChanged += handleListChange;
        }
        private object lockObj = new object();
        public ObservableCollection<Bet> listOfBets { get; private set; }
        public ObservableCollection<Match> listOfMatches { get; private set; }
        public void addBet(Bet bet)
        {
            this.listOfBets.Add(bet);
        }
        public Model.RPC.BookieConnection connection { get; private set; }
        public bool updatePending { get; private set; }
        public void processedUpdate()
        {
            lock (lockObj)
            {
                updatePending = false;    
            }
        }
        private void handleListChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            lock (lockObj)
            {
                updatePending = true;
            }
        }
    }
}
