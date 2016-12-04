using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateAndEvents
{
    
    class Program
    {
        static void Main(string[] args)
        {
            //WorkPerformedHandler del1=new WorkPerformedHandler(WorkPerformed1);
            //WorkPerformedHandler del2 = new WorkPerformedHandler(WorkPerformed2);
            //WorkPerformedHandler del3 = new WorkPerformedHandler(WorkPerformed3);
            ////del1(5,WorkType.Golf);
            ////del2(10,WorkType.GeneratesReport);
            ////del1 += del2;
            ////del1 += del3;
            ////DoWork(del1);
            //del1 += del2 + del3;
            //int finalHours=del1(10,WorkType.Golf);
            //Console.WriteLine(finalHours.ToString());
            Worker worker=new Worker();
            worker.WorkPerformed+=new EventHandler<WorkPerformedEventArgs>(Worker_WorkPerformed);
            worker.WorkCompleted+=new EventHandler(Worker_WorkPerformed);
            worker.DoWork(8,WorkType.GeneratesReport);
            Console.ReadLine();
        }

        private static void Worker_WorkPerformed(object sender, EventArgs e)
        {
            Console.WriteLine("Worker is done.");
        }

        private static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        {
           Console.WriteLine("Hours worked : "+e.Hours+" "+e.WorkType);
        }

        //static void DoWork(WorkPerformedHandler del)
        //{
        //    del(5,WorkType.Golf);
        //}

        //static int WorkPerformed1(int hours, WorkType workType)
        //{
        //    Console.WriteLine("WorkPerformed1 called "+hours.ToString());
        //    return hours + 1;
        //}
        //static int WorkPerformed2(int hours, WorkType workType)
        //{
        //    Console.WriteLine("WorkPerformed2 called "+hours.ToString());
        //    return hours + 1;
        //}
        //static int WorkPerformed3(int hours, WorkType workType)
        //{
        //    Console.WriteLine("WorkPerformed3 called " + hours.ToString());
        //    return hours + 1;
        //}
    }

    public enum WorkType
    {
        GoToMeeting,
        Golf,
        GeneratesReport
    }

}
