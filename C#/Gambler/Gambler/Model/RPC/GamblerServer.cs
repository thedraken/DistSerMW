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



        public void createGamblerServerInterface()
        {
            // create an instance of the service
            Object gamblerService = new MyGamblerService(gambler);

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
                Thread thread = new Thread(new ThreadStart(gamblerSocketListener.start));
                thread.Start();
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

        // print intercepted request/respons-pair on the console
        Console.WriteLine("intercepted response: " + response + " for request: " + request);
    }
}


/// <summary>
/// The class implementing the methods that are exposed via JSON-RPC.
/// The methods that should be exposed are tagged with [JsonRpcMethod]
/// </summary>
class MyGamblerService : JsonRpcService
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
        lock (_lock)
        {
            _listOfUpdates.Add(recievedMatch);
        }
        return true;
    }
    private ObservableCollection<Object> _listOfUpdates = new ObservableCollection<object>();
    public ObservableCollection<Object> getList()
    {
        lock (_lock)
        {
            return this._listOfUpdates;
        }
    }
    public void removeObjectFromList(Object o)
    {
        lock(_lock)
        {
            this._listOfUpdates.Remove(o);
        }
    }
}
