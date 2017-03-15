using System;
using System.Collections.Generic;
using System.Linq;

namespace Features
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee {Id = 1,Name = "Ahasan"},
                new Employee { Id=2,Name="Shapla"} 
            };
            IEnumerable<Employee> sales=new List<Employee>
            {
                new Employee { Id=3,Name="Habib"},
                new Employee { Id=4,Name="Zayn"}
            };
            foreach (var employee in sales.Where(e=>e.Name.StartsWith("Z")))
            {
                Console.WriteLine(employee.Name);
            }
            //Console.WriteLine(developers.Count());
            //IEnumerator<Employee> enumerator = sales.GetEnumerator();
            //while (enumerator.MoveNext())
            //{
            //    Console.WriteLine(enumerator.Current.Name);
            //}
            Console.ReadKey();
        }
    }
}
