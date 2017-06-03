using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog.Logger;

namespace Serilog.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            CiLogger logger =new CiLogger();
            Log.Information("This is test");
        }
    }
}
