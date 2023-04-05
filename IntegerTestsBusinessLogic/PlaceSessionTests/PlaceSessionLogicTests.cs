using BusinessLogic.LogicBusiness.Area;
using BusinessLogic.LogicBusiness.Cinema;
using BusinessLogic.LogicBusiness.Hall;
using BusinessLogic.LogicBusiness.Movie;
using BusinessLogic.LogicBusiness.Place;
using BusinessLogic.LogicBusiness.PlaceSession;
using BusinessLogic.LogicBusiness.Row;
using BusinessLogic.LogicBusiness.Session;
using BusinessLogic.LogicBusiness.User;
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
using DataAccess.Repositories.User;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IntegerTestsBusinessLogic.PlaceSessionTests
{
    [TestClass]
    public class PlaceSessionLogicTests
    {
        PlaceSessionLogic placeSessionLogic;
        PlaceLogic placeLogic;
        SessionLogic sessionLogic;
        UserLogic userLogic;
        RowLogic rowLogic;
        AreaLogic areaLogic;
        CinemaLogic cinemaLogic;
        HallLogic hallLogic;
        MovieLogic movieLogic;
        string connectionString = ConnectionString.connectionStringFake;
        long idCinema;
        long idHall;
        long idArea;
        long idRow;
        long idPlace;
        long idMovie;
        long idSession;
        long idUser;

        [TestInitialize]
        public void Initialize()
        {
            placeSessionLogic = new PlaceSessionLogic(new PlaceSessionRepository(connectionString));
            placeLogic = new PlaceLogic(new PlaceRepository(connectionString), placeSessionLogic);
            sessionLogic = new SessionLogic(new SessionRepository(connectionString), placeSessionLogic);
            userLogic = new UserLogic(new UserRepository(connectionString), placeSessionLogic);
            rowLogic = new RowLogic(new RowRepository(connectionString), placeLogic);
            areaLogic = new AreaLogic(new AreaRepository(connectionString), rowLogic, placeLogic);
            hallLogic = new HallLogic(new HallRepository(connectionString), areaLogic, sessionLogic);
            cinemaLogic = new CinemaLogic(new CinemaRepository(connectionString), hallLogic);
            movieLogic = new MovieLogic(new MovieRepository(connectionString), sessionLogic);

            idCinema = cinemaLogic.AddCinema("TestCinemaByPlaceSession", "img");
            idHall = hallLogic.AddHall(idCinema);
            idArea = areaLogic.AddArea(idHall, 2, 4);
            idRow = rowLogic.AddRow(1, idArea);
            idPlace = placeLogic.AddPlace(idRow, 1);
            idMovie = movieLogic.AddMovie("TestMovieByPlaceSession", "Test", DateTime.Now);
            idSession = sessionLogic.AddSession(idMovie, idHall, 100);
            idUser = userLogic.AddUser("TestUserByPlaceSession", "Test", "Test");
        }

        [TestMethod]
        public void AddPlaceSessionTest()
        {
            //Act
            long result = placeSessionLogic.AddPlaceSession(idPlace, idSession, idUser, StatePlace.Book);
            long expected = placeSessionLogic.GetPlaceSession(result).Id;

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DeletePlaceSessionTest()
        {
            //Arrange
            long expected = placeSessionLogic.AddPlaceSession(idPlace, idSession, idUser, StatePlace.Book);

            //Act
            placeSessionLogic.DeletePlaceSession(expected);

            //Assert
            Assert.IsNull(placeSessionLogic.GetPlaceSession(expected));
        }

        [TestMethod]
        public void UpdatePlaceSessionTest()
        {
            //Arrange
            long idPlaceSession = placeSessionLogic.AddPlaceSession(idPlace, idSession, idUser, StatePlace.Book);
            PlaceSessionModel expected = new PlaceSessionModel(idPlaceSession, idPlace, idSession, idUser, new DateTime(2022, 5, 20, 12, 00, 00), StatePlace.Book);

            //Act
            placeSessionLogic.UpdatePlaceSession(expected);
            PlaceSessionModel result = placeSessionLogic.GetPlaceSession(idPlaceSession);

            //Assert
            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.IdPlaces, result.IdPlaces);
            Assert.AreEqual(expected.IdSession, result.IdSession);
            Assert.AreEqual(expected.IdUsers, result.IdUsers);
            Assert.AreEqual(expected.DateModified, result.DateModified);
            Assert.AreEqual(expected.State, result.State);
        }

        [TestMethod]
        public void GetPlaceSessionTest()
        {
            //Arrange
            long idPlaceSession = placeSessionLogic.AddPlaceSession(idPlace, idSession, idUser, StatePlace.Book);
            PlaceSessionModel expected = new PlaceSessionModel(idPlaceSession, idPlace, idSession, idUser,
                                                               placeSessionLogic.GetPlaceSession(idPlaceSession).DateModified, StatePlace.Book);

            //Act
            PlaceSessionModel result = placeSessionLogic.GetPlaceSession(idPlaceSession);

            //Assert
            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.IdPlaces, result.IdPlaces);
            Assert.AreEqual(expected.IdSession, result.IdSession);
            Assert.AreEqual(expected.IdUsers, result.IdUsers);
            Assert.AreEqual(expected.DateModified, result.DateModified);
            Assert.AreEqual(expected.State, result.State);
        }

        [TestMethod]
        public void GetPlaceSessionsTest()
        {
            //Arrange
            List<PlaceSessionModel> expected = placeSessionLogic.GetPlaceSessions();
            expected.Add(placeSessionLogic.GetPlaceSession(placeSessionLogic.AddPlaceSession(idPlace, idSession, idUser, StatePlace.Book)));

            //Act
            List<PlaceSessionModel> result = placeSessionLogic.GetPlaceSessions();

            //Assert
            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].IdPlaces, result[i].IdPlaces);
                Assert.AreEqual(expected[i].IdSession, result[i].IdSession);
                Assert.AreEqual(expected[i].IdUsers, result[i].IdUsers);
                Assert.AreEqual(expected[i].DateModified, result[i].DateModified);
                Assert.AreEqual(expected[i].State, result[i].State);
            }
        }

        [TestMethod]
        public void GetPlaceSessionFKPlacesTest()
        {
            //Arrange
            List<PlaceSessionModel> expected = placeSessionLogic.GetPlaceSessionFKPlaces(idPlace);
            expected.Add(placeSessionLogic.GetPlaceSession(placeSessionLogic.AddPlaceSession(idPlace, idSession, idUser, StatePlace.Book)));

            //Act
            List<PlaceSessionModel> result = placeSessionLogic.GetPlaceSessionFKPlaces(idPlace);

            //Assert
            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].IdPlaces, result[i].IdPlaces);
                Assert.AreEqual(expected[i].IdSession, result[i].IdSession);
                Assert.AreEqual(expected[i].IdUsers, result[i].IdUsers);
                Assert.AreEqual(expected[i].DateModified, result[i].DateModified);
                Assert.AreEqual(expected[i].State, result[i].State);
            }
        }

        [TestMethod]
        public void GetPlaceSessionFKSessionTest()
        {
            //Arrange
            List<PlaceSessionModel> expected = placeSessionLogic.GetPlaceSessionFKSession(idSession);
            expected.Add(placeSessionLogic.GetPlaceSession(placeSessionLogic.AddPlaceSession(idPlace, idSession, idUser, StatePlace.Book)));

            //Act
            List<PlaceSessionModel> result = placeSessionLogic.GetPlaceSessionFKSession(idSession);

            //Assert
            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].IdPlaces, result[i].IdPlaces);
                Assert.AreEqual(expected[i].IdSession, result[i].IdSession);
                Assert.AreEqual(expected[i].IdUsers, result[i].IdUsers);
                Assert.AreEqual(expected[i].DateModified, result[i].DateModified);
                Assert.AreEqual(expected[i].State, result[i].State);
            }
        }

        [TestMethod]
        public void GetPlaceSessionFKUserTest()
        {
            //Arrange
            List<PlaceSessionModel> expected = placeSessionLogic.GetPlaceSessionFKUser(idUser);
            expected.Add(placeSessionLogic.GetPlaceSession(placeSessionLogic.AddPlaceSession(idPlace, idSession, idUser, StatePlace.Book)));

            //Act
            List<PlaceSessionModel> result = placeSessionLogic.GetPlaceSessionFKUser(idUser);

            //Assert
            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].IdPlaces, result[i].IdPlaces);
                Assert.AreEqual(expected[i].IdSession, result[i].IdSession);
                Assert.AreEqual(expected[i].IdUsers, result[i].IdUsers);
                Assert.AreEqual(expected[i].DateModified, result[i].DateModified);
                Assert.AreEqual(expected[i].State, result[i].State);
            }
        }

        [TestMethod]
        public void DeleteIdPlaceFromPlaceSession()
        {
            //Arrange
            placeSessionLogic.AddPlaceSession(idPlace, idSession, idUser, StatePlace.Book);
            placeSessionLogic.AddPlaceSession(idPlace, idSession, idUser, StatePlace.Book);

            //Act
            placeSessionLogic.DeleteIdPlaceFromPlaceSession(idPlace);
            List<PlaceSessionModel> result = placeSessionLogic.GetPlaceSessionFKPlaces(idPlace);

            //Assert
            Assert.AreEqual(result.Count, 0);
        }

        [TestMethod]
        public void DeleteIdSessionFromPlaceSession()
        {
            //Arrange
            placeSessionLogic.AddPlaceSession(idPlace, idSession, idUser, StatePlace.Book);
            placeSessionLogic.AddPlaceSession(idPlace, idSession, idUser, StatePlace.Book);

            //Act
            placeSessionLogic.DeleteIdSessionFromPlaceSession(idSession);
            List<PlaceSessionModel> result = placeSessionLogic.GetPlaceSessionFKSession(idSession);

            //Assert
            Assert.AreEqual(result.Count, 0);
        }

        [TestMethod]
        public void DeleteIdUserFromPlaceSession()
        {
            //Arrange
            placeSessionLogic.AddPlaceSession(idPlace, idSession, idUser, StatePlace.Book);
            placeSessionLogic.AddPlaceSession(idPlace, idSession, idUser, StatePlace.Book);

            //Act
            placeSessionLogic.DeleteIdUserFromPlaceSession(idUser);
            List<PlaceSessionModel> result = placeSessionLogic.GetPlaceSessionFKUser(idUser);

            //Assert
            Assert.AreEqual(result.Count, 0);
        }
    }
}
