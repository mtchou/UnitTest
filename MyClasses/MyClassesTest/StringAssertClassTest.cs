using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyClassesTest
{

    [TestClass]
    public class StringAssertClassTest : TestBase
    {
        [TestMethod]
        public void ContainTest()
        {
            string str1 = "Mandy Chou";
            string str2 = "Chou";

            StringAssert.Contains(str1, str2);
        }

        [TestMethod]
        public void StartWithTest()
        {
            string str1 = "All Lower Case";
            string str2 = "All Lower";

            StringAssert.StartsWith(str1, str2);
        }

        [TestMethod]
        public void IsAllLowerCaseTest()
        {
            Regex r = new Regex(@"^([^A-Z])+$");
            // zo+ means zo, zoo, zooooo etc, but not "z". {1, -}
            //^ string start, $ string end
            //[^A-Z] means anything that are not A-Z can be listed

            StringAssert.Matches("all lower case 134@", r); //fail
            //StringAssert.Matches("All lower case", r); //fail
        }
    }
}
