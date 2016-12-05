using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plural.LambdasAndDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var worker = new Worker();
            //worker.WorkPerformed += Worker_WorkPerformed;
            //worker.WorkCompleted += Worker_WorkCompleted;
            worker.WorkPerformed+=(s,e)=> Console.WriteLine("Worked: " + e.Hours + " hour(s) doing: " + e.WorkType);
            worker.WorkCompleted +=(s,e)=> Console.WriteLine("Work is complete!");
            worker.DoWork(8, WorkType.GenerateReports);

            Console.Read();
        }

        //static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        //{
        //    Console.WriteLine("Worked: " + e.Hours + " hour(s) doing: " + e.WorkType);
        //}

        //static void Worker_WorkCompleted(object sender, EventArgs e)
        //{
        //    Console.WriteLine("Work is complete!");
        //}
    }
}
