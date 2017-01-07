using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DelegateEvent1
{
    /// <summary>
    /// Declaration
    /// </summary>
    public delegate void SimpleDelegate();
    [TestClass]
    public class TestDelegate
    {
        [TestMethod]
        public void Main()
        {
            //Instantiation
            SimpleDelegate del=new SimpleDelegate(MyFunc);
            //Invocation
            del();
        }

        public void MyFunc()
        {
            Console.WriteLine("I was called by delegate...");
        }

    }
}
