namespace Robots.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class RobotsTests
    {
        private Robot robot;
        private Robot robot1;
        private Robot robot2;
        private RobotManager robotManager;

        [SetUp]
        public void SetUp()
        {
            robot = new Robot("Bot",13);
            robot1 = new Robot("Bot1", 21);
            robot2 = new Robot("Bot2", 34);
            robotManager = new RobotManager(2);
        }

        [Test]
        public void Ctor_Work_Properly()
        {
            Assert.IsNotNull(robot);
            Assert.IsNotNull(robotManager);
        }

        [Test]
        public void Prop_Work_Properly()
        {
            Assert.AreEqual("Bot",robot.Name);
            Assert.AreEqual(13, robot.MaximumBattery);
            Assert.AreEqual(13, robot.Battery);
            Assert.AreEqual(2,robotManager.Capacity);
            Assert.AreEqual(0, robotManager.Count);
        }

        [Test]
        public void Capacity_Throw_Exception()
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(-1) , "Invalid capacity!");
        }

        [Test]
        public void Add_Work_Properly()
        {
            robotManager.Add(robot2);
            robotManager.Add(robot1);
            Assert.AreEqual(2,robotManager.Count);
        }

        [Test]
        public void Add_Throw_Exception()
        {
            robotManager.Add(robot2);
            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robot2), $"There is already a robot with name {robot2.Name}!");
            robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robot1), "Not enough capacity!");
        }

        [Test]
        public void Remove_Work_Properly()
        {
            robotManager.Add(robot2);
            robotManager.Add(robot1);
            robotManager.Remove(robot1.Name);
            Assert.AreEqual(1, robotManager.Count);
        }

        [Test]
        public void Remove_Throw_Exception()
        {
            robotManager.Add(robot2);
            robotManager.Add(robot1);
            robotManager.Remove(robot1.Name);
            Assert.AreEqual(1, robotManager.Count);
            Assert.Throws<InvalidOperationException>(() => robotManager.Remove(robot.Name),$"Robot with the name Bot doesn't exist!");
        }

        [Test]
        public void Work_Work_Properly()
        {
            robotManager.Add(robot2);
            robotManager.Add(robot1);
            robotManager.Work(robot1.Name,"Clleaning", 1);
            Assert.AreEqual(20, robot1.Battery);
            Assert.AreEqual(21, robot1.MaximumBattery);
        }

        [Test]
        public void Work_Throw_Exception()
        {
            robotManager.Add(robot2);
            robotManager.Add(robot1);
            Assert.Throws<InvalidOperationException>(() 
                => robotManager.Work(robot1.Name, "Clleaning", 22), $"Bot doesn't have enough battery!");
            Assert.Throws<InvalidOperationException>(()
                => robotManager.Work(robot.Name, "Clleaning", 1), $"Robot with the name Bot doesn't exist!");
        }
        
        [Test]
        public void Charge_Work_Properly()
        {
            robotManager.Add(robot1);
            robotManager.Work(robot1.Name, "Clleaning", 1);
            robotManager.Charge(robot1.Name);
            Assert.AreEqual(21,robot1.MaximumBattery);
            Assert.AreEqual(21, robot1.Battery);
        }

        [Test]
        public void Charge_Throw_Exception()
        {
            robotManager.Add(robot2);
            robotManager.Add(robot1);
            Assert.Throws<InvalidOperationException>(()
                => robotManager.Charge(robot.Name), $"Robot with the name Bot doesn't exist!");
        }
    }
}
