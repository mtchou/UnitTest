using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using System;
using System.IO;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessOtherTest : TestBase
    {
        [ClassInitialize()]
        public static void ClassInitialise(TestContext tc)
        {
            //TODO: Intialise for all tests in class
            tc.WriteLine("In ClassInitialise() method");
        }

        [ClassCleanup()]
        public static void ClassCleanUp()
        {
            //TODO: Clean up after all tests in class
        }

        //Test Initialise and Test Clean Up will be run for EVERY [TestMethod]
        [TestInitialize]
        public void TestInitialise()
        {
            TestContext.WriteLine("In the TestInitialise() method");
            WriteDescription(this.GetType());

            if (TestContext.TestName.StartsWith("FileNameDoesExist"))
            {
                SetGoodFileName();
                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine(@"Create File " + _GoodFileName);
                    //Create a file
                    File.AppendAllText(_GoodFileName, "Hello world");
                }

            }

        }

        [TestCleanup]
        public void TestCleanUp()
        {
            TestContext.WriteLine("In the TestCleanUp() method");
            if (TestContext.TestName.StartsWith("FileNameDoesExist"))
            {
                TestContext.WriteLine(@"Delete File " + _GoodFileName);
                //Delete the file
                if (File.Exists(_GoodFileName))
                {
                    File.Delete(_GoodFileName);
                }
            }
        }


        [TestMethod]
        public void AreSameTest()
        {
            FileProcess x = new FileProcess();
            //FileProcess y = new FileProcess();
            FileProcess y = x;

            Assert.AreSame(x, y);
            //Assert.AreNotSame(x, y);
        }


        [TestMethod]
        public void AreEqualTest()
        {
            string str1 = "Mandy";
            string str2 = "mandy";
            //Assert.AreEqual(str1, str2); //Case sensitive
            Assert.AreEqual(str1, str2, true); //Ignore the case

        }

        [TestMethod]
        public void AreNotEqual()
        {
            string str1 = "Mandy";
            string str2 = "mandy";
            Assert.AreNotEqual(str1, str2); //Case sensitive
        }


        [TestMethod]
        public void FileNameDoesExistSimpleMessagae()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(_GoodFileName);
            Assert.IsFalse(fromCall, "File {0} Does Not Exist. {1}", _GoodFileName, fromCall);
            //Assert.IsFalse(fromCall, "File " + _GoodFileName + " Does Not Exist.");


        }



    }
}
