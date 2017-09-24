using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace multiple_browser
{
    [TestClass]
    public class FirefoxTests : TestBase
    {
        [TestInitialize]
        public override void TestInit()
        {
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(
                "/Users/tylerleonhardt/Desktop/ingeniux-user-conference/multiple-browser-tests/bin/Debug/netcoreapp2.0/");
            Driver = new FirefoxDriver(service);

            base.TestInit();
        }
    }
}
