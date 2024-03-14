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
    public class SelectorshubTests : TestBase
    {

        [TestMethod,Description("ChkOutDDLSelectTests_1")]
        public void ChkOutDDLSelectTests_1()
        {
            var chkDDl=new SelectorshubDashBoardPage(_driver);
            chkDDl.NavigatetoURL();
            chkDDl.ChkOutDDL("Join Training");
        }

        [TestMethod,Description("DatePickerSelectTests_1")]
        public void DatePickerSelectTests_1()
        {
            var chkDDl=new SelectorshubDashBoardPage(_driver);
            chkDDl.NavigatetoURL();
            chkDDl.DatePicker();
        }

        [TestMethod,Description("SerachAutoCompleteTxtBoxTests_1")]
        public void SerachAutoCompleteTxtBoxTests_1()
        {
            var _search=new SelectorshubDashBoardPage(_driver);
            _search.NavigatetoURL();
            _search.SerachAutoCompleteTxtBox("den");
        }

        [TestMethod,Description("SelectorshubTests_1")]        
        public void SelectorshubTests_1()
        {
            var loginPage = new SelectorshubDashBoardPage(_driver);
            loginPage.NavigatetoURL();
            loginPage.DashboardDDLSelectProducts();
        }

    }
}
