namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior testWarrior;

        [SetUp]
        public void SetUp()
        {
            testWarrior = new Warrior("test", 100, 100);
        }

        [Test]
        public void Should_Constructor_Create_Warrior()
        {
            Assert.IsNotNull(testWarrior);
        }

        [Test]
        public void Should_Name_Throw_Exception_When_Value_Is_Null()
        {
            Assert.Throws<ArgumentException>(() => new Warrior(null, 100, 100));
        }

        [Test]
        public void Should_Name_Throw_Exception_When_Value_Is_Empty()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("", 100, 100));
        }

        [Test]
        public void Should_Damage_Throw_Exception_When_Value_Is_Less_Than_Zero()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("test", -1, 100));
        }

        [Test]
        public void Should_Damage_Throw_Exception_When_Value_Is_Zero()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("test", 0, 100));
        }

        [Test]
        public void Should_HP_Throw_Exception_When_Value_Is_Less_Than_Zero()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("test", 100, -1));
        }

        [Test]
        public void Should_Attack_Calculate_Properly_MyWarrior_HP()
        {
            Warrior myWarrior = new Warrior("myWarrior", 50, 100);
            Warrior warriorToAttack = new Warrior("warriorToAttack", 90, 50);
            myWarrior.Attack(warriorToAttack);
            Assert.AreEqual(10, myWarrior.HP);
        }

        [Test]
        public void Should_Attack_Calculate_Properly_WarriorToAttack_HP_If_MyWarrior_Damage_Is_Bigger_Than_WarriorToAttack_HP()
        {
            Warrior myWarrior = new Warrior("myWarrior", 150, 100);
            Warrior warriorToAttack = new Warrior("warriorToAttack", 90, 50);
            myWarrior.Attack(warriorToAttack);
            Assert.AreEqual(0, warriorToAttack.HP);
        }

        [Test]
        public void Should_Attack_Calculate_Properly_WarriorToAttack_If_WarriorToAttack_HP_Is_Greater_Than_MyWarrior_Damage()
        {
            Warrior myWarrior = new Warrior("myWarrior", 50, 100);             
            Warrior warriorToAttack = new Warrior("warriorToAttack", 50, 101); 
            myWarrior.Attack(warriorToAttack);
            Assert.AreEqual(51, warriorToAttack.HP);
        }

        [Test]
        public void Should_Attack_Calculate_Properly_WarriorToAttack_If_WarriorToAttack_HP_Is_Equal_Than_MyWarrior_Damage()
        {
            Warrior myWarrior = new Warrior("myWarrior", 50, 100);
            Warrior warriorToAttack = new Warrior("warriorToAttack", 50, 100);
            myWarrior.Attack(warriorToAttack);
            Assert.AreEqual(50, warriorToAttack.HP);
        }

        [Test]
        public void Should_Attack_Throw_Exception_When_My_Warrior_HP_Is_Less_Than_MIN_ATTACK_HP()
        {
            Warrior myWarrior = new Warrior("myWarrior", 100, 29);
            Assert.Throws<InvalidOperationException>(() => myWarrior.Attack(testWarrior));
        }

        [Test]
        public void Should_Attack_Throw_Exception_When_WarriorToAttack_HP_Is_Less_Than_MIN_ATTACK_HP()
        {
            Warrior myWarrior = new Warrior("myWarrior", 100, 100);
            Warrior warriorToAttack = new Warrior("warrior", 100, 29);
            Assert.Throws<InvalidOperationException>(() => myWarrior.Attack(warriorToAttack));
        }

        [Test]
        public void Should_Attack_Throw_Exception_When_MyWarrior_Damage_Is_Less_Than_WarriorToAttack_Damage()
        {
            Warrior myWarrior = new Warrior("myWarrior", 50, 50);
            Warrior warriorToAttack = new Warrior("warriorToAttack", 100, 100);
            Assert.Throws<InvalidOperationException>(() => myWarrior.Attack(warriorToAttack));
        }
    }
}