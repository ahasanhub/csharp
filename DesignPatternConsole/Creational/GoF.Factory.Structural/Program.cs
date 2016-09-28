using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoF.Factory.Structural
{
    /// <summary>
    /// Main startup class for structural.
    /// This is Factory Method design pattarn.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry of console application.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // An array of creators
            Creator[] creators = new Creator[2];

            creators[0] = new ConcreteCreatorA();
            creators[1] = new ConcreteCreatorB();
            // Iterate over creators and create products
            foreach (Creator creator in creators)
            {
                Product product = creator.FactoryMethod();
                Console.WriteLine("Created {0}",
                  product.GetType().Name);
            }

            // Wait for user
            Console.ReadKey();
        }
    }
    /// <summary>
    /// The 'Product' abstract class.
    /// </summary>
    abstract class Product
    {
    }
    /// <summary>
    /// A 'ConcreteProduct' class.
    /// </summary>
    class ConcreteProductA:Product
    {
        
    }
    /// <summary>
    /// A 'ConcreteProduct' class.
    /// </summary>
    class ConcreteProductB:Product
    {

    }
    /// <summary>
    /// The 'Creator' Abstract class.
    /// </summary>
    abstract class Creator
    {
        public abstract Product FactoryMethod();
    }
    /// <summary>
    /// The 'ConcreteCreator' class.
    /// </summary>
    class ConcreteCreatorA : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductA();
        }
    }
    /// <summary>
    /// The 'ConcreteCreator' class.
    /// </summary>
    class ConcreteCreatorB : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductB();
        }
    }


}
