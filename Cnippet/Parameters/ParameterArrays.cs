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
    public class ParameterArrays
    {
        //This is example of parameters array.
        int AddElements(params int[] arr)
        {
            int sum = 0;
            foreach (int i in arr)
            {
                sum += i;
            }
            return sum;
        }
        [TestMethod]
        public void Main()
        {
            int result = AddElements(12, 11, 13);
            Debug.WriteLine("Result is :"+result);
        }
    }
}
