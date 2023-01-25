using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;
using System;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly IRepository<IDriver> driverRepository;
        private readonly IRepository<ICar> carRepository;
        private readonly IRepository<IRace> raceRepository;

        public ChampionshipController()
        {
            driverRepository = new DriverRepository();
            carRepository = new CarRepository();
            raceRepository = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            var driverCheck = driverRepository.GetByName(driverName);
            if (driverCheck == null)
            {
                throw new InvalidOperationException(
                    $"Driver {driverName} could not be found.");
            }

            var carCheck = carRepository.GetByName(carModel);
            if (carCheck == null)
            {
                throw new InvalidOperationException(
                    $"Car {carModel} could not be found.");
            }

            driverCheck.AddCar(carCheck);

            return $"Driver {driverName} received car {carModel}.";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var raceCheck = raceRepository.GetByName(raceName);
            if (raceCheck == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            var driverCheck = driverRepository.GetByName(driverName);
            if (driverCheck == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            raceCheck.AddDriver(driverCheck);
            
            return $"Driver {driverName} added in {raceName} race.";
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = null;
            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            var carCheck = carRepository.GetByName(model);
            if (carCheck != null)
            {
                throw new ArgumentException($"Car {model} is already create.");
            }

            this.carRepository.Add(car);

            return $"{car.GetType().Name} {model} is created.";
        }

        public string CreateDriver(string driverName)
        {
            var driverCheck = driverRepository.GetByName(driverName);
            if (driverCheck != null)
            {
                throw new ArgumentException($"Driver {driverName} is already created.");
            }

            IDriver driver = new Driver(driverName);

            this.driverRepository.Add(driver);

            return $"Driver {driverName} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            var raceCheck = raceRepository.GetByName(name);
            if (raceCheck != null)
            {
                throw new InvalidOperationException($"Race {name} is already created.");
            }

            IRace race = new Race(name, laps);

            this.raceRepository.Add(race);

            return $"Race {name} is created.";
        }

        public string StartRace(string raceName)
        {
            var raceToStart = this.raceRepository.GetByName(raceName);
            if (raceToStart == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (raceToStart.Drivers.Count < 3)
            {
                throw new InvalidOperationException(
                    $"Race {raceName} cannot start with less than 3 participants.");
            }

           var topDrivers = raceToStart.Drivers
                .OrderByDescending(x => x.Car.CalculateRacePoints(raceToStart.Laps))
                .Take(3)
                .ToArray();

            this.raceRepository.Remove(raceToStart);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Driver {topDrivers[0].Name} wins {raceName} race.");
            sb.AppendLine($"Driver {topDrivers[1].Name} is second in {raceName} race.");
            sb.AppendLine($"Driver {topDrivers[2].Name} is third in {raceName} race.");

            return sb.ToString().TrimEnd();
        }
    }
}
