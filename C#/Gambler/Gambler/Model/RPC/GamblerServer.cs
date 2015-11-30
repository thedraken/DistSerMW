using AustinHarris.JsonRpc;
using Gambler;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Gambler.Model;
using JSON_RPC_Server;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Gambler.Model.RPC.Common;
using System.Globalization;

namespace Gambler.Model.RPC
{
    public class GamblerServer
    {
        private Gambler gambler;
        private Thread socketListeningThread;
        private JsonSerializer jsonSerializer;
        private SocketListener gamblerSocketListener;
        public GamblerServer(Gambler gambler)
        {
            this.gambler = gambler;
            jsonSerializer = new JsonSerializer();
        }
        public MyGamblerService Service { get; private set; }
        public void createGamblerServerInterface()
        {
            // create an instance of the service
            Service = new MyGamblerService(gambler);

            // start a JSON-RPC server; all methods tagged with the [JsonRpcMethod] attribute
            // will be invokable remotely; all requests as well as all responses will be
            // passed on to the interceptor; please note that the server will
            // automatically expose an additional method to control how requests will be
            // processed;
            // pass a simple interceptor, which simply prints all intercepted requests
            // and responses


            // This creates an Interceptor that has the two functions interceptRequest and interceptResponse
            //Follwoing the code for an Interceptor which simply prints all intercepted requests
            // and responses, just for illustration purposes
            Interceptor interceptor = new SampleInterceptor();
            gamblerSocketListener = null;
            try
            {
                // launch a socket listener accepting and handling JSON-RPC requests
                gamblerSocketListener = new SocketListener(gambler.PortNo, interceptor);
            }
            catch (IOException e)
            {
             
                Console.WriteLine(e.ToString());
            }
            if (gamblerSocketListener != null)
            {
                socketListeningThread = new Thread(new ThreadStart(gamblerSocketListener.start));
                socketListeningThread.IsBackground = true;
                socketListeningThread.Start();
            }
        }
        public void destroyGamblerServerInterface()
        {
            try
            {
                //Destroy the service object
                Service = null;
                //Stop the socket listener
                gamblerSocketListener.stop();
            }
            catch
            {

            }
        }
    }
}


class SampleInterceptor : JSON_RPC_Server.Interceptor
{
    private List<RequestResponse> _listOfResponsesAndRequest = new List<RequestResponse>();
    /// <summary>
    /// Intecepts incoming jsonRequests, checks to see if already answered and if so will reply with the previous response
    /// </summary>
    /// <param name="jsonRequest">The JSON request sent</param>
    /// <returns>A null if we need to run the function, or the previous response if we've already handled it</returns>
    public JsonResponse interceptRequest(JsonRequest jsonRequest)
    {
        // print intercepted request on the console
        String request = JsonConvert.SerializeObject(jsonRequest);
        Console.WriteLine("intercepted request: " + request);
        JsonResponse response = null;
        //The request ID is made up of bookie name and the unique number for that message
        if (jsonRequest.Id != null)
        {
            var data = _listOfResponsesAndRequest.Where(t=> t.Request.Id.ToString().Equals(jsonRequest.Id.ToString()));
            if (data.Count() > 0 && data.First().Response != null)
            {
                response = data.First().Response;
                Console.WriteLine("Duplicate request recieved, sending original response back");
            }
        }
        return response;
    }
    /// <summary>
    /// An interceptor for the responses to be sent to the requesting client
    /// </summary>
    /// <param name="jsonRequest">The request for data</param>
    /// <param name="jsonResponse">The response of data</param>
    public void interceptResponse(JsonRequest jsonRequest, JsonResponse jsonResponse)
    {
        String request = JsonConvert.SerializeObject(jsonRequest);
        String response = JsonConvert.SerializeObject(jsonResponse);
        //We haven't had the message before from the request, let's add it to the list of processed messages
        if (_listOfResponsesAndRequest.Where(t => t.Request.Id.ToString().Equals(jsonRequest.Id.ToString())).Count() == 0)
            _listOfResponsesAndRequest.Add(new RequestResponse(jsonRequest, jsonResponse));
        Console.WriteLine("intercepted response: " + response + " for request: " + request);
    }
}

public class RequestResponse
{
    /// <summary>
    /// Any requests processed by the Gambler will be stored as a request response pair. Helps preventing duplicate messages sent to the gambler
    /// </summary>
    /// <param name="request">The JSÒN request message</param>
    /// <param name="response">The JSON response message</param>
    public RequestResponse(JsonRequest request, JsonResponse response)
    {
        this.Request = request;
        this.Response = response;
    }
    public JsonRequest Request { get; private set; }
    public JsonResponse Response { get; private set; }
}

