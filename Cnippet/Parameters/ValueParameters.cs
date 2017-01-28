using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Parameters
{
    [TestClass]
    public class ValueParameters
    {
        //This is instance method
        public void Test(int a,int b)
        {
            Debug.WriteLine($"Value parameter result : {a+b}");
        }
        [TestMethod]
        public void Main()//This is main method
        {
            Test(2,4);
        }
    }
}
