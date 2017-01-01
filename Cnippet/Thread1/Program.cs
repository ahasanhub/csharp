using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace Thread1
{
    class Program
    {
        static void Main(string[] args)
        {
          //created two thread
          Thread obj1=new Thread(Function1);
          Thread obj2 = new Thread(Function2);
           //invoked these threads
           obj1.Start();
           obj2.Start();
            Console.ReadKey();

        }

        static void Function1()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Function1 is executed "+i);
                //wait for 4 seconds
                Thread.Sleep(4000);
            }
        }
        static void Function2()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Function2 is executed " + i);
                //wait for 4 second
                Thread.Sleep(4000);
            }
        }
    }
}
