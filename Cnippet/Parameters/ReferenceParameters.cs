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
    public class ReferenceParameters
    {
        //This is static method
        static void Swap(ref int a,ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
       [TestMethod]
        public void TestSwap() //This is instance method
        {
            //Reference parameter is used for both input and output parameter passing.
            int x = 1, y = 2;
            Swap(ref x,ref y);
            Debug.WriteLine($"Reference value : x={x} and y={y}");
        }
    }
}