/// <summary>
/// The class implementing the methods that are exposed via JSON-RPC.
/// The methods that should be exposed are tagged with [JsonRpcMethod]
/// </summary>
public class MyGamblerService : JsonRpcService
{
    private Gambler.Model.Gambler gambler;
    public MyGamblerService(Gambler.Model.Gambler gambler)
    {
        this.gambler = gambler;
    }
    private object _lock = new object();
    /// <summary>
    /// Recieves a message to the gambler asking for a hello to be sent back
    /// </summary>
    /// <param name="bookieName">The bookie that sent the request</param>
    /// <returns>The message returned by the gambler, this is the bookie ID with added flair</returns>
    [JsonRpcMethod]
    public String sayHelloToGambler(String bookieName)
    {
        // implementation of the sayHelloToBookie method, which
        // can be invoked remotely with one argument of
        // type String, returning another String
        Console.WriteLine("sayHelloToGambler(" + bookieName + ")");
        return "Gambler says: Hello, bookie " + bookieName;
    }
    /// <summary>
    /// A message recieved saying a match has been started by the bookie
    /// </summary>
    /// <param name="bookieName">The name of the bookie starting the match</param>
    /// <param name="recievedMatch">The JSON object recieved</param>
    /// <returns>A boolean confirming if the match was processed correctly or not</returns>
    [JsonRpcMethod]
    public bool matchStarted(String bookieName, object recievedMatch)
    {
        string data = recievedMatch.ToString().Trim('{');
        data = data.Trim('}');
        data = data.Replace("\r\n", "");
        data = data.Replace("\"", "");
        data = data.Replace(" ", "");
        string[] array = data.Split(',');
        string bookieID = string.Empty;
        int id = int.MinValue;
        string teamA = string.Empty;
        string teamB = string.Empty;
        float oddsA = float.MinValue;
        float oddsB = float.MinValue;
        float oddsDraw = float.MinValue;
        float limit = float.MinValue;
        Gambler.Controller.FunctionController f = Gambler.Controller.FunctionController.getInstance();
        foreach (string s in array)
        {
            if (s.StartsWith("bookieID"))
                bookieID = s.Split(':')[1];
            else if (s.StartsWith("id") && !f.isInt(s.Split(':')[1], out id))
                throw new Exception("Match ID is not in an integer format");
            else if (s.StartsWith("teamA"))
                teamA = s.Split(':')[1];
            else if (s.StartsWith("teamB"))
                teamB = s.Split(':')[1];
            else if (s.StartsWith("oddsA") && !f.isFloat(s.Split(':')[1], out oddsA))
                throw new Exception("Odds A was not a valid float value");
            else if (s.StartsWith("oddsB") && !f.isFloat(s.Split(':')[1], out oddsB))
                throw new Exception("Odds B was not a valid float value");
            else if (s.StartsWith("limit") && !f.isFloat(s.Split(':')[1], out limit))
                throw new Exception("The limit was not a valid float value");
            else if (s.StartsWith("oddsDraw") && !f.isFloat(s.Split(':')[1], out oddsDraw))
                throw new Exception("Odds draw was not a valid float value");
        }
        if (teamA != string.Empty && teamB != string.Empty && bookieID != string.Empty)
        {
            MatchStartedResult msr = new MatchStartedResult(bookieID, id, teamA, teamB, oddsA, oddsB, oddsDraw, limit);
            RecievedMessage rm = new RecievedMessage(msr, RecievedMessage.MessageType.matchStarted);
            return addUpdate(rm);
        }
        else
            return false;
    }
    /// <summary>
    /// A message recieved saying there has been an update to the match odds
    /// </summary>
    /// <param name="bookieName">The name of the bookie sending the update</param>
    /// <param name="matchID">The match ID to update</param>
    /// <param name="team">The team odds to update</param>
    /// <param name="newOdds">The new float value to update the odds to</param>
    /// <returns>A boolean confirming if the update was processed correctly or not</returns>
    [JsonRpcMethod]
    public bool setOdds(String bookieName, int matchID, string team, float newOdds)
    {
        SetOddsResult sor = new SetOddsResult(bookieName, matchID, team, newOdds);
        RecievedMessage rm = new RecievedMessage(sor, RecievedMessage.MessageType.setOdds);
        return addUpdate(rm);
    }
    /// <summary>
    /// A message recieved saying the match has ended and any winnings recieved
    /// </summary>
    /// <param name="bookieName">The name of the bookie sending the message</param>
    /// <param name="matchID">The match ID that has ended</param>
    /// <param name="winningTeam">The team that won the match</param>
    /// <param name="amountWon">The amount won by the user, this can be 0</param>
    /// <returns>A boolean confirming if the update was processed correctly or not</returns>
    [JsonRpcMethod]
    public bool endBet(String bookieName, int matchID, string winningTeam, float amountWon)
    {
        EndBetResult ebr = new EndBetResult(bookieName, matchID, winningTeam, amountWon);
        RecievedMessage rm = new RecievedMessage(ebr, RecievedMessage.MessageType.endBet);
        return addUpdate(rm);
    }
    /// <summary>
    /// A message recieved that states a bookie is closing their connection
    /// </summary>
    /// <param name="bookieName">The bookie's name that is closing their connection</param>
    /// <returns>A boolean confirming if the update was processed correctly or not</returns>
    [JsonRpcMethod]
    public bool bookieExiting(String bookieName)
    {
        BookieExitingResult ber = new BookieExitingResult(bookieName);
        return addUpdate(new RecievedMessage(ber, RecievedMessage.MessageType.bookieExiting));
    }
    private bool addUpdate(RecievedMessage rm)
    {
        lock (_lock)
        {
            if (_listOfUpdates.Contains(rm))
                return false;
            else
            {
                _listOfUpdates.Add(rm);
                return true;
            }   
        }
    }
    private ObservableCollection<RecievedMessage> _listOfUpdates = new ObservableCollection<RecievedMessage>();
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public ObservableCollection<RecievedMessage> getList()
    {
        lock (_lock)
        {
            return this._listOfUpdates;
        }
    }
}
/// <summary>
/// Creates a class that stores the data that has been previously recieved
/// </summary>
public class RecievedMessage
{
    private static int _id = 0;
    /// <summary>
    /// Creates a class of the result recieved and the type of method that was called
    /// </summary>
    /// <param name="result"></param>
    /// <param name="type"></param>
    public RecievedMessage(Result result, MessageType type)
    {
        this.Result = result;
        this.Type = type;
        this.ID = ++_id;
    }
    public int ID { get; private set; }
    public enum MessageType
    {
        setOdds,
        matchStarted,
        endBet,
        bookieExiting
    }
    public Result Result { get; private set; }
    public MessageType Type { get; private set; }
    public override bool Equals(object obj)
    {
        if (!obj.GetType().Equals(this.GetType()))
            return false;
        RecievedMessage rm = (RecievedMessage)obj;
        if (!rm.Result.Equals(this.Result))
            return false;
        if (!rm.Type.Equals(this.Type))
            return false;
        return true;
    }
    public override int GetHashCode()
    {
        return ID;
    }
}
public abstract class Result
{
    public Result(string bookieID, int matchID)
    {
        this.BookieID = bookieID;
        this.MatchID = matchID;
    }
    public string BookieID { get; private set; }
    public int MatchID { get; private set; }
}
public class EndBetResult : Result
{
    public EndBetResult(string bookieID, int matchID, string winningTeam, float amountWon)
        : base(bookieID, matchID)
    {
        this.AmountWon = amountWon;
        this.WinningTeam = winningTeam;
    }
    
