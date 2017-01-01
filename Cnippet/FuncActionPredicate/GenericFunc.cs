using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FuncActionPredicate
{
    [TestClass]
    public class GenericFunc
    {
        [TestMethod]
        public void GenericFuncMain()
        {
            Func<string, string> upper = UppercaseString;
            string message = "hello i am ahasan";
            Debug.WriteLine(upper(message));
        }
        [TestMethod]
        public void Anonymous()
        {
            Func<string, string> upper = delegate(string str) { return str.ToUpper(); };
            string message = "i am anonymous function";
            Debug.WriteLine(upper(message));
        }
        [TestMethod]
        public void LambdaExpression()
        {
            Func<string, string> upper = m => m.ToUpper();
            string message = "i am lambda expression";
            Debug.WriteLine(upper(message));
        }

        private string UppercaseString(string message)
        {
            return message.ToUpper();
        }


    }
}
