using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestThread
{
   [TestClass]
    public class Foreground
    {
        [TestMethod]
        public void ForegroundMain()
        {
            Thread a=new Thread(ForegroundThread);
            var isBackground = a.IsBackground;
            a.Start();
           
            //
        }

        private void ForegroundThread()
        {
            Debug.WriteLine("Exit");
        }
    }
}
