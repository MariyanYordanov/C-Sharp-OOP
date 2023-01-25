namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AquariumsTests
    {
        private Fish fish;
        private Aquarium aquarium;

        [SetUp]
        public void SetUp()
        {
            fish = new Fish("Taranka");
            aquarium = new Aquarium("Aqua", 100);
        }


        [Test]
        public void Test_Ctor()
        {
            Assert.IsNotNull(aquarium);
            Assert.IsNotNull(fish);
            
        }

        [Test]
        public void Test_Prop()
        {
            Assert.AreEqual("Taranka", fish.Name);
            Assert.IsTrue(fish.Available);
            Assert.AreEqual("Aqua", aquarium.Name);
            Assert.AreEqual(100, aquarium.Capacity);
            Assert.AreEqual(0, aquarium.Count);
            
        }

        [Test]
        public void Test_Prop_Trow_Exception()
        {
            Aquarium aqua = new Aquarium("Test", 1);
            aqua.Add(fish);
            Assert.AreEqual(1,aqua.Count);
            Fish fishTest = new Fish("Test");
            Assert.Throws<ArgumentException>(() => new Aquarium("Aqua",-1), "Invalid aquarium capacity!");
            Assert.Throws<ArgumentNullException>(() => new Aquarium("", 100), "Invalid aquarium name!");
            Assert.Throws<InvalidOperationException>(() => aqua.Add(fishTest), "Aquarium is full!");
            Assert.Throws<InvalidOperationException>(() => aqua.RemoveFish(fishTest.Name), $"Fish with the name Test doesn't exist!");
            Assert.Throws<InvalidOperationException>(() => aqua.SellFish(fishTest.Name), $"Fish with the name Test doesn't exist!");
            
        }

        [Test]
        public void Report_Work_Properly()
        {
            Fish fishTest = new Fish("Test");
            aquarium.Add(fish);
            aquarium.Add(fishTest);
            Assert.AreEqual(aquarium.Report(),"Fish available at Aqua: Taranka, Test");
        }


        [Test]
        public void SellFish_Work_Properly()
        {
            aquarium.Add(fish);
            aquarium.SellFish(fish.Name);
            Assert.IsFalse(fish.Available);
            Assert.AreSame(fish, aquarium.SellFish(fish.Name));
        }

        [Test]
        public void RemoveFish_Work_Properly()
        {
            aquarium.Add(fish);
            Assert.AreEqual(1, aquarium.Count);
            aquarium.RemoveFish(fish.Name);
            Assert.AreEqual(0, aquarium.Count);
        }
    }
}
