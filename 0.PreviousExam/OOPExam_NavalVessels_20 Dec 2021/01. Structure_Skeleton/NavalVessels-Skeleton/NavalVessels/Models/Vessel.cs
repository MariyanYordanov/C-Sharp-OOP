using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        private double mainWeaponCaliber;
        private double speed;
        private double armorThickness;
        private readonly List<string> targets;

        protected Vessel(
            string name,
            double mainWeaponCaliber,
            double speed,
            double armorThickness)
        {
            Name = name;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed;
            ArmorThickness = armorThickness;
            targets = new List<string>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Vessel name cannot be null or empty.");
                }

                name = value;
            }
        }

        public ICaptain Captain
        {
            get => captain;
            set
            {
                captain = value ?? throw new 
                    NullReferenceException("Captain cannot be null.");
            }
        }
        public double ArmorThickness
        {
            get => armorThickness;
            set 
            {
                armorThickness = value;

                if (armorThickness < 0)
                {
                    armorThickness = 0;
                }
            } 
        }

        public double MainWeaponCaliber
        {
            get => mainWeaponCaliber;
            protected set => mainWeaponCaliber = value;
        }

        public double Speed 
        { 
            get => speed;
            protected set => speed = value;
        }
        public ICollection<string> Targets => targets;

        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null.");
            }

            target.ArmorThickness -= this.MainWeaponCaliber; 

            targets.Add(target.Name);
        }

        public abstract void RepairVessel();
       
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($" - {this.Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Armor thickness: {this.ArmorThickness}");
            sb.AppendLine($" *Main weapon caliber: {this.MainWeaponCaliber}");
            sb.AppendLine($" *Speed: {this.Speed} knots");
            if (this.Targets.Count == 0)
            {
                sb.AppendLine($" *Targets: None");
            }
            else
            {
                sb.AppendLine($" *Targets: {string.Join(", ",this.Targets)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
