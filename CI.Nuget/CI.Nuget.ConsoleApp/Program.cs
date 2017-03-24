using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CI.Nuget.ClassLibrary;


namespace CI.Nuget.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var d = new MyMath().Add(2, 5);
            Console.WriteLine(d);
            Console.ReadKey();
        }
    }
}
