using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoF.Adapter.Structural
{
    /// <summary>
    /// Main startup class for stuctural.
    /// Adapter design pattern.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //Create a Adapter and place a request.
            Target target=new Adapter();
            target.Request();
            //Wait for user
            Console.ReadKey();
        }
    }
    /// <summary>
    /// This is 'Target' class.
    /// </summary>
    class Target
    {
        public virtual void Request()
        {
            Console.WriteLine("Called Target Request()");
        }
    }
    /// <summary>
    /// The 'Adapter' class.
    /// </summary>
    class Adapter:Target
    {
        private Adaptee _adaptee=new Adaptee();
        public override void Request()
        {
            // Possibly do some other work
            //  and then call SpecificRequest
            _adaptee.SpecificRequest();
        }
    }
    /// <summary>
    /// The is 'Adaptee' class.
    /// </summary>
    class Adaptee
    {
        public void SpecificRequest()
        {
            Console.WriteLine("Called SpecificRequest()");
        }
    }
}
