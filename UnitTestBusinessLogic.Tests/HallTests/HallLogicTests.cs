using BusinessLogic.LogicBusiness.Hall;
using DataAccess.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using UnitTestBusinessLogic.Tests.AreaTests.SubObjects;
using UnitTestBusinessLogic.Tests.HallTests.SubObjects;
using UnitTestBusinessLogic.Tests.SessionTests.SubObjects;

namespace UnitTestBusinessLogic.Tests.HallTests
{
    [TestClass]
    public class HallLogicTests
    {
        HallLogic logic;

        [TestInitialize]
        public void Initialize()
        {
            List<HallModel> halls = new List<HallModel>
            {
                new HallModel(0,4),
                new HallModel(1,1),
                new HallModel(2,4),
                new HallModel(3,3),
                new HallModel(4,4),
                new HallModel(5,5)
            };
            logic = new HallLogic(new SubHallRepository(halls),
                                  new SubAreaLogic(),
                                  new SubSessionLogic());
        }
        [TestMethod]
        public void AddHallTest() => Assert.AreEqual(6, logic.AddHall(64));

        [TestMethod]
        public void DeleteHallTest()
        {
            //Arrange
            long id = 3;
            HallModel result = null;
            List<HallModel> halls = logic.GetHalls();

            //Act
            logic.DeleteHall(id);

            for (int i = 0; i < halls.Count; i++)
            {
                if (halls[i].Id == id)
                {
                    result = halls[i];
                    break;
                }
            }

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetFKCinemaTest()
        {
            //Arrange
            long idCinema = 4;
            List<HallModel> expected = new List<HallModel>
            {
                new HallModel(0,4),
                new HallModel(2,4),
                new HallModel(4,4)
            };

            //Act
            List<HallModel> result = logic.GetFKCinema(idCinema);

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
            long idHall = 3;
            HallModel expected = new HallModel(3, 3);

            //Act
            HallModel result = logic.GetHall(idHall);

            //Assert
            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.IdCinema, result.IdCinema);
        }

        [TestMethod]
        public void GetHallsTest()
        {
            //Arrange
            List<HallModel> expected = new List<HallModel>
            {
                new HallModel(0,4),
                new HallModel(1,1),
                new HallModel(2,4),
                new HallModel(3,3),
                new HallModel(4,4),
                new HallModel(5,5)
            };

            //Act
            List<HallModel> result = logic.GetHalls();

            //Assert
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].IdCinema, result[i].IdCinema);
            }
        }

        [TestMethod]
        public void UpdateHallTest()
        {
            //Arrange
            List<HallModel> halls = logic.GetHalls();
            HallModel expected = new HallModel(3, 134);

            //Act
            logic.UpdateHall(new HallModel(3, 134));

            //Assert
            Assert.AreEqual(expected.Id, halls[3].Id);
            Assert.AreEqual(expected.IdCinema, halls[3].IdCinema);
        }

        [TestMethod]
        public void GetHallByIdMovieTest()
        {
            //Arrange
            List<HallModel> expected = new List<HallModel>()
            { new HallModel(1, 1) };

            //Act
            List<HallModel> result = logic.GetHallByIdMovie(1,1);

            //Assert
            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].IdCinema, result[i].IdCinema);
            }
        }

        [TestMethod]
        public void GetHallByIdCinemaTest()
        {
            //Arrange
            List<HallModel> expected = new List<HallModel>
            {
                new HallModel(0,4),
                new HallModel(2,4),
                new HallModel(4,4)
            };

            //Act
            List<HallModel> result = logic.GetHallByIdCinema(4);
            
            //Assert
            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].IdCinema, result[i].IdCinema);
            }
        }
    }
}
