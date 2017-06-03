using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serilog.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger =
                new LoggerConfiguration().MinimumLevel.Debug()
                    .WriteTo.LiterateConsole()
                    .WriteTo.RollingFile(@"log\myapp-{Date}.txt")
                    .CreateLogger();
            Log.Information("Hello, World!");
            int a = 10, b = 0;
            try
            {
                Log.Debug("Dividing {A} by {B}", a, b);
                SomeTask();
            }
            catch (Exception ex)
            {
             Log.Error(ex,"Something went wrong");
            }
            Log.CloseAndFlush();
            Console.ReadKey();
        }

        static void SomeTask()
        {
            Log.Information("This is another logger.");
        }

    }
}
