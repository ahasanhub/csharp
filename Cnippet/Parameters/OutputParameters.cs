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
    public class OutputParameters
    {
        void Test(out int result)
        {
            result = 12;
        }
        [TestMethod]
        public void Main()
        {
            //This is only used for output parameter.This input is not working.
            int result = 0;
            Test(out result);
            Debug.WriteLine("Out parameter result :"+result);
        }
    }
}
