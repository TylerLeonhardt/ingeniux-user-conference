using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace multiple_browser
{
    [TestClass]
    public class ChromeTests : TestBase
    {
        [TestInitialize]
        public override void TestInit()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--no-sandbox");
            Driver = new ChromeDriver(
                "/Users/tylerleonhardt/Desktop/ingeniux-user-conference/multiple-browser-tests/bin/Debug/netcoreapp2.0/",
                options);

            base.TestInit();
        }
    }
}
