namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        private Warrior attacker;
        private Warrior defender;

        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
            attacker = new Warrior("at", 101, 100);
            defender = new Warrior("def", 60, 100);
        }

        [Test]
        public void Should_Constructor_Create_Elements() 
        {
            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void Should_IReadOnlyCollection_Warriors_Add_Warrior()
        {
            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void Should_Enroll_Work_Properly()
        {
            arena.Enroll(attacker);
            Assert.AreEqual(1, arena.Warriors.Count);
        }

        [Test]
        public void Should_ArenaCount_Work_Properly()
        {
            Assert.AreEqual(0, arena.Count);
        }

        [Test]
        public void Should_WarriorsCount_Work_Properly()
        {
            Assert.AreEqual(0, arena.Warriors.Count);
        }

        [Test]
        public void Should_Enroll_Throw_Exception_When_Warrior_Are_Dubling()
        {
            arena.Enroll(attacker);
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(attacker));
        }

        [Test]
        public void Should_Fight_Work_Properly()
        {
            arena.Enroll(attacker);
            arena.Enroll(defender);
            arena.Fight("at", "def");
            Assert.AreEqual(40, attacker.HP);
            Assert.AreEqual(0,defender.HP);
        }

        [Test]
        public void Should_Fight_Throw_Exception()
        {
            arena.Enroll(attacker);
            arena.Enroll(defender);
            Assert.Throws<InvalidOperationException>(() => arena.Fight("ati", "def"));
            Assert.Throws<InvalidOperationException>(() => arena.Fight("at", "de"));
        }
    }
}
