using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    /// <summary>
    /// This is 'ConcreteDecorator' class
    /// </summary>
    public class SpecialOffer : VehicleDecorator
    {
        public SpecialOffer(IVehicle vehicle) : base(vehicle)
        {
        }

        public int DiscountPercentage { get; set; }
        public string Offer { get; set; }

        public new double Price
        {
            get
            {
                double price = base.Price;
                int percentage = 100 - DiscountPercentage;
                return Math.Round((price*percentage)/100, 2);
            }
        }
    }
}
