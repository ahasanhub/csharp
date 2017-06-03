using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDelegate3
{
    /// <summary>
    /// This is subscriber class
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            AddTwoNumbers num=new AddTwoNumbers();
            //Event gets binded with delegate
            num.EventOddNumber += Num_EventOddNumber;
            num.EventEvenNumber += Num_EventEvenNumber;
            Console.WriteLine("Please enter value of a :");
            var a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the value of b:");
            var b = Convert.ToInt32(Console.ReadLine());
            num.Add(a,b);
            
            Console.ReadKey();
        }
        /// <summary>
        /// Delegate call this method when EventEvenNumber raised
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Num_EventEvenNumber(object sender, EvenNumberEventArgs e)
        {
           Console.WriteLine($"Even number Event executed : the sum is {e.Sum}");
        }
        /// <summary>
        /// Delegate call this method when EventOddNumber raised
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Num_EventOddNumber(object sender, OddNumberEventArgs e)
        {
            Console.WriteLine($"Odd number Event executed : the sum is {e.Sum}");
        }
    }
}
