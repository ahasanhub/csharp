using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static Random random=new Random();
        static void Main(string[] args)
        {
            //Wait on a single task with no timeout specified
            Task taskA=Task.Run(()=>Thread.Sleep(2000));
            Console.WriteLine($"task status : {taskA.Status}");
            Console.ReadKey();
        }
    }
}
