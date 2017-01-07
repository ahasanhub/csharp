using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate1
{
    class Program
    {
        static void Main(string[] args)
        {
            FileLogger fl=new FileLogger(@"C:\Process.txt");
            MyClass myClass=new MyClass();
            MyClass.LogHandler myLogHandler=new MyClass.LogHandler(fl.Logger);
            myClass.Process(myLogHandler);
            fl.Close();
        }
    }
}
