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
            ListOfBets = new ObservableCollection<Bet>();
            ListOfMatches = new ObservableCollection<Match>();
            Connection = new RPC.BookieConnection(connectingGambler, address.ToString(), portNo);
            Connection.establishSocketConnection();
            this.ID = Connection.sendConnect();
            UpdatePending = true;
            ListOfBets.CollectionChanged += handleListChange;
            ListOfMatches.CollectionChanged += handleListChange;
        }
        private object lockObj = new object();
        public ObservableCollection<Bet> ListOfBets { get; private set; }
        public ObservableCollection<Match> ListOfMatches { get; private set; }
        public void addBet(Bet bet)
        {
            this.ListOfBets.Add(bet);
        }
        public Model.RPC.BookieConnection Connection { get; private set; }
        public bool UpdatePending { get; private set; }
        public void processedUpdate()
        {
            lock (lockObj)
            {
                UpdatePending = false;    
            }
        }
        private void handleListChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            lock (lockObj)
            {
                UpdatePending = true;
            }
        }
        public void sayHello()
        {
            Connection.sayHello();
        }
    }
}
