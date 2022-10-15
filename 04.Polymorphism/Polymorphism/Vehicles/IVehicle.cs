namespace Vehicles
{
    public interface IVehicle
    {
        double TankCapacity { get; }
        double FuelConsumption { get; }
        double FuelQuantity { get; }
        double AirConditioner { get; }

        bool CanBeDriven(double distance);
        string Driving(double distance);
        void Refueling(double litres);
    }
}
