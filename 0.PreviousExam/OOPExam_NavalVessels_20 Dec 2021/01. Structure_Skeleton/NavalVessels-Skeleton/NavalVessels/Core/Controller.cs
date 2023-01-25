using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private readonly VesselRepository vessels;
        private readonly List<ICaptain> captains;

        public Controller()
        {
            vessels = new VesselRepository();
            captains = new List<ICaptain>();
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain captainToFind = captains
                .FirstOrDefault(x => x.FullName == selectedCaptainName);
            if (captainToFind == null)
            {
                return $"Captain {captainToFind.FullName} could not be found.";
            }

            IVessel vasselToFind = vessels.FindByName(selectedVesselName);
            if (vasselToFind == null)
            {
                return $"Vessel {selectedVesselName} could not be found.";
            }

            if (vasselToFind.Captain != null)// problem
            {
                return $"Vessel {selectedVesselName} is already occupied."; 
            }

            captainToFind.AddVessel(vasselToFind);
            
            vasselToFind.Captain = captainToFind; // problem

            return $"Captain {selectedCaptainName} command vessel {selectedVesselName}.";
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel attacer = vessels.FindByName(attackingVesselName);
            if (attacer == null)
            {
               return $"Vessel {attacer.Name} could not be found.";
            }

            IVessel defender = vessels.FindByName(defendingVesselName);
            if (defender == null)
            {
                return $"Vessel {defender.Name} could not be found.";
            }

            if (attacer.ArmorThickness == 0)
            {
                return $"Unarmored vessel {attacer.Name} cannot attack or be attacked.";
            }

            if (defender.ArmorThickness == 0)
            {
                return $"Unarmored vessel {defender.Name} cannot attack or be attacked.";
            }

            attacer.Attack(defender);

            defender.Captain.IncreaseCombatExperience();
            attacer.Captain.IncreaseCombatExperience();

            return $"Vessel {defender.Name} was attacked by vessel {attacer.Name}" +
                $" - current armor thickness: {defender.ArmorThickness}.";
        }

        public string CaptainReport(string captainFullName)
        {
            ICaptain captainToReport = captains
                .FirstOrDefault(x => x.FullName == captainFullName);

            return captainToReport.Report();
        }

        public string HireCaptain(string fullName)
        {
            ICaptain captainToUse = new Captain(fullName);

            if (captains.Contains(captainToUse))
            {
                return $"Captain {fullName} is already hired.";
            }
            else
            {
                captains.Add(captainToUse);
            }

            return $"Captain {captainToUse.FullName} is hired.";
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            IVessel vesselToUse;
            if (vesselType == "Submarine")
            {
                vesselToUse = new Submarine(name, mainWeaponCaliber,speed);
            }
            else if (vesselType == "Battleship")
            {
                vesselToUse = new Battleship(name, mainWeaponCaliber, speed);
            }
            else
            {
                return $"Invalid vessel type.";
            }

            vessels.Add(vesselToUse);

            return $"{vesselToUse.GetType().Name} {vesselToUse.Name} " +
                $"is manufactured with the main weapon caliber" +
                $" of {vesselToUse.MainWeaponCaliber} inches" +
                $" and a maximum speed of {vesselToUse.Speed} knots.";
        }

        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);
            if (vessel == null)
            {
                return $"Vessel {vessel.Name} could not be found.";
            }

            vessel.RepairVessel();

            return $"Vessel {vessel.Name} was repaired.";
        }

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vesselSpecialMode = vessels.FindByName(vesselName);
            if (vesselSpecialMode == null)
            {
                return $"Vessel {vesselSpecialMode.Name} could not be found.";
                
            }
            else
            {
                if (vesselSpecialMode.GetType().Name == "Battleship")
                {
                    Battleship battleship = vesselSpecialMode as Battleship;
                    battleship.ToggleSonarMode();
                    return $"Battleship {battleship.Name} toggled sonar mode.";
                }
                else 
                {
                    Submarine submarine = vesselSpecialMode as Submarine;
                    submarine.ToggleSubmergeMode();
                    return $"Submarine {submarine.Name} toggled submerge mode.";
                }
            }
            
        }

        public string VesselReport(string vesselName)
        {
            IVessel vesselToReport = vessels.FindByName(vesselName);

            return vesselToReport.ToString();
        }
    }
}
