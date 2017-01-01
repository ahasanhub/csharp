using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Thread
{
    [TestClass]
    public class Foreground
    {
        [TestMethod]
        public void ForegroundMain()
        {
            System.Threading.Thread a=new System.Threading.Thread(ForegroundThread);
            a.Start();
            //Main application is exit here..
        }

        private void ForegroundThread()
        {
            Debug.WriteLine("Exit");
           
        }
    }
}
