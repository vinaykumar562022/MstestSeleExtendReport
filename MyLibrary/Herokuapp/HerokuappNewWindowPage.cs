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
    public class HerokuappNewWindowPage : HerokuappBasePage
    {
        public HerokuappNewWindowPage(IWebDriver driver) : base(driver)
        {
            
        }

        

         [FindsBy(How = How.XPath, Using = "//*[@class='example']//h3")]
         private IWebElement NewWindowText;

       
        public void NavigatetoURL()
        {
            Driver.Navigate().GoToUrl(BaseURL+"windows/new");
        }
        
        
        public  void waitForElementtoExixt(IWebDriver driver, By by, int timeoutInSeconds)
        {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
        }
    

        
    
        public void CheckNewWindowText()
        {
            _test.Info("CheckNewWindowText started");
            //var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id='pact1']")));
             //Driver.switchTo().frame("pact1");
             //Driver.SwitchTo().Frame("pact1");
             //IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)Driver;
            //var currentFrame = jsExecutor.ExecuteScript("return self.id");
            // _test.Info("IframeID"+ currentFrame);
             waitForElementtoExixt(Driver,By.XPath("//*[@class='example']//h3"),30);
             
            //SelectItemByText(producstDDL,By.XPath("//a[@class='hfe-menu-item' and contains(text(),'Products')]"),20,"");
             Assert.IsTrue(NewWindowText.Text=="New Window");
            
            //Thread.Sleep(5000);
            //SelectItemByText(ele,"SelectorsHub");
            _test.Info("CheckNewWindowText Ended");
            
        }
    }

}