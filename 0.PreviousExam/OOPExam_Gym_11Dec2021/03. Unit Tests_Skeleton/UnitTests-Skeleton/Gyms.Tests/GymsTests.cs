using NUnit.Framework;
using System;
using System.Linq;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {
        [Test]
        public void Test()
        {
            Athlete athlete = new Athlete("Test");
            Assert.AreEqual("Test",athlete.FullName);
            Assert.AreEqual(false,athlete.IsInjured);
            Gym gym = new Gym("TestGym", 23);
            
            Assert.IsNotNull(gym);

            gym.AddAthlete(athlete);
            Assert.AreEqual(false, athlete.IsInjured);

            string report = $"Active athletes at {gym.Name}: {athlete.FullName}";
            Assert.AreEqual(report, gym.Report());

            Assert.AreEqual(23,gym.Capacity);
            Assert.AreEqual(1,gym.Count);
            Assert.AreEqual("TestGym", gym.Name);

            gym.InjureAthlete("Test");
            Assert.AreEqual(true, athlete.IsInjured);
            var returnAthlete = gym.InjureAthlete("Test");
            Assert.AreSame(athlete, returnAthlete);
            
            gym.RemoveAthlete("Test");
            Assert.AreEqual(0, gym.Count);
            
        }

        [Test]
        public void ExceptionTest()
        {
            Assert.Throws<ArgumentNullException>(() => new Gym(null, 23), "Invalid gym name.");
            Assert.Throws<ArgumentNullException>(() => new Gym("",23), "Invalid gym name.");
            Assert.Throws<ArgumentException>(() => new Gym("Test", -1), "Invalid gym capacity.");
            Gym gym = new Gym("TestGym", 1);
            Athlete athlete = new Athlete("Test Testov");
            Athlete athlete2 = new Athlete("Test2");
            gym.AddAthlete(athlete);
            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(athlete2), "The gym is full.");
            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("Test2"), $"The athlete {athlete2.FullName} doesn't exist.");
            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("Test2"), $"The athlete {athlete2.FullName} doesn't exist.");
        }
    }
}
