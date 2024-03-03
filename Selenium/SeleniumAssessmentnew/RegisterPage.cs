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
    internal class RegisterPage
    {
        private readonly IWebDriver driver;

        public RegisterPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }
        public void CheckRegisterButtonwithvalidinput()
        {
            ExtentReporting.CreateTest("CheckRegisterButtonwithvalidinput");

            string url = "http://localhost:3000/register";
            driver.Navigate().GoToUrl(url);
            Console.WriteLine(driver.Title.ToString());
            string pagesource = driver.PageSource;
            if (pagesource != null)
            {
                driver.Manage().Window.Maximize();
                driver.FindElement(By.Id("UserEmail")).SendKeys("newsnht1@gmail.com");
                driver.FindElement(By.Id("UserName")).SendKeys("newnsAhcp1u99nt");
                driver.FindElement(By.Id("UserPassword")).SendKeys("Acount231");
                driver.FindElement(By.Id("RegisterButton")).Click();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(driver => driver.Url.Contains("/home"));
                string currenturl = driver.Url;
                if (currenturl == "http://localhost:3000/home")
                {
                    Console.WriteLine("Test case passed for login with correct data redirect to next page");
                }
                else
                {
                    Console.WriteLine("Test case failed for login with correct not redirect to nextpage ");
                    Console.WriteLine(currenturl);
                }
            }
        }
        public void Check_register_with_empty_data_return_fails()
        {
            ExtentReporting.CreateTest("Check_register_with_empty_data_return_fails");

            string url = "http://localhost:3000/register";
            driver.Navigate().GoToUrl(url);
            Console.WriteLine(driver.Title.ToString());
            string pagesource = driver.PageSource;
            if (pagesource != null)
            {
                driver.Manage().Window.Maximize();
                driver.FindElement(By.Id("UserEmail")).SendKeys("");
                driver.FindElement(By.Id("UserName")).SendKeys("");
                driver.FindElement(By.Id("UserPassword")).SendKeys("");
                driver.FindElement(By.Id("RegisterButton")).Click();
                string useremailerror = driver.FindElement(By.Id("useremailerror")).Text;
                string userpwderror = driver.FindElement(By.Id("userpwderror")).Text;
                string usernameerror = driver.FindElement(By.Id("usernameerror")).Text;

                string currenturl = driver.Url;
                if (currenturl == "http://localhost:3000/" || useremailerror == "Please enter a email" || userpwderror == "Please enter a password" || usernameerror== "Please enter a username")
                {
                    Console.WriteLine("Test case passed for regiter with no data  not redirect to next page");
                }
                else
                {
                    Console.WriteLine("Test case failed for register with correct data redirect to nextpage");
                    Console.WriteLine(currenturl);
                }
            }
        }
        public void Check_Register_Button_with_exists_data_input()
        {
            ExtentReporting.CreateTest("Check_Register_Button_with_exists_data_input");

            string url = "http://localhost:3000/register";
            driver.Navigate().GoToUrl(url);
            Console.WriteLine(driver.Title.ToString());
            string pagesource = driver.PageSource;
            if (pagesource != null)
            {
                driver.Manage().Window.Maximize();
                driver.FindElement(By.Id("UserEmail")).SendKeys("Karthick@gmail.com");
                driver.FindElement(By.Id("UserName")).SendKeys("Karthick Subburaj");
                driver.FindElement(By.Id("UserPassword")).SendKeys("Karthick123");
                driver.FindElement(By.Id("RegisterButton")).Click();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(driver => driver.Url.Contains("/register"));
                string currenturl = driver.Url;
                string servererror = driver.FindElement(By.Id("servererror")).Text;
                if (currenturl == "http://localhost:3000/register" || servererror== "Email is already exists")
                {
                    Console.WriteLine("Test case passed for register with exists data not redirect to next page and show error");
                }
                else
                {
                    Console.WriteLine("Test case failed for login with exists data redirect to nextpage and not show error");
                    Console.WriteLine(currenturl);
                }
            }
        }
        public void Check_work_for_Login_button()
        {
            ExtentReporting.CreateTest("Check_work_for_Login_button");

            string url = "http://localhost:3000/register";
            driver.Navigate().GoToUrl(url);
            Console.WriteLine(driver.Title.ToString());
            string pagesource = driver.PageSource;


            if (pagesource != null)
            {
                driver.Manage().Window.Maximize();
                driver.FindElement(By.Id("LoginButton")).Click();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(driver => driver.Url.Contains("/"));
                string currenturl = driver.Url;
                if (currenturl == "http://localhost:3000/")
                {
                    Console.WriteLine("Test case passed for login button in login  page  redirect to login page");

                }
                else
                {
                    Console.WriteLine("Test case failed for login button in login  page not  redirect to login page");

                }

            }
        }

        }
}
