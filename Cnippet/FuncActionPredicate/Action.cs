using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FuncActionPredicate
{
    [TestClass]
    public class Action
    {
        [TestMethod]
        public void MainAction()
        {
            Action<string> show = m => Debug.WriteLine(m);
            string message = "This is test message";
            show(message);
        }
    }
}
