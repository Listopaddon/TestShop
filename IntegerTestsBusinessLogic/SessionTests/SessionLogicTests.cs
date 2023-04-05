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

namespace IntegerTestsBusinessLogic.SessionTests
{

    [TestClass]
    public class SessionLogicTests
    {
        SessionLogic sessionLogic;
        RowLogic rowLogic;
        PlaceLogic placeLogic;
        PlaceSessionLogic placeSessionLogic;
        AreaLogic areaLogic;
        CinemaLogic cinemaLogic;
        HallLogic hallLogic;
        MovieLogic movieLogic;
        string connectionString = ConnectionString.connectionStringFake;
        long idMovie;
        long idCinema;
        long idHall;

        [TestInitialize]
        public void Initialize()
        {
            placeSessionLogic = new PlaceSessionLogic(new PlaceSessionRepository(connectionString));
            placeLogic = new PlaceLogic(new PlaceRepository(connectionString), placeSessionLogic);
            rowLogic = new RowLogic(new RowRepository(connectionString), placeLogic);
            sessionLogic = new SessionLogic(new SessionRepository(connectionString), placeSessionLogic);
            areaLogic = new AreaLogic(new AreaRepository(connectionString), rowLogic, placeLogic);
            hallLogic = new HallLogic(new HallRepository(connectionString), areaLogic, sessionLogic);
            cinemaLogic = new CinemaLogic(new CinemaRepository(connectionString), hallLogic);
            movieLogic = new MovieLogic(new MovieRepository(connectionString), sessionLogic);

            idMovie = movieLogic.AddMovie("TestMovie", "Test", DateTime.Now);
            idCinema = cinemaLogic.AddCinema("TestCinema", "img");
            idHall = hallLogic.AddHall(idCinema);
        }

        [TestMethod]
        public void AddSessionTest()
        {
            //Act
            long result = sessionLogic.AddSession(idMovie, idHall, 100);
            long expected = sessionLogic.GetSession(result).Id;

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DeleteSessionTest()
        {
            //Arrange
            long idSession = sessionLogic.AddSession(idMovie, idHall, 100);

            //Act
            sessionLogic.DeleteSession(idSession);
            SessionModel result = sessionLogic.GetSession(idSession);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void UpdateSessionTest()
        {
            //Arrange
            long idSession = sessionLogic.AddSession(idMovie, idHall, 1200);
            SessionModel expected = new SessionModel(idSession, idMovie, idHall, 5000);

            //Act
            sessionLogic.UpdateSession(expected);
            SessionModel result = sessionLogic.GetSession(idSession);

            //Assert
            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.IdHall, result.IdHall);
            Assert.AreEqual(expected.IdMovie, result.IdMovie);
            Assert.AreEqual(expected.Price, result.Price);
        }

        [TestMethod]
        public void GetSessionsTest()
        {
            //Arrange
            List<SessionModel> expected = sessionLogic.GetSessions();
            expected.Add(sessionLogic.GetSession(sessionLogic.AddSession(idMovie, idHall, 100)));

            //Act
            List<SessionModel> result = sessionLogic.GetSessions();

            //Assert
            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].IdHall, result[i].IdHall);
                Assert.AreEqual(expected[i].IdMovie, result[i].IdMovie);
                Assert.AreEqual(expected[i].Price, result[i].Price);
            }
        }

        [TestMethod]
        public void GetSessionTest()
        {

            long idSession = sessionLogic.AddSession(idMovie, idHall, 1200);
            SessionModel expected = new SessionModel(idSession, idMovie, idHall, 1200);

            //Act
            SessionModel result = sessionLogic.GetSession(idSession);

            //Assert
            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.IdHall, result.IdHall);
            Assert.AreEqual(expected.IdMovie, result.IdMovie);
            Assert.AreEqual(expected.Price, result.Price);
        }

        [TestMethod]
        public void GetFKHallTest()
        {
            //Arrange
            long idHall = hallLogic.AddHall(idCinema);
            List<SessionModel> expected = sessionLogic.GetFkHall(idHall);
            expected.Add(sessionLogic.GetSession(sessionLogic.AddSession(idMovie, idHall, 400)));

            //Act
            List<SessionModel> result = sessionLogic.GetFkHall(idHall);

            //Assert
            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].IdHall, result[i].IdHall);
                Assert.AreEqual(expected[i].IdMovie, result[i].IdMovie);
                Assert.AreEqual(expected[i].Price, result[i].Price);
            }
        }

        [TestMethod]
        public void DeleteFKSessionsTest()
        {
            //Arrange
            long idHall = hallLogic.AddHall(idCinema);

            //Act
            List<SessionModel> result = sessionLogic.GetFkHall(idHall);
            sessionLogic.DeleteFKSessions(result);
            result = sessionLogic.GetFkHall(idHall);

            //Assert
            Assert.AreEqual(0, result.Count);

        }
    }
}
