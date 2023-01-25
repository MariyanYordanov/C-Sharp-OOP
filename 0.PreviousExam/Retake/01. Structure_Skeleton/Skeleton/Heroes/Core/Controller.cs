using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
using Heroes.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private readonly HeroRepository heroes;
        private readonly WeaponRepository weapons;
        private readonly Map map;

        public Controller()
        {
            heroes = new HeroRepository();
            weapons = new WeaponRepository();
            map = new Map();
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IHero hero = heroes.FindByName(heroName);
            if (hero == null)
            {
                throw new InvalidOperationException($"Hero { heroName } does not exist.");
            }

            IWeapon weapon = weapons.FindByName(weaponName);
            if (weapon == null)
            {
                throw new InvalidOperationException($"Weapon { weaponName } does not exist.");
            }

            if (hero.Weapon != null)
            {
                throw new InvalidOperationException($"Hero { heroName } is well-armed.");
            }

            hero.AddWeapon(weapon);

            return $"Hero { hero.Name } can participate in battle using a" +
                $" { weapon.GetType().Name.ToLower() }.";
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            IHero heroToAdd = null;
            if (heroes.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The hero { name } already exists.");
            }

            if (type == "Knight")
            {
                heroToAdd = new Knight(name, health, armour);
            }
            else if (type == "Barbarian")
            {
                heroToAdd = new Barbarian(name, health, armour);
            }
            else
            {
                throw new InvalidOperationException("Invalid hero type.");
            }

            heroes.Add(heroToAdd);

            if (heroToAdd.GetType().Name == "Knight")
            {
                return $"Successfully added Sir { name } to the collection.";

            }
            else
            {
                return $"Successfully added Barbarian { name } to the collection.";
            }
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            IWeapon weaponToAdd = null;
            if (weapons.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The weapon { name } already exists.");
            }

            if (type == "Claymore")
            {
                weaponToAdd = new Claymore(name, durability);
            }
            else if (type == "Mace")
            {
                weaponToAdd = new Mace(name, durability);
            }
            else
            {
                throw new InvalidOperationException("Invalid weapon type.");
            }

            weapons.Add(weaponToAdd);

            return $"A {weaponToAdd.GetType().Name.ToLower()} {weaponToAdd.Name} is added to the collection.";
        }

        public string HeroReport()
        {
            var players = heroes.Models
                .OrderBy(x => x.GetType().Name)
                .ThenByDescending(x => x.Health)
                .ThenBy(x => x.Name);

            StringBuilder sb = new StringBuilder();
            foreach (var hero in players)
            {
                sb.AppendLine($"{ hero.GetType().Name }: { hero.Name }");
                sb.AppendLine($"--Health: { hero.Health }");
                sb.AppendLine($"--Armour: { hero.Armour }");
                if (hero.Weapon != null)
                {
                    sb.AppendLine($"--Weapon: { hero.Weapon.Name }");
                }
                else
                {
                    sb.AppendLine($"--Weapon: /Unarmed");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string StartBattle()
        {
            return map.Fight((ICollection<IHero>)heroes.Models);
        }
    }
}
