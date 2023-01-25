using NUnit.Framework;
using System;
using System.Collections.Generic;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private UnitCar testCar;
        private UnitDriver testDriver;
        private Dictionary<string, UnitDriver> driverDic;

        [SetUp]
        public void Setup()
        {
            testCar = new UnitCar("Car", 100, 1.7);
            testDriver = new UnitDriver("Name", testCar);
            driverDic = new Dictionary<string, UnitDriver>();
        }

        [Test]
        public void TestDic()
        {
            Assert.IsNotNull(driverDic);
        }

        [Test]
        public void TestCarOne()
        {
            UnitCar car = new UnitCar("Car", 100, 1.7);
            Assert.IsNotNull(car);
            Assert.AreEqual("Car",car.Model);
            Assert.AreEqual(100,car.HorsePower);
            Assert.AreEqual(1.7, car.CubicCentimeters);
        }

        [Test]
        public void TestDriverOne()
        {
            UnitDriver driver = new UnitDriver("Name", testCar);
            Assert.IsNotNull(driver);
            Assert.AreEqual("Name", driver.Name);
            Assert.AreEqual(testCar, driver.Car);
        }

        [Test]
        public void TestDrivertwo()
        {
            Assert.Throws<ArgumentNullException>(() => new UnitDriver(null, testCar));
        }

        [Test]
        public void TestMethods()
        {
            RaceEntry raceEntry = new RaceEntry();
            Assert.IsNotNull(raceEntry);
            Assert.AreEqual(0, raceEntry.Counter);
            raceEntry.AddDriver(testDriver);
            Assert.AreEqual(1, raceEntry.Counter);
            
        }

        [Test]
        public void TestMethodsTwo()
        {
            RaceEntry raceEntry = new RaceEntry();
            raceEntry.AddDriver(testDriver);
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(null));
            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(testDriver));
        }

        [Test]
        public void TestMethodsThree() 
        {

            RaceEntry raceEntry = new RaceEntry();
            UnitDriver driver = new UnitDriver("Nam", testCar);
            raceEntry.AddDriver(driver);
            raceEntry.AddDriver(testDriver);
            Assert.AreEqual(100, raceEntry.CalculateAverageHorsePower());
        }

    }
}