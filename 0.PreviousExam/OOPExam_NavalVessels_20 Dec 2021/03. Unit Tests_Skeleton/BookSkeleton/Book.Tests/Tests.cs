namespace Book.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    public class Tests
    {
        private Book book1;
        private Book book2;
        Dictionary<int, string> testDic;

        [SetUp]
        public void SetUp()
        {
            book1 = new Book("The ants","Mike Johnson");
            testDic = new Dictionary<int, string>();
        }

        [Test]
        public void Constructor_Work_Properly()
        {
            Assert.IsNotNull(book1);
            Assert.IsNotNull(testDic);
        }

        [Test]
        public void Property_Work_Properly()
        {
            Assert.AreEqual("The ants",book1.BookName);
            Assert.AreEqual("Mike Johnson",book1.Author);
            Assert.AreEqual(0, testDic.Keys.Count);
            Assert.AreEqual(0, book1.FootnoteCount);
        }

        [Test]
        public void Property_Throw_Exceptions()
        {
            Assert.Throws<ArgumentException>(() => book2 = new Book("The ants", ""), $"Invalid {nameof(book2.Author)}!");
            Assert.Throws<ArgumentException>(() => book2 = new Book("", "Mike Johnson"), $"Invalid {nameof(book2.BookName)}!");
        }

        [Test]
        public void AddFootnote_Test()
        {
            book1.AddFootnote(1,"Ants");
            Assert.AreEqual(1, book1.FootnoteCount);
            Assert.Throws<InvalidOperationException> ( () => book1.AddFootnote(1, "Ants"), "Footnote already exists!");
        }

        [Test]
        public void FindFootnote_Test1()
        {
            book2 = new Book("Ant", "Make Doke");
            book2.AddFootnote(2, "Ant");
            book1.AddFootnote(1, "Ants");
            book1.FindFootnote(1);
            Assert.AreEqual(1, book1.FootnoteCount);
            Assert.Throws<InvalidOperationException>(() => book1.FindFootnote(3), "Footnote doesn't exists!");
            string result = $"Footnote #2: Ant";
            Assert.AreEqual(result, book2.FindFootnote(2));
        }

        [Test]
        public void AlterFootnote_Test()
        {
            book1.AddFootnote(1, "Ants");
            book1.AlterFootnote(1, "The ants");
            testDic.Add(1, "The ants");
            Assert.AreEqual(1, book1.FootnoteCount);
            string result = $"Footnote #1: The ants";
            Assert.AreEqual(result, book1.FindFootnote(1));
            Assert.Throws<InvalidOperationException>(() => book1.AlterFootnote(2, "The ants"), "Footnote does not exists!");
        }
    }
}