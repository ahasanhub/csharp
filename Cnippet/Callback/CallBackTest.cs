using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callback
{
    public class CallBackTest
    {
        public void Test()
        {
            TestCompletedCallBack callBack = TestCallBack;
            CallBack call=new CallBack();
            call.StartNewTask(callBack);
        }

        private void TestCallBack(string taskresult)
        {
            Console.WriteLine(taskresult);
        }
    }
    
}
