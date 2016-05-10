using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTutorialNet
{
    public class LocalParser
    {
        public static void Process()
        {
            // works with local html page but has browser window
            //IWebDriver driver = new ChromeDriver();
            // not working with local html page
            IWebDriver driver = new PhantomJSDriver();
            driver.Navigate().GoToUrl("file://c:/Work/Workspace/SeleniumTutorialNet/SeleniumTutorialNet/empty-page.html");
            //driver.Navigate().GoToUrl("http://www.google.ca");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            Console.WriteLine("\n\n"+driver.Title);
            //Console.WriteLine("\n\n" + driver.PageSource);
        }
    }
}
