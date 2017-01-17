using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDelegate2
{
    /// <summary>
    /// This is publisher class
    /// </summary>
    class AddTwoNumbers
    {
        
        public event EventHandler<OddNumberEventArgs> EventOddNumber;//Declare event(1)
        public void Add()
        {
            int result;
            result = 3 + 4;
            Console.WriteLine(result.ToString());
            //Check if result is odd number then raise event
            if (result % 2 != 0 && EventOddNumber != null)
            {
                EventOddNumber(this,new OddNumberEventArgs(result));//Raised event(2)
            }
        }
    }
    //Creating custom eventargs 
    public class OddNumberEventArgs : EventArgs
    {
        public int  Sum { get; set; }
        public OddNumberEventArgs(int result)
        {
            Sum = result;
        }
    }

}
