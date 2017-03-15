using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MultiThreading
{
    [TestClass]
    public class ParallelTest
    {
        static void F1()
        {
            Debug.WriteLine("F1");
        }
        static void F2()
        {
            Debug.WriteLine("F2");
        }
        static void F3()
        {
            Debug.WriteLine("F3");
        }

        [TestMethod]
        public void TestInvoke()
        {
            Parallel.Invoke(F1,F2,F3);
        }
        [TestMethod]
        public void TestFor()
        {
            Parallel.For(0, 100, x => Debug.WriteLine(x));
        }
    }
}
