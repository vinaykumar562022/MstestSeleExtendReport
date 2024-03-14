using System;
using System.Configuration;
using System.IO;
using AventStack.ExtentReports;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MyLibrary.Logging;
//using MyLibrary.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace MyLibrary
{
    [TestClass]
    public class TestBase:Report
    {
        public TestContext TestContext  { get; set; }
        protected IWebDriver _driver;
        
        [AssemblyInitialize]
        public static void OneTimeRun(TestContext tc)
        {
            TestBase testBase=new TestBase();
            testBase.StartReport();
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            _extent.Flush();
        }

        [TestInitialize]
        public void StartTest()
        {
            StartTest(TestContext);
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var _browserType = config["BrowserType"] ?? "CHROME";
            BrowserType browserType=BrowserType.Chrome;

            switch (_browserType)
            {
                case "CHROME":
                    browserType=BrowserType.Chrome;
                    break;
                case "IE":
                    browserType=BrowserType.Edge;
                    break;
                case "FIREFOX":
                    browserType = BrowserType.Firefox;
                    break;
                default:
                    break;//throw new ArgumentOutOfRangeException(nameof(browserType), browserType, null);
            }

            switch (browserType)
            {
                case BrowserType.Chrome:
                    {
                        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                        _driver = new ChromeDriver();
                        break;
                    }
                case BrowserType.Firefox:
                    {
                        new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                        _driver = new FirefoxDriver();
                        break;
                        
                    }
                case BrowserType.Edge:
                    {
                        new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                        _driver = new EdgeDriver();
                        break;
                    }
                default:
                    throw new ArgumentOutOfRangeException(nameof(browserType), browserType, null);
            }
            _driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(20);
            _driver.Manage().Window.Maximize();

        }

        [TestCleanup]
        public void TestCleanup()
        {
            var testStatus=TestContext.CurrentTestOutcome;
            Status logStatus;
            
            DateTime time = DateTime.Now;
            String fileName = "Screenshot " + time.ToString("h_mm_ss") + ".png";
             switch (testStatus)
             {
                case UnitTestOutcome.Failed:
                    logStatus=Status.Fail;
                    //_test.Fail("Test Failed", captureScreenshot(_driver, fileName));
                    TestResult tr=new TestResult(){Outcome=TestContext.CurrentTestOutcome};
                    //tr.Outcome=TestContext.CurrentTestOutcome;
                    TestFailed(TestContext,tr);
                    break;
                case UnitTestOutcome.Passed:
                    logStatus=Status.Pass;
                    //TestResult tr2=new TestResult(){Outcome=TestContext.CurrentTestOutcome};
                    //tr.Outcome=TestContext.CurrentTestOutcome;
                    //TestFailed(TestContext,tr2);
                    break;
                default:
                   logStatus=Status.Pass;
                    break;
             }
             _test.Log(logStatus,"Test Ended with status"+logStatus);
             
             _extent.Flush();
             //_test
            _test=null;
             _driver.Quit();
        }

        public MediaEntityModelProvider captureScreenshot(IWebDriver driver, String screenshotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;

            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenshotName).Build();
        }

        public void TestFailed(TestContext testContext, TestResult result)
        {
            //var fileName = $"{testContext.TestName}_{result.Outcome}_{result.EndTime:yyyy-MM-dd_HH-mm-ss}.png";
            var fileName = $"{testContext.TestName}_{result.Outcome}_{DateTime.Now.ToString("yyyyMMddHHmmssffff")}.png";
            //var filePath = Path.Combine(testContext.TestResultsDirectory, fileName);

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string reportPath = projectDirectory + "\\TestResults\\";
            var filePath = Path.Combine(reportPath, fileName);

            var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
            screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);
        }

        public void StartReport()
        {
            InitiateReport();
        }       
       
    }    

}