    public string WinningTeam { get; private set; }
    public float AmountWon { get; private set; }
    public override bool Equals(object obj)
    {
        if (obj.GetType() != this.GetType())
            return false;
        EndBetResult ebr = (EndBetResult)obj;
        if (!ebr.MatchID.Equals(this.MatchID))
            return false;
        if (!ebr.BookieID.Equals(this.BookieID))
            return false;
        return true;
    }
    public override int GetHashCode()
    {
        return MatchID;
    }
}
public class SetOddsResult : Result
{
    private static int _id = 0;
    public SetOddsResult(string bookieID, int matchID, string teamName, float newOdds)
        : base(bookieID, matchID)
    {
        this.TeamName = teamName;
        this.NewOdds = newOdds;
        this.ID = ++_id;
    }
    public int ID { get; private set; }
    public string TeamName { get; private set; }
    public float NewOdds { get; private set; }
    public override bool Equals(object obj)
    {
        return false;
    }
    public override int GetHashCode()
    {
        return ID;
    }
}
public class MatchStartedResult : Result
{
    public MatchStartedResult(string bookieID, int id, string teamA, string teamB, float oddsA, float oddsB, float oddsDraw, float limit)
        : base(bookieID, id)
    {   
        this.TeamA = teamA;
        this.TeamB = teamB;
        this.OddsA = oddsA;
        this.OddsB = oddsB;
        this.Limit = limit;
        this.OddsDraw = oddsDraw;
    }
    
    public string TeamA { get; private set; }
    public string TeamB { get; private set; }
    public float OddsA { get; private set; }
    public float OddsB { get; private set; }
    public float OddsDraw { get; private set; }
    public float Limit { get; private set; }
    public override bool Equals(object obj)
    {
        if (obj.GetType() != this.GetType())
            return false;
        MatchStartedResult msr = (MatchStartedResult)obj;
        if (!msr.MatchID.Equals(this.MatchID))
            return false;
        if (!msr.BookieID.Equals(this.BookieID))
            return false;
        return true;
    }
    public override int GetHashCode()
    {
        return MatchID;
    }
}
public class BookieExitingResult : Result
{
    public BookieExitingResult(string bookieID)
        : base(bookieID, 0)
    {

    }
}