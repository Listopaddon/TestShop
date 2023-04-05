using BusinessLogic.LogicBusiness.Area;
using DataAccess.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using UnitTestBusinessLogic.Tests.PlaceTests.SubObjects;
using UnitTestBusinessLogic.Tests.RowTests.SubObjects;

namespace UnitTestBusinessLogic.Tests
{
    [TestClass]
    public class AreaLogicTests
    {
        AreaLogic areaLogic;

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
            areaLogic = new AreaLogic(new SubAreaRepository(areas), new SubRowLogic(), new SubPlaceLogic());
        }

        [TestMethod]
        public void AddAreaTest() => Assert.AreEqual(6, areaLogic.AddArea(2));


        [TestMethod]
        public void DeleteAreaTest()
        {
            //Arrange
            long id = 5;
            AreaModel result = null;
            List<AreaModel> areaDtos = areaLogic.GetAreas();

            //Act
            areaLogic.DeleteArea(id);
            for (int i = 0; i < areaDtos.Count; i++)
            {
                if (areaDtos[i].Id == id)
                {
                    result = areaDtos[i];
                    break;
                }
            }

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void DeleteIdHallFromAreaTest()
        {
            //Arrange
            long id = 3;
            List<AreaModel> areaDtosResult = new List<AreaModel>();
            List<AreaModel> areaDtos = areaLogic.GetAreas();

            //Act
            areaLogic.DeleteIdHallFromArea(id);
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

            //Assert
            Assert.AreEqual(areaDtosResult.Count, 0);
        }

        [TestMethod]
        public void GetAreasTest()
        {
            //Arrange
            List<AreaModel> expected = new List<AreaModel>
            {
                 new AreaModel(0, 1),
                 new AreaModel(1, 2),
                 new AreaModel(2, 3),
                 new AreaModel(3, 2),
                 new AreaModel(4, 3),
                 new AreaModel(5, 3)
            };

            //Act
            List<AreaModel> result = areaLogic.GetAreas();

            //Assert
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[0].Id, result[0].Id);
                Assert.AreEqual(expected[0].IdHall, result[0].IdHall);
            }
        }

        [TestMethod]
        public void UpdateAreaTest()
        {
            //Arrange
            List<AreaModel> areas = areaLogic.GetAreas();
            AreaModel expected = new AreaModel(3, 14);

            //Act
            areaLogic.UpdateArea(new AreaModel(3, 14));

            //Assert
            Assert.AreEqual(expected.Id, areas[3].Id);
            Assert.AreEqual(expected.IdHall, areas[3].IdHall);

        }

        [TestMethod]
        public void GetAreaTest()
        {
            //Arrange
            AreaModel expected = new AreaModel(3, 2);

            //Act
            AreaModel result = areaLogic.GetArea(3);

            //Assert
            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(result.IdHall, result.IdHall);
        }

        [TestMethod]
        public void GetFKHall()
        {
            //Arrange
            List<AreaModel> expected = new List<AreaModel>
            {
                  new AreaModel(1, 2),
                  new AreaModel(3, 2)
            };

            //Act
            List<AreaModel> result = areaLogic.GetFKHall(2);

            //Assert
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].IdHall, result[i].IdHall);
            }
        }
    }
}
