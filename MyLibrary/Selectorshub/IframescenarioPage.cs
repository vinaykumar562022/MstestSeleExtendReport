
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using AventStack.ExtentReports;
using MyLibrary.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System;
using System.Threading;

namespace MyLibrary.Pages
{
    public class IframescenarioPage : IframescenarioBasePage
    {
        public IframescenarioPage(IWebDriver driver) : base(driver)
        {
            
        }

        

        // [FindsBy(How = How.XPath, Using = "//*[@id='lost']")]
        // private IWebElement btnLost;

       
        public void NavigatetoURL()
        {
            Driver.Navigate().GoToUrl(BaseURL);
        }
        
        
        public  void waitForElementtoExixt(IWebDriver driver, By by, int timeoutInSeconds)
        {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
        }
    

        
    
        public void IframescenarioInput()
        {
            _test.Info("DashboardDDL started");
             Driver.SwitchTo().Frame("pact1");
             IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)Driver;
            var currentFrame = jsExecutor.ExecuteScript("return self.id");
             _test.Info("IframeID"+ currentFrame);
             waitForElementtoExixt(Driver,By.XPath("//*[@id='inp_val']"),30);
             Assert.IsTrue(Driver.FindElement(By.XPath("//*[@id='inp_val']"))!=null);
             IWebElement ele= Driver.FindElement(By.XPath("//*[@id='inp_val']"));
             ele.SendKeys("vinay");
             _test.Info("Found the memory test text box");
            
            Thread.Sleep(5000);
            _test.Info("DashboardDDL Ended");
            
        }
    }

}
