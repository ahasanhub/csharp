using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateAndEvents
{
    public delegate void WorkPerformedHandler(int hours, WorkType workType);
    class Program
    {
        static void Main(string[] args)
        {
            WorkPerformedHandler del1=new WorkPerformedHandler(WorkPerformed1);
            WorkPerformedHandler del2 = new WorkPerformedHandler(WorkPerformed2);
            WorkPerformedHandler del3 = new WorkPerformedHandler(WorkPerformed3);
            //del1(5,WorkType.Golf);
            //del2(10,WorkType.GeneratesReport);
            //del1 += del2;
            //del1 += del3;
            //DoWork(del1);
            del1 += del2 + del3;
            del1(10,WorkType.Golf);
            Console.ReadLine();
        }

        static void DoWork(WorkPerformedHandler del)
        {
            del(5,WorkType.Golf);
        }

        static void WorkPerformed1(int hours, WorkType workType)
        {
            Console.WriteLine("WorkPerformed1 called "+hours.ToString());
        }
        static void WorkPerformed2(int hours, WorkType workType)
        {
            Console.WriteLine("WorkPerformed2 called "+hours.ToString());
        }
        static void WorkPerformed3(int hours, WorkType workType)
        {
            Console.WriteLine("WorkPerformed3 called " + hours.ToString());
        }
    }

    public enum WorkType
    {
        GoToMeeting,
        Golf,
        GeneratesReport
    }

}
