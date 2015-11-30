using AustinHarris.JsonRpc;
using Gambler.Model.RPC.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
        /// <summary>
        /// Allows a Gambler to say hello to a bookie
        /// </summary>
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
        /// <summary>
        /// Closes a connection with a bookie
        /// </summary>
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
        /// <summary>
        /// Connects with a Bookie
        /// </summary>
        /// <returns>The unique ID of the bookie</returns>
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
        /// <summary>
        /// Allows a gambler to place a bet, will return a string of the message sent back from the bookie
        /// </summary>
        /// <param name="b">The bet to place against the bookie</param>
        /// <returns>The message returned by the bookie server</returns>
        public string placeBet(Bet b)
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
            while (response == null || response.Result.ToString().Equals(PlaceBetResult.LOST_CONNECTION.ToString()))
            {
                //Will rety up to 3 times (As set in _maxRetries). We don't mind sending a duplicate message, as the bookie will handle it and reply back with the previous response
                if (_retry > _maxRetries)
                    return PlaceBetResult.LOST_CONNECTION.ToString();
                _retry++;
                //Sleep for 10 seconds so we can do initial test scenario
                //Other wise we can't test another user beating this gambler to the punch of creating a bet
                Thread.Sleep(10000);
                response = handleJsonRpcRequest("placeBet", parameter, messageID);
            }
            return response.Result.ToString();
        }
        /// <summary>
        /// Gets a list of all open matches from the bookie
        /// </summary>
        /// <param name="requestingB">The bookie to request the matches from</param>
        /// <returns>A list of open matches</returns>
        public List<Match> showMatches(Bookie requestingB)
        {
            object[] parameter = new object[] {
                _gambler.ID
            };
            JsonResponse response = handleJsonRpcRequest("showMatches", parameter, this._gambler.getNextMessageID());
            if (response != null)
            {
                string[] array = responseToStringArray(response);
                List<Match> listOfMatches = new List<Match>();
                foreach (string str in array)
                {
                    if (str.Contains(","))
                    {
                        string bookieID = string.Empty;
                        int id = int.MinValue;
                        string teamA = string.Empty;
                        string teamB = string.Empty;
                        float oddsA = float.MinValue;
                        float oddsB = float.MinValue;
                        float oddsDraw = float.MinValue;
                        float limit = float.MinValue;
                        string[] matchData = str.Split(',');
                        Controller.FunctionController f = Controller.FunctionController.getInstance();
                        foreach (string m in matchData)
                        {
                            if (m.StartsWith("bookieID"))
                                bookieID = m.Split(':')[1];
                            else if (m.StartsWith("id") && !f.isInt(m.Split(':')[1], out id))
                                throw new Exception("Match ID is not in an integer format");
                            else if (m.StartsWith("teamA"))
                                teamA = m.Split(':')[1];
                            else if (m.StartsWith("teamB"))
                                teamB = m.Split(':')[1];
                            else if (m.StartsWith("oddsA") && !f.isFloat(m.Split(':')[1], out oddsA))
                                throw new Exception("Odds A was not a valid float value");
                            else if (m.StartsWith("oddsB") && !f.isFloat(m.Split(':')[1], out oddsB))
                                throw new Exception("Odds B was not a valid float value");
                            else if (m.StartsWith("limit") && !f.isFloat(m.Split(':')[1], out limit))
                                throw new Exception("Stake was not a valid float value");
                            else if (m.StartsWith("oddsDraw") && !f.isFloat(m.Split(':')[1], out oddsDraw))
                                throw new Exception("Odds draw was not a valid float value");
                        }
                        if (teamA != string.Empty && teamB != string.Empty && bookieID != string.Empty && bookieID == requestingB.ID)
                            listOfMatches.Add(new Match(id, teamA, oddsA, teamB, oddsB, oddsDraw, limit, requestingB));
                    }
                }
                return listOfMatches;
            }
            return new List<Match>();
        }
        private static string[] responseToStringArray(JsonResponse response)
        {
            string data = response.Result.ToString();
            data = data.Replace("\r\n", "");
            data = data.Replace("\"", "");
            data = data.Replace(" ", "");
            string[] array = data.Split(new char[] { '{', '}' }, StringSplitOptions.RemoveEmptyEntries);
            return array;
        }
        /// <summary>
        /// Asks the bookies for a list of bets that have been placed against a specific match ID, this allows for better knowledge for the gambler to place wise bets
        /// </summary>
        /// <param name="m">The match to get the list of bets for</param>
        /// <returns>A list of bets returned by the bookie</returns>
        public List<Bet> getOtherBetsPlaced(Match m)
        {
            List<Bet> listOfBets = new List<Bet>();
            object[] parameter = new object[]{
                _gambler.ID,
                m.ID
            };
            string messageID = this._gambler.getNextMessageID();
            JsonResponse response = handleJsonRpcRequest("getMatchBets", parameter, messageID);
            if (response != null)
            {
                string[] array = responseToStringArray(response);
                foreach (string s in array)
                {
                    if (s.Contains(","))
                    {
                        string[] betData = s.Split(',');
                        string bookieID = string.Empty;
                        int matchID = int.MinValue;
                        string teamID = string.Empty;
                        float stake = float.MinValue;
                        float odds = float.MinValue;
                        Controller.FunctionController f = Controller.FunctionController.getInstance();
                        foreach (string b in betData)
                        {
                            if (b.StartsWith("bookieID"))
                                bookieID = b.Split(':')[1];
                            else if (b.StartsWith("matchID") && !f.isInt(b.Split(':')[1], out matchID))
                                throw new Exception("Match ID is not in an integer format");
                            else if (s.StartsWith("amount") && !f.isFloat(s.Split(':')[1], out stake))
                                throw new Exception("Stake was not a valid float value");
                            else if (b.StartsWith("team"))
                                teamID = b.Split(':')[1];
                            else if (s.StartsWith("odds") && !f.isFloat(s.Split(':')[1], out odds))
                                throw new Exception("Odds was not a valid float value");
                        }
                        if (bookieID != string.Empty && matchID != int.MinValue)
                            listOfBets.Add(new Bet(bookieID, matchID, teamID, stake, odds));
                    }
                }
            }
            return listOfBets;
        }
        /// <summary>
        /// Requests any previous winnings the gambler didn't recieve before he disconnected
        /// </summary>
        /// <returns>A float amount of any winnings, this could be zero</returns>
        public float getPreviousWinnings()
        {
            object[] parameter = new object[]{
                _gambler.ID
            };
            string messageID = this._gambler.getNextMessageID();
            JsonResponse response = handleJsonRpcRequest("getPreviousWinnings", parameter, messageID);
            if (response != null)
            {
                float ret = 0;
                if (Controller.FunctionController.getInstance().isFloat(response.Result.ToString(), out ret))
                    return ret;
            }
            return 0;
        }
    }
}
