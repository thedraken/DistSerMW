using AustinHarris.JsonRpc;
using Gambler.Model.RPC.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gambler.Model.RPC
{
    public class BookieConnection : JsonRpcConnection
    {

        private String bookieID; // bookie-ID of the bookie on the other side of this connection
        private Gambler gambler;   // the enclosing bookie

        public BookieConnection(Gambler gambler, String gamblerIP, int gamblerPort) : base(gambler.ID, gamblerIP, gamblerPort)
        {
            // initialize JsonRpcConnection base class
            this.gambler = gambler;
        }

        public void sayHello()
        {
            object[] parameter = new object[] {
                gambler.ID
            };
            JsonResponse response = handleJsonRpcRequest("sayHelloToBookie", parameter);

            // show hello message returned by gambler
            String sayHelloResponse = response.Result.ToString();

            Console.WriteLine("Bookie " + bookieID + " sent response: " + sayHelloResponse);
        }

        public String sendConnect()
        {
            // connect the bookie 
            object[] parameter = new object[] {
                gambler.ID,
                gambler.Address.ToString(),
                gambler.PortNo
            };
            JsonResponse response = handleJsonRpcRequest("connect", parameter);

            String bookieID = response.Result.ToString();

            Trace.TraceInformation("connected with bookie " + bookieID);
            this.bookieID = bookieID;
            return bookieID;
        }

        public PlaceBetResult placeBet(Bet b)
        {
            object[] parameter = new object[] {
                gambler.ID,
                b.MatchID,
                b.TeamID,
                b.Odds,
                b.Stake
            };
            JsonResponse response = handleJsonRpcRequest("placeBet", parameter);
            return (PlaceBetResult)Enum.Parse(typeof(PlaceBetResult), response.Result.ToString());
        }
        public bool showMatches()
        {
            object[] parameter = new object[] {
                gambler.ID
            };
            JsonResponse response = handleJsonRpcRequest("showMatches", parameter);
            Object result = response.Result.ToString();

            Trace.TraceInformation("connected with bookie " + bookieID);
            return true;
        }
    }
}
