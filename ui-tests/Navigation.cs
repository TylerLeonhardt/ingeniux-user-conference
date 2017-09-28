using System;
using OpenQA.Selenium.Chrome;

namespace ui_tests
{
	public class Navigation
    {
        ChromeDriver Driver;

        public Navigation(ChromeDriver driver)
        {
            Driver = driver;
        }

        public bool NavigateTo(string location)
        {
            if (!Driver.Title.Contains(location))
            {
                Driver.FindElementByLinkText(location).Click();
            }
            return Driver.Title.Contains(location);
        }
    }
}
