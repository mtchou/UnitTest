using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using System;
using System.IO;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest : TestBase
    {
        private const string BAD_FILE_NAME = @"C:\windows\bogus.exe";

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
        [Description("Check to see if a file name exist.")]
        [Owner("Mandy")]
        [Priority(1)]
        [TestCategory("No Exception")]
        //[Ignore]
        public void FileNameDoesExist()
        {
            //Arrange - initial variable
            FileProcess fp = new FileProcess();
            bool fromCall;


            TestContext.WriteLine(@"Checking file: " + _GoodFileName);
            //Act - invoke method to test
            //@ symbol: tell compiler not to deal with 
            fromCall = fp.FileExists(_GoodFileName);


            //Assert
            Assert.IsTrue(fromCall);
            //Assert.Inconclusive();
        }

        [TestMethod]
        [Timeout(3000)]
        public void SimulateTimeout()
        {
            System.Threading.Thread.Sleep(4000); //4000 m-sec
        }

        [TestMethod]
        [Description("Check to see if a file name does not exist.")]
        [Owner("Mandy")]
        [Priority(2)]
        [TestCategory("No Exception")]
        public void FileNameDoesNotExist()
        {

            //Arrange - initial variable
            FileProcess fp = new FileProcess();
            bool fromCall;

            //Act - invoke method to test
            //@ symbol: tell compiler not to deal with 
            TestContext.WriteLine(@"Checking File " + BAD_FILE_NAME);
            fromCall = fp.FileExists(BAD_FILE_NAME);

            //Assert
            Assert.IsFalse(fromCall);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Check for an throw ArgumentNullException using ExpectedException.")]
        [Owner("Goat")]
        [Priority(3)]
        [TestCategory("Exception")]
        public void FileNameNullOrEmpty_UsingAttribute()
        {
            FileProcess fp = new FileProcess();

            TestContext.WriteLine(@"Checking for a null file (ArgumentNullException)");
            fp.FileExists("");

        }

        [TestMethod]
        [Description("Check for an throw ArgumentNullException using try catch.")]
        [Owner("Goat")]
        [Priority(3)]
        [TestCategory("Exception")]
        public void FileNameNullOrEmpty_UsingTryCatch()
        {
            FileProcess fp = new FileProcess();

            try
            {
                TestContext.WriteLine(@"Checking for a null file (TryCatch)");
                fp.FileExists("");
            }
            catch (ArgumentNullException)
            {
                //This means file exists returns an argumentNulException. This indicates the test is success, so we return nothing
                return;
            }

            Assert.Fail("Call to FileExist() does not return an ArgumentNullException");
        }
    }
}
