using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using AventStack.ExtentReports;
using MyLibrary.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System;

namespace MyLibrary.Pages
{
    public class HerokuappWindowPage : HerokuappBasePage
    {
        public HerokuappWindowPage(IWebDriver driver) : base(driver)
        {
            
        }

        

         [FindsBy(How = How.XPath, Using = "//a[contains(@href,'/windows/new')]")]
         private IWebElement LnkClickHere;

       
        public void NavigatetoURL()
        {
            Driver.Navigate().GoToUrl(BaseURL+"windows");
        }
        
        
        public  void waitForElementtoExixt(IWebDriver driver, By by, int timeoutInSeconds)
        {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
        }
    

        
    
        public void ClickHereLnk()
        {
            _test.Info("ClickHereLnk started");
            //var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id='pact1']")));
             //Driver.switchTo().frame("pact1");
             //Driver.SwitchTo().Frame("pact1");
             //IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)Driver;
            //var currentFrame = jsExecutor.ExecuteScript("return self.id");
            // _test.Info("IframeID"+ currentFrame);
             waitForElementtoExixt(Driver,By.XPath("//a[contains(@href,'/windows/new')]"),30);
             LnkClickHere.Click();
            _test.Info("ClickHereLnk Ended");
            
        }
    }

}