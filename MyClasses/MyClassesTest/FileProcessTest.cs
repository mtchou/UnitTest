using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using System;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest
    {
        protected string _GoodFileName;
        private const string BAD_FILE_NAME = @"C:\windows\bogus.exe";
        public TestContext TestContext { get; set; }

        protected void SetGoodFileName()
        {
            _GoodFileName = TestContext.Properties["GoodFileName"].ToString();
            if (_GoodFileName.Contains("[AppPath]")) {
                _GoodFileName = _GoodFileName.Replace("[AppPath]", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }

        }

        [TestMethod]
        public void FileNameDoesExist()
        {
            //Arrange - initial variable
            FileProcess fp = new FileProcess();
            bool fromCall;

            SetGoodFileName();
            //Act - invoke method to test
            //@ symbol: tell compiler not to deal with 
            TestContext.WriteLine(@"Checking File " + _GoodFileName);
            fromCall = fp.FileExists(_GoodFileName);

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
