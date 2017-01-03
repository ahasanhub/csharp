using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            //Use implicitly-typed lambda expression
            //...Assign it to a Finc instance.
            //
            Func<int, int> func1 = x => x + 1;
            //
            //Use lambda expression wit statement body.
            //
            Func<int, int> func2 = x => { return x + 1; };
            //
            //Use formal parameters with expression body
            //
            Func<int, int> func3 = (int x) => x + 1;
            //
            //Use multiple parameters.
            //
            Func<int, int, int> func4 = (x, y) => x * y;
            //
            //Use no parameter in a lambda expression.
            //
            Action func5 = () => Console.WriteLine("Hello");
            //
            //Use no parameter in a lambda expression.
            //
            Func<int> func6 = () => 10;
            //
            //Use delegate method expression
            //
            Func<int, int> func7 = delegate(int x) { return x + 1; };
            //
            //Use delegate expression with no parameter list.
            //
            Func<int> func8 = delegate { return 11; };
            //
            // Invoke each of the lambda expressions and delegate we created.
            //...The method above are executed.
            //
            Console.WriteLine(func1.Invoke(1));
            Console.WriteLine(func2.Invoke(1));
            Console.WriteLine(func3.Invoke(1));
            Console.WriteLine(func4.Invoke(2,4));
            func5.Invoke();
            Console.WriteLine(func6.Invoke());
            Console.WriteLine(func7.Invoke(1));
            Console.WriteLine(func8.Invoke());
            Console.ReadKey();
        }
    }
}
