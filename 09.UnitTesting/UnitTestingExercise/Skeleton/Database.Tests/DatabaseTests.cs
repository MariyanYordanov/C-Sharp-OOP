namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {

        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        [TestCase(new[] { int.MinValue, int.MaxValue })]
        [TestCase(new[] { 0 })]
        public void ShouldConstructorCreateElements(int[] parameters)
        {
            // Arrange
            Database database = new Database(parameters);

            // Assert
            Assert.AreEqual(parameters.Length, database.Count);
        }

        [TestCase(new[] { 1, 3 }, new[] { 2, 4 }, 4)]
        [TestCase(new int[0], new[] { int.MaxValue, int.MinValue }, 2)]
        [TestCase(new int[0], new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16}, 16)]
        public void AddElementShouldPass(int[] constructorParameters, int[] elementwsToAdd, int expectedCount)
        {
            Database database = new Database(constructorParameters);
            for (int i = 0; i < elementwsToAdd.Length; i++)
            {
                database.Add(i);
            }

            Assert.AreEqual(expectedCount, database.Count);
        }

        [TestCase(new[] { 1, 2, }, new[] { 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }, 17)]
        [TestCase(new int[0] , new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }, 17)]
        public void ShouldThrowExceptionIfTheElementsIsMoreThanSixteenElements(
            int[] constructorParameters, int[] elementwsToAdd, int errorParameter)
        {
            Database database = new Database();
            for (int i = 0; i < constructorParameters.Length; i++)
            {
                database.Add(i);
            }

            for (int i = 0; i < elementwsToAdd.Length; i++)
            {
                database.Add(i);
            }

            TestDelegate code = () => { database.Add(errorParameter); };
            InvalidOperationException invalidOperationException = Assert.Throws<InvalidOperationException>(code);
        }

        [TestCase(
            new[] { int.MinValue, -65465, -144, -89, 0, 1_234_567, int.MaxValue},
            new[] { 3, 5, 8, 13, 21, 34, 55, 89, 144 }, 3, 13)]
        [TestCase(new int[0], new[] { int.MinValue, -65465, -144, -89, 0, 1_234_567, int.MaxValue }, 0, 7)]
        [TestCase(new int[0], new[] { int.MinValue, -65465, -144, -89, 0, 1_234_567, int.MaxValue }, 7, 0)]
        public void ShouldRemoveWhithValidData(
            int[] constructorParameters, int[] elementwsToAdd, int elementsToRemove, int expectedCount)
        {
            Database database = new Database(constructorParameters);
            foreach (var item in elementwsToAdd)
            {
                database.Add(item);
            }

            for (int i = 0; i < elementsToRemove; i++)
            {
                database.Remove();
            }
           
            Assert.AreEqual(expectedCount, database.Count);
        }

        [TestCase(new[] { 4, 5, 6, 7, 8, 9}, 6)]
        [TestCase(new int[0], 0 )]
        public void SouldRemoveThrowExceptionWithInvalidData(
            int[] constructorParameters, int elementsToRemove)
        {
            Database database = new Database(constructorParameters);
            for (int i = 0; i < elementsToRemove; i++)
            {
                database.Remove();
            }

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [TestCase(new[] { 4, 5, 6, 7, 8, 9 }, new[] { 1, 2, 3}, 3, new[] { 4, 5, 6, 7, 8, 9 })]
        [TestCase(new int[0], new int[0], 0, new int[0] )]
        public void ShouldBeFetchCopyAllElementsInNewArray(
            int[] constructorParameters, int[] elementwsToAdd, int elementsToRemove, int[] expectedArray)
        {
            Database database = new Database(constructorParameters);
            foreach (var item in elementwsToAdd)
            {
                database.Add(item);
            }

            for (int i = 0; i < elementsToRemove; i++)
            {
                database.Remove();
            }

            int[] databaseCopy = database.Fetch();
            
            CollectionAssert.AreEqual(expectedArray, databaseCopy);
        }
    }
}
