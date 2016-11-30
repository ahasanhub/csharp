using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Plural.TipsTrap2
{
    [TestClass]
    public class CompilerInferredGenericMethodTypes
    {
        [TestMethod]
        public void Example()
        {
            const string name = "Ahasan";
            const int age = 32;
            //DebugToWrite(age);
            DebugToWrite<string>(name);
            DebugToWrite<int>(age);

        }
        void DebugToWrite<T>(T obj)
        {
            Debug.WriteLine(obj);
        }

        void DebugToWrite(object s)
        {
            Debug.WriteLine(s);
        }
    }
}
