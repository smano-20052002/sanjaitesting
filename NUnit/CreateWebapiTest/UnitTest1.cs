using CreateWebapi.Model;
using CreateWebapi.Controllers;
using CreateWebapi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CreateWebapiTest
{
    public class Tests
    {
        dynamic optionsbuilder;
        AppDbContext applicationdbContext;

        [SetUp]
        public void Setup()
        {
            optionsbuilder = new DbContextOptionsBuilder().UseMySql("server=localhost;user=root;password=admin123;database=RelevantzMovieCenter", new MySqlServerVersion(new Version())); ;
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
        public void Post_with_correct_type_returns_correctResult()
        {
            AddMovieController addMovieController = new AddMovieController(applicationdbContext);
            
            MovieDetails movieDetails = new MovieDetails()
            {
               MovieId =0,
               MovieName="Kiren1",
               MovieType="Romance",
               MovieLanguage="Tamil",
               MovieDurations="2.40 hour"
            };
            //var oldmovie = applicationdbContext.MovieDetails.Count();

            var result = addMovieController.Post(movieDetails).Result;

            //var newmovie = applicationdbContext.MovieDetails.Count();
            Assert.IsInstanceOf<OkResult>(result);
        }
        [Test]
        public void Post_with_same_id_returns_wrongResult()
        {
            AddMovieController addMovieController = new AddMovieController(applicationdbContext);

            MovieDetails movieDetails = new MovieDetails()
            {
                MovieId = 25,
                MovieName = "Kiren1",
                MovieType = "Action",
                MovieLanguage = "Tamil",
                MovieDurations = "2.40 hour"
            };
            //var oldmovie = applicationdbContext.MovieDetails.Count();

            var result = addMovieController.Post(movieDetails).Result;

            //var newmovie = applicationdbContext.MovieDetails.Count();
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }

    }
}