using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using MyLibrary.Pages;
using System.Runtime.CompilerServices;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MyLibrary.Tests
{
    [TestClass]
    public class AutomationexerciseLoginTests : TestBase
    {
        

        [TestMethod,Description("AutomationexerciseLogin_ValidCredentials_Success")]
        [DynamicData(nameof(UserData),DynamicDataSourceType.Method)]
        //[DataRow("username2", "password2")]
        //public void Login_ValidCredentials_Success(string username, string password)
        public void AutomationexerciseLogin_ValidCredentials_Success(string username, string password)
        {
            //TestInitialize(browserType);

            var loginPage = new AutomationexerciseLoginPage(_driver);

            //_driver.Navigate().GoToUrl("https://qaportal.synnexb2b.com.au:4443/");
            loginPage.NavigatetoURL();

            loginPage.AutomationexerciseLogin(username, password);
        }

        
        private static IEnumerable<object[]> UserData()
        {
            yield return new object[] { "vinaykumar562018@gmail.com", "Vinay@123" };
            //yield return new object[] { "pivital", ""};
            // get
            // {
            //     return new[]
            //     { 
            //         new object[] { "pivital", ""},
            //         new object[] { "pivital", "" },
                    
            //     };
            // }
        }
    }
}
