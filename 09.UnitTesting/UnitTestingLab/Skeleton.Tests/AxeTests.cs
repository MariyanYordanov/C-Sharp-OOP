using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void WeaponLosesDurabilityAfterAttack()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);
            axe.Attack(dummy);
            Assert.That(axe.DurabilityPoints, Is.EqualTo(9),"Axe DurabilityPoints doesn't change after attack");
        }

        [Test]
        public void AttackingWithBrokenWeapon()
        {
            Axe axe = new Axe(10, 1);
            axe.Attack(new Dummy(10, 10));
            Assert.That(() => { axe.Attack(new Dummy(10, 10)); }, Throws.InvalidOperationException, "The wepon is broken");
        }
    }
}