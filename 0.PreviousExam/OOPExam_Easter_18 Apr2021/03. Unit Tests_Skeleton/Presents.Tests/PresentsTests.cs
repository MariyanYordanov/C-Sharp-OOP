namespace Presents.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class PresentsTests
    {
        private Present present;
        private Bag bag;

        [SetUp]
        public void SetUp()
        {
            present = new Present("Ball", 2.12);
            bag = new Bag();
        }

        [Test]
        public void Test_Present()
        {
            Assert.AreEqual(2.12, present.Magic);
            Assert.AreEqual("Ball", present.Name);
        }

        [Test]
        public void Test_Bag()
        {
            Assert.IsNotNull(bag);
            
            string result = $"Successfully added present {present.Name}.";
            Assert.AreEqual(result, bag.Create(present));
        }

        [Test]
        public void Bag_Trow_Exceptions()
        {
            bag.Create(present);
            Present present1 = null;
            Assert.Throws<ArgumentNullException>(() => bag.Create(present1));
            Assert.Throws<InvalidOperationException>(() => bag.Create(present));
        }

        [Test]
        public void Remove_Work_Properly()
        {
            Present present1 = new Present("Sas",1.11);
            bag.Create(present);
            bag.Create(present1);
            Assert.IsTrue(bag.Remove(present1));
        }
        
        [Test]
        public void GetPresentWithLeastMagic_Work_Properly()
        {
            Present present1 = new Present("Sas", 1.11);
            bag.Create(present);
            bag.Create(present1);
            Assert.AreEqual(present1,bag.GetPresentWithLeastMagic());
        }
        
        [Test]
        public void GetPresent_Work_Properly()
        {
            Present present1 = new Present("Sas", 1.11);
            bag.Create(present);
            bag.Create(present1);
            Assert.AreEqual(present1, bag.GetPresent(present1.Name));
        }
        
        [Test]
        public void GetPresents_Work_Properly()
        {
            Present present1 = new Present("Sas", 1.11);
            bag.Create(present);
            bag.Create(present1);
            Assert.IsNotEmpty(bag.GetPresents());
        }
    }
}
