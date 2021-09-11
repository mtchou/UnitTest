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

     
        [TestMethod]
        public void FileNameDoesExist()
        {
            //Arrange - initial variable
            FileProcess fp = new FileProcess();
            bool fromCall;

            SetGoodFileName();
            if (!string.IsNullOrEmpty(_GoodFileName))
            {
                //Create a file
                File.AppendAllText(_GoodFileName, "Hello world");
            }
            //Act - invoke method to test
            //@ symbol: tell compiler not to deal with 
            TestContext.WriteLine(@"Checking File " + _GoodFileName);
            fromCall = fp.FileExists(_GoodFileName);

            //Delete the file
            if (File.Exists(_GoodFileName))
            {
                File.Delete(_GoodFileName);
            }

            //Assert
            Assert.IsTrue(fromCall);
            //Assert.Inconclusive();
        }

        [TestMethod]
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
        public void FileNameNullOrEmpty_UsingAttribute()
        {
            FileProcess fp = new FileProcess();

            TestContext.WriteLine(@"Checking for a null file (ArgumentNullException)");
            fp.FileExists("");

        }

        [TestMethod]
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
