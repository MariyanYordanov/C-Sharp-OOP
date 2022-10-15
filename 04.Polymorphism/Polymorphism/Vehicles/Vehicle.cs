namespace Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private double tankCapacity;
        private double fuelConsumption;
        private double fuelQuantity;
        protected Vehicle(double tankCapacity, double fuelQuantity, double fuelConsumption)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }
       
        
        public double FuelQuantity
        {
            get => fuelQuantity;
            private set
            {
                Validator.ValidateValue(value);
                if (value > TankCapacity)
                {
                    fuelQuantity = 0.0;
                }
                else
                {
                    fuelQuantity = value;
                }
                
            }
        }
        public double FuelConsumption
        {
            get => fuelConsumption;
            private set
            {
                Validator.ValidateValue(value);
                fuelConsumption = value;
            }
        }

        public double TankCapacity
        {
            get => tankCapacity;
            private set
            {
                tankCapacity = value;
            }
        }

        public virtual double AirConditioner => 0.0;

        public bool CanBeDriven(double distance)
        {
            double neededFuel = (FuelConsumption + AirConditioner) * distance;
            if (neededFuel <= FuelQuantity)
            {
                FuelQuantity -= neededFuel;
                return true;
            }
            else
            {
                return false;
            }
        }

        public string Driving(double distance)
        {
            if (CanBeDriven(distance))
            {
                return $"{GetType().Name} travelled {distance} km";
            }
            else
            {
                return $"{GetType().Name} needs refueling";
            }
        }

        public void Refueling(double litres)
        {
            if (!CanRefuel(litres))
            {
                return;
            }

            if (GetType().Name == "Truck")
            {
                FuelQuantity += litres * 0.95;
            }
            else if (GetType().Name == "Car")
            {
                FuelQuantity += litres;
            }
            else if (GetType().Name == "Bus")
            {
                FuelQuantity += litres;
            }
        }

        public override string ToString()
        {
            return $" {FuelQuantity:F2}";
        }

        private bool CanRefuel(double litres)
        {
            if (litres <= 0)
            {
                System.Console.WriteLine("Fuel must be a positive number");
                return false;
            }

            if (litres + FuelQuantity > TankCapacity)
            {
                System.Console.WriteLine($"Cannot fit {litres} fuel in the tank");
                return false;
            }

            return true;
        }
    }
}
