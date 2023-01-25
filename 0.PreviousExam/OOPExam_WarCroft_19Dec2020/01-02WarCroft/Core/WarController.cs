using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private List<Character> party;
		private List<Item> pool;
		public WarController()
		{
			party = new List<Character>();
			pool = new List<Item>();
		}

		public string JoinParty(string[] args)
		{
			if (args[0] == "Priest")
            {
				party.Add(new Priest(args[1]));
			}
            else if (args[0] == "Warrior")
            {
				party.Add(new Warrior(args[1]));
			}
            else
            {
				throw new ArgumentException(
					string.Format(ExceptionMessages.InvalidCharacterType, args[1]));
			}

			return $"{args[1]} joined the party!";
		}

		public string AddItemToPool(string[] args)
		{
			if (args[0] == "FirePotion")
			{
				pool.Add(new FirePotion());
			}
			else if (args[0] == "HealthPotion")
			{
				pool.Add(new HealthPotion());
			}
			else
			{
				throw new ArgumentException(
					string.Format(ExceptionMessages.InvalidItem, args[0]));
			}

			return $"{args[0]} added to pool.";
		}

		public string PickUpItem(string[] args)
		{
			Character character = party.FirstOrDefault(x => x.Name == args[0]);
            if (character == null)
            {
				throw new ArgumentException(
					string.Format(ExceptionMessages.CharacterNotInParty, args[0]));
			}

			Item item = pool.LastOrDefault();
            if (item == null)
            {
				throw new InvalidOperationException("No items left in pool!");
			}

			character.Bag.AddItem(item);

			return $"{character.Name} picked up {item.GetType().Name}!";
		}

		public string UseItem(string[] args)
		{
			Character character = party.FirstOrDefault(x => x.Name == args[0]);
            if (character == null)
            {
				throw new ArgumentException(
					string.Format(ExceptionMessages.CharacterNotInParty, args[0]));
            }

			Item item = pool.FirstOrDefault(x => x.GetType().Name == args[1]);

			character.UseItem(item);

			return $"{character.Name} used {item.GetType().Name}.";
		}

		public string GetStats()
		{
			var info = party
				.OrderByDescending(x => x.IsAlive)
				.ThenByDescending(x => x.Health);

			StringBuilder sb = new StringBuilder();
            foreach (var hero in info)
            {
				string status = "Dead";
                if (hero.IsAlive)
                {
					status = "Alive";
                }

				sb.AppendLine($"{hero.Name} - HP: {hero.Health}/{hero.BaseHealth}," +
					$" AP: {hero.Armor}/{hero.BaseArmor}, Status: {status}");
			}

			return sb.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			var attacker = party.FirstOrDefault(x => x.Name == args[0]);
            if (attacker == null)
            {
				throw new ArgumentException(
					string.Format(ExceptionMessages.CharacterNotInParty, args[0]));
			}

			var receiver = party.FirstOrDefault(x => x.Name == args[1]);
			if (receiver == null)
			{
				throw new ArgumentException(
					string.Format(ExceptionMessages.CharacterNotInParty, args[1]));
			}

			if (attacker.GetType().Name == "Priest")
			{
				throw new ArgumentException($"{attacker.Name} cannot attack!");
			}

			var attackerAsWarrior = attacker as Warrior;

			attackerAsWarrior.Attack(receiver);

			if (!receiver.IsAlive)
			{
				return $"{attackerAsWarrior.Name} attacks {receiver.Name}" +
					$" for {attackerAsWarrior.AbilityPoints} hit points!" +
					$" {receiver.Name} has {receiver.Health}/{receiver.BaseHealth}" +
					$" HP and {receiver.Armor}/{receiver.BaseArmor} " +
					$"AP left!{Environment.NewLine}{receiver.Name} is dead!";
			}

			return $"{attackerAsWarrior.Name} attacks {receiver.Name}" +
				$" for {attackerAsWarrior.AbilityPoints} hit points! " +
				$"{receiver.Name} has {receiver.Health}/{receiver.BaseHealth} " +
				$"HP and {receiver.Armor}/{receiver.BaseArmor} AP left!";
		}

		public string Heal(string[] args)
		{
			var healer = party.FirstOrDefault(x => x.Name == args[0]);
			if (healer == null)
			{
				throw new ArgumentException(
					string.Format(ExceptionMessages.CharacterNotInParty, args[0]));
			}

			var receiver = party.FirstOrDefault(x => x.Name == args[1]);
			if (receiver == null)
			{
				throw new ArgumentException(
					string.Format(ExceptionMessages.CharacterNotInParty, args[1]));
			}

            if (healer.GetType().Name == "Warrior")
            {
				throw new ArgumentException($"{healer.Name} cannot heal!");

			}

			var trueHealer = healer as Priest;

			trueHealer.Heal(receiver);

			return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}!" +
				$" {receiver.Name} has {receiver.Health} health now!";
		}
	}
}
