using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses.PersonClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassesTest
{

    [TestClass]
    public class CollectionAssertClassTest : TestBase
    {
        [TestMethod]
        public void AreCollectionEqualWithComparerTest()
        {
            PersonManager mgr = new PersonManager();
            List<Person> listPeopleExpected = new List<Person>();
            List<Person> listPeopleActual;

            listPeopleExpected.Add(new Person() { FirstName = "Mandy", LastName = "Chou" });
            listPeopleExpected.Add(new Person() { FirstName = "Ashwini", LastName = "Suloch" });
            listPeopleExpected.Add(new Person() { FirstName = "Alan", LastName = "Wong" });

            listPeopleActual = mgr.GetPeople();

            CollectionAssert.AreEqual(listPeopleExpected, listPeopleActual,
                Comparer<Person>.Create((x, y) => x.FirstName == y.FirstName && x.LastName == y.LastName ? 0 : 1)); //reutrn 0 = success; 1 = fail
        }

        [TestMethod]
        public void AreCollectionsEquivalentTest()
        {
            PersonManager mgr = new PersonManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual;

            peopleActual = mgr.GetPeople();
            peopleExpected.Add(peopleActual[1]);
            peopleExpected.Add(peopleActual[2]);
            peopleExpected.Add(peopleActual[0]);

            CollectionAssert.AreEquivalent(peopleExpected, peopleActual);
        }

        [TestMethod]
        public void IsCollectionOfTypeTest()
        {
            PersonManager mgr = new PersonManager();
            List<Person> peopleActual = new List<Person>();

            peopleActual = mgr.GetSupervisor();

            CollectionAssert.AllItemsAreInstancesOfType(peopleActual, typeof(Supervisor));
                
        }

        [TestMethod]
        public void AreCollectionsEquealTest()
        {
            PersonManager mgr = new PersonManager();
            List<Person> peopleExpected;
            List<Person> peopleActual;

            peopleActual = mgr.GetPeople();
            peopleExpected = peopleActual; // this will pass
            //peopleExpected = mgr.GetPeople(); // this will fail
            
            CollectionAssert.AreEqual(peopleExpected, peopleActual);
        }

        [TestMethod]
        public void AreCollectionsEqual()
        {
            PersonManager mgr = new PersonManager();
            List<Person> listPeopleExpected = new List<Person>();
            List<Person> listPeopleActual = new List<Person>();

            listPeopleExpected.Add(new Person() { FirstName = "Mandy", LastName = "Chou" });
            listPeopleExpected.Add(new Person() { FirstName = "Ashwini", LastName = "Suloch" });
            listPeopleExpected.Add(new Person() { FirstName = "Alan", LastName = "Wong" });

            listPeopleActual = mgr.GetPeople();

            CollectionAssert.AreEqual(listPeopleExpected, listPeopleActual);// Fail. They look like the same data, but actually they point to different object


        }
    }
}
