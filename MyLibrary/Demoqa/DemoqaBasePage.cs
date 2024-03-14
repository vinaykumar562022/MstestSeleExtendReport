
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using MyLibrary.Logging;

namespace MyLibrary.Pages
{
    public abstract class DemoqaBasePage :Report
    {
        protected readonly IWebDriver Driver;
        protected readonly string BaseURL="https://demoqa.com/";
        protected DemoqaBasePage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}