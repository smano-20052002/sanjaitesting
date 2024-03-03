
using FetchWebapi.Controllers;
using FetchWebapi.Data;

using Microsoft.EntityFrameworkCore;
using FetchWebapi.Model;
using System;
using Microsoft.AspNetCore.Mvc;
namespace FetchWebapiTest
{
    public class Tests

    {
        dynamic optionsbuilder;
        Appdbcontext applicationdbContext;

          [SetUp]
        public void Setup()
        {
            optionsbuilder = new DbContextOptionsBuilder().UseMySql("server=localhost;user=root;password=admin123;database=RelevantzMovieCenter", new MySqlServerVersion(new Version()));

            applicationdbContext = new Appdbcontext(optionsbuilder.Options);
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

            applicationdbContext = new Appdbcontext(optionsbuilder.Options);

            bool expected = false;

            // act
            bool result = applicationdbContext.Database.CanConnect();

            // assert
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Get_by_id_returns_NotFound_for_invalid_Id()
        {
            FetchMovieController fetchMovieController = new FetchMovieController(applicationdbContext);
            var result = fetchMovieController.GetIndividual(1).Result;
            
            Assert.IsInstanceOf<NotFoundResult>(result);
        }
        [Test]
        public void GetById_returns_correctResult(){
            FetchMovieController fetchMovieController = new FetchMovieController(applicationdbContext);
            var result = (OkObjectResult)fetchMovieController.GetIndividual(25).Result;
            var value = (MovieDetails)result.Value;
            Assert.AreEqual(25, value.MovieId);

        }
        [Test]
        public void GetById_returns_correctResultType()
        {
            FetchMovieController fetchMovieController = new FetchMovieController(applicationdbContext);
            var result = (OkObjectResult)fetchMovieController.GetIndividual(25).Result;
            var value = (MovieDetails)result.Value;
            Assert.IsInstanceOf<MovieDetails>(value);

        }
        [Test]
        public void Get_returnsAllResults()
        {
            FetchMovieController fetchMovieController = new FetchMovieController(applicationdbContext);
            var result = fetchMovieController.Get().Result as List<MovieDetails>;
            List<MovieDetails> value = (List<MovieDetails>)result ;
            var countresult = (OkObjectResult)fetchMovieController.TotalCount().Result;
            int countvalue = (int)countresult.Value;
            //assert
            Assert.AreEqual(countvalue, value.Count);

        }
        [Test]
        public void GetAll_returnsTypeCheck()
        {
            FetchMovieController fetchMovieController = new FetchMovieController(applicationdbContext);
            var result = fetchMovieController.Get().Result as List<MovieDetails>;
            List<MovieDetails> value = (List<MovieDetails>)result;
            Assert.IsInstanceOf<MovieDetails>(value.First());

        }
    }
}