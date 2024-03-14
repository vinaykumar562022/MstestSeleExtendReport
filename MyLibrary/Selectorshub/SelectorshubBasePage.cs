using OpenQA.Selenium;
//using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;
using MyLibrary.Logging;

namespace MyLibrary.Pages
{
    public abstract class SelectorshubBasePage :Report
    {
        protected readonly IWebDriver Driver;
        //protected readonly ExtentTest Test;
        protected readonly string BaseURL="https://selectorshub.com/xpath-practice-page/";
        protected SelectorshubBasePage(IWebDriver driver)
        {
            Driver = driver;
            //Test = ExtentTestManager.GetCurrentTest();
            PageFactory.InitElements(driver, this);
        }
    }
}
