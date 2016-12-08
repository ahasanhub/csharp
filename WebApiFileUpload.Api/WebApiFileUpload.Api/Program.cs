using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace WebApiFileUpload.Api
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:8000/";
            using (WebApp.Start<Startup>(url:baseAddress))
            {
                Console.WriteLine("Server is started...");
                Console.ReadLine();
                //HttpWebRequest request = (HttpWebRequest) WebRequest.Create(baseAddress + "api/values");
                //System.Diagnostics.Process.Start(baseAddress + "api/values");
                 
            }
           
        }
    }
}
