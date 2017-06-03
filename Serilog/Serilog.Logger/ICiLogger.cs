using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serilog.Logger
{
    public interface ICiLogger
    {
        ILogger Log { get; set; }
    }
}
