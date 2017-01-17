using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDelegate
{
    /// <summary>
    /// This is publisher class
    /// </summary>
    class AddTwoNumbers
    {
        public delegate void DelegateOddNumber();//Declare delegate(1)
        public event DelegateOddNumber EventOddNumber;//Declare event()2

        public void Add()
        {
            int result;
            result = 3 + 4;
            Console.WriteLine(result.ToString());
            //Check if result is odd number then raise event
            if (result %2 !=0 && EventOddNumber!=null)
            {
                EventOddNumber();//Raised event(3)
            }
        }
    }
}
