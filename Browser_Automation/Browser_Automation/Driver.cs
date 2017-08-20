using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Browser_Automation
{
    class Driver
    {
        public enum Browser
        {
            chrome,
            firefox,
            ie,
        }
        public IWebDriver getDriver(string browser_type)
        {
            Browser parsed_browser_type; IWebDriver driver=null;
            bool passed_type = browser_type != null ? true : false;
            if (passed_type)
            {
                Enum.TryParse(browser_type, out parsed_browser_type);
   
                switch (browser_type.ToLower())
                {

                    case "chrome":
                       driver= new ChromeDriver(new ChromeOptions { Proxy = null });
                        break;
                    case "firefox":
                       driver= new FirefoxDriver();
                        break;
                    case "ie":
                        driver= new InternetExplorerDriver(new InternetExplorerOptions { Proxy = null });
                        break;
                    default:
                    case "":
                       throw new Exception("Browser cannot be null");
                }
            }
            return driver;
        }
    }
}
