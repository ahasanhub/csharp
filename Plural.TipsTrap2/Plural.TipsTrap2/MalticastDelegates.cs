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
    public class MalticastDelegates
    {
        private delegate void ProgressChangeNotifier(int percent);

        void WriteToDebug(int percent)
        {
            Debug.WriteLine(percent);
        }

        void WriteToDebugWithMessage(int percent)
        {
            Debug.WriteLine("Progress now at : "+percent);
        }
        [TestMethod]
        public void MulticastExample()
        {
            ProgressChangeNotifier progressChange=new ProgressChangeNotifier(WriteToDebug);
            Debug.WriteLine("Invoking delegate with a single target method assigned");
            progressChange(50);


            progressChange += WriteToDebugWithMessage;
            Debug.WriteLine("Invoking delegate with two target methods assigned");
            progressChange(50);


            progressChange -= WriteToDebug;
            Debug.WriteLine("Invoking delegate with first target method removed");
            progressChange(50);

        }

        private delegate int MathOperation(int a,int b);

        int Add(int a, int b)
        {
            Debug.WriteLine("add called");
            return a + b;
        }

        int Multiply(int a, int b)
        {
            Debug.WriteLine("Multiply called");
            return a*b;
        }

       [TestMethod]
        public void MulticastReturnValues()
        {
            var mathDelegate=new MathOperation(Add);
            mathDelegate += Multiply;
            var result = mathDelegate(10, 10);
            Debug.WriteLine(result);
        }
    }
}
