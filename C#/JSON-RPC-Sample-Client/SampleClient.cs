using AustinHarris.JsonRpc;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace JSON_RPC_Sample_Client
{

    class SampleClient
    {

        private TcpClient clientSocket;
        private IPEndPoint localIPEndPoint;
        private StreamWriter writer;
        private StreamReader reader;
        private JsonSerializer jsonSerializer;

        private SampleClient()
        {
            // setup a connection with some JSON-RPC server

            // clientSocket = new TcpClient("192.168.105.133", 3333);
            clientSocket = new TcpClient("192.168.105.1", 30100);
            localIPEndPoint = ((IPEndPoint)(clientSocket.Client.LocalEndPoint));
            NetworkStream stream = clientSocket.GetStream();
            // create writer and a reader objects to send JSON-RPC requests to the
            // JSON-RPC server and to receive responses
            writer = new StreamWriter(stream, Encoding.UTF8);
            reader = new StreamReader(stream, Encoding.UTF8);
            // JsonSerializer is a very helpful class for
            // JSON serialization/deserialization purposes
            jsonSerializer = new JsonSerializer();
        }

        static void Main(string[] args)
        {
            SampleClient sampleClient = new SampleClient();

            sampleClient.communicateWithServer();

            Console.In.ReadLine();
        }

        private void communicateWithServer()
        {
            // invoke the sayHello method on the JSON-RPC server
            sayHello();
            // invoke the createItem method on the JSON-RPC server
            createItem();

            // tell the JSON-RPC server to discard the subsequent request ...
            discardNextRequest();
            // ... which actually means that this sayHello request will
            // be discarded on JSON-RPC server-side, effectively mimicking
            // a dropped connection
            sayHelloAgain();
        }

        private void sayHello()
        {
            // compose a JSON-RPC request, using the JsonRequest class
            // provided by the JSON-RPC library as a helper class
            JsonRequest sayHelloRequest = new JsonRequest
            {
                // set the necessary fields of the request object:
                // - name of the method
                Method = "sayHello",
                // - array of all method parameters
                Params = new object[] { "Jack" },
                // - id of the request
                Id = 1
            };
            // create a JSON string from the request object
            String sayHelloRequestString = JsonConvert.SerializeObject(sayHelloRequest);
            // print the JSON-RPC request on the console for
            // informational purposes
            Console.WriteLine("sending request: " + sayHelloRequestString);
            // send the JSON-RPC request string to the JSON-RPC server
            writer.Write(sayHelloRequestString);
            // flush the stream to make sure the request is sent via the socket
            writer.Flush();

            // wait for the JSON-RPC response to arrive via the socket and convert
            // the JSON-RPC response string into a JsonResponse object
            JsonResponse sayHelloResponse = (JsonResponse)jsonSerializer.Deserialize(reader, typeof(JsonResponse));

            // print the (re-encoded) JSON-RPC response to the console
            // for informational purposes
            String sayHelloResponseString = JsonConvert.SerializeObject(sayHelloResponse);
            Console.WriteLine(sayHelloResponseString);
        }

        private void createItem()
        {
            JsonRequest createItemRequest = new JsonRequest
            {
                Method = "createItem",
                Params = new object[] { "Energy Drink", (float)1.32 },
                Id = 2
            };
            String createItemRequestString = JsonConvert.SerializeObject(createItemRequest);
            Console.WriteLine("sending request: " + createItemRequestString);
            writer.Write(createItemRequestString);
            writer.Flush();

            JsonResponse createItemResponse = (JsonResponse)jsonSerializer.Deserialize(reader, typeof(JsonResponse));
            String createItemResponseString = JsonConvert.SerializeObject(createItemResponse);
            Console.WriteLine(createItemResponseString);
            Item item = JsonConvert.DeserializeObject<Item>(createItemResponse.Result.ToString());
            Console.WriteLine(item);
        }

        private void discardNextRequest()
        {
            JsonRequest setModeOfHostRequest = new JsonRequest
            {
                Method = "setModeOfHost",
                Params = new object[] { localIPEndPoint.Address.ToString(), localIPEndPoint.Port, JSON_RPC_Server.ServiceMode.DISCONNECT_BEFORE_PROCESSING.ToString() },
                Id = 3
            };
            String setModeOfHostRequestString = JsonConvert.SerializeObject(setModeOfHostRequest);
            Console.WriteLine("sending request: " + setModeOfHostRequestString);
            writer.Write(setModeOfHostRequestString);
            writer.Flush();

            JsonResponse setModeOfHostResponse = (JsonResponse)jsonSerializer.Deserialize(reader, typeof(JsonResponse));
            String setModeOfHostResponseString = JsonConvert.SerializeObject(setModeOfHostResponse);
            Console.WriteLine(setModeOfHostResponseString);
        }

        private void sayHelloAgain()
        {
            JsonRequest sayHelloRequest = new JsonRequest
            {
                Method = "sayHello",
                Params = new object[] { "Joe" },
                Id = 4
            };
            String sayHelloRequestString = JsonConvert.SerializeObject(sayHelloRequest);
            Console.WriteLine("sending request: " + sayHelloRequestString);
            writer.Write(sayHelloRequestString);
            writer.Flush();

            JsonResponse sayHelloResponse = (JsonResponse)jsonSerializer.Deserialize(reader, typeof(JsonResponse));
            if (sayHelloResponse == null)
            {
                Console.WriteLine("response is null, bailing out");
            }
            else
            {
                String sayHelloResponseString = JsonConvert.SerializeObject(sayHelloResponse);
                Console.WriteLine(sayHelloResponseString);
            }
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