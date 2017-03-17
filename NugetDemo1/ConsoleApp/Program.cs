using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NugetDemo1;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MyMath sdf=new MyMath();
            var ss = sdf.Add(2, 4);
            Console.WriteLine(ss);
            Console.ReadKey();
        }
    }
}
