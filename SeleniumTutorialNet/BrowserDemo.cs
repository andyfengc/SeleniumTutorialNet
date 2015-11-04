using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;

namespace SeleniumTutorialNet
{
    class BrowserDemo
    {
        public static void OpenHtmlUnitDriver()
        {
            // initialize a WebDriver instance
            //IWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), DesiredCapabilities.HtmlUnit());
            IWebDriver driver = new RemoteWebDriver(DesiredCapabilities.HtmlUnit());
            // load google search page
            driver.Navigate().GoToUrl("https://www.google.ca");
            // print title
            Console.WriteLine("Page title: " + driver.Title);
            // enter search word and submit
            IWebElement element = driver.FindElement(By.Name("q"));
            element.SendKeys("Cheese");
            element.Submit();
            // print title
            Console.WriteLine("Page title: " + driver.Title);
            // quit the driver
            driver.Quit();
        }

        public static void OpenPhantomJs()
        {
            // initialize a WebDriver instance
            IWebDriver driver = new PhantomJSDriver();
            // load google search page
            driver.Navigate().GoToUrl("https://www.google.ca");
            // print title
            Console.WriteLine("Page title: " + driver.Title);
            // enter search word and submit
            IWebElement element = driver.FindElement(By.Name("q"));
            element.SendKeys("Cheese");
            element.Submit();
            // print title
            Console.WriteLine("Page title: " + driver.Title);
            // quit the driver
            driver.Quit();
        }
    }
}
