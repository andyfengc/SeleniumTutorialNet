using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTutorialNet
{
    /// <summary>
    /// demo 2: grab data
    /// </summary>
    public class TrackingDemo
    {
        public static void TrackWithoutBrowser()
        {
            // initialize a WebDriver instance
            IWebDriver driver = new PhantomJSDriver();
            WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Window.Maximize();
            // load search page
            driver.Navigate().GoToUrl("http://www.purolator.com/purolator/ship-track/tracking-summary.page?submit=true&componentID=1359477580240");
            // wait 5 seconds
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            // write page
            using (Stream stream = File.Open(@"d:\delete\selenium\1.html", FileMode.Create, FileAccess.ReadWrite))
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(driver.PageSource);
                    stream.Write(bytes, 0, bytes.Length);
                }
            }


            Console.WriteLine("Page title: " + driver.Title);
            // enter tracking number and submit
            IWebElement element = driver.FindElement(By.CssSelector("form textarea#search"));
            element.SendKeys("JFV242486848");
            element.Submit();
            //// wait 5 seconds
            //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            //// write result page
            //using (Stream stream = File.Open(@"d:\delete\selenium\2.html", FileMode.Create, FileAccess.ReadWrite))
            //{
            //    using (BinaryWriter writer = new BinaryWriter(stream))
            //    {
            //        byte[] bytes = Encoding.UTF8.GetBytes(driver.PageSource);
            //        stream.Write(bytes, 0, bytes.Length);
            //    }
            //}




                // locate the tracking history table
            var trackingHistory = driver.FindElement(By.CssSelector("#historyDiv table#history tbody"));
            string result = trackingHistory.Text;
            var rows = trackingHistory.FindElements(By.TagName("tr")).ToList();
            string locationPath = "//td[@class='location']";
            //var locations = driverWait.Until(drv => drv.FindElements(By.XPath("//td[@class='location']")));
            //driverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//td[@class='location']")));
             var locations = driver.FindElements(By.XPath(locationPath));
            foreach (var location in locations)
            {
                string a = location.Text;
            }
            foreach (var row in rows)
            {
                var t = row.FindElements(By.TagName("td"));
                string location = row.FindElements(By.ClassName("location")).FirstOrDefault().Text;
                string event_name = row.FindElements(By.TagName("td"))[3].Text;
            }
            // quit the driver
            driver.Quit();
        }

        public static void TrackWithChrome()
        {
            // initialize a WebDriver instance
            ChromeDriver driver = new ChromeDriver();
            // load google search page
            driver.Navigate().GoToUrl("http://www.purolator.com/purolator/ship-track/tracking-summary.page?submit=true&componentID=1359477580240");
            // wait 5 seconds
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            // write page
            using (Stream stream = File.Open(@"d:\delete\selenium\1.html", FileMode.Create, FileAccess.ReadWrite))
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(driver.PageSource);
                    stream.Write(bytes, 0, bytes.Length);
                }
            }

            Console.WriteLine("Page title: " + driver.Title);
            // enter tracking number and submit
            IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("textarea#search")));
            element.Click();
            element.SendKeys("JFV242486848");
            element.Submit();
            // wait 5 seconds
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            // write result page
            using (Stream stream = File.Open(@"d:\delete\selenium\2.html", FileMode.Create, FileAccess.ReadWrite))
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(driver.PageSource);
                    stream.Write(bytes, 0, bytes.Length);
                }
            }
            // quit the driver
            driver.Quit();
        }
    }
}
