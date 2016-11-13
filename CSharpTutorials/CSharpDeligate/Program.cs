using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDeligate
{
    //A delegate is like a pointer to a function. It is a reference type data type and it holds the reference of a method. All the delegates are implicitly derived from System.Delegate class.
    class Program
    {
        //Declare delegate
        public delegate void Print(int value);
        static void Main(string[] args)
        {
            ////Print delegate point to PrintNumber
            //Print printDel = PrintNumber;
            //printDel(1000);
            //printDel(200);

            ////Print delegate point to PrintMoney
            //printDel = PrintMoney;
            //printDel(300);
            //printDel(100);
            PrintHelper(PrintNumber,1000);
            PrintHelper(PrintMoney,100);

            Console.ReadKey();
        }
        //A method can have a parameter of a delegate type and can invoke the delegate parameter
        public static void PrintHelper(Print delegateFunc,int printToNum)
        {
            delegateFunc.Invoke(printToNum);
        }

        public static void PrintNumber(int num)
        {
            Console.WriteLine($"Number :{num}");
        }

        public static void PrintMoney(int money)
        {
            Console.WriteLine($"Money : {money}");
        }
    }
}
