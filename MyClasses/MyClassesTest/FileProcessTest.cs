using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using System;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest
    {
        [TestMethod]
        public void FileNameDoesExist()
        {
            //Arrange - initial variable
            FileProcess fp = new FileProcess();
            bool fromCall;

            //Act - invoke method to test
            //@ symbol: tell compiler not to deal with /
            fromCall = fp.FileExists(@"C:\windows\regedit.exe");

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
            //@ symbol: tell compiler not to deal with /
            fromCall = fp.FileExists(@"C:\windows\bogus.exe");

            //Assert
            Assert.IsFalse(fromCall);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileNameNullOrEmpty_UsingAttribute()
        {
            FileProcess fp = new FileProcess();

            fp.FileExists("");

        }

        [TestMethod]
        public void FileNameNullOrEmpty_UsingTryCatch()
        {
            FileProcess fp = new FileProcess();

            try
            {
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
