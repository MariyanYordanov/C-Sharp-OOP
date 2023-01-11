namespace Formula1.Utilities
{
    public static class ExceptionMessages
    {
        public const string InvalidF1CarModel = "Invalid car model: {0}.";
                                              //"Invalid car model: { model }."

        public const string InvalidF1HorsePower = "Invalid car horsepower: {0}.";
                                                //"Invalid car horsepower: { horsepower }."

        public const string InvalidF1EngineDisplacement = "Invalid car engine displacement: {0}.";
                                                        //"Invalid car engine displacement: { engine displacement }."

        public const string CarExistErrorMessage = "Formula one car {0} is already created.";
                                                 //"Formula one car { model } is already created."

        public const string InvalidTypeCar = "Formula one car type {0} is not valid.";
                                           //"Formula one car type { type } is not valid."

        public const string CarDoesNotExistErrorMessage = "Car {0} does not exist.";
                                                        //"Car { model } does not exist."

        public const string InvalidPilot = "Invalid pilot name: {0}.";
                                         //"Invalid pilot name: { fullName }."

        public const string InvalidCarForPilot = "Pilot car can not be null.";
                                               //"Pilot car can not be null."

        // Ha-ha-ha missing message
        public const string InvalidPilotForRace = "Null pilot can not be added to a race.";
        //


        public const string PilotExistErrorMessage = "Pilot {0} is already created.";
                                                   //"Pilot { full name } is already created."

        public const string PilotDoesNotExistErrorMessage = "Can not add pilot {0} to the race.";
                                                          //"Can not add pilot { pilot full name } to the race."

        public const string PilotDoesNotExistOrHasCarErrorMessage = "Pilot {0} does not exist or has a car.";
                                                                  //"Pilot { pilot name } does not exist or has a car."

        public const string InvalidRaceName = "Invalid race name: {0}.";
                                            //"Invalid race name: { race name }."

        public const string InvalidLapNumbers = "Invalid lap numbers: {0}.";
                                              //"Invalid lap numbers: { number of laps }."

        public const string RaceExistErrorMessage = "Race {0} is already created.";
                                                  //"Race { race name } is already created."

        public const string RaceDoesNotExistErrorMessage = "Race {0} does not exist.";
                                                         //"Race { race name } does not exist."

        public const string InvalidRaceParticipants = "Race {0} cannot start with less than three participants.";
                                                    //"Race { race name } cannot start with less than three participants."

        public const string RaceTookPlaceErrorMessage = "Can not execute race {0}.";
                                                      //"Can not execute race { race name }."

    }
}
