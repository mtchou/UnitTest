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
    public class PersonTest : TestBase
    {
        [TestMethod]
        public void IsinstranceOfTypeTest()
        {
            PersonManager mgr = new PersonManager();
            Person per;
            
            per = mgr.CreatePerson("Paul", "Sheriff", true);

            Assert.IsInstanceOfType(per, typeof(Supervisor)); //pass
            //Assert.IsInstanceOfType(per, typeof(Person)); //pass
            //Assert.IsInstanceOfType(per, typeof(Employee)); //fail
        }

        [TestMethod]
        public void IsNullTest()
        {
            PersonManager mgr = new PersonManager();
            Person per;

            per = mgr.CreatePerson("", "Chou", true);

            Assert.IsNull(per);
        }

    }
}
