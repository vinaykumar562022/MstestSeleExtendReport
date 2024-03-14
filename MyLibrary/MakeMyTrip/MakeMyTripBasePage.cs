
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using MyLibrary.Logging;

namespace MyLibrary.Pages
{
    public abstract class MakeMyTripBasePage :Report
    {
        protected readonly IWebDriver Driver;
        protected readonly string BaseURL="https://www.makemytrip.com";
        protected MakeMyTripBasePage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}