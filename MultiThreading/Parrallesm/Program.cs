//Reference link for multi threading
// https://www.codeproject.com/Articles/1162148/Multi-threading-in-Csharp-Back-to-Basics-Part-of

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Parrallesm
{
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct SystemTime
    {
        public ushort Year;
        public ushort Month;
        public ushort DayOfWeek;
        public ushort Day;
        public ushort Hour;
        public ushort Minute;
        public ushort Second;
        public ushort Milliseconds;

        public string ToHMSM() =>
            $"{Hour}:{Minute}:{Second}:{Milliseconds,3}";
    }
    class Program
    {
        [DllImport("Kernel32.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint GetCurrentThreadId();
        [DllImport("Kernel32.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void GetLocalTime(out SystemTime time);
        static void Main(string[] args)
        {
            int threadNumber = 10;
            Stopwatch sw=new Stopwatch();

            Console.WriteLine("Starting threads...");
            Console.WriteLine("CLR ThreadId  OS ThreadId Time");
            Console.WriteLine("------------  ----------   ----");
            CountdownEvent countdownEvent=new CountdownEvent(threadNumber);
            sw.Start();
            for (int i = 0; i < threadNumber; i++)
            {
                new Thread(() =>
                {
                    SystemTime time;
                    GetLocalTime(out time);
                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId,12}   {GetCurrentThreadId(),11:X}  {time.ToHMSM()}");
                    countdownEvent.Signal();
                }).Start();
            }
            
            countdownEvent.Wait();
            sw.Stop();
            Console.WriteLine($"Total run time (ms): {sw.ElapsedMilliseconds}");

            Console.WriteLine("\nStarting threadPool threads...");
            Console.WriteLine("CLR ThreadId  OS ThreadId Time");
            Console.WriteLine("------------  ----------   ----");
            countdownEvent.Reset();
            sw.Reset();
            sw.Start();
            for (int i = 0; i < threadNumber; i++)
            {
                ThreadPool.QueueUserWorkItem(_ =>
                {
                    SystemTime time;
                    GetLocalTime(out time);
                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId,12}   {GetCurrentThreadId(),11:X}  {time.ToHMSM()}");
                    countdownEvent.Signal();
                });
            }
            countdownEvent.Wait();
            sw.Stop();
            Console.WriteLine($"Total run time (ms): {sw.ElapsedMilliseconds}");

            Console.WriteLine("\nStarting Tasks...");
            Console.WriteLine("CLR ThreadId  OS ThreadId Time");
            Console.WriteLine("------------  ----------   ----");
            Task[] tasks=new Task[threadNumber];
            sw.Reset();
            sw.Start();
            for (int i = 0; i < threadNumber; i++)
            {
                tasks[i]=Task.Run(() =>
                {
                    SystemTime time;
                    GetLocalTime(out time);
                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId,12}   {GetCurrentThreadId(),11:X}  {time.ToHMSM()}");
                });
            }
            Task.WaitAll(tasks);
            sw.Stop();
            Console.WriteLine($"Total run time (ms): {sw.ElapsedMilliseconds}");

            Console.WriteLine("\nStarting TPL Tasks...");
            Console.WriteLine("CLR ThreadId  OS ThreadId Time");
            Console.WriteLine("------------  ----------   ----");
            sw.Reset();
            sw.Start();
            Parallel.For(0, threadNumber, _ =>
            {
                SystemTime time;
                GetLocalTime(out time);
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId,12}   {GetCurrentThreadId(),11:X}  {time.ToHMSM()}");
            });
            sw.Stop();
            Console.WriteLine($"Total run time (ms): {sw.ElapsedMilliseconds}");
            //-------------------------------------//
            Console.ReadKey();
        }
    }
}
