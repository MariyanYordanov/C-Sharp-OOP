namespace Vehicles
{
    public class Truck : Vehicle 
    {
        public Truck(double tankCapasity, double fuelQuantity, double fuelConsumption)
            : base(tankCapasity, fuelQuantity, fuelConsumption)
        {
        }

        public override double AirConditioner => base.AirConditioner + 1.6;
        public override string ToString()
        {
            return $"{GetType().Name}:" + base.ToString();
        }

    }
}
