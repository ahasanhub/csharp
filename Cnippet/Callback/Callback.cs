using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callback
{
    public delegate void TestCompletedCallBack(string taskResult);
    public class CallBack
    {
        public void StartNewTask(TestCompletedCallBack testCompletedCallBack)
        {
            Console.WriteLine("I have started new task.");
            testCompletedCallBack?.Invoke("I have completed task.");
        }
    }
}
