using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using AventStack.ExtentReports;
using MyLibrary.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace MyLibrary.Pages
{
    public class AutomationexerciseLoginPage : AutomationexerciseLoginPageBasePage
    {
        public AutomationexerciseLoginPage(IWebDriver driver) : base(driver)
        {
            
        }

        [FindsBy(How = How.XPath, Using = "//input[@type='email' and @placeholder='Email Address' and @data-qa='login-email']")]
        private IWebElement _usernameInput;

        [FindsBy(How = How.XPath, Using = "//input[@type='password']")]
        private IWebElement _passwordInput;

        [FindsBy(How = (How.XPath), Using = "//button[@type='submit' and text() = 'Login']")]
        private IWebElement _loginButton;

        public void NavigatetoURL()
        {
            Driver.Navigate().GoToUrl(BaseURL+"login");
        }
        
        

        public void AutomationexerciseLogin(string username, string password)
        {
            _test.Info("Login started");
            //LogInfo($"Logging in with username: {username} and password: {password}");
            _usernameInput.SendKeys(username);
            _test.Info("username:"+username);
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//input[@type='email' and @placeholder='Email Address' and @data-qa='login-email']")));
            
            _passwordInput.SendKeys(password);
            _test.Info("password:"+password);
            //var wait2 = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//input[@type='password']")));
            _test.Info("after pasword:");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//button[@type='submit' and text() = 'Login']")));
            _test.Info("before Click");
            _loginButton.Click();
            Thread.Sleep(5000);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//div[contains(@class, 'shop-menu')]//*[contains(@class,'fa-user')]//following-sibling::b")));

            Assert.IsTrue(Driver.FindElement(By.XPath("//div[contains(@class, 'shop-menu')]//*[contains(@class,'fa-user')]//following-sibling::b")).Text=="vinay");      
            ////div[contains(@class, 'shop-menu')]//*[contains(@class,'fa-user')]//following-sibling::b
            _test.Info("after Click");
            _test.Info("Login Ended");
            
        }
    }

}