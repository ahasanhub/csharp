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
    public class Background
    {
        [TestMethod]
        public void Main()
        {
            Thread a = new Thread(BackgroundThread) {IsBackground = true};
            a.Start();
        }

        private void BackgroundThread()
        {
            Debug.WriteLine("Exit..");
        }
    }
}
