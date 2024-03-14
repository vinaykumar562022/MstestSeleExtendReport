using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using MyLibrary.Logging;

namespace MyLibrary.Pages
{
    public abstract class IframescenarioBasePage :Report
    {
        protected readonly IWebDriver Driver;
        protected readonly string BaseURL="https://selectorshub.com/iframe-scenario/";
        protected IframescenarioBasePage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}