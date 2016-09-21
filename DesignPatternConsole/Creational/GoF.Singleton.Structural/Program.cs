using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoF.Singleton.Structural
{
    /// <summary>
    /// Main startup class for Structural.
    /// Singleton design pattern.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Constractor is protected -- cannot use new
            Singleton s1 = Singleton.Instance();
            Singleton s2=Singleton.Instance();
            //Test same instance
            if (s1==s2)
            {
                Console.WriteLine("Objects are the same instance.");
            }
            //Wait for user
            Console.ReadKey();
        }
    }
    /// <summary>
    /// The 'Singleton' class.
    /// </summary>
    class  Singleton
    {
        private static Singleton _instance;
        //Constructor is 'protected'
        protected Singleton()
        {
        }

        public static Singleton Instance()
        {
            //Uses lazy initialization.
            //Note: This is not thread safe.
            if (_instance==null)
            {
                _instance=new Singleton();
            }
            return _instance;
        }
    }
}
