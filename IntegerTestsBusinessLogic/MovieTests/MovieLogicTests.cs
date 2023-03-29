using BusinessLogic.LogicBusiness.Movie;
using DataAccess.Models;
using DataAccess.Repositories;
using DataAccess.Repositories.Movie;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace IntegerTestsBusinessLogic.Movie
{
    [TestClass]
    public class MovieLogicTests
    {
        MovieLogic movieLogic;
        string connectionString = ConnectionString.connectionStringFake;

        [TestInitialize]
        public void Initialize()
        {
            movieLogic = new MovieLogic(new MovieRepository(connectionString));
        }

        [TestMethod]
        public void AddMovieTest()
        {
            long result = movieLogic.AddMovie("Bad Boys 2", "Cool Film",
                                             new DateTime(1900, 1, 1, 12, 12, 0));
            long expected = movieLogic.GetMovie(result).Id;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DeleteMovieTest()
        {
            long id = movieLogic.AddMovie("Interstellar", "Very cool film",
                                              new DateTime(2021, 5, 20, 22, 00, 00));
            movieLogic.DeleteMovie(id);
            Assert.IsNull(movieLogic.GetMovie(id));
        }

        [TestMethod]
        public void UpdateMovieTest()
        {
            MovieModel expected = new MovieModel(2, "Test update", "true", new DateTime(2022, 5, 20, 12, 00, 00));
            movieLogic.UpdateMovie(expected);
            MovieModel result = movieLogic.GetMovie(2);

            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.Name, result.Name);
            Assert.AreEqual(expected.Time, result.Time);
            Assert.AreEqual(expected.Discription, result.Discription);
        }

        [TestMethod]
        public void GetMoviesTest()
        {
            List<MovieModel> expected = movieLogic.GetMovies();
            expected.Add(movieLogic.GetMovie(movieLogic.AddMovie("FilmTest", "good",
                                             new DateTime(2020, 4, 24, 18, 20, 00))));

            List<MovieModel> result = movieLogic.GetMovies();

            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].Name, result[i].Name);
                Assert.AreEqual(expected[i].Time, result[i].Time);
                Assert.AreEqual(expected[i].Discription, result[i].Discription);
            }
        }

        [TestMethod]
        public void GetMovieTest()
        {
            MovieModel expected = new MovieModel(3, "Bad Boys 3", "Cool Film 3",
                                             new DateTime(2022, 5, 20, 19, 0, 0));
            MovieModel result = movieLogic.GetMovie(3);

            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.Name, result.Name);
            Assert.AreEqual(expected.Time, result.Time);
            Assert.AreEqual(expected.Discription, result.Discription);
        }

        [TestMethod]
        public void GetAllMoviesForThisCinemaTest()
        {
            List<MovieModel> expected = new List<MovieModel>()
            {
                new MovieModel(2, "Test update", "true", new DateTime(2022, 5, 20, 12, 00, 00)),
                new MovieModel(3, "Bad Boys 3", "Cool Film 3", new DateTime(2022, 5, 20, 19, 0, 0)),
                new MovieModel(4, "Bad Boys 4", "Cool Film 4", new DateTime(2022, 5, 20, 17, 0, 0))
            };


            List<MovieModel> result = movieLogic.GetMoviesWithCinema(3);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].Name, result[i].Name);
                Assert.AreEqual(expected[i].Time, result[i].Time);
                Assert.AreEqual(expected[i].Discription, result[i].Discription);
            }
        }        
    }
}
