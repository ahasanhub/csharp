using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DelegateEvent1
{
    public class TestDelegate1
    {
        public delegate void LogHandler(string message);

        public void Process(LogHandler handler)
        {
            handler?.Invoke("Process Begin...");
            handler?.Invoke("Process End...");
        }

    }
    [TestClass]
    public class TestApplication
    {
        public static void Logger(string message)
        {
            Console.WriteLine(message);
        }

        [TestMethod]
        public void Main()
        {
            TestDelegate1.LogHandler handler=new TestDelegate1.LogHandler(Logger);
            TestDelegate1 obj1=new TestDelegate1();
            obj1.Process(handler);
        }
    }
}
