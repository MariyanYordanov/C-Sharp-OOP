using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] dataCar = Console.ReadLine().Split();
            string[] dataTruck = Console.ReadLine().Split();
            string[] dataBus = Console.ReadLine().Split();
            int N = int.Parse(Console.ReadLine());

            Car car = new Car(double.Parse(dataCar[3]), double.Parse(dataCar[1]), double.Parse(dataCar[2]));
            Truck truck = new Truck(double.Parse(dataTruck[3]), double.Parse(dataTruck[1]), double.Parse(dataTruck[2]));
            Bus bus = new Bus(double.Parse(dataBus[3]), double.Parse(dataBus[1]), double.Parse(dataBus[2]));

            for (int i = 0; i < N; i++)
            {
                string[] token = Console.ReadLine().Split();
                string methodType = token[0];
                string vehicleType = token[1];
                double kmOrLiters = double.Parse(token[2]);
                if (methodType == "Drive")
                {
                    if (vehicleType == "Car")
                    {
                        Console.WriteLine(car.Driving(kmOrLiters));
                    }
                    else if (vehicleType == "Truck")
                    {
                        Console.WriteLine(truck.Driving(kmOrLiters));
                    }
                    else if (vehicleType == "Bus")
                    {
                        Console.WriteLine(bus.Driving(kmOrLiters));
                    }
                }
                else if (methodType == "Refuel")
                {
                    if (vehicleType == "Car")
                    {
                        car.Refueling(kmOrLiters);
                    }
                    else if (vehicleType == "Truck")
                    {
                        truck.Refueling(kmOrLiters);
                    }
                    else if (vehicleType == "Bus")
                    {
                        bus.Refueling(kmOrLiters);
                    }
                }
                else if (methodType == "DriveEmpty")
                {
                    bus.People = PeopleInBus.Without;
                    Console.WriteLine(bus.Driving(kmOrLiters));
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }
    }
}
