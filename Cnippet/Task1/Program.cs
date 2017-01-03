using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t=Task.Run(() =>
            {
                //jast loop
                int ctr = 0;
                for ( ctr = 0; ctr <= 1000000; ctr++)
                {
                    
                }
                Console.WriteLine($"Finished {ctr} loop iterations");
            });
            t.Wait();
            Console.ReadKey();
        }
    }
}
