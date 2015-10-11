using AustinHarris.JsonRpc;
using System;
using Newtonsoft.Json;
using System.Diagnostics;

namespace JSON_RPC_Sample_Server
{

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
}
