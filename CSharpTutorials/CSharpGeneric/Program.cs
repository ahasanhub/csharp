using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGeneric
{
    class Program
    {
        public delegate T Add<T>(T param1,T parm2);
        static void Main(string[] args)
        {
            //MyGenericClass<int> intGenericClass = new MyGenericClass<int>(10);
            //int val = intGenericClass.GenericMethod(200);
            Add<int> add = Addint;
            Console.WriteLine(add(5,6));
            Add<string> concat = AddString;
            Console.WriteLine(concat("Hello","World"));
            Console.ReadKey();
        }

        public static int Addint(int val1,int val2)
        {
            return val1 + val2;
        }

        public static string AddString(string str1, string str2)
        {
            return str1 + " "+str2;
        }
    }
}
