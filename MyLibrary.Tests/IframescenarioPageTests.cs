using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using MyLibrary.Pages;
using System.Runtime.CompilerServices;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Tests
{
    [TestClass]
    public class IframescenarioPageTests : TestBase
    {
        

        [TestMethod,Description("IframescenarioPageTests_1")]        
        public void IframescenarioPageTests_1()
        {
            var loginPage = new IframescenarioPage(_driver);            
            loginPage.NavigatetoURL();
            loginPage.IframescenarioInput();
        }

    }
}
