using BusinessLogic.LogicBusiness.Area;
using BusinessLogic.LogicBusiness.Cinema;
using BusinessLogic.LogicBusiness.Hall;
using BusinessLogic.LogicBusiness.Movie;
using BusinessLogic.LogicBusiness.Place;
using BusinessLogic.LogicBusiness.PlaceSession;
using BusinessLogic.LogicBusiness.Row;
using BusinessLogic.LogicBusiness.Session;
using DataAccess.Models;
using DataAccess.Repositories;
using DataAccess.Repositories.Area;
using DataAccess.Repositories.Cinema;
using DataAccess.Repositories.Hall;
using DataAccess.Repositories.Movie;
using DataAccess.Repositories.Place;
using DataAccess.Repositories.PlaceSession;
using DataAccess.Repositories.Row;
using DataAccess.Repositories.Session;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace IntegerTestsBusinessLogic.Movie
{
    [TestClass]
    public class MovieLogicTests
    {
        MovieLogic movieLogic;
        PlaceSessionLogic placeSessionLogic;
        SessionLogic sessionLogic;
        CinemaLogic cinemaLogic;
        HallLogic hallLogic;
        AreaLogic areaLogic;
        RowLogic rowLogic;
        PlaceLogic placeLogic;
        string connectionString = ConnectionString.connectionStringFake;
        long idCinema;
        long idHall;
        long idMovie;
        long idSession;

        [TestInitialize]
        public void Initialize()
        {
            placeSessionLogic = new PlaceSessionLogic(new PlaceSessionRepository(connectionString));
            sessionLogic = new SessionLogic(new SessionRepository(connectionString), placeSessionLogic);
            movieLogic = new MovieLogic(new MovieRepository(connectionString), sessionLogic);
            placeLogic = new PlaceLogic(new PlaceRepository(connectionString), placeSessionLogic);
            rowLogic = new RowLogic(new RowRepository(connectionString), placeLogic);
            areaLogic = new AreaLogic(new AreaRepository(connectionString), rowLogic, placeLogic);
            hallLogic = new HallLogic(new HallRepository(connectionString), areaLogic, sessionLogic);
            cinemaLogic = new CinemaLogic(new CinemaRepository(connectionString), hallLogic);

            idCinema = cinemaLogic.AddCinema("TestCinemaByMovie", "img");
            idHall = hallLogic.AddHall(idCinema);
            idMovie = movieLogic.AddMovie("TestMovieForGetMovie", "Test", new DateTime(2022, 5, 20, 19, 0, 0));
            idSession = sessionLogic.AddSession(idMovie, idHall, 100);
        }

        [TestMethod]
        public void AddMovieTest()
        {
            //Act
            long result = movieLogic.AddMovie("TestMovieForAdd", "Test", DateTime.Now);
            long expected = movieLogic.GetMovie(result).Id;

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DeleteMovieTest()
        {
            //Arrange
            long idArea = movieLogic.AddMovie("TestMovieForDelete", "Test", DateTime.Now);

            //Act
            movieLogic.DeleteMovie(idArea);

            //Assert
            Assert.IsNull(movieLogic.GetMovie(idArea));
        }

        [TestMethod]
        public void UpdateMovieTest()
        {
            //Arrange
            long idMovie = movieLogic.AddMovie("TestMovieForUpdate", "test", new DateTime(2022, 5, 20, 12, 00, 00));
            MovieModel expected = new MovieModel(idMovie, "TestMovieForUpdate", "Test", new DateTime(2022, 5, 20, 12, 00, 00));

            //Act
            movieLogic.UpdateMovie(expected);
            MovieModel result = movieLogic.GetMovie(idMovie);

            //Assert
            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.Name, result.Name);
            Assert.AreEqual(expected.Time, result.Time);
            Assert.AreEqual(expected.Discription, result.Discription);
        }

        [TestMethod]
        public void GetMoviesTest()
        {
            //Arrange
            List<MovieModel> expected = movieLogic.GetMovies();
            expected.Add(movieLogic.GetMovie(movieLogic.AddMovie("TestMovieForGetMovies", "Test", DateTime.Now)));

            //Act
            List<MovieModel> result = movieLogic.GetMovies();

            //Assert
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
            //Arrange
            MovieModel expected = new MovieModel(idMovie, "TestMovieForGetMovie", "Test", new DateTime(2022, 5, 20, 19, 0, 0));

            //Act
            MovieModel result = movieLogic.GetMovie(idMovie);

            //Assert
            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.Name, result.Name);
            Assert.AreEqual(expected.Time, result.Time);
            Assert.AreEqual(expected.Discription, result.Discription);
        }

        [TestMethod]
        public void GetMoviesWithCinema()
        {
            //Arrange
            List<MovieSessionModel> expected = new List<MovieSessionModel>()
            {
                new MovieSessionModel(idMovie,"TestMovie","Test",new DateTime(2022, 5, 20, 19, 0, 0),idSession,idHall,100)
            };

            //Act
            List<MovieSessionModel> result = movieLogic.GetMoviesWithCinema(idCinema);

            //Assert
            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expected[i].IdMovie, result[i].IdMovie);
                Assert.AreEqual(expected[i].Name, result[i].Name);
                Assert.AreEqual(expected[i].Discription, result[i].Discription);
                Assert.AreEqual(expected[i].Time, result[i].Time);
                Assert.AreEqual(expected[i].IdSession, result[i].IdSession);
                Assert.AreEqual(expected[i].IdHall, result[i].IdHall);
                Assert.AreEqual(expected[i].Price, result[i].Price);
            }
        }
    }
}
