namespace Vehicles
{
    public class Car : Vehicle
    {
        public Car(double tankCapasity, double fuelQuantity, double fuelConsumption)
            : base(tankCapasity, fuelQuantity, fuelConsumption)
        {
        }

        public override double AirConditioner => base.AirConditioner + 0.9;

        public override string ToString()
        {
            return $"{GetType().Name}:" + base.ToString();
        }
    }
}
