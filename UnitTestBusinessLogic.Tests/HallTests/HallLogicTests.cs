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
            long id = 3;
            HallModel result = null;
            List<HallModel> halls = logic.GetHalls();
            logic.DeleteHall(id);

            for (int i = 0; i < halls.Count; i++)
            {
                if (halls[i].Id == id)
                {
                    result = halls[i];
                    break;
                }
            }

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetFKCinemaTest()
        {
            long idCinema = 4;
            List<HallModel> expected = new List<HallModel>
            {
                new HallModel(0,4),
                new HallModel(2,4),
                new HallModel(4,4)
            };
            List<HallModel> result = logic.GetFKCinema(idCinema);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].IdCinema, result[i].IdCinema);
            }
        }

        [TestMethod]
        public void GetHallTest()
        {
            long idHall = 3;
            HallModel expected = new HallModel(3, 3);
            HallModel result = logic.GetHall(idHall);

            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.IdCinema, result.IdCinema);
        }

        [TestMethod]
        public void GetHallsTest()
        {
            List<HallModel> expected = new List<HallModel>
            {
                new HallModel(0,4),
                new HallModel(1,1),
                new HallModel(2,4),
                new HallModel(3,3),
                new HallModel(4,4),
                new HallModel(5,5)
            };

            List<HallModel> result = logic.GetHalls();

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].IdCinema, result[i].IdCinema);
            }
        }

        [TestMethod]
        public void UpdateHallTest()
        {
            List<HallModel> halls = logic.GetHalls();
            HallModel expected = new HallModel(3, 134);
            logic.UpdateHall(new HallModel(3, 134));

            Assert.AreEqual(expected.Id, halls[3].Id);
            Assert.AreEqual(expected.IdCinema, halls[3].IdCinema);
        }

        [TestMethod]
        public void GetHallByIdMovieTest()
        {
            List<HallModel> expected = new List<HallModel>()
            { new HallModel(1, 1) };
            List<HallModel> result = logic.GetHallByIdMovie(1,1);

            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].IdCinema, result[i].IdCinema);
            }
        }

        [TestMethod]
        public void GetHallByIdCinemaTest()
        {
            List<HallModel> expected = new List<HallModel>
            {
                new HallModel(0,4),
                new HallModel(2,4),
                new HallModel(4,4)
            };

            List<HallModel> result = logic.GetHallByIdCinema(4);

            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].IdCinema, result[i].IdCinema);
            }
        }
    }
}
