using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    /// <summary>
    /// This is 'ConcreteComponet' class
    /// </summary>
    public class HondaCity: IVehicle
    {
        public string Make => "HondaCity";

        public string Model => "CNG";
        public double Price => 100000;
    }
}
