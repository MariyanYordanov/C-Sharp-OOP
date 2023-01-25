using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]
        public void Constructor_Should_SetCapacityCorrectly()
        {
            var shop = new Shop(6);

            Assert.That(shop.Capacity, Is.EqualTo(6));
        }

        [Test]
        public void Negative_CapacityShould_ThrowException()
        {
            Assert.Throws<ArgumentException>(
                () => new Shop(-6),
                "Invalid capacity.");
        }

        [Test]
        public void Constructor_ShouldSetCount_Correctly()
        {
            var shop = new Shop(6);
            var smartphone = new Smartphone("Samsung Galaxy A50", 100);

            shop.Add(smartphone);

            Assert.That(shop.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddMethod_ShouldAddSmartphone_Correctly()
        {
            var shop = new Shop(6);
            var smartphone = new Smartphone("Samsung Galaxy A50", 100);

            shop.Add(smartphone);

            Assert.That(shop.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddMethod_Should_ThrowExceptionIfSmartphoneExisting()
        {
            var shop = new Shop(6);
            var smartphone = new Smartphone("Samsung Galaxy A50", 100);

            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(
                () => shop.Add(smartphone),
                $"The phone model {smartphone.ModelName} already exist.");
        }

        [Test]
        public void AddMethod_ShouldThrowExceptio_IfNoCapacityLeft()
        {
            var shop = new Shop(1);
            var smartphone = new Smartphone("Samsung Galaxy A50", 100);

            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(
                () => shop.Add(new Smartphone("Iphone 10", 1000)),
                "The shop is full.");
        }

        [Test]
        public void RemoveMethod_ShouldRemoveSmartphoneCorrectly()
        {
            var shop = new Shop(5);
            var smartphone = new Smartphone("Samsung Galaxy A50", 100);

            shop.Add(smartphone);
            shop.Remove("Samsung Galaxy A50");

            Assert.That(shop.Count, Is.EqualTo(0));
        }

        [Test]
        public void RemoveMethod_ShouldThrowExceptionIfTheSmartphoneIs_Null()
        {
            var shop = new Shop(1);
            var smartphone = new Smartphone("Samsung Galaxy A50", 100);

            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(
                () => shop.Remove(null),
                $"The phone model {smartphone.ModelName} doesn't exist.");
        }

        [Test]
        public void TestPhoneMethod_ShouldThrowExceptionIfSmartphoneIsNull()
        {
            var shop = new Shop(1);
            var smartphone = new Smartphone("Samsung Galaxy A50", 100);

            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(
                () => shop.TestPhone(null, 100),
                $"The phone model {smartphone.ModelName} doesn't exist.");
        }

        [Test]
        public void TestPhoneMethod_ShouldThrowException0IfSmartphoneBatteryIsBellowThe_CurrentBateryCharge()
        {
            var shop = new Shop(1);
            var smartphone = new Smartphone("Samsung Galaxy A50", 100);

            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(
                () => shop.TestPhone("Samsung Galaxy A50", 1000),
                $"The phone model {smartphone.ModelName} is low on batery.");
        }

        [Test]
        public void TestPhoneMethod_Should_DecreaseBatteryChargeCorrectly()
        {
            var shop = new Shop(1);
            var smartphone = new Smartphone("Samsung Galaxy A50", 100);

            shop.Add(smartphone);
            shop.TestPhone("Samsung Galaxy A50", 50);

            Assert.That(smartphone.CurrentBateryCharge, Is.EqualTo(50));
        }

        [Test]
        public void ChargePhoneMethod_ShouldThrowExceptionIfSmartphoneIsNull()
        {
            var shop = new Shop(1);
            var smartphone = new Smartphone("Samsung Galaxy A50", 100);

            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(
                () => shop.ChargePhone(null),
               $"The phone model {smartphone.ModelName} doesn't exist.");
        }

        [Test]
        public void ChargePhoneMethod_ShouldChargeSmartphoneCorrectly()
        {
            var shop = new Shop(1);
            var smartphone = new Smartphone("Samsung Galaxy A50", 100);

            shop.Add(smartphone);
            shop.TestPhone("Samsung Galaxy A50", 80);
            shop.ChargePhone("Samsung Galaxy A50");

            Assert.That(smartphone.CurrentBateryCharge, Is.EqualTo(100));
        }
    }
}