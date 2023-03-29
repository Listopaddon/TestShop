using BusinessLogic.LogicBusiness.Area;
using DataAccess.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using UnitTestBusinessLogic.Tests.PlaceTests.SubObjects;
using UnitTestBusinessLogic.Tests.RowTests.SubObjects;
using UnitTestBusinessLogic.Tests.SessionTests.SubObjects;

namespace UnitTestBusinessLogic.Tests
{
    [TestClass]
    public class AreaLogicTests
    {
        AreaLogic area;

        [TestInitialize]
        public void Initialize()
        {
            List<AreaModel> areas = new List<AreaModel>
            {
                  new AreaModel(0, 1),
                  new AreaModel(1, 2),
                  new AreaModel(2, 3),
                  new AreaModel(3, 2),
                  new AreaModel(4, 3),
                  new AreaModel(5, 3)
            };
            this.area = new AreaLogic(new SubAreaRepository(areas), new SubRowLogic());
        }

        [TestMethod]
        public void AddAreaTest()
        {
            Assert.AreEqual(6, area.AddArea(2));
        }

        [TestMethod]
        public void DeleteAreaTest()
        {
            long id = 5;
            AreaModel result = null;
            List<AreaModel> areaDtos = area.GetAreas();
            area.DeleteArea(id);

            for (int i = 0; i < areaDtos.Count; i++)
            {
                if (areaDtos[i].Id == id)
                {
                    result = areaDtos[i];
                    break;
                }
            }

            Assert.IsNull(result);
        }

        [TestMethod]
        public void DeleteIdHallFromAreaTest()
        {
            long id = 3;
            List<AreaModel> areaDtosResult = new List<AreaModel>();
            List<AreaModel> areaDtos = area.GetAreas();
            area.DeleteIdHallFromArea(id);

            for (int i = 0; i < areaDtos.Count; i++)
            {
                if (areaDtos[0].IdHall == 4)
                {
                    areaDtosResult.Add(areaDtos[i]);
                }
                else if (areaDtos[0].IdHall == 4)
                {
                    areaDtosResult.Add(areaDtos[i]);
                }
            }

            Assert.AreEqual(areaDtosResult.Count, 0);
        }

        [TestMethod]
        public void GetAreasTest()
        {
            List<AreaModel> expected = new List<AreaModel>
            {
                 new AreaModel(0, 1),
                 new AreaModel(1, 2),
                 new AreaModel(2, 3),
                 new AreaModel(3, 2),
                 new AreaModel(4, 3),
                 new AreaModel(5, 3)
            };

            List<AreaModel> result = area.GetAreas();

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[0].Id, result[0].Id);
                Assert.AreEqual(expected[0].IdHall, result[0].IdHall);
            }
        }

        [TestMethod]
        public void UpdateAreaTest()
        {
            List<AreaModel> areas = area.GetAreas();
            AreaModel expected = new AreaModel(3, 14);
            area.UpdateArea(new AreaModel(3, 14));

            Assert.AreEqual(expected.Id, areas[3].Id);
            Assert.AreEqual(expected.IdHall, areas[3].IdHall);

        }

        [TestMethod]
        public void GetAreaTest()
        {
            AreaModel expected = new AreaModel(3, 2);
            AreaModel result = area.GetArea(3);

            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(result.IdHall, result.IdHall);
        }

        [TestMethod]
        public void GetFKHall()
        {
            List<AreaModel> expected = new List<AreaModel>
            {
                  new AreaModel(1, 2),
                  new AreaModel(3, 2)
            };

            List<AreaModel> result = area.GetFKHall(2);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].IdHall, result[i].IdHall);
            }
        }
    }
}
