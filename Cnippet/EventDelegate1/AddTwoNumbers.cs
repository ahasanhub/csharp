using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDelegate1
{
    /// <summary>
    /// This is publisher class
    /// </summary>
    class AddTwoNumbers
    {
        
        public event EventHandler<EventArgs> EventOddNumber;//Declare event(1)
        public void Add()
        {
            int result;
            result = 3 + 4;
            Console.WriteLine(result.ToString());
            //Check if result is odd number then raise event
            if (result % 2 != 0 && EventOddNumber != null)
            {
                EventOddNumber(this,EventArgs.Empty);//Raised event(3)
            }
        }
    }
}
