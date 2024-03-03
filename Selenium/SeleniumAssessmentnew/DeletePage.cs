using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Reports;

namespace SeleniumAssessment
{
    internal class DeletePage
    {
        private IWebDriver driver;
        public DeletePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void Check_delete_button_display_Dialog_box()
        {
            ExtentReporting.CreateTest("  Check_delete_button_display_Dialog_box");

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
        public void Check_dialog_box_Delete_button_delete_element()
        {
            ExtentReporting.CreateTest(" Check_dialog_box_Delete_button_delete_element(");

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
                    driver.FindElement(By.Id("dialogdeletebutton")).Click();
                    wait.Until(driver => driver.Url.Contains("/list"));
                    if(modal==null)
                    {

                        Console.WriteLine("Test failed for delete button in dialog box not return to list page");

                    }
                    else
                    {
                        Console.WriteLine("Test passed for delete button in dialog box return to list page");


                    }
                }
            }
        }
        public void Check_dialog_box_Cancel_button_return_list_page()
        {
            ExtentReporting.CreateTest(" Check_dialog_box_Cancel_button_return_list_page");

            string url = "http://localhost:3000/list";
            driver.Navigate().GoToUrl(url);
            Console.WriteLine(driver.Title.ToString());
            string pagesource = driver.PageSource;


            if (pagesource != null)
            {
                driver.Manage().Window.Maximize();
                driver.FindElements(By.Id("DeleteButton")).First().Click();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(driver => driver.Url.Contains("/list"));

                IWebElement modal = driver.FindElement(By.Id("dialogbox"));

                

                if (modal.Displayed)
                {
                    driver.FindElement(By.Id("dialogcancelbutton")).Click();
                    wait.Until(driver => driver.Url.Contains("/list"));
                    if (modal==null)
                    {
                        Console.WriteLine("Test failed for delete button in dialog box not return to list page");

                    }
                    else
                    {
                        Console.WriteLine("Test passed for delete button in dialog box return to list page");


                    }
                }
            }
        }
    }
}
