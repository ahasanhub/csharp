using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rx.Basic
{
    class Program
    {
        static void Main(string[] args)
        {
            var query = from number in Enumerable.Range(1, 10) select number;
            foreach (int number in query)
            {
                Console.WriteLine(number);
            }
            ImDone();
            var observableQuery = query.ToObservable();
            observableQuery.Subscribe(Console.WriteLine, ImDone);
            Console.ReadKey();
        }

        static void ImDone()
        {
            Console.WriteLine("I am done.");
        }
    }
}
