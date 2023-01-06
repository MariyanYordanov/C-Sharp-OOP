namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [TestCaseSource("TestConstructorData")]
        public void ShouldConstructorCreateDatabase(Person[] people, int expectedCount)
        {
            Database database = new Database(people);
            Assert.AreEqual(expectedCount, database.Count);
        }

        [TestCaseSource("TestCaseAddData")]
        public void AddShouldAddValidData(Person[] people, Person[] peopleToAdd, int expectedCount)
        {
            Database database = new Database(people);
            foreach (var item in peopleToAdd)
            {
                database.Add(item);
            }

            Assert.AreEqual(expectedCount, database.Count);
        }

        [TestCaseSource("TestAddDataInvalidData")]
        public void ShouldAddThrowException(Person[] peopleConstructor, Person[] peopleToAdd, Person person)
        {
            Database database = new Database(peopleConstructor);
            foreach (var item in peopleToAdd)
            {
                database.Add(item);
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(person));
        }

        [TestCaseSource("TestRemoveValidData")]
        public void ShouldRemoveValidData(Person[] peopleConstructor, Person[] peopleToAdd, int removeCount, int expectedCount)
        {
            Database database = new Database(peopleConstructor);
            foreach (var item in peopleToAdd)
            {
                database.Add(item);
            }

            for (int i = 0; i < removeCount; i++)
            {
                database.Remove();
            }

            Assert.AreEqual(expectedCount, database.Count);
        }

        [TestCaseSource("TestRemoveInalidData")]
        public void ShouldTrowException(Person[] peopleConstructor, int removeCount)
        {
            Database database = new Database(peopleConstructor);

            for (int i = 0; i < removeCount; i++)
            {
                database.Remove();
            }

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [TestCaseSource("TestFindByUsernameValidUsername")]
        public void ShouldFindPersonByUsernameInDatabase(Person[] peopleConstructor, Person[] peopleToAdd, string usernameToFind)
        {
            Database database = new Database(peopleConstructor);
            foreach (var item in peopleToAdd)
            {
                database.Add(item);
            }

            Person personToFind = database.FindByUsername(usernameToFind);

            Assert.AreEqual(usernameToFind, personToFind.UserName);
        }

        [TestCaseSource("TestFindByUsernameInvalidUsername")]
        public void ThrowExceptionIfGivenParamerersAreFalseUsername(Person[] peopleConstructor, Person[] peopleToAdd, string usernameToFind)
        {
            Database database = new Database(peopleConstructor);
            foreach (var item in peopleToAdd)
            {
                database.Add(item);
            }

            Assert.Throws<InvalidOperationException>(() => database.FindByUsername(usernameToFind));
        }

        [TestCaseSource("TestFindByUsernameWithInvalidDataNullOrEmpty")]
        public void ThrowExceptionIfGivenParamerersAreNullOrEmpty(Person[] peopleConstructor, Person[] peopleToAdd, string usernameToFind)
        {
            Database database = new Database(peopleConstructor);
            foreach (var item in peopleToAdd)
            {
                database.Add(item);
            }

            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(usernameToFind));
        }

        [TestCaseSource("TestFindByIdWithValidId")]
        public void ShouldFindPersonByIdInDatabase(Person[] peopleConstructor, Person[] peopleToAdd, long userToFind)
        {
            Database database = new Database(peopleConstructor);
            foreach (var item in peopleToAdd)
            {
                database.Add(item);
            }

            Person personToFind = database.FindById(userToFind);

            Assert.AreEqual(userToFind, personToFind.Id);
        }

        [TestCaseSource("TestFindByIdWithIdLessThahZero")]
        public void ThrowExceptionIfIdValueIsLessThanZero(Person[] peopleConstructor, Person[] peopleToAdd, long userToFind)
        {
            Database database = new Database(peopleConstructor);
            foreach (var item in peopleToAdd)
            {
                database.Add(item);
            }

            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(userToFind));
        }

        [TestCaseSource("TestFindIdIfIdValueIsFalse")]
        public void ThrowExceptionIfIdValueIsFalse(Person[] peopleConstructor, Person[] peopleToAdd, long userToFind)
        {
            Database database = new Database(peopleConstructor);
            foreach (var item in peopleToAdd)
            {
                database.Add(item);
            }

            Assert.Throws<InvalidOperationException>(() => database.FindById(userToFind));
        }

        

        public static IEnumerable<TestCaseData> TestFindIdIfIdValueIsFalse()
        {
            TestCaseData[] testCaseDatas = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "some"),
                        new Person(2,"thing"),
                        new Person(3, "else")
                    },
                    new Person[]
                    {
                        new Person(4, "Ivan"),
                        new Person(5,"Parvan"),
                        new Person(6, "Petkan")
                    },
                    7),
            };

            foreach (var item in testCaseDatas)
            {
                yield return item;
            }
        }

        public static IEnumerable<TestCaseData> TestFindByIdWithIdLessThahZero() 
        {
            TestCaseData[] testCaseDatas = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "some"),
                        new Person(2,"thing"),
                        new Person(3, "else")
                    },
                    new Person[]
                    {
                        new Person(4, "Ivan"),
                        new Person(5,"Parvan"),
                        new Person(6, "Petkan")
                    },
                    -1),
            };

            foreach (var item in testCaseDatas)
            {
                yield return item;
            }
        }

        public static IEnumerable<TestCaseData> TestFindByIdWithValidId()
        {
            TestCaseData[] testCaseDatas = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "some"),
                        new Person(2,"thing"),
                        new Person(3, "else")
                    },
                    new Person[]
                    {
                        new Person(4, "Ivan"),
                        new Person(5,"Parvan"),
                        new Person(6, "Petkan")
                    },
                    6),
            };

            foreach (var item in testCaseDatas)
            {
                yield return item;
            }
        }

        public static IEnumerable<TestCaseData> TestFindByUsernameInvalidUsername()
        {
            TestCaseData[] testCaseDatas = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "some"),
                        new Person(2,"thing"),
                        new Person(3, "else")
                    },
                    new Person[]
                    {
                        new Person(4, "Ivan"),
                        new Person(5,"Parvan"),
                        new Person(6, "Petkan")
                    },
                    "Pekan"),
            };

            foreach (var item in testCaseDatas)
            {
                yield return item;
            }
        }

        public static IEnumerable<TestCaseData> TestFindByUsernameWithInvalidDataNullOrEmpty() 
        {
            TestCaseData[] testCaseDatas = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "some"),
                        new Person(2,"thing"),
                        new Person(3, "else")
                    },
                    new Person[]
                    {
                        new Person(4, "Ivan"),
                        new Person(5,"Parvan"),
                        new Person(6, "Petkan")
                    },
                    ""),
                 new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "some"),
                        new Person(2,"thing"),
                        new Person(3, "else")
                    },
                    new Person[]
                    {
                        new Person(4, "Ivan"),
                        new Person(5,"Parvan"),
                        new Person(6, "Petkan")
                    },
                    null),
            };

            foreach (var item in testCaseDatas)
            {
                yield return item;
            }
        }

        public static IEnumerable<TestCaseData> TestFindByUsernameValidUsername()
        {
            TestCaseData[] testCaseDatas = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "some"),
                        new Person(2,"thing"),
                        new Person(3, "else")
                    },
                    new Person[]
                    {
                        new Person(4, "Ivan"),
                        new Person(5,"Parvan"),
                        new Person(6, "Petkan")
                    },
                    "Petkan"),
            };

            foreach (var item in testCaseDatas)
            {
                yield return item;
            }
        }

        public static IEnumerable<TestCaseData> TestRemoveInalidData()
        {
            TestCaseData[] testCaseDatas = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "some"),
                        new Person(2,"thing"),
                        new Person(3, "else")
                    },
                    3),
            };

            foreach (var item in testCaseDatas)
            {
                yield return item;
            }
        }

        public static IEnumerable<TestCaseData> TestRemoveValidData()
        {
            TestCaseData[] testCaseDatas = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "some"),
                        new Person(2,"thing"),
                        new Person(3, "else")
                    },
                    new Person[]
                    {
                        new Person(4, "som"),
                        new Person(5, "ing"),
                        new Person(6, "ele")
                    },
                    2,
                    4),

                new TestCaseData(new Person[]{ },new Person[]{new Person(0, "non")  }, 1, 0),
            };

            foreach (var item in testCaseDatas)
            {
                yield return item;
            }
        }

        public static IEnumerable<TestCaseData> TestCaseAddData()
        {
            TestCaseData[] testCaseDatas = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "some"),
                        new Person(2,"thing"),
                        new Person(3, "else")
                    },
                    new Person[]
                    {
                        new Person(4, "som"),
                        new Person(5, "ing"),
                        new Person(6, "ele")
                    },
                    6),

                new TestCaseData(new Person[]{ },new Person[]{new Person(0, "non")  }, 1),
            };

            foreach (var item in testCaseDatas)
            {
                yield return item;
            }
        }

        public static IEnumerable<TestCaseData> TestConstructorData()
        {
            TestCaseData[] testCaseDatas = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "some"),
                        new Person(2,"thing"),
                        new Person(3, "else")
                    }, 3),

                new TestCaseData(new Person[]{new Person(0, "non") }, 1),
                new TestCaseData(new Person[]{ },0),
            };

            foreach (var item in testCaseDatas)
            {
                yield return item;
            }
        }

        public static IEnumerable<TestCaseData> TestAddDataInvalidData()
        {
            TestCaseData[] testCaseDatas = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "some"),
                        new Person(2,"thing"),
                        new Person(3, "else"),
                        
                    },
                    new Person[]
                    {
                        new Person(4, "and"),
                        new Person(5, "nothing"),
                        new Person(6, "is"),
                        new Person(7, "like"),
                        new Person(8, "writing"),
                        new Person(9, "dummy"),
                        new Person(10, "tests"),
                        new Person(11, "for"),
                        new Person(12, "stupid"),
                        new Person(13, "exersice"),
                        new Person(14, "with"),
                        new Person(15, "long"),
                        new Person(16, "data"),
                    },
                    new Person(17, "name")
                    ),
                new TestCaseData(
                    new Person[]
                    {
                    },
                    new Person[]
                    {
                        new Person(1, "some"),
                        new Person(2,"thing"),
                        new Person(3, "else"),
                        new Person(4, "and"),
                        new Person(5, "nothing"),
                        new Person(6, "is"),
                        new Person(7, "like"),
                        new Person(8, "writing"),
                        new Person(9, "dummy"),
                        new Person(10, "tests"),
                        new Person(11, "for"),
                        new Person(12, "stupid"),
                        new Person(13, "exersice"),
                        new Person(14, "with"),
                        new Person(15, "long"),
                        
                    },
                    new Person(16, "long")
                    ),
                new TestCaseData(
                    new Person[]
                    {
                    },
                    new Person[]
                    {
                        new Person(1, "some"),
                        new Person(2,"thing"),
                        new Person(3, "else"),
                        new Person(4, "and"),
                        new Person(5, "nothing"),
                        new Person(6, "is"),
                        new Person(7, "like"),
                        new Person(8, "writing"),
                        new Person(9, "dummy"),
                        new Person(10, "tests"),
                        new Person(11, "for"),
                        new Person(12, "stupid"),
                        new Person(13, "exersice"),
                        new Person(14, "with"),
                        new Person(15, "long"),

                    },
                    new Person(15, "name")
                    ),
            };

            foreach (var item in testCaseDatas)
            {
                yield return item;
            }
        }
    }
}