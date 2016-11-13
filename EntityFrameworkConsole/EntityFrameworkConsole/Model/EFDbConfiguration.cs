using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkConsole.Model
{
    public class EFDbConfiguration:DbConfiguration
    {
        public EFDbConfiguration()
        {
            AddInterceptor(new EFCommandInterceptor());
        }
    }
}
