using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Methods
{
    [TestClass]
    public class StaticInstance
    {
        [TestMethod]
        public void TestMain()
        {
            Entity.SetNextSerialNumber(1000);
            Entity e1=new Entity();
            Entity e2=new Entity();
            Debug.WriteLine("Output e1 :"+e1.GetSerialNumber());
            Debug.WriteLine("Output e2 :" + e2.GetSerialNumber());
            Debug.WriteLine("Output nextSerialNumber :" + Entity.GetNextSerialNumber());
        }
    }
}
