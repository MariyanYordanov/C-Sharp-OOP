using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return $"Race cannot be completed because both racers are not available!";
            }

            if (!racerOne.IsAvailable())
            {
                return $"{racerTwo} wins the race! {racerOne} was not available to race!";
            }

            if (!racerTwo.IsAvailable())
            {
                return $"{racerOne} wins the race! {racerTwo} was not available to race!";
            }

            racerOne.Race();
            racerTwo.Race();

            double behaviorFirst = 0;

            if (racerOne.RacingBehavior == "strict")
            {
                behaviorFirst = 1.2;
            }
            else if (racerOne.RacingBehavior == "aggressive")
            {
                behaviorFirst = 1.1;
            }

            double behaviorSecond = 0;

            if (racerTwo.RacingBehavior == "strict")
            {
                behaviorSecond = 1.2;
            }
            else if (racerTwo.RacingBehavior == "aggressive")
            {
                behaviorSecond = 1.1;
            }

            var chanceOfWinningFirst = 
                racerOne.Car.HorsePower * 
                racerOne.DrivingExperience * 
                behaviorFirst;
            var chanceOfWinningSecond = 
                racerTwo.Car.HorsePower * 
                racerTwo.DrivingExperience * 
                behaviorSecond;

            IRacer winner;
            if (chanceOfWinningFirst > chanceOfWinningSecond)
            {
                winner = racerOne;
            }
            else
            {
                winner = racerTwo;
            }
            
            return $"{racerOne.Username} has just raced against {racerTwo.Username}! " +
                $"{winner.Username} is the winner!";
        }
    }
}
