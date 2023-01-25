using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private string msg;
        public Battleship(
            string name,
            double mainWeaponCaliber,
            double speed)
            : base(name, mainWeaponCaliber, speed, 300)
        {
        }

        public bool SonarMode { get; private set; } = false;

        public void ToggleSonarMode()
        {
            if (this.SonarMode == false)
            {
                this.SonarMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
                this.msg = "ON";
            }
            else if (this.SonarMode == true)
            {
                SonarMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
                this.msg = "OFF";
            }
        }

        public override void RepairVessel()
        {
            if (this.ArmorThickness < 300)
            {
                this.ArmorThickness = 300;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Sonar mode: {msg}");

            return sb.ToString().TrimEnd();
        }
    }
}
