using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RobiSMSConsole
{
    class Program
    {
        static HttpClient client=new HttpClient();
        static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            string username = "ConstantMD";
            string password = "Abcd@123";
            string from = "8801847169882";
            string to = "8801714814251";
            string message = "Hello I am Ahasan.This is testing sms message.";

            var path = $@"ApacheGearWS/SendTextMessage?Username={username}&Password={password}&From={from}&To={to}&Message={message}";
            client.BaseAddress=new Uri("https://bmpws.robi.com.bd/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //Call api
            var response=await CallAsync(path);
        }

        static async Task<string> CallAsync(string path)
        {
            
            HttpResponseMessage response = await client.GetAsync(path);
            response.EnsureSuccessStatusCode();
           
            return await response.Content.ReadAsStringAsync(); ;
        }
    }
}
