using AustinHarris.JsonRpc;
using System;
using Newtonsoft.Json;
using System.Diagnostics;

namespace JSON_RPC_Sample_Server
{
    class SampleServer
    {
        static void Main(string[] args)
        {
            Trace.Listeners.Add(new ConsoleTraceListener());

            // create an instance of the service
            Object exampleService = new ExampleService();

            // start a JSON-RPC server; all methods tagged with the [JsonRpcMethod] attribute
            // will be invokable remotely; all requests as well as all responses will be
            // passed on to the interceptor; please note that the server will
            // automatically expose an additional method to control how requests will be
            // processed;
            // pass a simple interceptor, which simply prints all intercepted requests
            // and responses
            JSON_RPC_Server.SocketListener.start(3333, new SampleInterceptor());
        }

    }

    class SampleInterceptor : JSON_RPC_Server.Interceptor
    {
        public JsonResponse interceptRequest(JsonRequest jsonRequest)
        {
            String request = JsonConvert.SerializeObject(jsonRequest);

            // print intercepted request on the console
            Console.WriteLine("intercepted request: " + request);
            return null;
        }

        public void interceptResponse(JsonRequest request, JsonResponse response)
        {
            // print intercepted request/respons-pair on the console
            Console.WriteLine("intercepted response: " + response + " for request: " + request);
        }
    }

    class ExampleService : JsonRpcService
    {

        // Implementation of a simple sayHello method, which
        // can be invoked remotely with one argument of
        // type String, returning another String.
        // All methods tagged with the [JsonRpcMethod] attributed will be exported
        // and can be called remotely via JSON-RPC.
        // Handles JSON-RPC like : {'method':'sayHello','params':['Jack'],'id':1}
        [JsonRpcMethod]
        public String sayHello(String name)
        {
            Console.WriteLine("sayHello(" + name + ")");
            return "Hello, " + name;
        }

        // Implementation of a method createItem, which creates and returns
        // an instance of the class Item.
        // Handles JSON-RPC like : {'method':'decr','params':[5],'id':1}
        [JsonRpcMethod]
        public Item createItem(String description, float price)
        {
            Console.WriteLine("createItem(" + description + ", " + price + ")");
            return new Item(description, price);
        }
    }

    public class Item
    {

        public int itemNr { get; }
        public String description { get; }
        public float price { get; }

        static private int nextItemNr = 1000;

        public Item(String description, float price)
        {
            this.itemNr = nextItemNr++;
            this.description = description;
            this.price = price;
        }

        public override String ToString()
        {
            return "item nr: " + itemNr + " description: " + description + " price: " + price;
        }

    }

}
