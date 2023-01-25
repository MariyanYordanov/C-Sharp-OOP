using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private FormulaOneCarRepository carRepository;
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;

        public Controller()
        {
            carRepository = new FormulaOneCarRepository();
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot myPilot = pilotRepository.FindByName(pilotName);
            IFormulaOneCar myCar = carRepository.FindByName(carModel);

            if (myPilot == null || myPilot.Car != null)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages
                    .PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }
            if (myCar == null)
            {
                throw new NullReferenceException(
                    string.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }
            myPilot.AddCar(myCar);
            carRepository.Remove(myCar);
            return string.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, myCar.GetType().Name, carModel);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IRace myRace = raceRepository.FindByName(raceName);
            IPilot myPilot = pilotRepository.FindByName(pilotFullName);
            if (myRace == null)
            {
                throw new NullReferenceException(
                    string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            if (myPilot == null || myPilot.CanRace == false || myRace.Pilots.Any(x => x.FullName == pilotFullName))
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }
            myRace.AddPilot(myPilot);
            return string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            IFormulaOneCar existingCar = carRepository.FindByName(model);
            if (existingCar != null)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.CarExistErrorMessage, model));
            }
            IFormulaOneCar carToBeAdded = null;
            if (type == "Williams")
            {
                carToBeAdded = new Williams(model, horsepower, engineDisplacement);
            }
            else if (type == "Ferrari")
            {
                carToBeAdded = new Ferrari(model, horsepower, engineDisplacement);
            }
            else
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.InvalidTypeCar, type));
            }
            carRepository.Add(carToBeAdded);
            return string.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }

        public string CreatePilot(string fullName)
        {
            IPilot existingPilot = pilotRepository.FindByName(fullName);
            if (existingPilot != null)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }
            IPilot pilotToBeAdded = new Pilot(fullName);
            pilotRepository.Add(pilotToBeAdded);
            return string.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            IRace existingRace = raceRepository.FindByName(raceName);
            if (existingRace != null)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }
            IRace raceToBeAdded = new Race(raceName, numberOfLaps);
            raceRepository.Add(raceToBeAdded);
            return string.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string PilotReport()
        {
            StringBuilder sb = new StringBuilder();
            var pilots = pilotRepository.Models.ToList();
            foreach (var pilot in pilots.OrderByDescending(x => x.NumberOfWins))
            {
                sb.AppendLine(pilot.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();
            var races = raceRepository.Models.ToList();
            foreach (var race in races.Where(x => x.TookPlace == true))
            {
                sb.AppendLine(race.RaceInfo());
            };
            return sb.ToString().TrimEnd();
        }

        public string StartRace(string raceName)
        {
            IRace myRace = raceRepository.FindByName(raceName);
            if (myRace == null)
            {
                throw new NullReferenceException(
                    string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            int raceParticipantsCount = myRace.Pilots.Count;
            if (raceParticipantsCount < 3)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }
            if (myRace.TookPlace == true)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }
            myRace.TookPlace = true;
            int laps = myRace.NumberOfLaps;
            List<IPilot> winners = myRace.Pilots.OrderByDescending(x => x.Car.RaceScoreCalculator(laps)).Take(3).ToList();
            winners[0].WinRace();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format(OutputMessages.PilotFirstPlace, winners[0].FullName, raceName));
            sb.AppendLine(string.Format(OutputMessages.PilotSecondPlace, winners[1].FullName, raceName));
            sb.AppendLine(string.Format(OutputMessages.PilotThirdPlace, winners[2].FullName, raceName));
            return sb.ToString().TrimEnd();
        }
    }
}
