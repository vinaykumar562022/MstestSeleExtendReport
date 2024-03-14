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
using System.Collections.Generic;

namespace MyLibrary.Pages
{
    public class MakeMyTripPage : MakeMyTripBasePage
    {
        public MakeMyTripPage(IWebDriver driver) : base(driver)
        {
            
        }

        

        [FindsBy(How = How.XPath, Using = "//*[@id='fromCity']")]
        private IWebElement TxtFromCity;

        [FindsBy(How = How.XPath, Using = "//*[@id='toCity']")]
        private IWebElement TxtToCity;
       
        public void NavigatetoURL()
        {
            Driver.Navigate().GoToUrl(BaseURL);
        }
        
        
        public  void waitForElementtoExixt(IWebDriver driver, By by, int timeoutInSeconds)
        {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
        }
    

        public void EnterCity(string fromCity)
        {
            _test.Info("EnterCity started");

            Thread.Sleep(2000);
            if(  Driver.FindElement(By.XPath("//*[@class='imageSlideContainer']")).Displayed)
            {
                

                IWebElement ele= Driver.FindElement(By.XPath("//*[@class='imageSlideContainer']"));
                Actions action = new Actions(Driver);
                action.MoveToElement(Driver.FindElement(By.TagName("HTML"))).MoveByOffset(100,100).Click().Perform();
                action.MoveByOffset(20,20).Perform();
                //Thread.Sleep(10000);
                action.Click();
            }
            //WebDriverWait wait=new WebDriverWait(SeleniumExtras.WaitHelpers.ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.XPath("")))
            waitForElementtoExixt(Driver,By.XPath("//*[@id='fromCity']"),20);
            TxtFromCity.Click();
            //TxtFromCity.SendKeys("hyd");
            waitForElementtoExixt(Driver,By.XPath("//*[@placeholder='From']"),20);
            var txtbox=Driver.FindElement(By.XPath("//*[@placeholder='From']"));
            txtbox.SendKeys(fromCity);
            Thread.Sleep(3000);
            waitForElementtoExixt(Driver,By.XPath("//*[@id='react-autowhatever-1']//ul//li//*[@class='calc60']"),30);
            
            IList<IWebElement> ddl=Driver.FindElements(By.XPath("//*[@id='react-autowhatever-1']//ul//li//*[@class='calc60']"));
            _test.Info("City: started");

            foreach (var item in ddl)
            {
                
                var cityDescr= Driver.FindElement(By.XPath("//*[@id='react-autowhatever-1']//ul//li//*[@class='calc60']//*[contains(@class,'blackText')]"));
                _test.Info("City-: "+cityDescr.Text);
                // if(cityDescr.Text.ToLower().Contains("hyderabad"))
                // {
                //     cityDescr.Click();
                // }
            }
            

            _test.Info("EnterCity ended without error");
        }
    
    //     public void ClickNewWindowButton()
    //     {
    //         _test.Info("ClickNewWindowButton started");

             
    //          waitForElementtoExixt(Driver,By.XPath("//*[@id='windowButton']"),30);
    //          BtnNewWindow.Click();

    //                     // Get the window handles for all open windows
    //         string currentWindowHandle = Driver.CurrentWindowHandle;
            
    //         IList<string> _windowHandles = Driver.WindowHandles;

    //          Driver.SwitchTo().Window(_windowHandles[1]);

    //         waitForElementtoExixt(Driver,By.XPath("//*[@id='sampleHeading']"),30);

    //          Assert.IsTrue(Driver.FindElement(By.XPath("//*[@id='sampleHeading']")).Text=="This is a sample page");
             
            
    //         Thread.Sleep(3000);
    //         Driver.SwitchTo().Window(currentWindowHandle);

    //         waitForElementtoExixt(Driver,By.XPath("//*[@class='main-header']"),30);

    //         Assert.IsTrue(Driver.FindElement(By.XPath("//*[@class='main-header']")).Text=="Browser Windows");
            
    //         _test.Info("ClickNewWindowButton Ended");
           
    //     }
    }

}