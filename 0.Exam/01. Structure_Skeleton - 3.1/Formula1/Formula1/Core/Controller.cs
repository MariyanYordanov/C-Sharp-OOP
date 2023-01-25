using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private readonly PilotRepository pilotRepository;
        private readonly RaceRepository raceRepository;
        private readonly FormulaOneCarRepository carRepository;

        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
            carRepository = new FormulaOneCarRepository();
        }

        // problem
        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilotToUse = pilotRepository.FindByName(pilotName); 
            IFormulaOneCar formula = carRepository.FindByName(carModel);

            if (pilotToUse == null || pilotToUse.Car != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }

            if (formula == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
                    
            }

            pilotToUse.AddCar(formula);

            carRepository.Remove(formula);

            return $"Pilot {pilotToUse.FullName} will drive a {formula.GetType().Name} {formula.Model} car.";
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IPilot pilotToAdd = pilotRepository.FindByName(pilotFullName);
            IRace race = raceRepository.FindByName(raceName);

            if (race == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if (pilotToAdd == null ||
                pilotToAdd.CanRace == false ||
                race.Pilots.Any(x => x.FullName == pilotFullName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            race.AddPilot(pilotToAdd);

            return $"Pilot {pilotToAdd.FullName} is added to the {race.RaceName} race.";
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            IFormulaOneCar formula1 = carRepository.FindByName(model);
            if (formula1 != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, model));
            }

            IFormulaOneCar formula;

            if (type == "Ferrari")
            {
                formula = new Ferrari(model, horsepower, engineDisplacement);
            }
            else if (type == "Williams")
            {
                formula = new Williams(model, horsepower, engineDisplacement);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar,type));
            }

            carRepository.Add(formula);

            return $"Car {formula.GetType().Name}, model {formula.Model} is created.";
        }

        public string CreatePilot(string fullName)
        {
            IPilot pilot1 = pilotRepository.FindByName(fullName);
            if (pilot1 != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage,fullName));
            }

            IPilot pilotToUse = new Pilot(fullName);

            pilotRepository.Add(pilotToUse);

            return $"Pilot {pilotToUse.FullName} is created.";
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            IRace race1 = raceRepository.FindByName(raceName);
            if (race1 != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage,raceName));
            }

            IRace race = new Race(raceName, numberOfLaps);

            raceRepository.Add(race);

            return $"Race {race.RaceName} is created.";
        }

        public string PilotReport()
        {
            StringBuilder sb = new StringBuilder();
            var pilots = pilotRepository.Models.OrderByDescending(x => x.NumberOfWins).ToList();
            foreach (var pilot in pilots)
            {
                sb.AppendLine(pilot.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();
            var races = raceRepository.Models.Where(x => x.TookPlace == true).ToList();
            foreach (var race in races)
            {
                sb.AppendLine(race.RaceInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string StartRace(string raceName)
        {
            IRace race = raceRepository.FindByName(raceName);
            
            if (race == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage,raceName));
            }

            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }

            if (race.TookPlace == true)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            race.TookPlace = true;
            race.Pilots.Any(x => x.CanRace);

            var winners = race.Pilots
                .OrderByDescending(x => x.Car.RaceScoreCalculator(race.NumberOfLaps))
                .Take(3)
                .ToArray();
            winners[0].WinRace();
           
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Pilot {winners[0].FullName} wins the {raceName} race.");
            sb.AppendLine($"Pilot {winners[1].FullName} is second in the {raceName} race.");
            sb.AppendLine($"Pilot {winners[2].FullName} is third in the {raceName} race.");


            return sb.ToString().TrimEnd();
        }
    }
}
