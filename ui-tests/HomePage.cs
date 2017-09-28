using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ui_tests
{
	public class HomePage
    {
        ChromeDriver Driver;
        public HomePage(ChromeDriver driver)
        {
            Driver = driver;
        }

        public HomePage GoTo()
        {
            new Navigation(Driver).NavigateTo("Home");
            return this;
        }

        public bool SearchFor(string query)
        {
            Driver.FindElementById("searchBoxInput").SendKeys(query + Keys.Enter);
            return Driver.Title.Contains("Items");
        }
    }
}
