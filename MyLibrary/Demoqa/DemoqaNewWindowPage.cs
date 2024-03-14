using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using AventStack.ExtentReports;
using MyLibrary.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MyLibrary.Pages
{
    public class DemoqaNewWindowPage : DemoqaBasePage
    {
        public DemoqaNewWindowPage(IWebDriver driver) : base(driver)
        {
            
        }

        

         [FindsBy(How = How.XPath, Using = "//*[@id='windowButton']")]
         private IWebElement BtnNewWindow;

       
        public void NavigatetoURL()
        {
            Driver.Navigate().GoToUrl(BaseURL+"browser-windows");
        }
        
        
        public  void waitForElementtoExixt(IWebDriver driver, By by, int timeoutInSeconds)
        {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
        }
    

        
    
        public void ClickNewWindowButton()
        {
            _test.Info("ClickNewWindowButton started");

             
             waitForElementtoExixt(Driver,By.XPath("//*[@id='windowButton']"),30);
             BtnNewWindow.Click();

                        // Get the window handles for all open windows
            string currentWindowHandle = Driver.CurrentWindowHandle;
            
            IList<string> _windowHandles = Driver.WindowHandles;

             Driver.SwitchTo().Window(_windowHandles[1]);

            waitForElementtoExixt(Driver,By.XPath("//*[@id='sampleHeading']"),30);

             Assert.IsTrue(Driver.FindElement(By.XPath("//*[@id='sampleHeading']")).Text=="This is a sample page");
             
            
            Thread.Sleep(3000);
            Driver.SwitchTo().Window(currentWindowHandle);

            waitForElementtoExixt(Driver,By.XPath("//*[@class='main-header']"),30);

            Assert.IsTrue(Driver.FindElement(By.XPath("//*[@class='main-header']")).Text=="Browser Windows");
            
            _test.Info("ClickNewWindowButton Ended");
           
        }
    }

}