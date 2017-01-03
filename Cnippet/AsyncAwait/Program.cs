using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();
            Task<int> carTask = Task.Factory.StartNew<int>(BookCar);
            Task<int> hotelTask = Task.Factory.StartNew<int>(BookHotel);
            Task<int> planeTask = Task.Factory.StartNew<int>(BookPlane);
            Task hotelFollowupTask = hotelTask.ContinueWith(prev=>Console.WriteLine($"{prev.Result}"));
            hotelFollowupTask.Wait();
            //Task.WaitAll(carTask,hotelTask,planeTask);
            Console.WriteLine($"Finished booking : carid={carTask.Result}, hotelId={hotelTask.Result},planeId={planeTask.Result}");
            Console.WriteLine($"Finished in {sw.ElapsedMilliseconds / 1000.0}");
            //This is the serial way
            //Stopwatch sw = Stopwatch.StartNew();
            //int carId = BookCar();
            //int hotelId = BookHotel();
            //int planeId = BookPlane();
            //Console.WriteLine($"Finished in {sw.ElapsedMilliseconds / 1000.0}");
            Console.ReadKey();
        }
        static Random random=new Random();

        private static int BookPlane()
        {
            Console.WriteLine("Booking hotel...");
            Thread.Sleep(8000);
            Console.WriteLine("Done with hotel.");
            return random.Next(100);
        }

        private static int BookHotel()
        {
            Console.WriteLine("Booking plane...");
            Thread.Sleep(5000);
            Console.WriteLine("Done with plane.");
            return random.Next(100);
        }

        private static int BookCar()
        {
            Console.WriteLine("Booking car...");
            Thread.Sleep(3000);
            Console.WriteLine("Done with car.");
            return random.Next(100);
        }
    }
}
