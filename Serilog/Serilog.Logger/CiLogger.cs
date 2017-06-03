using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serilog.Logger
{
    public class CiLogger 
    {
        public CiLogger()
        {
            Log.Logger =
               new LoggerConfiguration().MinimumLevel.Debug()
                   .WriteTo.LiterateConsole()
                   .WriteTo.RollingFile(@"log\myapp-{Date}.txt")
                   .CreateLogger();
        }
    }
}
