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
    internal class UpdatePage
    {
        private readonly IWebDriver driver;

        public UpdatePage(IWebDriver webDriver)
        {
            driver = webDriver;
        }
        public void CheckUpdateButtonwithvalidinput()
        {
            ExtentReporting.CreateTest("CheckUpdateButtonwithvalidinput");

            string url = "http://localhost:3000/create/13";
            driver.Navigate().GoToUrl(url);
            Console.WriteLine(driver.Title.ToString());
            string pagesource = driver.PageSource;
           
            if (pagesource != null)
            {
                driver.Manage().Window.Maximize();
                driver.FindElement(By.Id("movieName")).Clear();
                driver.FindElement(By.Id("movieType")).Clear();
                driver.FindElement(By.Id("movieLanguage")).Clear();
                driver.FindElement(By.Id("movieDurations")).Clear();
                driver.FindElement(By.Id("movieName")).SendKeys("Leo 2");
                driver.FindElement(By.Id("movieType")).SendKeys("Action");
                driver.FindElement(By.Id("movieLanguage")).SendKeys("Tamil");
                driver.FindElement(By.Id("movieDurations")).SendKeys("2.54 hour");
                driver.FindElement(By.Id("AddUpdateButton")).Click();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(driver => driver.Url.Contains("/"));
                string currenturl = driver.Url;
                if (currenturl == "http://localhost:3000/list")
                {
                    Console.WriteLine("Test case passed for update movie with correct data redirect to next page");


                }
                else
                {
                    Console.WriteLine("Test case failed for update movie with correct not redirect to nextpage ");
                    Console.WriteLine(currenturl);
                }
            }
        }
        public void Check_update_movie_with_empty_data_return_fails()
        {
            ExtentReporting.CreateTest("Check_update_movie_with_empty_data_return_fails");

            string url = "http://localhost:3000/create/13";
            driver.Navigate().GoToUrl(url);
            Console.WriteLine(driver.Title.ToString());
            string pagesource = driver.PageSource;
            if (pagesource != null)
            {
                driver.Manage().Window.Maximize();
                driver.FindElement(By.Id("movieName")).Clear();
                driver.FindElement(By.Id("movieType")).Clear();
                driver.FindElement(By.Id("movieLanguage")).Clear();
                driver.FindElement(By.Id("movieDurations")).Clear();
                driver.FindElement(By.Id("movieName")).SendKeys("");
                driver.FindElement(By.Id("movieType")).SendKeys("");
                driver.FindElement(By.Id("movieLanguage")).SendKeys("");
                driver.FindElement(By.Id("movieDurations")).SendKeys("");
                driver.FindElement(By.Id("AddUpdateButton")).Click();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
                wait.Until(driver => driver.Url.Contains("/create"));
                


               
                string currenturl = driver.Url;
                if (currenturl== "http://localhost:3000/create/24")
                {
                    Console.WriteLine("Test case passed for update movie with no data not redirect to next page and show error");


                }
                else
                {
                    Console.WriteLine("Test case failed for update movie with no data or not show error");
                    Console.WriteLine(currenturl);
                }
            }
        }

        public void Check_work_for_View_button()
        {
            ExtentReporting.CreateTest("Check_work_for_View_button");

            string url = "http://localhost:3000/create";
            driver.Navigate().GoToUrl(url);
            Console.WriteLine(driver.Title.ToString());
            string pagesource = driver.PageSource;


            if (pagesource != null)
            {
                driver.Manage().Window.Maximize();
                driver.FindElement(By.Id("ViewButton")).Click();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(driver => driver.Url.Contains("/list"));
                string currenturl = driver.Url;
                if (currenturl == "http://localhost:3000/list")
                {
                    Console.WriteLine("Test case passed for view button in create  page  redirect to list page");

                }
                else
                {
                    Console.WriteLine("Test case failed for view button in create  page not  redirect to list page");

                }

            }
        }


    }
}
