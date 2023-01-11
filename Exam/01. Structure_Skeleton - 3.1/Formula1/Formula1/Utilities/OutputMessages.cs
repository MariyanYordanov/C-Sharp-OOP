namespace Formula1.Utilities
{
   public static class OutputMessages
    {
        public const string SuccessfullyCreatePilot = "Pilot {0} is created.";
                                                    //"Pilot { full name } is created."

        public const string SuccessfullyCreateCar = "Car {0}, model {1} is created.";
                                                  //"Car { type }, model { model } is created."

        public const string SuccessfullyCreateRace = "Race {0} is created.";
                                                   //"Race { race name } is created."

        public const string SuccessfullyPilotToCar = "Pilot {0} will drive a {1} {2} car.";
                                                   //"Pilot { pilot name } will drive a {type of car} { model } car."

        public const string SuccessfullyAddPilotToRace = "Pilot {0} is added to the {1} race.";
                                                       //"Pilot { pilot full name } is added to the { race name } race."

        public const string PilotFirstPlace = "Pilot {0} wins the {1} race.";
                                             //Pilot { pilot full name } wins the { race name } race.

        public const string PilotSecondPlace = "Pilot {0} is second in the {1} race.";
                                              //Pilot { pilot full name } is second in the { race name } race.

        public const string PilotThirdPlace = "Pilot {0} is third in the {1} race.";
                                             //Pilot { pilot full name } is third in the { race name } race."

    }
}
