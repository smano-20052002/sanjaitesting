using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using Utils.Reports;
namespace SeleniumAssessment
{
    internal class LoginPage
    {
        private readonly IWebDriver driver;

        public LoginPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }
        public void CheckLoginButtonwithvalidinput()
        {
            ExtentReporting.CreateTest("CheckLoginButtonwithvalidinput");

            string url = "http://localhost:3000";
            driver.Navigate().GoToUrl(url);
            Console.WriteLine(driver.Title.ToString());
            string pagesource = driver.PageSource;
            if (pagesource != null)
            {
                driver.Manage().Window.Maximize();
                driver.FindElement(By.Id("UserEmail")).SendKeys("Karthick@gmail.com");
                driver.FindElement(By.Id("UserPassword")).SendKeys("Karthick123");
                driver.FindElement(By.Id("LoginButton")).Click();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(driver => driver.Url.Contains("/home"));
                string currenturl= driver.Url;
                if (currenturl == "http://localhost:3000/home")
                {
                    Console.WriteLine("Test case passed for login with correct data redirect to next page");
                }
                else
                {
                    Console.WriteLine("Test case failed for login with correct not redirect to nextpage");
                    Console.WriteLine(currenturl);
                }
            }

        }
        public void Check_login_with_empty_data_return_fails()
        {
            ExtentReporting.CreateTest("Check_login_with_empty_data_return_fails");

            string url = "http://localhost:3000";
            driver.Navigate().GoToUrl(url);
            Console.WriteLine(driver.Title.ToString());
            string pagesource = driver.PageSource;
            if (pagesource != null)
            {
                driver.Manage().Window.Maximize();
                driver.FindElement(By.Id("UserEmail")).SendKeys("");
                driver.FindElement(By.Id("UserPassword")).SendKeys("");
                driver.FindElement(By.Id("LoginButton")).Click();
                string useremailerror=driver.FindElement(By.Id("useremailerror")).Text;
                string userpwderror = driver.FindElement(By.Id("userpwderror")).Text;
               
                string currenturl = driver.Url;
                if (currenturl == "http://localhost:3000/" && useremailerror== "Please enter a email" && userpwderror== "Please enter a password")
                {
                    Console.WriteLine("Test case passed for login with no data  not redirect to next page");
                }
                else
                {
                    Console.WriteLine("Test case failed for login with correct data redirect to nextpage");
                    Console.WriteLine(currenturl);
                }
            }

        }
        //public void Check_Login_Button_with_invalid_account_input()
        //{
        //    string url = "http://localhost:3000";
        //    driver.Navigate().GoToUrl(url);
        //    Console.WriteLine(driver.Title.ToString());
        //    string pagesource = driver.PageSource;


        //    if (pagesource != null)
        //    {
        //        driver.Manage().Window.Maximize();
        //        driver.FindElement(By.Id("UserEmail")).SendKeys("noaccount@gmail.com");
        //        driver.FindElement(By.Id("UserPassword")).SendKeys("12345678");
        //        driver.FindElement(By.Id("LoginButton")).Click();
        //        string errormsg=driver.FindElement(By.Id("servererror")).Text;

        //        string currenturl = driver.Url;
        //        if (currenturl == "http://localhost:3000" &&  errormsg== "No account in this email")
        //        {
        //            Console.WriteLine("Test case passed for login with wrong data not redirect and show error");
        //        }
        //        else
        //        {
        //            Console.WriteLine("Test case failed for login with wrong data not show error");

        //        }

        //    }

        //}
        public void Check_Login_Button_with_invalid_password_input()
        {
            ExtentReporting.CreateTest("Check_Login_Button_with_invalid_password_input");

            string url = "http://localhost:3000";
            driver.Navigate().GoToUrl(url);
            Console.WriteLine(driver.Title.ToString());
            string pagesource = driver.PageSource;


            if (pagesource != null)
            {
                driver.Manage().Window.Maximize();
                driver.FindElement(By.Id("UserEmail")).SendKeys("Karthick@gmail.com");
                driver.FindElement(By.Id("UserPassword")).SendKeys("12345678");
                driver.FindElement(By.Id("LoginButton")).Click();
                string errormsg = driver.FindElement(By.Id("servererror")).Text;
                
                string currenturl = driver.Url;
                if (currenturl == "http://localhost:3000" && errormsg == "Wrong Password")
                {
                    Console.WriteLine("Test case passed for login with wrong password not redirect and show error");
                }
                else
                {
                    Console.WriteLine("Test case failed for login with wrong password not show error");

                }

            }

        }
        public void Check_work_for_Register_button()
        {
            ExtentReporting.CreateTest("Check_work_for_Register_button");

            string url = "http://localhost:3000";
            driver.Navigate().GoToUrl(url);
            Console.WriteLine(driver.Title.ToString());
            string pagesource = driver.PageSource;


            if (pagesource != null)
            {
                driver.Manage().Window.Maximize();
                driver.FindElement(By.Id("RegisterButton")).Click();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(driver => driver.Url.Contains("/register"));
                string currenturl = driver.Url;
                if (currenturl == "http://localhost:3000/register")
                {
                    Console.WriteLine("Test case passed for register button in login  page  redirect to register page");

                }
                else
                {
                    Console.WriteLine("Test case failed for register button in login  page not  redirect to register page");

                }

            }
        }
    }
}
