using AustinHarris.JsonRpc;
using JSON_RPC_Server;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Gambler.Model.RPC.Common
{
    public class JsonRpcConnection
    {

        private String serverIP;  // IP address of the JSON-RPC server
        private int serverPort;   // port number of the JSON-RPC server

        private TcpClient tcpClient; // socket connection with the JSON-RPC server
        private NetworkStream stream;
        private StreamWriter writer; // writer to write to socket's stream
        private StreamReader reader; // reader to read from socket's stream
        private JsonSerializer jsonSerializer; // Json object to use e.g. for serialization/deserialization

        public JsonRpcConnection(String uniqueID, String serverIP, int serverPort)
        {
            // remember IP and port of the JSON-RPC server, also in case we need to re-connect
            this.serverIP = serverIP;
            this.serverPort = serverPort;


            // create an instance of JsonSerializer, the primary class for serialization of JSON Objects
            this.jsonSerializer = new JsonSerializer();
        }

        public JsonSerializer getJsonSerializer()
        {
            return this.jsonSerializer;
        }

        public void establishSocketConnection()
        {
            // setup a socket connection to the JSON-RPC server
            try
            {
                tcpClient = new TcpClient(serverIP, serverPort);
                Trace.TraceInformation("Connection with JSON-RPC server opened at local endpoint " + tcpClient.Client.LocalEndPoint);
                stream = tcpClient.GetStream();
                // create writer and a reader objects for sending JSON-RPC requests to the
                // JSON-RPC server and to receive responses
                writer = new StreamWriter(stream, Encoding.UTF8);
                reader = new StreamReader(stream, Encoding.UTF8);
            }
            catch (SocketException e)
            {

                Console.WriteLine(e.ToString());
            }
            catch (IOException e)
            {

                Console.WriteLine(e.ToString());
            }
        }

        public void closeRPCConnection()
        {
            try
            {
                stream.Close();
                tcpClient.Close();
            }
            catch (IOException e)
            {
                Trace.TraceWarning("problem closing socket connection with JSON - RPC server at " + serverIP + ":" + serverPort);
                Console.WriteLine(e.ToString());
            }
        }


        /*
         * The setModeOfHost method tells the designated Gambler to handle any incoming RPCalls originating 
         * from this Bookie with the behaviour specified by the ServiceMode
         * 
         * Refer to the Getting started document for more information.
         */
        public void setModeOfHost(ServiceMode serviceMode, string uniqueID)
        {
            IPEndPoint localIPEndpoint = (IPEndPoint)tcpClient.Client.LocalEndPoint;
            Object[] parameters = new object[] {
                localIPEndpoint.Address.ToString(),
                localIPEndpoint.Port,
                serviceMode.ToString()
            };
            handleJsonRpcRequest("setModeOfHost", parameters, uniqueID);
        }

        protected JsonResponse handleJsonRpcRequest(String method, Object[] parameters, string uniqueID)
        {
            JsonRequest request = new JsonRequest
            {
                Method = method,
                Params = parameters,
                Id = uniqueID
            };
            JArray jsonParams = request.Params as JArray;
            JsonResponse jsonResponse = null;

            // create a JSON string from the request object
            String requestString = JsonConvert.SerializeObject(request, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize
            });

            Trace.TraceInformation("sending request: " + requestString);
            // attempting to send the request via the writer to
            // the JSON-RPC server might throw an IOException
            if (writer != null)
            {
                writer.Write(requestString);
                // flush the stream to make sure the request is sent via the socket
                writer.Flush();
            }

            // try to receive a response via the reader
            var response = jsonSerializer.Deserialize(reader, typeof(JsonResponse));

            // check whether a response has been received
            if (response != null)
            {
                jsonResponse = (JsonResponse)response;
                // (re-)serialize the response for informational purposes
                String responseString = JsonConvert.SerializeObject(jsonResponse);

                Trace.TraceInformation("received response: " + responseString);
            }
            else
            {
                // connection to JSON-RPC server is lost
                Trace.TraceInformation("server connection dropped");
                establishSocketConnection();
            }
            return jsonResponse;
        }
    }
}
