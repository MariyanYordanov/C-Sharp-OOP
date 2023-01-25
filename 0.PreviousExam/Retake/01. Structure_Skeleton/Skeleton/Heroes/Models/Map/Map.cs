using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            List<IHero> knights = new List<IHero>();
            List<IHero> barbarians = new List<IHero>();

            int deadKnight = 0;
            int deadBarbarians = 0;

            foreach (var player in players)
            {
                if (player.GetType().Name == nameof(Knight))
                {
                    knights.Add(player);
                }
                else
                {
                    barbarians.Add(player);
                }
            }

            for (int i = 0; i < knights.Count; i++)
            {
                if (knights[i].IsAlive)
                {
                    foreach (var barbarian in barbarians)
                    {
                        barbarian.TakeDamage(knights[i].Weapon.DoDamage());
                        if (!barbarian.IsAlive)
                        {
                            deadBarbarians++;
                        }
                    }
                }
            }

            for (int i = 0; i < barbarians.Count; i++)
            {
                if (barbarians[i].IsAlive)
                {
                    foreach (var knight in knights)
                    {
                        knight.TakeDamage(barbarians[i].Weapon.DoDamage());
                        if (!knight.IsAlive)
                        {
                            deadKnight++;
                        }
                    }
                }
            }


            if (barbarians.Count < knights.Count)
            {
                return $"The knights took {deadKnight} casualties but won the battle.";
            }
            else
            {
                return $"The barbarians took {deadBarbarians} casualties but won the battle.";
            }
        }
    }
}
