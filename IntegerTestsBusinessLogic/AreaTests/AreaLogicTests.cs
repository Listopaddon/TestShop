using BusinessLogic.LogicBusiness.Area;
using BusinessLogic.LogicBusiness.Place;
using BusinessLogic.LogicBusiness.PlaceSession;
using BusinessLogic.LogicBusiness.Row;
using DataAccess.Models;
using DataAccess.Repositories;
using DataAccess.Repositories.Area;
using DataAccess.Repositories.Place;
using DataAccess.Repositories.PlaceSession;
using DataAccess.Repositories.Row;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace IntegerTestsBusinessLogic.AreaTests
{
    [TestClass]
    public class AreaLogicTests
    {
        AreaLogic areaLogic;
        string connectionString = ConnectionString.connectionStringFake;

        [TestInitialize]
        public void Initializide()
        {
            areaLogic = new AreaLogic(new AreaRepository(connectionString),
                                      new RowLogic(new RowRepository(connectionString),
                                      new PlaceLogic(new PlaceRepository(connectionString),
                                                     new PlaceSessionLogic(new PlaceSessionRepository(connectionString)))));
        }

        [TestMethod]
        public void AddAreaTest()
        {
            long result = areaLogic.AddArea(3);
            long expected = areaLogic.GetArea(result).Id;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DeleteAreaTest()
        {
            long id = areaLogic.AddArea(3); ;
            areaLogic.DeleteArea(id);
            Assert.IsNull(areaLogic.GetArea(id));
        }

        [TestMethod]
        public void UpdateAreaTest()
        {
            long expected = areaLogic.AddArea(3);
            areaLogic.UpdateArea(new AreaModel(expected, 2));
            AreaModel result = areaLogic.GetArea(expected);

            Assert.AreEqual(areaLogic.GetArea(expected).Id, result.Id);
            Assert.AreEqual(areaLogic.GetArea(expected).IdHall, result.IdHall);
        }

        [TestMethod]
        public void GetAreasTest()
        {
            List<AreaModel> expected = areaLogic.GetAreas();
            expected.Add(areaLogic.GetArea(areaLogic.AddArea(3)));
            expected.Add(areaLogic.GetArea(areaLogic.AddArea(3)));

            List<AreaModel> result = areaLogic.GetAreas();

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].IdHall, result[i].IdHall);
            }
        }

        [TestMethod]
        public void GetFKHallTest()
        {
            long id = 3;
            List<AreaModel> expected = areaLogic.GetFKHall(id);

            expected.Add(areaLogic.GetArea(areaLogic.AddArea(id)));
            expected.Add(areaLogic.GetArea(areaLogic.AddArea(id)));
            expected.Add(areaLogic.GetArea(areaLogic.AddArea(id)));


            List<AreaModel> result = areaLogic.GetFKHall(id);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].IdHall, result[i].IdHall);
            }
        }

        [TestMethod]
        public void GetAreaTest()
        {
            long id = 2;
            AreaModel expected = new AreaModel(id, 2);
            AreaModel result = areaLogic.GetArea(id);

            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.IdHall, result.IdHall);
        }

        [TestMethod]
        public void DeleteIdHallFromArea()
        {
            long id = 4;
            List<AreaModel> expected = new List<AreaModel>();
            areaLogic.AddArea(id);
            areaLogic.AddArea(id);
            areaLogic.DeleteIdHallFromArea(id);
            List<AreaModel> areas = areaLogic.GetFKHall(id);

            for (int i = 0; i < areas.Count; i++)
            {
                if (areas[i].IdHall == id)
                {
                    expected.Add(areas[i]);
                }
            }

            Assert.AreEqual(expected.Count, 0);
        }
    }
}
