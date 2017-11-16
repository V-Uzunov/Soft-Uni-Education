namespace Database.Tests
{
    using System;
    using NUnit.Framework;
    using _01.Database.Models;
    using System.Linq;

    [TestFixture]
    public class DatabaseTests
    {
        private Database db;

        [SetUp]
        public void TestInit()
        {
            this.db=new Database();
        }

        [Test]
        public void AddMoreThan16ElementsInDatabase()
        {
            for (int i = 0; i < 17; i++)
            {
                db.Add(i);
            }

            var ex = Assert.Throws<InvalidOperationException>(
                () => db.Add(1));
            Assert.AreEqual("Cannot add element more than 16 elements", ex.Message);
        }

        [Test]
        public void AddElementsInDatabase()
        {
            db.Add(1);

            Assert.AreEqual(1, db.CountOfElements(), "Cannot add elements in db");
        }

        [Test]
        public void TestForRemoveElementsMethod()
        {
            db.Add(1);
            db.Add(2);
            db.Add(3);
            db.Remove();

            Assert.IsTrue(db.CountOfElements() == 2, "Cannot remove elements");
        }

        [Test]
        public void TestForRemoveMethorRemoveElementsFromLastIndex()
        {
            db.Add(1);
            db.Add(2);
            db.Add(3);
            db.Add(4);
            db.Remove();

            
            CollectionAssert.AreEqual(new []{1, 2, 3}, db.Fetch(), "Cannot remove elements from last index");
        }

        [Test]
        public void TestingElementsCountMethod()
        {
            db.Add(1);
            db.Add(2);
            db.Add(3);

            Assert.AreEqual(3, db.CountOfElements(), "Count method don`t return actualy number counts");
        }
    }
}
