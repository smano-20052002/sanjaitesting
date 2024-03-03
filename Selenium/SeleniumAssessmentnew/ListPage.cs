using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V119.WebAuthn;
using OpenQA.Selenium.Support.UI;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Reports;

namespace SeleniumAssessment
{
    internal class ListPage
    {
        private IWebDriver driver;
        public ListPage(IWebDriver driver) {
            this.driver = driver;
        }
        public void Check_work_for_Add_button()
        {
            ExtentReporting.CreateTest(" Check_work_for_Add_button");

            string url = "http://localhost:3000/list";
            driver.Navigate().GoToUrl(url);
            Console.WriteLine(driver.Title.ToString());
            string pagesource = driver.PageSource;


            if (pagesource != null)
            {
                driver.Manage().Window.Maximize();
                driver.FindElement(By.Id("AddButton")).Click();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(driver => driver.Url.Contains("/create"));
                string currenturl = driver.Url;
                if (currenturl == "http://localhost:3000/create")
                {
                    Console.WriteLine("Test case passed for add button in list  page  redirect to create page");

                }
                else
                {
                    Console.WriteLine("Test case failed for add button in list  page not  redirect to create page");

                }

            }
        }
        public void Check_work_for_Update_button()
        {
            ExtentReporting.CreateTest("Check_work_for_Update_butto");

            string url = "http://localhost:3000/list";
            driver.Navigate().GoToUrl(url);
            Console.WriteLine(driver.Title.ToString());
            string pagesource = driver.PageSource;


            if (pagesource != null)
            {
                driver.Manage().Window.Maximize();
                driver.FindElements(By.Id("UpdateButton")).First().Click();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(driver => driver.Url.Contains("/create/25"));
                string currenturl = driver.Url;
                if (currenturl == "http://localhost:3000/create/25")
                {
                    Console.WriteLine("Test case passed for update button in list  page  redirect to update page");

                }
                else
                {
                    Console.WriteLine("Test case failed for update button in list  page not  redirect to update page");

                }

            }
        }
        public void Check_work_for_Delete_button()
        {
            ExtentReporting.CreateTest("Check_work_for_Delete_button");

            string url = "http://localhost:3000/list";
            driver.Navigate().GoToUrl(url);
            Console.WriteLine(driver.Title.ToString());
            string pagesource = driver.PageSource;


            if (pagesource != null)
            {
                driver.Manage().Window.Maximize();
                driver.FindElements(By.Id("DeleteButton")).First().Click();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(driver => driver.FindElement(By.Id("dialogbox")).Displayed);
                IWebElement modal = driver.FindElement(By.Id("dialogbox"));
                if (modal.Displayed)
                {
                    Console.WriteLine("Test passed for delete button display the delete dialog box");
                   
                }
                else
                {
                    Console.WriteLine("Test failed for delete button not display the delete dialog box");
                }


            }
        }
    }
}
