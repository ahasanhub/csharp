using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            Method();
            Console.WriteLine("Main thread.");
            Console.ReadLine();
        }

        private static async void Method()
        {
            await Task.Run(new Action(LongTask));
            Console.WriteLine("New thread.");//wait until the longtask finishes
        }

        public static void LongTask()
        {
            Thread.Sleep(20000);
        }
    }
}
