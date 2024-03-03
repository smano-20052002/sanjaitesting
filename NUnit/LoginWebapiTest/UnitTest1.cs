
using LoginWebapi.Controller;
using LoginWebapi.Data;

using Microsoft.EntityFrameworkCore;
using LoginWebapi.Model;
using System;
using Microsoft.AspNetCore.Mvc;
using Google.Protobuf.WellKnownTypes;
using Org.BouncyCastle.Crypto.Macs;
class RegisterResult
{
    public bool Exists { get; set; }
}
namespace LoginWebapiTest
{
    public class Tests
    {
        dynamic optionsbuilder;
        AppDbContext applicationdbContext;

        [SetUp]
        public void Setup()
        {
            optionsbuilder = new DbContextOptionsBuilder().UseMySql("server=localhost;user=root;password=admin123;database=RelevantzMovieLogin", new MySqlServerVersion(new Version()));

            applicationdbContext = new AppDbContext(optionsbuilder.Options);
        }

        [Test]
        public void ApplicationDbContext_should_connect_to_mysql()
        {

            bool expected = true;

            // act
            bool result = applicationdbContext.Database.CanConnect();

            // assert
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void ApplicationDbContext_with_wrong_password_should_not_connect_to_mysql()
        {
            optionsbuilder = new DbContextOptionsBuilder().UseMySql("server=localhost;user=root;password=wrongpassword;database=RelevantzMovieLogin", new MySqlServerVersion(new Version()));

            applicationdbContext = new AppDbContext(optionsbuilder.Options);

            bool expected = false;

            // act
            bool result = applicationdbContext.Database.CanConnect();

            // assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Check_Register_with_new_user_should_return_Ok_status()
        {
            UserLogin user1 = new UserLogin()
            {
                UserEmail="stdao3@gmail.com",
                UserName="Tessaaero3",
                UserPassword="test1234"
            };

            UserController userController = new UserController(applicationdbContext);
            var result = (OkObjectResult)userController.Post(user1).Result;
            var value=result.Value;

            Assert.AreEqual("{\"Exists\":false}", value);
        }
        [Test]
        public void Check_Register_with_old_user_should_return_Fail_status()
        {
            UserLogin user1 = new UserLogin()
            {
                UserEmail = "Karthick@gmail.com",
                UserName = "Karthick Subburaj",
                UserPassword = "Karthick123"
            };

            UserController userController = new UserController(applicationdbContext);
            var result = (OkObjectResult)userController.Post(user1).Result;
            var value = result.Value;

            Assert.AreEqual("{\"Exists\":true}", value);
        }
        
        [Test]
        public void Check_Login_with_wrong_password_should_return_Fail_status()
        {
            LoginDetails user1 = new LoginDetails()
            {
                UserEmail = "Karthick@gmail.com",
                UserPassword = "Karthick1234n"
            };

            UserController userController = new UserController(applicationdbContext);
            var result = (OkObjectResult)userController.Login(user1).Result;
            var value = result.Value;

            Assert.AreEqual("{\"account\":true,\"emailstatus\":true,\"passwordstatus\":false}", value);

        }
        [Test]
        public void Check_Login_with_correct_user_should_return_Ok_status()
        {
            LoginDetails user1 = new LoginDetails()
            {
                UserEmail = "Karthick@gmail.com",
                UserPassword = "Karthick123"
            };

            UserController userController = new UserController(applicationdbContext);
            var result = (OkObjectResult)userController.Login(user1).Result;
            var value = result.Value;

            Assert.AreEqual("{\"account\":true,\"emailstatus\":true,\"passwordstatus\":true,\"usernamer\":\"Karthick Subburaj\"}", value);
            
        }
    }
}