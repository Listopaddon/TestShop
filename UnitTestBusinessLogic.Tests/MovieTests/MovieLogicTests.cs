using BusinessLogic.LogicBusiness.Movie;
using DataAccess.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using UnitTestBusinessLogic.Tests.MovieTests.SubObjects;

namespace UnitTestBusinessLogic.Tests.MovieTests
{
    [TestClass]
    public class MovieLogicTests
    {
        MovieLogic movieLogic;

        [TestInitialize]
        public void Initialize()
        {
            List<MovieModel> movies = new List<MovieModel>
            {
                new MovieModel(0,"Bad Boys", "Cool film",new DateTime(20,00)),
                new MovieModel(1,"Bad Boys 2", "Cool film",new DateTime(22,00)),
                new MovieModel(2,"Green boy", "Bad film",new DateTime(10,00)),
                new MovieModel(3,"Jhon Week", "Cool film",new DateTime(22,00)),
                new MovieModel(4,"Jhon Week 2", "Cool film",new DateTime(14,00)),
                new MovieModel(5,"Jhon Week 3", "Cool film",new DateTime(15,00)),
                new MovieModel(6,"Bad Boys", "Cool film",new DateTime(20,00)),
                new MovieModel(7,"Bad Boys", "Cool film",new DateTime(20,00))
            };

            movieLogic = new MovieLogic(new SubMovieRepository(movies));
        }

        [TestMethod]
        public void AddMovieTest()
        {
            Assert.AreEqual(8, movieLogic.AddMovie("5 Element", "Mega film", new System.DateTime(20, 00)));
        }

        [TestMethod]
        public void DeleteMovieTest()
        {
            long id = 2;
            MovieModel result = null;
            List<MovieModel> movies = movieLogic.GetMovies();
            movieLogic.DeleteMovie(2);

            for (int i = 0; i < movies.Count; i++)
            {
                if (movies[i].Id == id)
                {
                    result = movies[i];
                    break;
                }
            }

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetMoviesTest()
        {
            List<MovieModel> expected = new List<MovieModel>
            {
                new MovieModel(0,"Bad Boys", "Cool film",new System.DateTime(20,00)),
                new MovieModel(1,"Bad Boys 2", "Cool film",new System.DateTime(22,00)),
                new MovieModel(2,"Green boy", "Bad film",new System.DateTime(10,00)),
                new MovieModel(3,"Jhon Week", "Cool film",new System.DateTime(22,00)),
                new MovieModel(4,"Jhon Week 2", "Cool film",new System.DateTime(14,00)),
                new MovieModel(5,"Jhon Week 3", "Cool film",new System.DateTime(15,00)),
                new MovieModel(6,"Bad Boys", "Cool film",new System.DateTime(20,00)),
                new MovieModel(7,"Bad Boys", "Cool film",new System.DateTime(20,00))
            };

            List<MovieModel> result = movieLogic.GetMovies();

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].Name, result[i].Name);
                Assert.AreEqual(expected[i].Discription, result[i].Discription);
                Assert.AreEqual(expected[i].Time, result[i].Time);
            }
        }

        [TestMethod]
        public void UpdateMovieTest()
        {
            MovieModel expected = new MovieModel(3, "5 Element", "Mega film", new System.DateTime(15, 00));
            movieLogic.UpdateMovie(expected);
            List<MovieModel> movies = movieLogic.GetMovies();

            Assert.AreEqual(expected.Id, movies[3].Id);
            Assert.AreEqual(expected.Name, movies[3].Name);
            Assert.AreEqual(expected.Discription, movies[3].Discription);
            Assert.AreEqual(expected.Time, movies[3].Time);
        }

        [TestMethod]
        public void GetMovieTest()
        {
            MovieModel expected = new MovieModel(1, "Bad Boys 2", "Cool film", new System.DateTime(22, 00));
            MovieModel result = movieLogic.GetMovie(1);

            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.Name, result.Name);
            Assert.AreEqual(expected.Time, result.Time);
            Assert.AreEqual(expected.Discription, result.Discription);
        }

        [TestMethod]
        public void GetAllMoviesForThisCinemaTest()
        {
            List<MovieModel> expected = new List<MovieModel>
            {
                new MovieModel(0, "Create Movie", "Discription", new DateTime()),
                new MovieModel(0, "Create Movie", "Discription", new DateTime())
            };

            List<MovieModel> result = movieLogic.GetMoviesWithCinema(1);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].Name, result[i].Name);
                Assert.AreEqual(expected[i].Discription, result[i].Discription);
                Assert.AreEqual(expected[i].Time, result[i].Time);
            }
        }
    }
}
