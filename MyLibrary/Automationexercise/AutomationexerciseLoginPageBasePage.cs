using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using MyLibrary.Logging;

namespace MyLibrary.Pages
{
    public abstract class AutomationexerciseLoginPageBasePage :Report
    {
        protected readonly IWebDriver Driver;
        //protected readonly ExtentTest Test;
        protected readonly string BaseURL="https://automationexercise.com/";
        protected AutomationexerciseLoginPageBasePage(IWebDriver driver)
        {
            Driver = driver;
            //Test = ExtentTestManager.GetCurrentTest();
            PageFactory.InitElements(driver, this);
        }
    }
}