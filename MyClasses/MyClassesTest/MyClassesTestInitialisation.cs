using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassesTest
{
    [TestClass]
    public class MyClassesTestInitialisation
    {
        [AssemblyInitialize]
        public static void AssemblyInitialise(TestContext tc)
        {
            //TODO: Initialise for all tests within an assembly
            tc.WriteLine("In AssmblyInitialise() method");
        }

        [AssemblyCleanup]
        public static void AssembyCleanup()
        {
            //TODO: Clean up after all tests in an assembly
            
        }
    }
}
