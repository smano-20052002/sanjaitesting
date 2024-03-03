using UpdateWebapi.Model;
using UpdateWebapi.Controllers;
using UpdateWebapi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;

namespace UpdateWebapiTest
{
    public class Tests
    {
        dynamic optionsbuilder;
        AppDbContext appdbContext;

        [SetUp]
        public void Setup()
        {
            optionsbuilder = new DbContextOptionsBuilder().UseMySQL("server=localhost;user=root;password=admin123;database=RelevantzMovieCenter");
            appdbContext = new AppDbContext(optionsbuilder.Options);

        }


        [Test]
        public void ApplicationDbContext_should_connect_to_mysql()
        {
            var expected = true;

            // act
            var result = appdbContext.Database.CanConnect();
            Assert.That(result, Is.EqualTo(expected));
            // assert

        }
        [Test]
        public void ApplicationDbContext_with_wrong_password_should_not_connect_to_mysql()
        {
            optionsbuilder = new DbContextOptionsBuilder().UseMySQL("server=localhost;user=root;password=wrongpassword;database=RelevantzMovieCenter");

            appdbContext = new AppDbContext(optionsbuilder.Options);

            bool expected = false;

            // act
            bool result = appdbContext.Database.CanConnect();

            // assert
            Assert.That(result, Is.EqualTo(expected));

        }
        [Test]
        public void Update_with_correct_type_returns_correctResult()
        {
           
            UpdateMovieController updateMovieController = new UpdateMovieController(appdbContext);

            MovieDetails movieDetails = new MovieDetails()
            {
                MovieId =13,
                MovieName = "Kiren1",
                MovieType = "Romance",
                MovieLanguage = "Tamil",
                MovieDurations = "2.40 hour"
            };
            //var oldmovie = applicationdbContext.MovieDetails.Count();

            var result = updateMovieController.UpdateMovie(movieDetails).Result;

            //var newmovie = applicationdbContext.MovieDetails.Count();
            Assert.IsInstanceOf<OkResult>(result);

        }
        [Test]
        public void Update_with_0_id_returns_wrongResult()
        {
            UpdateMovieController updateMovieController = new UpdateMovieController(appdbContext);

            MovieDetails movieDetails = new MovieDetails()
            {
                MovieId = 0,
                MovieName = "Kiren1",
                MovieType = "Action",
                MovieLanguage = "Tamil",
                MovieDurations = "2.40 hour"
            };
            //var oldmovie = applicationdbContext.MovieDetails.Count();

            var result = updateMovieController.UpdateMovie(movieDetails).Result;

            //var newmovie = applicationdbContext.MovieDetails.Count();
            Assert.IsInstanceOf<BadRequestResult>(result);
        }
       
    }
}