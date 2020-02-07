using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Looping_Rest_Call
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Start");
            RunPostAsync();
            Console.WriteLine("End");
        }

        static HttpClient client = new HttpClient();

        private static void RunPostAsync()
        {

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            Inputs inputs = new Inputs();

            inputs.receiver.Add("name", "O=Seller, L=New York, C=US");
            inputs.receiver.Add("owningKey", "GfHq2tTVk9z4eXgyMt8N3rf2WN4Dd2hdHRQrdwaN8DTKXgR1LvFmMQmDp8dM");



            var res = client.PostAsync("http://localhost:8999/api/rest/cordapps/workflows/flows/net.corda.examples.sendfile.flows.SendAttachment",
                new StringContent(JsonConvert.SerializeObject(inputs)));

            try
            {
                res.Result.EnsureSuccessStatusCode();

                Console.WriteLine("Response " + res.Result.Content.ReadAsStringAsync().Result + Environment.NewLine);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error " + res + " Error " +
                ex.ToString());
            }

            //Console.WriteLine("Response: {0}", res.result);
                
        }
        public class Inputs
        {
            public Dictionary<string, string> receiver = new Dictionary<string, string>();
        }
    }
}
