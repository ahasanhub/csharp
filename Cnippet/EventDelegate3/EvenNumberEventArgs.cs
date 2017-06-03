using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDelegate3
{
    public class EvenNumberEventArgs : EventArgs
    {
        public int Sum { get; set; }

        public EvenNumberEventArgs(int sum)
        {
            Sum = sum;
        }
    }
}
