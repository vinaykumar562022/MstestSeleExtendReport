using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using MyLibrary.Pages;
using System.Runtime.CompilerServices;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Collections.Generic;
using System;

namespace MyLibrary.Tests
{
    [TestClass]
    public class HerokuappPageTests : TestBase
    {
        

        [TestMethod,Description("HerokuappPageTests_NewWindow_1")]        
        public void HerokuappPageTests_NewWindow_1()
        {
            _test.Info("HerokuappPageTests_NewWindow_1 started");

            var windowPage = new HerokuappWindowPage(_driver);
            //var newwindowPage = new HerokuappNewWindowPage(_driver);

            //_driver.Navigate().GoToUrl("https://qaportal.synnexb2b.com.au:4443/");
            windowPage.NavigatetoURL();

            

            // Get the handle of the first tab
            string firstTabHandle = _driver.CurrentWindowHandle;

            windowPage.ClickHereLnk();
            Thread.Sleep(3000);
            
            // Get the window handles for all open tabs
            IList<string> windowHandles = _driver.WindowHandles;

            // Switch to the new tab
            _driver.SwitchTo().Window(_driver.WindowHandles[1]);

            Thread.Sleep(3000);

            var newwindowPage = new HerokuappNewWindowPage(_driver);
            newwindowPage.CheckNewWindowText();

            // Switch back to the first tab
            _driver.SwitchTo().Window(firstTabHandle);

            Thread.Sleep(3000);

            Assert.IsTrue(_driver.FindElement(By.XPath("//h3")).Text=="Opening a new window"); 

             _test.Info("HerokuappPageTests_NewWindow_1 ended without error");
        }

        [TestMethod,Description("HerokuappPageTests_NewBrowserWindow_1")]        
        public void HerokuappPageTests_NewBrowserWindow_1()
        {
            _test.Info("HerokuappPageTests_NewBrowserWindow_1 started");

            //open a new window
            var selectorshubDash =new SelectorshubDashBoardPage(_driver);
            selectorshubDash.NavigatetoURL();

            Thread.Sleep(3000);
            // Open a new window
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.open('https://the-internet.herokuapp.com/windows', '_blank');");

            // Get the window handles for all open windows
            string currentWindowHandle = _driver.CurrentWindowHandle;
            
            IList<string> _windowHandles = _driver.WindowHandles;

            foreach (string windowHandle in _driver.WindowHandles)
            {
                if (windowHandle != currentWindowHandle)
                {
                    Thread.Sleep(3000);
                    // Switch to the new window
                    _driver.SwitchTo().Window(windowHandle);

                    var herokuappWindowPage=new HerokuappWindowPage(_driver);

                    herokuappWindowPage.ClickHereLnk();
                    Thread.Sleep(3000);
                    // Perform actions on the new window
                    Console.WriteLine("Title of the new window: " + _driver.Title);

                    // Switch back to the first window
                    _driver.SwitchTo().Window(currentWindowHandle);
                    selectorshubDash.DatePicker();
                    // Perform actions on the first window
                    Console.WriteLine("Title of the first window: " + _driver.Title);
                }
            }
            IList<string> _windowHandles1 = _driver.WindowHandles;
            _test.Info("HerokuappPageTests_NewBrowserWindow_1 ended without error");

            IList<string> _windowHandles2 = _driver.WindowHandles;
        }
    

        [TestMethod,Description("DemoqaNewWindowPageTests_1")] 
        public void DemoqaNewWindowPageTests_1()
        {
            _test.Info("DemoqaNewWindowPageTests_1 started");
            var demoqaPage=new DemoqaNewWindowPage(_driver);
            demoqaPage.NavigatetoURL();
            demoqaPage.ClickNewWindowButton();

            _test.Info("DemoqaNewWindowPageTests_1 ended without error");
        }

        [TestMethod,Description("HerokuappPageTests_DragAndDrop_1")] 
        public void HerokuappPageTests_DragAndDrop_1()
        {
            _test.Info("HerokuappPageTests_DragAndDrop_1 started");
            var demoqaPage=new HerokuappDragDropPage(_driver);
            demoqaPage.NavigatetoURL();
            demoqaPage.DragAndDropAtoB();

            _test.Info("HerokuappPageTests_DragAndDrop_1 ended without error");
        }

    }
}