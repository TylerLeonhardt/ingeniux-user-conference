// using Microsoft.VisualStudio.TestTools.UnitTesting;
// using OpenQA.Selenium;
// using OpenQA.Selenium.Chrome;
// using OpenQA.Selenium.Firefox;
// using OpenQA.Selenium.Safari;

// namespace multiple_browser
// {
//     [TestClass]
//     public class ChromeSmokeTests
//     {
//         [DataTestMethod]
//         [DataRow(Browsers.Chrome)]
//         [DataRow(Browsers.Firefox)]
//         [DataRow(Browsers.Safari)]
//         public void GoToAboutTab(Browsers broswer)
//         {
//             IWebDriver driver = GetWebDriver(broswer);
//         }

//         public enum Browsers
//         {
//             Chrome, Firefox, Safari
//         }

//         public static IWebDriver GetWebDriver(Browsers browser)
//         {
//             switch (browser)
//             {
//                 case Browsers.Chrome:
//                     ChromeOptions chromeOptions = new ChromeOptions();
//                     return new ChromeDriver(chromeOptions);
//                 case Browsers.Firefox:
//                     FirefoxOptions firefoxOptions = new FirefoxOptions();
//                     return new FirefoxDriver(firefoxOptions);
//                 case Browsers.Safari:
//                 SafariOptions safariOptions = new SafariOptions();
//                     return new SafariDriver(safariOptions);
//                 default:
//                     return null;
//             }
//         }
//     }
// }
