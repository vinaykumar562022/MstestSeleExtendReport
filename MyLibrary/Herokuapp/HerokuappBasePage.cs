using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using MyLibrary.Logging;

namespace MyLibrary.Pages
{
    public abstract class HerokuappBasePage :Report
    {
        protected readonly IWebDriver Driver;
        protected readonly string BaseURL="https://the-internet.herokuapp.com/";
        protected HerokuappBasePage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}