﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace Owin.SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9000/";
            //Start OWIN host
            using (WebApp.Start<Startup>(url:baseAddress))
            {
                HttpClient client=new HttpClient();
                client.DefaultRequestHeaders.Add("Client","hospital");
                var response = client.GetAsync(baseAddress + "api/values").Result;
                Console.WriteLine(response);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                
            }
            
            Console.ReadLine();
        }
    }
}
