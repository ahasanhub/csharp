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
            Standard standard=new Standard();
            standard.Description = "Std";
            Student stu1=new Student {StudentName = "Ahasan"};
            Student stu2 = new Student { StudentName = "Hasam" };
            Student stu3 = new Student { StudentName = "Arif" };
            standard.Students.Add(stu1);
            standard.Students.Add(stu2);
            standard.Students.Add(stu3);

            using (var ctx = new SchoolContext())
            {
                ctx.Standards.Add(standard);
                ctx.SaveChanges();
                var st = ctx.Standards.ToList();
            }
        }
    }
}
