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
            SocketListener gamblerSocketListener = null;
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
    }

}


class SampleInterceptor : JSON_RPC_Server.Interceptor
{


    //TODO implement a more meaningfull interceptor

    public JsonResponse interceptRequest(JsonRequest jsonRequest)
    {
        String request = JsonConvert.SerializeObject(jsonRequest);

        // print intercepted request on the console
        Console.WriteLine("intercepted request: " + request);
        return null;
    }

    // HINT 1: 	this message returns an JsonResponse object, in case that it shall do nothing with it, simply return null.
    // HINT 2: 	If you want to have more details on the interceptors you can have a look at  
    //			the code in the class ClientConnectionHandler Class located in the JsonRPCScoketServer.cs file in the MyBookie Project

    public void interceptResponse(JsonRequest jsonRequest, JsonResponse jsonResponse)
    {
        String request = JsonConvert.SerializeObject(jsonRequest);
        String response = JsonConvert.SerializeObject(jsonResponse);
        //TODO deal with preventing duplicates request coming through
        //Match phase duplication
        //Winning duplications

        // print intercepted request/respons-pair on the console
        Console.WriteLine("intercepted response: " + response + " for request: " + request);
    }
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
    public ReplyMessage matchStarted(String bookieName, object recievedMatch)
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
        int limit = int.MinValue;  
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
                oddsA = float.Parse(s.Split(':')[1]);
            else if (s.StartsWith("oddsB"))
                oddsB = float.Parse(s.Split(':')[1]);
            else if (s.StartsWith("limit"))
                limit = int.Parse(s.Split(':')[1]);
        }
        if (teamA != string.Empty && teamB != string.Empty && bookieID != string.Empty)
        {
            MatchStartedResult msr = new MatchStartedResult(bookieID, id, teamA, teamB, oddsA, oddsB, limit);
            RecievedMessage rm = new RecievedMessage(msr, RecievedMessage.MessageType.matchStarted);
            return addUpdate(rm);
        }
        else
            return ReplyMessage.REJECTED;
    }
    [JsonRpcMethod]
    public ReplyMessage setOdds(String bookieName, int matchID, string team, float newOdds)
    {
        SetOddsResult sor = new SetOddsResult(bookieName, matchID, team, newOdds);
        RecievedMessage rm = new RecievedMessage(sor, RecievedMessage.MessageType.setOdds);
        return addUpdate(rm);
    }
    [JsonRpcMethod]
    public ReplyMessage endBet(String bookieName, int matchID, string winningTeam, float amountWon)
    {
        EndBetResult ebr = new EndBetResult(bookieName, matchID, winningTeam, amountWon);
        RecievedMessage rm = new RecievedMessage(ebr, RecievedMessage.MessageType.endBet);
        return addUpdate(rm);
    }
    private ReplyMessage addUpdate(RecievedMessage rm)
    {
        ReplyMessage message = ReplyMessage.REJECTED;
        lock (_lock)
        {
            if (_listOfUpdates.Contains(rm))
                message = ReplyMessage.REJECTED_DUPLICATE;
            else
            {
                _listOfUpdates.Add(rm);
                message = ReplyMessage.ACCEPTED;
            }
        }
        return message;
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
        endBet
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
    public Result(string bookieID)
    {
        this.BookieID = bookieID;
    }
    public string BookieID { get; private set; }
}
public class EndBetResult : Result
{
    public EndBetResult(string bookieID, int matchID, string winningTeam, float amountWon)
        : base(bookieID)
    {
        this.AmountWon = amountWon;
        this.WinningTeam = winningTeam;
        this.MatchID = matchID;
    }
    public int MatchID { get; private set; }
    public string WinningTeam { get; private set; }
    public float AmountWon { get; private set; }
}
public class SetOddsResult : Result
{
    public SetOddsResult(string bookieID, int matchID, string teamName, float newOdds)
        : base(bookieID)
    {
        this.MatchID = matchID;
        this.TeamName = teamName;
        this.NewOdds = newOdds;
    }
    public int MatchID { get; private set; }
    public string TeamName { get; private set; }
    public float NewOdds { get; private set; }
}
public class MatchStartedResult : Result
{
    public MatchStartedResult(string bookieID, int id, string teamA, string teamB, float oddsA, float oddsB, int limit)
        : base(bookieID)
    {   
        this.ID = id;
        this.TeamA = teamA;
        this.TeamB = teamB;
        this.OddsA = oddsA;
        this.OddsB = oddsB;
        this.Limit = limit;
    }
    
    public int ID { get; private set; }
    public string TeamA { get; private set; }
    public string TeamB { get; private set; }
    public float OddsA { get; private set; }
    public float OddsB { get; private set; }
    public int Limit { get; private set; }
}
