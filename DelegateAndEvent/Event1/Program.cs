using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event1
{
    /* ========= Subscriber of the Event ============== */
    //It's now easier and cleaner to merely add instances
    //of the delegate to the event, instead of having to
    //manage things ourselves 
    class Program
    {
        static void Logger(string message)
        {
            Console.WriteLine(message);
        }

        static void Main(string[] args)
        {
            FileLogger fl=new FileLogger(@"C:\process.txt");
            MyClass myClass=new MyClass();
            //Subscribe the functions Logger and fl.Logger
            myClass.Log+=new MyClass.LogHandler(Logger);
            myClass.Log += new MyClass.LogHandler(fl.Logger);
            //The Event will now be triggered in the Process() Method
            myClass.Process();
            fl.Close();
            Console.ReadKey();
        }
    }
}
