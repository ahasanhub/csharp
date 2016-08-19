using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkConsole.Model;

namespace EntityFrameworkConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new SchoolContext())
            {
                var st = ctx.Students.ToList();
            }
        }
    }
}
