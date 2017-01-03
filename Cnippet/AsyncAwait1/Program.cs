using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task<string> sCode = Task.Run(async ()=>await GenerateCodeAsync());
            Task<string> sCode = Task.Run(GenerateCodeAsync);
            Console.WriteLine(sCode.Result);
            Console.ReadKey();
        }

        static Task<string> GenerateCodeAsync()
        {
            return Task.Run<string>(()=>GenerateCode());
        }

        static string GenerateCode()
        {
            Thread.Sleep(2000);
            return "I am come back";
        }
    }
}
