using BusinessLogic.LogicBusiness.Place;
using BusinessLogic.LogicBusiness.PlaceSession;
using DataAccess.Models;
using DataAccess.Repositories;
using DataAccess.Repositories.Place;
using DataAccess.Repositories.PlaceSession;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace IntegerTestsBusinessLogic.Place
{
    [TestClass]
    public class PlaceLogicTests
    {
        PlaceLogic placeLogic;
        string connectionString = ConnectionString.connectionStringFake;

        [TestInitialize]
        public void Initialize()
        {
            placeLogic = new PlaceLogic(new PlaceRepository(connectionString),
                                        new PlaceSessionLogic(new PlaceSessionRepository(connectionString)));
        }

        [TestMethod]
        public void AddPlaceTest()
        {
            long result = placeLogic.AddPlace(2, 25);
            long expected = placeLogic.GetPlace(result).Id;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DeletePlaceTest()
        {
            long id = placeLogic.AddPlace(2,222);
            placeLogic.DeletePlace(id);
            Assert.IsNull(placeLogic.GetPlace(id));
        }

        [TestMethod]
        public void UpdatePlaceTest()
        {
            PlaceModel expected = new PlaceModel(3, 2, 33);
            placeLogic.UpdatePlace(expected);
            PlaceModel result = placeLogic.GetPlace(2);

            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.IdRow, result.IdRow);
            Assert.AreEqual(expected.NumberPlace, result.NumberPlace);
        }

        [TestMethod]
        public void GetPlacesTest()
        {
            List<PlaceModel> expected = placeLogic.GetPlaces();
            expected.Add(placeLogic.GetPlace(placeLogic.AddPlace(2, 33)));

            List<PlaceModel> result = placeLogic.GetPlaces();

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
            long fkRow = 2;
            List<PlaceModel> expected = placeLogic.GetFkRow(fkRow);
            expected.Add(placeLogic.GetPlace(placeLogic.AddPlace(fkRow, 33)));

            List<PlaceModel> result = placeLogic.GetFkRow(fkRow);

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
            PlaceModel expected = new PlaceModel(3, 2, 33);
            PlaceModel result = placeLogic.GetPlace(3);

            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.IdRow, result.IdRow);
            Assert.AreEqual(expected.NumberPlace, result.NumberPlace);
        }

        [TestMethod]
        public void DeleteIdRowFromPlace()
        {
            long id = 2;
            placeLogic.DeleteIdRowFromPlace(id);
            List<PlaceModel> result = placeLogic.GetFkRow(id);

            Assert.AreEqual(result.Count, 0);
        }
    }
}
