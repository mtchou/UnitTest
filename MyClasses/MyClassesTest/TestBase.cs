using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

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

        protected void WriteDescription(Type typ) //type will be the test class we are in
        {
            string testName = TestContext.TestName;

            //Find the test method currently executing
            MemberInfo method = typ.GetMethod(testName);

            if (method != null)
            {
                //See if we can find the description attribute. If it finds the description, it will return the description; otherwise, return null
                Attribute attr = method.GetCustomAttribute(typeof(DescriptionAttribute));
                if (attr != null)
                {
                    //Case the attribute to description attribute
                    DescriptionAttribute dattr = (DescriptionAttribute)attr;
                    TestContext.WriteLine("Test Description: " + dattr.Description);
                }

            }
        }


    }
}
