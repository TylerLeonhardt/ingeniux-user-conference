using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ui_tests
{
    public class ItemsPage
    {
        ChromeDriver Driver;

        public ItemsPage(ChromeDriver driver)
        {
            Driver = driver;
        }

        public ItemsPage GoTo()
        {
            new Navigation(Driver).NavigateTo("Items");
            return this;
        }

        public ItemsPage SearchFor(string query)
        {
            Driver.FindElementById("searchBoxInput").SendKeys(query + Keys.Enter);
            return this;
        }

        public ItemsPage GoToNextPage()
        {
            Driver.FindElement(By.CssSelector("#mainColumn > ul.pager > li.next > form > input.pager-button")).SendKeys(Keys.Enter);
            return this;
        }

        public ItemsPage GoToPreviousPage()
        {
            Driver.FindElement(By.CssSelector("#mainColumn > ul.pager > li.previous > form > input.pager-button")).SendKeys(Keys.Enter);
            return this;
        }

        public bool CheckIfOnPage(int page)
        {
            var results = Driver.FindElement(By.ClassName("search"))
                  .FindElement(By.TagName("h2"));

            // Ex: "Displaying results 21 - 40." gets 40
            int upperBoundOfSearchResults = int.Parse(results.Text.TrimEnd('.').Split(" - ")[1]);
            return upperBoundOfSearchResults / 20 == page;
        }
    }
}
