using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw=Stopwatch.StartNew();
            Console.WriteLine("Program Begin");
            //DoAsTask();
            DoAsAsync();
            Console.WriteLine("Program End");
            Console.WriteLine("Time"+sw.ElapsedMilliseconds/1000.0);
            Console.ReadLine();
        }

        private static void DoAsTask()
        {
           Console.WriteLine("1 - Starting");
           Task<int> t=Task.Run<int>(()=>DoSomethingThatTakesTime());
           Console.WriteLine("2 - Task started");
           t.Wait();
           Console.WriteLine("3 - Task completed with result : "+t.Result);
        }

        private static async void DoAsAsync()
        {
            Console.WriteLine("1 - Starting");
            Task<int> t = Task.Run<int>(() => DoSomethingThatTakesTime());
            Console.WriteLine("2 - Task started");
            var result = await t;
            Console.WriteLine("3 - Task completed with result : " + result);
        }

        static int DoSomethingThatTakesTime()
        {
            Console.WriteLine("A - Started something");
            Thread.Sleep(2000);
            Console.WriteLine("B - Completed something");
            return 120;
        }
    }
}
