using System;
using System.IO;
using System.Reflection;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyLibrary.Logging
{
 

    public class Report
    {
        public static ExtentReports _extent =new ExtentReports();

        
        public static ExtentTest _test;

        private static readonly IConfiguration Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        
        
        

        public void InitiateReport()
        {
            //var reportPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //var htmlReporter = new ExtentHtmlReporter(Path.Combine(reportPath, "TestResults\\TestReport.html"));

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string reportPath = projectDirectory + "\\TestResults\\index.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            htmlReporter.Config.ReportName="test.html";
            
            //var htmlReporter = new ExtentHtmlReporter(reportPath);
            
            
            
            
           

            //var htmlReporter = new ExtentHtmlReporter("TestResults\\extent-report.html");
            
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
            //_test = _extent.CreateTest("MyLibrary.Tests");
        }

        public void StartTest(TestContext testContext)
        {
            var testCategory=testContext.TestName.Split('_')[0];
            //testContext.TestName
            var a=_test;
            //if(testContext.DataRow==null)
            _test= _extent.CreateTest(testContext.TestName,testContext.TestName).AssignCategory(testCategory);
            _test.Log(Status.Info,"Test Started New-");
        }

        
    }

    public enum BrowserType
    {
        Chrome,
        Firefox,
        Edge
    }
}