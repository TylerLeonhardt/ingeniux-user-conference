using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;

namespace multiple_browser
{
    public class TestBase
    {
        public IWebDriver Driver { get; set; }

        public virtual void TestInit()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("http://localhost:5000/");
            Assert.IsTrue(Driver.Title.Contains("webapp"), "Did not properly navigate to home page.");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (Driver != null)
            {
                Driver.Quit();
            }
        }

        [TestMethod]
        public void GoToAboutTab()
        {
            IWebElement about = Driver.FindElement(By.LinkText("About"));
            about.Click();

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.Until((d) => d.FindElements(By.TagName("h2")).Count > 0);

            IWebElement header = Driver.FindElement(By.TagName("h2"));
            Assert.IsTrue(header.Text.Equals("About"));
        }

        [TestMethod]
        public void GoToContactTab()
        {
            IWebElement about = Driver.FindElement(By.LinkText("Contact"));
            about.Click();

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.Until((d) => d.FindElements(By.TagName("h2")).Count > 0);

            IWebElement header = Driver.FindElement(By.TagName("h2"));
            Assert.IsTrue(header.Text.Equals("Contact"));
        }

        [TestMethod]
        public void NavigateThroughCarousel()
        {
            var pages = Driver.FindElements(By.ClassName("item"));
            Assert.IsTrue(pages[0].GetAttribute("class").Contains("active"));

            IWebElement rightCarousel = Driver.FindElement(By.ClassName("glyphicon-chevron-right"));
            rightCarousel.Click();

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.Until((d) => d.FindElements(By.ClassName("item"))[1].GetAttribute("class").Contains("active"));

            pages = Driver.FindElements(By.ClassName("item"));
            Assert.IsTrue(pages[1].GetAttribute("class").Contains("active"));
        }

        [TestMethod]
        public void GoToLink()
        {
            IWebElement link = Driver.FindElement(By.LinkText("Bootstrap"));
            link.Click();

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.Until((d) => d.Title.Contains("Bootstrap"));

            Assert.IsTrue(Driver.Title.Contains("Bootstrap"));
        }
    }
}
