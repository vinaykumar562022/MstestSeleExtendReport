using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Collections.Generic;
using System;

namespace MyLibrary.Pages
{
    public class SelectorshubDashBoardPage : SelectorshubBasePage
    {
        public SelectorshubDashBoardPage(IWebDriver driver) : base(driver)
        {
            
        }

        [FindsBy(How = How.XPath, Using = "//a[@class='hfe-menu-item' and contains(text(),'Products')]")]
        private IWebElement producstDDL;

        [FindsBy(How = How.XPath, Using = "//a[@class='hfe-menu-item' and contains(text(),'Pro Plans')]")]
        private IWebElement proPlansDDL;

        [FindsBy(How = (How.XPath), Using = "//a[@class='hfe-menu-item' and contains(text(),'Pro Plans')]")]
        private IWebElement coursesLink;

        [FindsBy(How = How.XPath, Using = "//*[@id='tablepress-1_wrapper']//*[@type='search']")]
         private IWebElement search;

        ////*[@class='dropdown']//*[@class='dropdown-content']//a

        [FindsBy(How = How.XPath, Using = "//*[@class='dropdown']")]
        //"//*[@class='dropdown']//*[@class='dropdown-content']")]
         private IWebElement chkOutDDL;

         ////*[@type='date']
         [FindsBy(How = How.XPath, Using = "//*[@type='date']")]
        //"//*[@class='dropdown']//*[@class='dropdown-content']")]
         private IWebElement datePicker;

        public void NavigatetoURL()
        {
            Driver.Navigate().GoToUrl(BaseURL);
        }
        
        public void DatePicker()
        {
            //IJavaScriptExecutor js = (IJavaScriptExecutor) Driver;
            
            datePicker.SendKeys("12/12/2022");
            Thread.Sleep(5000);
            //js.ExecuteScript("arguments[0].value = arguments[1]",
        }
        public void ChkOutDDL(string selection)
        {
            _test.Info("ChkOutDDL started");
            Actions actions=new Actions(Driver);
            var wait=new WebDriverWait(Driver,TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@class='dropdown']")));

            IJavaScriptExecutor js = (IJavaScriptExecutor) Driver;
            //js.ExecuteScript("script to execute");            
            js.ExecuteScript("window.scrollBy(0,250)", "");

            actions.MoveToElement(chkOutDDL).Perform();

            IList<IWebElement> ddl=chkOutDDL.FindElements(By.XPath("//*[@class='dropdown-content']//a"));

            foreach (var item in ddl)
            {
                if(item.Text==selection)
                {
                    item.Click();
                }
            }
            _test.Info("ChkOutDDL ended");
        }

        public void SerachAutoCompleteTxtBox(string searchText)
        {
            _test.Info("SerachAutoCompleteTxtBox started");

            
            var wait=new WebDriverWait(Driver,TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id='tablepress-1_wrapper']//*[@type='search']")));
            search.SendKeys(searchText);
            
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id='tablepress-1']")));
            // xpath of html table
			var elemTable =	Driver.FindElement(By.XPath("//*[@id='tablepress-1']"));

			// Fetch all Row of the table
			List<IWebElement> lstTrElem = new List<IWebElement>(elemTable.FindElements(By.TagName("tr")));
			String strRowData = "";

            // Traverse each row
			foreach (var elemTr in lstTrElem)
			{
				// Fetch the columns from a particuler row
				List<IWebElement> lstTdElem = new List<IWebElement>(elemTr.FindElements(By.TagName("td")));
				if (lstTdElem.Count > 0)
				{
                    bool ser=false;
					// Traverse each column
					foreach (var elemTd in lstTdElem)
					{
                        if(elemTd.Text.ToLower().Contains(searchText))
                        {
                            ser=true;
                            break;
                        }
						// "\t\t" is used for Tab Space between two Text
						strRowData = strRowData + elemTd.Text + "\t\t";
					}

                    if(!ser)
                    {
                        Assert.Fail();
                    }
				}
				else
				{
					// To print the data into the console
					Console.WriteLine("This is Header Row");
					Console.WriteLine(lstTrElem[0].Text.Replace(" ", "\t\t"));
				}
				Console.WriteLine(strRowData);
				strRowData = String.Empty;
			}
            // wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id='tablepress-1']//tbody//tr")));
            // IList<IWebElement> list=Driver.FindElements(By.XPath("//*[@id='tablepress-1']//tbody//tr"));
            // IList<IWebElement> rowTD;

