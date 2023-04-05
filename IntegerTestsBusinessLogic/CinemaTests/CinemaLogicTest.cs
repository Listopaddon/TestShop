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

namespace IntegerTestsBusinessLogic.Cinema
{
    [TestClass]
    public class CinemaLogicTest
    {
        CinemaLogic cinemaLogic;
        HallLogic hallLogic;
        AreaLogic areaLogic;
        RowLogic rowLogic;
        PlaceLogic placeLogic;
        SessionLogic sessionLogic;
        MovieLogic movieLogic;
        string connectionString = ConnectionString.connectionStringFake;
        long idCinema;
        long idHall ;
        long idMovie ;
        long idSession;

        [TestInitialize]
        public void Initialize()
        {
            placeLogic = new PlaceLogic(new PlaceRepository(connectionString), new PlaceSessionLogic(new PlaceSessionRepository(connectionString)));
            rowLogic = new RowLogic(new RowRepository(connectionString), placeLogic);
            areaLogic = new AreaLogic(new AreaRepository(connectionString), rowLogic, placeLogic);
            sessionLogic = new SessionLogic(new SessionRepository(connectionString), new PlaceSessionLogic(new PlaceSessionRepository(connectionString)));
            hallLogic = new HallLogic(new HallRepository(connectionString), areaLogic, sessionLogic);
            cinemaLogic = new CinemaLogic(new CinemaRepository(connectionString), hallLogic);
            movieLogic = new MovieLogic(new MovieRepository(connectionString), sessionLogic);

            idCinema = cinemaLogic.AddCinema("TestCinemaByGetIdCinema", "jpg");
            idHall = hallLogic.AddHall(idCinema);
            idMovie = movieLogic.AddMovie("TestFilmByCinema", "Test", DateTime.Now);
            idSession = sessionLogic.AddSession(idMovie, idHall, 100);
        }

        [TestMethod]
        public void AddCinemaTest()
        {
            //Act
            long result = cinemaLogic.AddCinema("TestCinemaForAddCinema", "jpg");
            long expected = cinemaLogic.GetCinema(result).Id;

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetCinemasTest()
        {
            //Arrange
            List<CinemaModel> expected = cinemaLogic.GetCinemas();
            expected.Add(cinemaLogic.GetCinema(cinemaLogic.AddCinema("TestCinemaForGetCinemas", "jpg")));

            //Act
            List<CinemaModel> result = cinemaLogic.GetCinemas();

            //Assert
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].Name, result[i].Name);
                Assert.AreEqual(expected[i].Picture, result[i].Picture);
            }
        }

        [TestMethod]
        public void DeleteCinemaTest()
        {
            //Arrange
            long idCinema = cinemaLogic.AddCinema("TestCinemaForDeleteCinema", "jpg");

            //Act
            cinemaLogic.DeleteCinema(idCinema);

            //Assert
            Assert.IsNull(cinemaLogic.GetCinema(idCinema));
        }

        [TestMethod]
        public void UpdateCinemaTest()
        {
            //Arrange
            CinemaModel expected = new CinemaModel(idCinema, "TestCinemaForUpdateCinemaIsTrue", "jpg");

            //Act
            cinemaLogic.UpdateCinema(expected);
            CinemaModel result = cinemaLogic.GetCinema(idCinema);

            //Assert
            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.Name, result.Name);
            Assert.AreEqual(expected.Picture, result.Picture);
        }

        [TestMethod]
        public void GetCinema()
        {
            //Arrange
            CinemaModel expected = new CinemaModel(idCinema, "TestCinemaByGetIdCinema", "jpg");

            //Act
            CinemaModel result = cinemaLogic.GetCinema(idCinema);

            //Assert
            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.Name, result.Name);
            Assert.AreEqual(expected.Picture, result.Picture);
        }

        [TestMethod]
        public void GetIdCinemaByFilmFromSessionTest()
        {
            //Arrange
            List<CinemaModel> expected = new List<CinemaModel>()
            {
                new CinemaModel(idCinema,"TestCinemaByGetIdCinema", "jpg")
            };

            //Act
            List<CinemaModel> result = cinemaLogic.GetIdCinemaByFilmFromSession(idMovie);

            //Assert
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].Name, result[i].Name);
                Assert.AreEqual(expected[i].Picture, result[i].Picture);
            }
        }
    }
}
