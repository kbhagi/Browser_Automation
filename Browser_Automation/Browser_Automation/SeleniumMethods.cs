using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NUnit.Framework;
using Browser_Automation;

public class Browser_Simulation
{
    static Driver d; static IWebDriver driver; 
    static Browser_Simulation sm;
   
    public Browser_Simulation(string browser_type)
	{
        d = new Driver();
        driver = d.getDriver(browser_type);
    }

    public IWebDriver getDriver()
    {
        return driver;
    }

    public  void Click_Element(IWebElement ele)
    {
        ele.Click();

    }

    public  void Send_Keys(IWebElement ele, string value)
    {

         ele.SendKeys(value);
    }

    public  IWebElement FindElement(string by_type, string element_value)
    {
        IWebElement element = null;
        try
        {
            switch (by_type)
            {

                case "ClassName":
                    element= driver.FindElement(By.ClassName(element_value));
                    break;

                case "CssSelector":
                    element = driver.FindElement(By.CssSelector(element_value));
                    break;
                case "Id":
                    element = driver.FindElement(By.Id(element_value));
                    break;
                case "LinkText":
                    element= driver.FindElement(By.LinkText(element_value));
                    break;
                case "Name":
                    element= driver.FindElement(By.Name(element_value));
                    break;
                case "PartialLinkText":
                    element= driver.FindElement(By.PartialLinkText(element_value));
                    break;
                case "TagName":
                    element= driver.FindElement(By.TagName(element_value));
                    break;
                case "XPath":
                    element= driver.FindElement(By.XPath(element_value));
                    break;
                default:
                case "":
                    throw new Exception("Element type not found");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.GetBaseException());
        }
        return element;
    }

     public  void CleanUp()
    {
        try
        {
            //if(driver!=null)
            driver.Close();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.GetBaseException());
        }
    }

    public  void Navigate(string url)
    {
        try
        {
            driver.Navigate().GoToUrl(url);
        }
        catch (Exception ex)
        {
            // Add useful information to the exception
            throw new ApplicationException("Something wrong happened in the navigating url :", ex);
        }
        finally
        {
            if (driver != null)
                driver.Close();
        }
    }


}
