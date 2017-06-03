using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDelegate3
{
    /// <summary>
    /// This is publisher class
    /// </summary>
    public class AddTwoNumbers
    {
        public event EventHandler<OddNumberEventArgs> EventOddNumber;//Declare OddEvent
        public event EventHandler<EvenNumberEventArgs> EventEvenNumber;//Declare EvenEvent

        public void Add(int a, int b)
        {
            var sum = a + b;
            //This is simple output
            Console.WriteLine($"Sum ({a}+{b})={sum}");
            //Raise event for odd number
            if ((sum % 2!=0))
            {
                EventOddNumber?.Invoke(this,new OddNumberEventArgs(sum));
            }
            //Raise event for even number
            if (sum % 2==0)
            {
                EventEvenNumber?.Invoke(this,new EvenNumberEventArgs(sum));
            }
        }
    }
}
