using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void AttackedDummyLosesHealth()
        {
            Axe axe = new Axe(10,10);
            Dummy dummy = new Dummy(10,10);
            axe.Attack(dummy);
            Assert.That(dummy.Health, Is.EqualTo(0), "Dummy Healt is zero");
        }

        [Test]
        public void DeadDummyThrowsException()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);
            dummy.TakeAttack(axe.AttackPoints);
            Assert.That(() => { dummy.TakeAttack(axe.AttackPoints); }, Throws.InvalidOperationException, "TakeAttack throws exception after dummy death");
        }

        [Test]
        public void CanDeadDummyGiveXP()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(11, 10);
            dummy.TakeAttack(axe.AttackPoints);
            Assert.That(() => { dummy.GiveExperience(); }, Throws.InvalidOperationException, "Dead Dummy can't give his ecxpirience points");
        }

        [Test]
        public void CantDeadDummyGiveXP()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);
            dummy.TakeAttack(axe.AttackPoints);
            Assert.That(dummy.GiveExperience(), Is.EqualTo(10), "Return experience points");
        }

    }
}