            // foreach (IWebElement row in list)
            // {
            //     rowTD = row.FindElements(By.TagName("td"));
            //     if(rowTD.Count > 0)
            //     {
            //         foreach (var item in rowTD)
            //         {
            //             var b=item.Text;
            //         }
            //         if((rowTD[rowTD.Count-1].Text.Contains("den")))
            //         {
                        
            //         }
            //         else
            //         {
            //             var a=rowTD[1].Text;
            //             Assert.Fail();
            //             break;
            //         }
            //         //test failed
            //     }
            // }

            _test.Info("SerachAutoCompleteTxtBox ended");

        }

        
        public  void waitForElementtoExixt(IWebDriver driver, By by, int timeoutInSeconds)
        {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
        }
    

        public  void SelectItemByText(IWebElement element,By by,int waitforElementinSec, string textToSelect) 
		{ 
            IWebElement element_=Driver.FindElement(by);
			waitForElementtoExixt(Driver,by,waitforElementinSec); 
			SelectElement dropdown = new SelectElement(element_); 
			dropdown.SelectByText(textToSelect); 
		}

        public  void SelectItemByText(IWebElement element, string textToSelect) 
		{ 
            //IWebElement element_=Driver.FindElement(by);
			//waitForElementtoExixt(Driver,by,waitforElementinSec); 
			SelectElement dropdown = new SelectElement(element); 
			dropdown.SelectByText(textToSelect); 
		}
    

        public void DashboardDDLSelectProducts()
        {
            _test.Info("DashboardDDL started");
            //LogInfo($"Logging in with username: {username} and password: {password}");
            //_usernameInput.SendKeys(username);
            //_test.Info("username:"+username);
            //var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//input[@type='email' and @placeholder='Email Address' and @data-qa='login-email']")));
             waitForElementtoExixt(Driver,By.XPath("//a[@class='hfe-menu-item' and contains(text(),'Products')]"),30);
             producstDDL.Click();
            //SelectItemByText(producstDDL,By.XPath("//a[@class='hfe-menu-item' and contains(text(),'Products')]"),20,"");
            waitForElementtoExixt(Driver,By.XPath("//a[@class='hfe-menu-item' and contains(text(),'Products')]//following::a"),30);
            var eleList= Driver.FindElements(By.XPath("//a[@class='hfe-menu-item' and contains(text(),'Products')]//following::a"));
            
            IList<IWebElement> all = eleList;

            String[] allText = new String[all.Count];
            int i = 0;
            foreach (IWebElement element in all)
            {
                string _text="SelectorsHub";
                if(element.Text==_text)
                {
                    element.Click();
                    break;
                }
                allText[i++] = element.Text;
                _test.Info("The products are "+i+":"+ element.Text);

            }
            
           Thread.Sleep(5000);
            //SelectItemByText(ele,"SelectorsHub");
            _test.Info("DashboardDDL Ended");
           // producstDDL
            //_passwordInput.SendKeys(password);
            // _test.Info("password:"+password);
            // //var wait2 = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            // wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//input[@type='password']")));
            // _test.Info("after pasword:");
            // wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//button[@type='submit' and text() = 'Login']")));
            // _test.Info("before Click");
            // _loginButton.Click();
            // Thread.Sleep(5000);
            // wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//div[contains(@class, 'shop-menu')]//*[contains(@class,'fa-user')]//following-sibling::b")));

            // Assert.IsTrue(Driver.FindElement(By.XPath("//div[contains(@class, 'shop-menu')]//*[contains(@class,'fa-user')]//following-sibling::b")).Text=="vinay");      
            // ////div[contains(@class, 'shop-menu')]//*[contains(@class,'fa-user')]//following-sibling::b
            // _test.Info("after Click");
            // _test.Info("Login Ended");
            
        }
    }


}
