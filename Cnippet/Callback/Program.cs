using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callback
{
    class Program
    {
        static void Main(string[] args)
        {
            CallBackTest callBackTest=new CallBackTest();
            callBackTest.Test();
            Console.ReadLine();
        }
    }
}
