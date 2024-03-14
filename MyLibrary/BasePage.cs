using OpenQA.Selenium;
//using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;
using AventStack.ExtentReports;
using MyLibrary.Logging;


namespace MyLibrary.Pages
{
    public abstract class BasePage :Report
    {
        protected readonly IWebDriver Driver;
        //protected readonly ExtentTest Test;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }

    
}

