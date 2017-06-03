using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDelegate3
{
    public class OddNumberEventArgs : EventArgs
    {
        public int Sum { get; set; }

        public OddNumberEventArgs(int result)
        {
            Sum = result;
        }
    }
}
