using BusinessLogic.LogicBusiness.Area;
using BusinessLogic.LogicBusiness.Cinema;
using BusinessLogic.LogicBusiness.Hall;
using BusinessLogic.LogicBusiness.Place;
using BusinessLogic.LogicBusiness.PlaceSession;
using BusinessLogic.LogicBusiness.Row;
using BusinessLogic.LogicBusiness.Session;
using DataAccess.Models;
using DataAccess.Repositories;
using DataAccess.Repositories.Area;
using DataAccess.Repositories.Cinema;
using DataAccess.Repositories.Hall;
using DataAccess.Repositories.Place;
using DataAccess.Repositories.PlaceSession;
using DataAccess.Repositories.Row;
using DataAccess.Repositories.Session;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace IntegerTestsBusinessLogic.Place
{
    [TestClass]
    public class PlaceLogicTests
    {
        PlaceLogic placeLogic;
        RowLogic rowLogic;
        PlaceSessionLogic placeSessionLogic;
        AreaLogic areaLogic;
        CinemaLogic cinemaLogic;
        HallLogic hallLogic;
        SessionLogic sessionLogic;
        string connectionString = ConnectionString.connectionStringFake;
        long idCinema;
        long idHall;
        long idArea;
        long idRow;
        long idPlace;

        [TestInitialize]
        public void Initialize()
        {
            placeLogic = new PlaceLogic(new PlaceRepository(connectionString), placeSessionLogic);
            rowLogic = new RowLogic(new RowRepository(connectionString), placeLogic);
            sessionLogic = new SessionLogic(new SessionRepository(connectionString), placeSessionLogic);
            areaLogic = new AreaLogic(new AreaRepository(connectionString), rowLogic, placeLogic);
            hallLogic = new HallLogic(new HallRepository(connectionString), areaLogic, sessionLogic);
            cinemaLogic = new CinemaLogic(new CinemaRepository(connectionString), hallLogic);

            idCinema = cinemaLogic.AddCinema("TestCinema", "img");
            idHall = hallLogic.AddHall(idCinema);
            idArea = areaLogic.AddArea(idHall, 2, 4);
            idRow = rowLogic.AddRow(1, idArea);
            idPlace = placeLogic.AddPlace(idRow, 25);
        }

        [TestMethod]
        public void AddPlaceTest()
        {
            //Act
            long result = placeLogic.AddPlace(idRow, 30);
            long expected = placeLogic.GetPlace(result).Id;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DeletePlaceTest()
        {
            //Arrange
            long idPlace = placeLogic.AddPlace(idRow, 20);

            //Act
            placeLogic.DeletePlace(idPlace);

            //Assert
            Assert.IsNull(placeLogic.GetPlace(idPlace));
        }

        [TestMethod]
        public void UpdatePlaceTest()
        {
            //Arrange
            long idPlace = placeLogic.AddPlace(idRow, 33);
            PlaceModel expected = new PlaceModel(idPlace, idRow, 50);

            //Act
            placeLogic.UpdatePlace(expected);
            PlaceModel result = placeLogic.GetPlace(idPlace);

            //Assert
            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.IdRow, result.IdRow);
            Assert.AreEqual(expected.NumberPlace, result.NumberPlace);
        }

        [TestMethod]
        public void GetPlacesTest()
        {
            //Arrange
            List<PlaceModel> expected = placeLogic.GetPlaces();
            expected.Add(placeLogic.GetPlace(placeLogic.AddPlace(idRow, 33)));

            //Act
            List<PlaceModel> result = placeLogic.GetPlaces();

            //Assert
            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].IdRow, result[i].IdRow);
                Assert.AreEqual(expected[i].NumberPlace, result[i].NumberPlace);
            }
        }

        [TestMethod]
        public void GetFkRowTest()
        {
            //Arrange
            List<PlaceModel> expected = placeLogic.GetFkRow(idRow);
            expected.Add(placeLogic.GetPlace(placeLogic.AddPlace(idRow, 33)));

            //Act
            List<PlaceModel> result = placeLogic.GetFkRow(idRow);

            //Assert
            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].IdRow, result[i].IdRow);
                Assert.AreEqual(expected[i].NumberPlace, result[i].NumberPlace);
            }
        }

        [TestMethod]
        public void GetPlaceTest()
        {
            //Arrange
            PlaceModel expected = placeLogic.GetPlace(idPlace);

            //Act
            PlaceModel result = placeLogic.GetPlace(idPlace);

            //Assert
            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.IdRow, result.IdRow);
            Assert.AreEqual(expected.NumberPlace, result.NumberPlace);
        }

        [TestMethod]
        public void DeleteIdRowFromPlace()
        {
            //Arrange
            long idPlace = placeLogic.AddPlace(idRow,200);

            //Act
            placeLogic.DeleteIdRowFromPlace(idPlace);
            List<PlaceModel> result = placeLogic.GetFkRow(idPlace);

            //Assert
            Assert.AreEqual(result.Count, 0);
        }

    }
}
