using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double armor;
        private double abilityPoints;
        protected Bag bag;
        

        protected Character(string name,
            double baseHealth, 
            double baseArmor, 
            double abilityPoints, 
            Bag bag)
        {
            Name = name;
            BaseHealth = baseHealth;
            BaseArmor = baseArmor;
            Health = baseHealth;
            Armor = baseArmor;
            AbilityPoints = abilityPoints;
            Bag = bag;
            IsAlive = true;
        }


        public Bag Bag { get; }

        public double AbilityPoints
        {
            get => this.abilityPoints;
            private set
            {
                abilityPoints = value;
            }
        }

        public double BaseHealth
        {
            get => this.baseHealth;
            private set
            {
                this.baseHealth = value;
            }
        }

        public double BaseArmor
        {
            get => this.baseArmor;
            private set
            {
                this.baseArmor = value;
            }
        }

        public double Health
        {
            get => this.health;
            internal set
            {
                this.health = value;

                if (this.health > this.baseHealth)
                {
                    this.health = this.baseHealth;
                }

                if (this.health < 0)
                {
                    this.health = 0;
                    IsAlive = false;
                }
            }
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }

                name = value;
            }
        }

        public double Armor
        {
            get => this.armor;
            private set
            {
                this.armor = value;

                if (this.armor < 0)
                {
                    this.armor = 0;
                }
            }
        }

        public bool IsAlive { get; set; } = true;

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();
            if (hitPoints > this.Armor)
            {
                this.Armor = 0;
                this.Health -= (hitPoints - this.Armor);
            }

            this.Armor -= hitPoints;

            if (this.Health < 0)
            {
                this.IsAlive = false;
            }
        }

        public void UseItem(Item item)
        {
            this.EnsureAlive();
            item.AffectCharacter(this);
        }
    }
}