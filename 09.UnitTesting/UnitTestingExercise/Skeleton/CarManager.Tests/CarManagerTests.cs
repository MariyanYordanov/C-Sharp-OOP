namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        [Test]
        public void Should_Constructor_Create_Cars_With_FuelAmount_Equal_To_Zero()
        {
            Car car = new Car("make", "model", 5.5, 44.5);
            Assert.AreEqual(0, car.FuelAmount);
        }

        [Test]
        public void Test_If_Constructor_Works_Correctly()
        {
            Car car = new Car("make", "model", 5.5, 44.5);
            Assert.IsNotNull(car);
        }

        [Test]
        public void Constructor_Should_Throws_Exception_If_Make_Is_Null()
        {
            Assert.Throws<ArgumentException>(() => new Car(null, "model", 5.5, 44.5));
        }

        [Test]
        public void Constructor_Should_Throws_Exception_If_Make_Is_Empty()
        {
            Assert.Throws<ArgumentException>(() => new Car("", "model", 5.5, 44.5));
        }

        [Test]
        public void Constructor_Should_Throws_Exception_If_Model_Is_Null()
        {
            Assert.Throws<ArgumentException>(() => new Car("make", null, 5.5, 44.5));
        }

        [Test]
        public void Constructor_Should_Throws_Exception_If_Model_Is_Empty()
        {
            Assert.Throws<ArgumentException>(() => new Car("make", "", 5.5, 44.5));
        }

        [Test]
        public void Constructor_Should_Throws_Exception_If_FuelConsumption_Is_Zero()
        {
            Assert.Throws<ArgumentException>(() => new Car("make", "model", 0, 44.5));
        }

        [Test]
        public void Constructor_Should_Throws_Exception_If_FuelConsumption_Is_Less_Than_Zero()
        {
            Assert.Throws<ArgumentException>(() => new Car("make", "model", -1, 44.5));
        }

        [Test]
        public void Constructor_Should_Throws_Exception_If_FuelCapasity_Is_Zero()
        {
            Assert.Throws<ArgumentException>(() => new Car("make", "model", 5.5, 0));
        }

        [Test]
        public void Constructor_Should_Throws_Exception_If_FuelCapasity_Is_Less_Than_Zero()
        {
            Assert.Throws<ArgumentException>(() => new Car("make", "model", 5.5, -1));
        }

        [Test]
        public void Refuel_Should_Return_New_Value_Of_Amount_If_Value_Is_Greater_Than_FuelCapacity()
        {
            Car car = new Car("make", "model", 5.5, 44.5);
            car.Refuel(50);
            Assert.AreEqual(44.5, car.FuelAmount);
        }

        [Test]
        public void Refuel_Should_Return_New_Value_Of_Amount()
        {
            Car car = new Car("make", "model", 5.5, 44.5);
            car.Refuel(44.5);
            Assert.AreEqual(44.5, car.FuelAmount);
        }

        [Test]
        public void Refuel_Should_Throws_Exception_If_FuelAmount_Is_Less_Than_Zero()
        {
            Car car = new Car("make", "model", 5.5, 44.5);
            Assert.Throws<ArgumentException>(() => car.Refuel(-1) );
        }

        [Test]
        public void Refuel_Should_Throws_Exception_If_FuelAmount_Is_Zero()
        {
            Car car = new Car("make", "model", 5.5, 44.5);
            Assert.Throws<ArgumentException>(() => car.Refuel(0));
        }

        [Test]
        public void Drive_Should_Return_Corect_Value_Of_Driven_Distance()
        {
            Car car = new Car("make", "model", 5, 44.5);
            car.Refuel(20);
            car.Drive(50);
            Assert.AreEqual(17.5,car.FuelAmount);
        }

        [Test]
        public void Drive_Should_Throw_Exception_If_FuelAmount_Is_Less_Than_Needed_Fuel_Per_Given_Distance()
        {
            Car car = new Car("make", "model", 5, 44.5);
            car.Refuel(2);
            Assert.Throws<InvalidOperationException>(() => car.Drive(50));
        }

        
    }
}