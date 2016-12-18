using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TutorialsPoint.CSharp
{
    public delegate string MyDel(string str);

    [TestClass]
    public class EventProgram
    {
        private event MyDel MyEvent;

        public EventProgram()
        {
            MyEvent+=new MyDel(WelcomeUser);
        }

        public string WelcomeUser(string username)
        {
            return "Welcome " + username;
        }

        [TestMethod]
        public void MainEvent()
        {
            EventProgram eventProgram=new EventProgram();
            string result = MyEvent("Tutorials Point");
            Debug.WriteLine(result);
        }
    }
}
