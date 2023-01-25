using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Computers.Tests
{
    public class Tests
    {
        [Test]
        public void ConstructorShouldCreateObjects()
        {
            ComputerManager computerManager = new ComputerManager();
            Assert.IsNotNull(computerManager.Computers);
            Computer computer = new Computer("Asus", "Rock", 1111.11m);
            computerManager.AddComputer(computer);
            Assert.IsNotEmpty(computerManager.Computers);
        }

        [Test]
        public void ShouldCCounterWorkProperly()
        {
            Computer computer = new Computer("Asus", "Rock", 1111.11m);
            ComputerManager computerManager = new ComputerManager();
            Assert.AreEqual(0, computerManager.Count);
            computerManager.AddComputer(computer);
            Assert.AreEqual(1, computerManager.Count);
            Assert.AreEqual(computerManager.Count, computerManager.Computers.Count);
        }

        [Test]
        public void SouldValidateNullValueThrowException()
        {
            Computer computer = null;
            ComputerManager computerManager = new ComputerManager();
            Assert.Throws<ArgumentNullException>(() => computerManager.AddComputer(computer));
            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputersByManufacturer(null));
        }

        [Test]
        public void ShouldAddComputerWorkProperly()
        {
            Computer computer = new Computer("Asus", "Rock", 1111.11m);
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(computer);
            Assert.IsNotNull(computerManager);
        }

        [Test]
        public void ShouldAddComputerThrowException()
        {
            Computer computer = new Computer("Asus", "Rock", 1111.11m);
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(computer);
            Assert.Throws<ArgumentException>(() => computerManager.AddComputer(computer));
        }

        [Test]
        public void ShouldRemoveComputerWorkProperly()
        {
            Computer laptop = new Computer("Asus", "Rock", 1111.11m);
            Computer computer = new Computer("Asser", "Some", 1221.12m);
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(laptop);
            computerManager.AddComputer(computer);
            
            Assert.AreEqual(laptop, computerManager.RemoveComputer("Asus", "Rock"));
        }

        [Test]
        public void ShouldRemoveComputerWorkProperly2()
        {
            Computer laptop = new Computer("Asus", "Rock", 1111.11m);
            Computer computer = new Computer("Asser", "Some", 1221.12m);
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(laptop);
            computerManager.AddComputer(computer);
            computerManager.RemoveComputer("Asus", "Rock");
            Assert.AreEqual(1, computerManager.Computers.Count);
        }

        [Test]
        public void GetComputerThrowException()
        {
            Computer laptop1 = new Computer("Test", "Tes", 1000.0m);
            Computer laptop2 = new Computer("Test", "Est", 1010.0m);

            ComputerManager computerManager = new ComputerManager();

            computerManager.AddComputer(laptop1);
            computerManager.AddComputer(laptop2);
            
            Assert.Throws<ArgumentException>(() => computerManager.GetComputer("Tes", "Test"));
            Assert.Throws<ArgumentException>(() => computerManager.GetComputer("Test", "Test"));
            Assert.Throws<ArgumentException>(() => computerManager.GetComputer("Tes", "Est"));
        }

        [Test]
        public void GetComputersByManufacturerWorkProperly()
        {
            Computer laptop = new Computer("Asus", "Rock", 1111.11m);
            Computer computer = new Computer("Asser", "Some", 1221.12m);
            ComputerManager computerManager = new ComputerManager();
            ComputerManager computerManagerCheck = new ComputerManager();
            computerManager.AddComputer(laptop);
            computerManager.AddComputer(computer);
            computerManagerCheck.AddComputer(laptop);
            computerManagerCheck.AddComputer(computer);
            CollectionAssert.AreEqual(computerManagerCheck.GetComputersByManufacturer("Asus"), computerManager.GetComputersByManufacturer("Asus"));
            Assert.AreEqual(2, computerManagerCheck.Count);
            Assert.AreEqual(2, computerManager.Count);
        }


        [Test]
        public void GetComputerCheck3()
        {
            ComputerManager computerManager = new ComputerManager();
            Computer computer = new Computer("Test", "Est", 1010.0m);
            computerManager.AddComputer(computer);

            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputer(null, ""));
            Assert.Throws<ArgumentNullException>(() => computerManager.RemoveComputer(null, ""));
            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputer("", null));
            Assert.Throws<ArgumentNullException>(() => computerManager.RemoveComputer("", null));
            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputer(null, null));
            Assert.Throws<ArgumentNullException>(() => computerManager.RemoveComputer(null, null));
            
        }
    }
}