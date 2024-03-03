using System;

using DeleteWebapi.Controllers;
using DeleteWebapi.Data;

using Microsoft.EntityFrameworkCore;
using DeleteWebapi.Controllers;
using System;
using Microsoft.AspNetCore.Mvc;

namespace DeleteWebapiTest
{
    public class Tests

    {
        dynamic optionsbuilder;
        AppDbContext applicationdbContext;

        [SetUp]
        public void Setup()
        {
            optionsbuilder = new DbContextOptionsBuilder().UseMySql("server=localhost;user=root;password=admin123;database=RelevantzMovieCenter", new MySqlServerVersion(new Version()));

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
            optionsbuilder = new DbContextOptionsBuilder().UseMySql("server=localhost;user=root;password=wrongpassword;database=RelevantzMovieCenter", new MySqlServerVersion(new Version()));

            applicationdbContext = new AppDbContext(optionsbuilder.Options);

            bool expected = false;

            // act
            bool result = applicationdbContext.Database.CanConnect();

            // assert
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Delete_returns_BadRequest_InvalidId()
        {
            DeleteMovieController deleteMovieController = new DeleteMovieController(applicationdbContext);
            var result=deleteMovieController.DeleteMovie(-1).Result;
            Assert.IsInstanceOf<BadRequestResult>(result);

        }
        [Test]
        public void Delete_returns_NotFound_NotExistsId()
        {
            DeleteMovieController deleteMovieController = new DeleteMovieController(applicationdbContext);
            var result = deleteMovieController.DeleteMovie(1).Result;
            Assert.IsInstanceOf<NotFoundResult>(result);

        }
        [Test]
        public void Delete_returns_CorrectResult()
        {
            DeleteMovieController deleteMovieController = new DeleteMovieController(applicationdbContext);
            var result = deleteMovieController.DeleteMovie(27).Result;
            Assert.IsInstanceOf<OkResult>(result);

        }
    }
}