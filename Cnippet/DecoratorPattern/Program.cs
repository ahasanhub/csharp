using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //Basic vehicle
            HondaCity car=new HondaCity();
            Console.WriteLine($"Honda city base price are {car.Price}");

            //Special offer
            SpecialOffer offer=new SpecialOffer(car);
            offer.DiscountPercentage = 25;
            offer.Offer = "25 % discount";
            Console.WriteLine($"{offer.Offer} @ Diwali special offer and price are : {offer.Price}");
            Console.ReadKey();
        }
    }
}
