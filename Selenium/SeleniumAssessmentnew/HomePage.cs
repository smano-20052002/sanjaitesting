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
    internal class HomePage
    {
        private readonly IWebDriver driver;

        public HomePage(IWebDriver webDriver)
        {
            driver = webDriver;
        }
        public void Check_add_movie_button_redirect_to_add_page()
        {
            ExtentReporting.CreateTest("  Check_add_movie_button_redirect_to_add_page");

            string url = "http://localhost:3000/home";
            driver.Navigate().GoToUrl(url);
            Console.WriteLine(driver.Title.ToString());
            string pagesource = driver.PageSource;


            if (pagesource != null)
            {
                driver.Manage().Window.Maximize();
                driver.FindElement(By.Id("AddMovie")).Click();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(driver => driver.Url.Contains("/create"));
                string currenturl = driver.Url;
                if (currenturl == "http://localhost:3000/create")
                {
                    Console.WriteLine("Test case passed for add movie button in home  page  redirect to add movie page");
                    
                }
                else
                {
                    Console.WriteLine("Test case failed for add movie button in home  page not  redirect to add movie page");

                }

            }
        }
        public void Check_list_movie_button_redirect_to_list_page()
        {
            ExtentReporting.CreateTest("  Check_list_movie_button_redirect_to_list_page");

            string url = "http://localhost:3000/home";
            driver.Navigate().GoToUrl(url);
            Console.WriteLine(driver.Title.ToString());
            string pagesource = driver.PageSource;


            if (pagesource != null)
            {
                driver.Manage().Window.Maximize();
                driver.FindElement(By.Id("ListMovie")).Click();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(driver => driver.Url.Contains("/list"));
                string currenturl = driver.Url;
                if (currenturl == "http://localhost:3000/list")
                {
                    Console.WriteLine("Test case passed for list movie button in home  page  redirect to list movie page");

                }
                else
                {
                    Console.WriteLine("Test case failed for list movie button in home  page not  redirect to list movie page");

                }

            }
        }
        public void Check_value_in_total_movie_not_null()
        {
            ExtentReporting.CreateTest("  Check_value_in_total_movie_not_null");

            string url = "http://localhost:3000/home";
            driver.Navigate().GoToUrl(url);
            Console.WriteLine(driver.Title.ToString());
            string pagesource = driver.PageSource;


            if (pagesource != null)
            {
                driver.Manage().Window.Maximize();
                int total = Convert.ToInt32(driver.FindElement(By.Id("TotalMovie")).Text);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(driver => driver.Url.Contains("/home"));
                string currenturl = driver.Url;
                if (currenturl == "http://localhost:3000/home" && total>0)
                {
                    Console.WriteLine("Test case passed for total movie column show number of movie in home  page  ");

                }
                else
                {
                    Console.WriteLine("Test case failed for total movie column not show number of movie in home  page  ");

                }

            }
        }
    }
}
