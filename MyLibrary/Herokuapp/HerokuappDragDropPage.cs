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
    public class HerokuappDragDropPage : HerokuappBasePage
    {
        public HerokuappDragDropPage(IWebDriver driver) : base(driver)
        {
            
        }

        

         [FindsBy(How = How.XPath, Using = "//*[@id='column-a']//header")]
         private IWebElement dragBoxA;

         
         [FindsBy(How = How.XPath, Using = "//*[@id='column-b']//header")]
         private IWebElement dragBoxB;

       
        public void NavigatetoURL()
        {
            Driver.Navigate().GoToUrl(BaseURL+"drag_and_drop");
        }
        
        
        public  void waitForElementtoExixt(IWebDriver driver, By by, int timeoutInSeconds)
        {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
        }
    

        
    
        public void DragAndDropAtoB()
        {
            _test.Info("DragAndDropAtoB started");
            //var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id='pact1']")));
             //Driver.switchTo().frame("pact1");
             //Driver.SwitchTo().Frame("pact1");
             //IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)Driver;
            //var currentFrame = jsExecutor.ExecuteScript("return self.id");
            // _test.Info("IframeID"+ currentFrame);
            Actions action=new Actions(Driver);
            action.DragAndDrop(dragBoxA,dragBoxB).Build().Perform();

            Assert.IsTrue(Driver.FindElement(By.XPath("//*[@id='column-b']//header")).Text=="A");
            _test.Info("DragAndDropAtoB Ended");
            
        }
    }

}