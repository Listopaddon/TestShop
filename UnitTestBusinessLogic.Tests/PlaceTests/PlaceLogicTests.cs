using BusinessLogic.LogicBusiness.Place;
using DataAccess.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using UnitTestBusinessLogic.Tests.PlaceTests.SubObjects;
using UnitTestBusinessLogic.Tests.PlaceSessionTests.SubObjects;

namespace UnitTestBusinessLogic.Tests.PlaceTests
{
    [TestClass]
    public class PlaceLogicTests
    {
        PlaceLogic placeLogic;
        [TestInitialize]
        public void Initialize()
        {
            List<PlaceModel> places = new List<PlaceModel>
            {
                new PlaceModel(0,2,14),
                new PlaceModel(1,2,24),
                new PlaceModel(2,4,34),
                new PlaceModel(3,3,44),
                new PlaceModel(4,4,54),
                new PlaceModel(5,2,64),
                new PlaceModel(6,3,74)
            };

            placeLogic = new PlaceLogic(new SubPlaceRepository(places), new SubPlaceSessionLogic());
        }

        [TestMethod]
        public void AddPlaceTest() => Assert.AreEqual(7, placeLogic.AddPlace(4, 54));

        [TestMethod]
        public void DeletePlaceTest()
        {
            long id = 3;
            PlaceModel result = null;
            List<PlaceModel> places = placeLogic.GetPlaces();
            placeLogic.DeletePlace(id);

            for (int i = 0; i < places.Count; i++)
            {
                if (places[i].Id == id)
                {
                    result = places[i];
                    break;
                }
            }

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetPlacesTest()
        {
            List<PlaceModel> expected = new List<PlaceModel>
            {
                new PlaceModel(0,2,14),
                new PlaceModel(1,2,24),
                new PlaceModel(2,4,34),
                new PlaceModel(3,3,44),
                new PlaceModel(4,4,54),
                new PlaceModel(5,2,64),
                new PlaceModel(6,3,74)
            };

            List<PlaceModel> result = placeLogic.GetPlaces();

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].IdRow, result[i].IdRow);
                Assert.AreEqual(expected[i].NumberPlace, result[i].NumberPlace);
            }
        }

        [TestMethod]
        public void UpdatePlaceTest()
        {
            PlaceModel expected = new PlaceModel(3, 5, 43);
            placeLogic.UpdatePlace(expected);
            List<PlaceModel> places = placeLogic.GetPlaces();

            Assert.AreEqual(expected.Id, places[3].Id);
            Assert.AreEqual(expected.IdRow, places[3].IdRow);
            Assert.AreEqual(expected.NumberPlace, places[3].NumberPlace);
        }

        [TestMethod]
        public void GetFKRow()
        {
            List<PlaceModel> expected = new List<PlaceModel>
            {
               new PlaceModel(0,2,14),
                new PlaceModel(1,2,24),
                new PlaceModel(5,2,64)
            };

            List<PlaceModel> result = placeLogic.GetFkRow(2);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].IdRow, result[i].IdRow);
                Assert.AreEqual(expected[i].NumberPlace, result[i].NumberPlace);
            }
        }

        [TestMethod]
        public void GetPlaceTest()
        {
            PlaceModel expected = new PlaceModel(2, 4, 34);
            PlaceModel result = placeLogic.GetPlace(2);

            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.IdRow, result.IdRow);
            Assert.AreEqual(expected.NumberPlace, result.NumberPlace);
        }

        [TestMethod]
        public void DeleteIdRowFromPlace()
        {
            long id = 2;
            List<PlaceModel> expected = new List<PlaceModel>();
            List<PlaceModel> places = placeLogic.GetPlaces();
            placeLogic.DeleteIdRowFromPlace(id);

            for (int i = 0; i < places.Count; i++)
            {
                if (places[0].IdRow == id)
                {
                    places.Remove(places[0]);
                }
                else if (places[i].IdRow == id)
                {
                    places.Remove(places[i]);
                }
            }
        }
    }
}
