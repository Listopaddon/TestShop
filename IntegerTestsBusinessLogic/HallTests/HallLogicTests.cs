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

namespace IntegerTestsBusinessLogic.Hall
{
    [TestClass]
    public class HallLogicTests
    {
        HallLogic hallLogic;
        AreaLogic areaLogic;
        RowLogic rowLogic;
        PlaceLogic placeLogic;
        SessionLogic sessionLogic;
        CinemaLogic cinemaLogic;
        MovieLogic movieLogic;
        string connectionString = ConnectionString.connectionStringFake;
        long idCinema;
        long idHall;
        long idMovie;
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

            idCinema = cinemaLogic.AddCinema("TestCinemaForUpdateHall", "img");
            idHall = hallLogic.AddHall(idCinema);
            idMovie = movieLogic.AddMovie("TestFilmByHall", "Test", DateTime.Now);
            idSession = sessionLogic.AddSession(idMovie, idHall, 100);
        }

        [TestMethod]
        public void AddHallTest()
        {
            //Arrange
            long idCinema = cinemaLogic.AddCinema("TestCinemaForAddHall", "img");

            //Act
            long result = hallLogic.AddHall(idCinema);
            long expected = hallLogic.GetHall(result).Id;

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DeleteHallTest()
        {
            //Arrange
            long idCinema = cinemaLogic.AddCinema("TestCinemaForDeleteHall", "img");
            long idHall = hallLogic.AddHall(idCinema);

            //Act
            hallLogic.DeleteHall(idHall);

            //Assert
            Assert.IsNull(hallLogic.GetHall(idHall));
        }

        [TestMethod]
        public void UpdateHallTest()
        {
            //Arrange            
            long idCinemaAfterUpdate = cinemaLogic.AddCinema("TestCinemaAfterUpdate", "img");
            HallModel expected = new HallModel(idHall, idCinemaAfterUpdate);

            //Act
            hallLogic.UpdateHall(expected);
            HallModel result = hallLogic.GetHall(idHall);

            //Assert
            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.IdCinema, result.IdCinema);
        }

        [TestMethod]
        public void GetHallsTest()
        {
            //Arrange
            List<HallModel> expected = hallLogic.GetHalls();
            expected.Add(hallLogic.GetHall(hallLogic.AddHall(idCinema)));

            //Act
            List<HallModel> result = hallLogic.GetHalls();

            //Assert
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].IdCinema, result[i].IdCinema);
            }
        }

        [TestMethod]
        public void GetHallTest()
        {
            //Arrange
            HallModel expected = new HallModel(idHall, idCinema);

            //Act
            HallModel result = hallLogic.GetHall(idHall);

            //Assert
            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.IdCinema, result.IdCinema);
        }

        [TestMethod]
        public void GetFKCinemaTest()
        {
            //Arrange
            List<HallModel> expected = hallLogic.GetFKCinema(idCinema);
            expected.Add(hallLogic.GetHall(hallLogic.AddHall(idCinema)));
            expected.Add(hallLogic.GetHall(hallLogic.AddHall(idCinema)));
            expected.Add(hallLogic.GetHall(hallLogic.AddHall(idCinema)));

            //Act
            List<HallModel> result = hallLogic.GetFKCinema(idCinema);

            //Assert
            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].IdCinema, result[i].IdCinema);
            }
        }

        [TestMethod]
        public void GetHallByIdMovie()
        {
            //Arrange            
            List<HallModel> expected = new List<HallModel>()
            {
                new HallModel(idHall,idCinema)
            };

            //Act
            List<HallModel> result = hallLogic.GetHallByIdMovie(idMovie, idCinema);

            //Assert
            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].IdCinema, result[i].IdCinema);
            }
        }

        [TestMethod]
        public void GetHallByIdCinema()
        {
            //Arrange
            long idCinema = cinemaLogic.AddCinema("TestCinemaByGetHallsByIdCinema", "jpg");
            List<HallModel> expected = new List<HallModel>();
            expected.Add(hallLogic.GetHall(hallLogic.AddHall(idCinema)));
            expected.Add(hallLogic.GetHall(hallLogic.AddHall(idCinema)));
            expected.Add(hallLogic.GetHall(hallLogic.AddHall(idCinema)));

            //Act
            List<HallModel> result = hallLogic.GetHallByIdCinema(idCinema);

            //Assert
            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].IdCinema, result[i].IdCinema);
            }
        }
    }
}
