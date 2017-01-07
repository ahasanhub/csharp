using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateEvent1
{
    public class TestDelegate1
    {
        public delegate void LogHandler(string message);

        public void Process(LogHandler handler)
        {
            if (handler!=null)
            {
                handler("Process Begin...");
            }
            handler?.Invoke("Process End...");
        }

    }
}
