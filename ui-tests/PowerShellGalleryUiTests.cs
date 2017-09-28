using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ui_tests
{
    [TestClass]
    public class PowerShellGalleryUiTests
    {
        ChromeDriver Driver;

        [TestInitialize]
        public void TestInit()
        {
            Driver = new ChromeDriver("/Users/tylerleonhardt/Desktop/ingeniux-user-conference/ui-tests/bin/Debug/netcoreapp2.0");
            Driver.Navigate().GoToUrl("https://powershellgallery.com");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (Driver != null)
            {
                Driver.Close();
            }
        }

        [TestMethod]
        public void NavigatesToHomePage()
        {
            Assert.IsTrue(Driver.Title.Contains("Home"));
        }







        [TestMethod]
        public void NavigatesToSearchPage()
        {
            Driver.FindElement(By.LinkText("Items")).Click();
            Assert.IsTrue(Driver.Title.Contains("Items"));
        }

        [TestMethod]
        public void DoSearch()
        {
            Driver.FindElement(By.Id("searchBoxInput")).SendKeys("AzureRM.Storage" + Keys.Enter);

            Assert.IsTrue(Driver.Title.Contains("Items"));

            Assert.IsTrue(Driver.FindElements(By.LinkText("AzureRM.Storage")).Count > 0);
        }


















        [TestMethod]
        public void DoSearchBetter()
        {
            Driver.FindElement(By.Id("searchBoxInput")).SendKeys("AzureRM.Storage" + Keys.Enter);

            Assert.IsTrue(Driver.Title.Contains("Items"));

            var listItems = Driver.FindElements(By.ClassName("package-list-header"));

            Assert.IsTrue(listItems[0].FindElements(By.LinkText("AzureRM.Storage")).Count > 0);
        }










        [TestMethod]
        public void DoSearchUsingClass()
        {
            var itemsPage = new ItemsPage(Driver);
            itemsPage.GoTo()
                     .SearchFor("Azure")
                     .GoToNextPage();

            Assert.IsTrue(itemsPage.CheckIfOnPage(2));
        }
    }
}
