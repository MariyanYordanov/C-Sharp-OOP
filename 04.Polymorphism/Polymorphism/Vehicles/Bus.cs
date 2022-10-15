using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        public Bus(double tankCapasity, double fuelQuantity, double fuelConsumption)
            : base(tankCapasity, fuelQuantity, fuelConsumption)
        {
        }

        public PeopleInBus People { get; set; }

        public override double AirConditioner
        {
            get
            {
                if (People == PeopleInBus.Without)
                {
                    return base.AirConditioner;
                }
                else
                {
                    return base.AirConditioner + 1.4;
                }
            }
        }

        public override string ToString()
        {
            return $"{GetType().Name}:" + base.ToString();
        }
    }
}
