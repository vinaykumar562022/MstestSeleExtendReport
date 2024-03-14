using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using MyLibrary.Pages;
using System.Runtime.CompilerServices;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyLibrary.Tests
{
    [TestClass]
    public class MakeMyTripTests : TestBase
    {

        [TestMethod,Description("AutoBoxFromCityTests_1")]
        public void AutoBoxFromCityTests_1()
        {
            var autBox=new MakeMyTripPage(_driver);
            autBox.NavigatetoURL();
            autBox.EnterCity("hyd");
        }

    }
}
