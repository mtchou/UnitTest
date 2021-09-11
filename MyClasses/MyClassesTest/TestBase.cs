using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MyClassesTest
{
    public class TestBase
    {
        public TestContext TestContext { get; set; }

        //use protected, so they can be used in the the inherit chain
        protected string _GoodFileName;
        protected void SetGoodFileName()
        {
            _GoodFileName = TestContext.Properties["GoodFileName"].ToString();
            if (_GoodFileName.Contains("[AppPath]"))
            {
                _GoodFileName = _GoodFileName.Replace("[AppPath]", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }

        }


    }
}
