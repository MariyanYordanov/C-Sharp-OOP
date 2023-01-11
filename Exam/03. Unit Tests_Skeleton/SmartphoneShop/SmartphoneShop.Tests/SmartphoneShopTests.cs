using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
       [Test]
       public void Ctor_Test()
       {
            Smartphone smartphone = new Smartphone("Nokia", 120);
            Shop shop = new Shop(2);
            Assert.IsNotNull(smartphone);
            Assert.IsNotNull(shop);
            shop.Add(smartphone);
            Assert.That(shop.Count, Is.EqualTo(1));
        }

        [Test]
        public void Prop_Test()
        {
            Smartphone smartphone = new Smartphone("Nokia", 120);
            Shop shop = new Shop(2);
            Assert.AreEqual("Nokia",smartphone.ModelName);
            Assert.AreEqual(120,smartphone.MaximumBatteryCharge);
            Assert.AreEqual(120, smartphone.CurrentBateryCharge);
            Assert.AreEqual(2, shop.Capacity);
            Assert.AreEqual(0,shop.Count);
        }

        [Test]
        public void Trow_Exception()
        {
            Smartphone smartphone = new Smartphone("Nokia", 120);
            Smartphone smartphone1 = new Smartphone("Nok", 10);
            Assert.Throws<ArgumentException> (() => new Shop(-1), "Invalid capacity.");
            Shop shop = new Shop(2);
            shop.Add(smartphone);
            shop.Add(smartphone1);

            Assert.Throws<InvalidOperationException>(()
                => shop.Add(smartphone), $"The phone model {smartphone.ModelName} already exist.");

            Smartphone smartphoneTest = new Smartphone("Test", 10);

            Assert.Throws<InvalidOperationException>(()
                => shop.Add(smartphoneTest), "The shop is full.");

            Assert.Throws<InvalidOperationException>(()
                => shop.Remove(null) 
                , $"The phone model {smartphoneTest.ModelName} doesn't exist.");

            Assert.Throws<InvalidOperationException>(()
                => shop.TestPhone(smartphoneTest.ModelName, 20),
                $"The phone model Test doesn't exist.");

            Assert.Throws<InvalidOperationException>(()
                => shop.TestPhone(smartphone1.ModelName, 11), 
                $"The phone model Nok is low on batery.");

            Assert.Throws<InvalidOperationException>(()
                => shop.TestPhone(smartphone.ModelName, 121) ,
                $"The phone model Nokia is low on batery.");

            Assert.Throws<InvalidOperationException>(() 
                => shop.ChargePhone(null), 
                $"The phone model {smartphoneTest.ModelName} doesn't exist.");
        }

        [Test]
        public void Add_Work_Properly()
        {
            Smartphone smartphone = new Smartphone("Nokia", 120);
            Shop shop = new Shop(2);
            shop.Add(smartphone);
            Assert.AreEqual(1,shop.Count);
        }

        [Test]
        public void Remove_Work_Properly()
        {
            Smartphone smartphone = new Smartphone("Nokia", 120);
            Shop shop = new Shop(2);
            shop.Add(smartphone);
            shop.Remove(smartphone.ModelName);
            Assert.AreEqual(0, shop.Count);
        }
        
        [Test]
        public void TestPhone_Work_Properly()
        {
            Smartphone smartphone = new Smartphone("Nokia", 120);
            Shop shop = new Shop(2);
            shop.Add(smartphone);
            shop.TestPhone(smartphone.ModelName,20);
            Assert.AreEqual(100,smartphone.CurrentBateryCharge);
            Assert.AreEqual(120, smartphone.MaximumBatteryCharge);
        }
       

        [Test]
        public void ChargePhone_Work_Properly()
        {
            Smartphone smartphone = new Smartphone("Nokia", 120);
            Shop shop = new Shop(2);
            shop.Add(smartphone);
            shop.TestPhone(smartphone.ModelName, 20);
            shop.ChargePhone(smartphone.ModelName);
            Assert.AreEqual(120,smartphone.MaximumBatteryCharge);
            Assert.AreEqual(120, smartphone.CurrentBateryCharge);
            Assert.That(smartphone.CurrentBateryCharge, Is.EqualTo(120));
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