using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.PhantomJS;

namespace SeleniumTutorialNet
{
    class TrackingDemo
    {
        public static void TrackWithoutBrowser()
        {
            // initialize a WebDriver instance
            IWebDriver driver = new PhantomJSDriver();
            // load google search page
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
            IWebElement element = driver.FindElement(By.Id("search"));
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

        public static void TrackWithoutChrome()
        {
            // initialize a WebDriver instance
            ChromeDriver driver = new ChromeDriver();
            // load google search page
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
            IWebElement element = driver.FindElementById("search");
            element.SendKeys("JFV242486848");
            //element.Submit();
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
