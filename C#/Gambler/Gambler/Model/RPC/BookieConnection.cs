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
        private String _bookieID; // bookie-ID of the bookie on the other side of this connection
        private Gambler _gambler;   // the enclosing bookie
        private int _retry = 0;
        private int _maxRetries = 3;
        public BookieConnection(Gambler gambler, String gamblerIP, int gamblerPort) : base(gambler.ID, gamblerIP, gamblerPort)
        {
            // initialize JsonRpcConnection base class
            this._gambler = gambler;
        }

        public void sayHello()
        {
            object[] parameter = new object[] {
                _gambler.ID
            };
            JsonResponse response = handleJsonRpcRequest("sayHelloToBookie", parameter, this._gambler.getNextMessageID());
            if (response != null)
            {
                String sayHelloResponse = response.Result.ToString();
                Console.WriteLine("Bookie " + _bookieID + " sent response: " + sayHelloResponse);
            }
        }
        public void closeConnection()
        {
            object[] parameter = new object[] {
                _gambler.ID
            };
            JsonResponse response = handleJsonRpcRequest("gamblerExiting", parameter, this._gambler.getNextMessageID());
            if (response != null)
                Console.WriteLine("Bookie " + _bookieID + " sent response to exit request: " + response.ToString());
            base.closeRPCConnection();
        }
        public String sendConnect()
        {
            // connect the bookie 
            object[] parameter = new object[] {
                _gambler.ID,
                _gambler.Address.ToString(),
                _gambler.PortNo
            };
            JsonResponse response = handleJsonRpcRequest("connect", parameter, this._gambler.getNextMessageID());
            if (response != null)
            {
                String bookieID = response.Result.ToString();

                Trace.TraceInformation("connected with bookie " + bookieID);
                this._bookieID = bookieID;
                return bookieID;
            }
            else
            {
                Trace.TraceInformation("failed to connect to bookie");
                return string.Empty;
            }
        }
        public PlaceBetResult placeBet(Bet b)
        {
            object[] parameter = new object[] {
                _gambler.ID,
                b.MatchID,
                b.TeamID,
                b.Odds,
                b.Stake
            };
            string messageID = this._gambler.getNextMessageID();
            JsonResponse response = handleJsonRpcRequest("placeBet", parameter, messageID);
            while (response == null)
            {
                if (_retry > _maxRetries)
                    return PlaceBetResult.LOST_CONNECTION;
                _retry++;
                response = handleJsonRpcRequest("placeBet", parameter, messageID);
            }
            return (PlaceBetResult)Enum.Parse(typeof(PlaceBetResult), response.Result.ToString());
        }
        public List<Match> showMatches(Bookie requestingB)
        {
            object[] parameter = new object[] {
                _gambler.ID
            };
            JsonResponse response = handleJsonRpcRequest("showMatches", parameter, this._gambler.getNextMessageID());
            if (response != null)
            {
                string data = response.Result.ToString();
                data = data.Replace("\r\n", "");
                data = data.Replace("\"", "");
                data = data.Replace(" ", "");
                string[] array = data.Split(new char[] { '{', '}' }, StringSplitOptions.RemoveEmptyEntries);
                List<Match> listOfMatches = new List<Match>();
                foreach (string s in array)
                {
                    if (s.Contains(","))
                    {
                        string bookieID = string.Empty;
                        int id = int.MinValue;
                        string teamA = string.Empty;
                        string teamB = string.Empty;
                        float oddsA = float.MinValue;
                        float oddsB = float.MinValue;
                        int limit = int.MinValue;
                        string[] matchData = s.Split(',');
                        foreach (string m in matchData)
                        {
                            if (m.StartsWith("bookieID"))
                                bookieID = m.Split(':')[1];
                            else if (m.StartsWith("id"))
                                id = int.Parse(m.Split(':')[1]);
                            else if (m.StartsWith("teamA"))
                                teamA = m.Split(':')[1];
                            else if (m.StartsWith("teamB"))
                                teamB = m.Split(':')[1];
                            else if (m.StartsWith("oddsA"))
                                oddsA = float.Parse(m.Split(':')[1]);
                            else if (m.StartsWith("oddsB"))
                                oddsB = float.Parse(m.Split(':')[1]);
                            else if (m.StartsWith("limit"))
                                limit = int.Parse(m.Split(':')[1]);
                        }
                        if (teamA != string.Empty && teamB != string.Empty && bookieID != string.Empty && bookieID == requestingB.ID)
                            listOfMatches.Add(new Match(id, teamA, oddsA, teamB, oddsB, limit, requestingB));
                    }
                }
                return listOfMatches;
            }
            return new List<Match>();
        }
    }
}
