using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Safari;

namespace multiple_browser
{
    [TestClass]
    public class SafariTests : TestBase
    {
        [TestInitialize]
        public override void TestInit()
        {
            Driver = new SafariDriver();

            base.TestInit();
        }
    }
}
