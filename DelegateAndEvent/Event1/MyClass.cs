using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event1
{
    
    /* ========= Publisher of the Event ============== */
    public class MyClass
    {
       //Define a delegate named LogHandler, which will encapsulate
       //any method that takes a string as the parameter and returns no value
        public delegate void LogHandler(string message);
        //Define an Event based on above Delegate
        public event LogHandler Log;
        //Instead of having the Process() function take a delegate
        //as a parameter, we have declare a Log event. Call the Event,
        //using the OnXXXX Method,where XXXX is the name of Event.
        public void Process()
        {
            OnLog("Process is begin...");
            OnLog("Process is end...");
        }
        //By Default, create an OnXXXX Method, to call the Event
        protected void OnLog(string message)
        {
            Log?.Invoke(message);
        }


    }
}
