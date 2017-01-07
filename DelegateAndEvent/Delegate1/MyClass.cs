using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate1
{
    public class MyClass
    {
        public delegate void LogHandler(string message);

        public void Process(LogHandler handler)
        {
            handler?.Invoke("Process begin...");
            handler?.Invoke("Process end...");
        }
    }
}
