using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            private List<Car> fixedCar;
            [SetUp]
            public void SetUp()
            {
                fixedCar = new List<Car>();
            }
            [Test]
            public void Car_Ctor_Work_Properly()
            {
                Car carTest = new Car("Honda", 2);
                Assert.IsNotNull(carTest);
                Assert.AreEqual("Honda", carTest.CarModel);
                Assert.AreEqual(2, carTest.NumberOfIssues);
                Assert.IsFalse(carTest.IsFixed);
            }

            [Test]
            public void Garage_Ctor_Work_Properly()
            {
                Car carTest = new Car("Honda", 2);
                Garage garageTest = new Garage("Dobrite",2);
                Assert.IsNotNull(garageTest);
                Assert.AreEqual("Dobrite",garageTest.Name);
                Assert.AreEqual(2, garageTest.MechanicsAvailable);
                Assert.AreEqual(0, garageTest.CarsInGarage);
            }

            [Test]
            public void GarageName_Throw_Exception()
            {
                Assert.Throws<ArgumentNullException>(()
                    => new Garage(null, 2), "Invalid garage name.");
            }

            [Test]
            public void GarageMechanics_Throw_Exception()
            {
                Assert.Throws<ArgumentException>(()
                    => new Garage("Test", 0),
                    "At least one mechanic must work in the garage.");
            }

            [Test]
            public void Add_Work_Properly()
            {
                Car carTest = new Car("Honda", 2);
                Garage garageTest = new Garage("Dobrite", 2);
                garageTest.AddCar(carTest);
                Assert.AreEqual(1, garageTest.CarsInGarage);
            }

            [Test]
            public void Add_Throw_Exception()
            {
                Car carTest = new Car("Honda", 2);
                Garage garageTest = new Garage("Dobrite", 1);
                garageTest.AddCar(carTest);
                Assert.Throws<InvalidOperationException>(()
                    => garageTest.AddCar(new Car("Fiat", 2)),
                    "No mechanic available.");
            }

            [Test]
            public void FixCar_Work_Properly()
            {
                Car carTest = new Car("Honda", 2);
                Garage garageTest = new Garage("Dobrite", 2);
                garageTest.AddCar(carTest);
                Assert.AreSame(carTest, garageTest.FixCar(carTest.CarModel));
                Assert.IsTrue(carTest.IsFixed);
                
            }

            [Test]
            public void FixCar_Throw_Exception()
            {
                Car carTest = new Car("Honda", 2);
                
                Garage garageTest = new Garage("Dobrite", 1);
                garageTest.AddCar(carTest);
                Assert.Throws<InvalidOperationException>(()
                    => garageTest.FixCar("Fiat"),
                    $"The car Fiat doesn't exist.");
            }

            [Test]
            public void RemoveFixedCar_Work_Properly()
            {
                Car carTest = new Car("Honda", 2);
                Garage garageTest = new Garage("Dobrite", 2);
                garageTest.AddCar(carTest);
                garageTest.FixCar("Honda");
                garageTest.RemoveFixedCar();
                fixedCar.Add(carTest);
                
                Assert.AreEqual(0,garageTest.CarsInGarage);
            }

            [Test]
            public void RemoveFixedCar_Throw_Exception()
            {
                Car carTest = new Car("Honda", 2);
                Garage garageTest = new Garage("Dobrite", 2);
                garageTest.AddCar(carTest);
                garageTest.FixCar("Honda");
                garageTest.RemoveFixedCar();
                Assert.Throws<InvalidOperationException>(() 
                    => garageTest.RemoveFixedCar(), $"No fixed cars available.");
            }

            [Test]
            public void Report_Work_Properly()
            {
                Car carTest = new Car("Honda", 2);
                Car car = new Car("Fiat", 1);
                Garage garageTest = new Garage("Dobrite", 2);
                garageTest.AddCar(carTest);
                garageTest.AddCar(car);
                garageTest.FixCar("Honda");
                garageTest.RemoveFixedCar();
                string report = $"There are 1 " +
                $"which are not fixed: Fiat.";
                Assert.AreEqual(report,garageTest.Report());
                
            }
        }
    }
}