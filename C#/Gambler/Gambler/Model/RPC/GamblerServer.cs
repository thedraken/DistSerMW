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
        // the enclosing gambler
        private Gambler gambler;
        // IP address of the gambler's JSON-RPC server interface
        private String gamblerIP;
        // port on which the gambler's JSON-RPC server listens
        private int gamblerPort;

        private Thread socketListeningThread;

        private JsonSerializer jsonSerializer;
        private SocketListener gamblerSocketListener;

        public GamblerServer(Gambler gambler, String gamblerIP, int gamblerPort)
        {
            this.gamblerIP = gamblerIP;
            this.gambler = gambler;
            this.gamblerPort = gamblerPort;
            jsonSerializer = new JsonSerializer();
        }

        public String getGamblerIP()
        {
            return gamblerIP;
        }

        public int getGamblerPort()
        {
            return gamblerPort;
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
                gamblerSocketListener = new SocketListener(gamblerPort, interceptor);
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
    public JsonResponse interceptRequest(JsonRequest jsonRequest)
    {
        // print intercepted request on the console
        String request = JsonConvert.SerializeObject(jsonRequest);
        Console.WriteLine("intercepted request: " + request);
        JsonResponse response = null;
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

    // HINT 1: 	this message returns an JsonResponse object, in case that it shall do nothing with it, simply return null.
    // HINT 2: 	If you want to have more details on the interceptors you can have a look at  
    //			the code in the class ClientConnectionHandler Class located in the JsonRPCScoketServer.cs file in the MyBookie Project

    public void interceptResponse(JsonRequest jsonRequest, JsonResponse jsonResponse)
    {
        String request = JsonConvert.SerializeObject(jsonRequest);
        String response = JsonConvert.SerializeObject(jsonResponse);
        if (_listOfResponsesAndRequest.Where(t => t.Request.Id.ToString().Equals(jsonRequest.Id.ToString())).Count() == 0)
            _listOfResponsesAndRequest.Add(new RequestResponse(jsonRequest, jsonResponse));
        // print intercepted request/respons-pair on the console
        Console.WriteLine("intercepted response: " + response + " for request: " + request);
    }
}

public class RequestResponse
{
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
    [JsonRpcMethod]
    public String sayHelloToGambler(String bookieName)
    {
        // implementation of the sayHelloToBookie method, which
        // can be invoked remotely with one argument of
        // type String, returning another String
        Console.WriteLine("sayHelloToGambler(" + bookieName + ")");
        return "Gambler says: Hello, bookie " + bookieName;
    }
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
        foreach (string s in array)
        {
            if (s.StartsWith("bookieID"))
                bookieID = s.Split(':')[1];
            else if (s.StartsWith("id"))
                id = int.Parse(s.Split(':')[1]);
            else if (s.StartsWith("teamA"))
                teamA = s.Split(':')[1];
            else if (s.StartsWith("teamB"))
                teamB = s.Split(':')[1];
            else if (s.StartsWith("oddsA"))
                oddsA = float.Parse(s.Split(':')[1], CultureInfo.InvariantCulture);
            else if (s.StartsWith("oddsB"))
                oddsB = float.Parse(s.Split(':')[1], CultureInfo.InvariantCulture);
            else if (s.StartsWith("limit"))
                limit = float.Parse(s.Split(':')[1], CultureInfo.InvariantCulture);
            else if (s.StartsWith("oddsDraw"))
                oddsDraw = float.Parse(s.Split(':')[1], CultureInfo.InvariantCulture);
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
    [JsonRpcMethod]
    public bool setOdds(String bookieName, int matchID, string team, float newOdds)
    {
        SetOddsResult sor = new SetOddsResult(bookieName, matchID, team, newOdds);
        RecievedMessage rm = new RecievedMessage(sor, RecievedMessage.MessageType.setOdds);
        return addUpdate(rm);
    }
    [JsonRpcMethod]
    public bool endBet(String bookieName, int matchID, string winningTeam, float amountWon)
    {
        EndBetResult ebr = new EndBetResult(bookieName, matchID, winningTeam, amountWon);
        RecievedMessage rm = new RecievedMessage(ebr, RecievedMessage.MessageType.endBet);
        return addUpdate(rm);
    }
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
    public ObservableCollection<RecievedMessage> getList()
    {
        lock (_lock)
        {
            return this._listOfUpdates;
        }
    }
}

public class RecievedMessage
{
    private static int _id = 0;
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
        this.OddsDraw = OddsDraw;
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