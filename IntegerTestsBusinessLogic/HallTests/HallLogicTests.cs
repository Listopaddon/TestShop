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

namespace IntegerTestsBusinessLogic.Hall
{
    [TestClass]
    public class HallLogicTests
    {
        HallLogic hallLogic;
        CinemaLogic cinemaLogic;
        string connectionString = ConnectionString.connectionStringFake;

        [TestInitialize]
        public void Initialize()
        {
            hallLogic = new HallLogic(new HallRepository(connectionString),
                                      new AreaLogic(new AreaRepository(connectionString),
                                                          new RowLogic(new RowRepository(connectionString),
                                                          new PlaceLogic(new PlaceRepository(connectionString),
                                                                         new PlaceSessionLogic(new PlaceSessionRepository(connectionString))))),
                                      new SessionLogic(new SessionRepository(connectionString),
                                                       new PlaceSessionLogic(new PlaceSessionRepository(connectionString))));
            cinemaLogic = new CinemaLogic(new CinemaRepository(connectionString), hallLogic);
        }

        [TestMethod]
        public void AddHallTest()
        {
            long result = hallLogic.AddHall(3);
            long expected = hallLogic.GetHall(result).Id;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DeleteHallTest()
        {
            long id = hallLogic.AddHall(3);
            hallLogic.DeleteHall(id);

            Assert.IsNull(hallLogic.GetHall(id));
        }

        [TestMethod]
        public void UpdateHallTest()
        {
            HallModel expected = new HallModel(2, 3);
            hallLogic.UpdateHall(expected);
            HallModel result = hallLogic.GetHall(2);

            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.IdCinema, result.IdCinema);
        }

        [TestMethod]
        public void GetHallsTest()
        {
            List<HallModel> expected = hallLogic.GetHalls();
            expected.Add(hallLogic.GetHall(hallLogic.AddHall(3)));

            List<HallModel> result = hallLogic.GetHalls();

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].IdCinema, result[i].IdCinema);
            }
        }

        [TestMethod]
        public void GetHallTest()
        {
            HallModel expected = new HallModel(3, 3);
            HallModel result = hallLogic.GetHall(3);

            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.IdCinema, result.IdCinema);
        }

        [TestMethod]
        public void GetFKCinemaTest()
        {
            long id = 4;
            List<HallModel> expected = hallLogic.GetFKCinema(id);

            expected.Add(hallLogic.GetHall(hallLogic.AddHall(id)));
            expected.Add(hallLogic.GetHall(hallLogic.AddHall(id)));
            expected.Add(hallLogic.GetHall(hallLogic.AddHall(id)));



            List<HallModel> result = hallLogic.GetFKCinema(id);

            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].IdCinema, result[i].IdCinema);
            }
        }

        [TestMethod]
        public void GetHallByIdMovieTest()
        {
            List<HallModel> expected = new List<HallModel>()
            {
                new HallModel(1,1)
            };

            List<HallModel> result = hallLogic.GetHallByIdMovie(1,1);

            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].IdCinema, result[i].IdCinema);
            }

        }

        [TestMethod]
        public void GetHallByIdCinemaTest()
        {
            List<HallModel> expected = new List<HallModel>()
            {
                new HallModel(1,1)
            };

            List<HallModel> result = hallLogic.GetHallByIdCinema(1);

            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].IdCinema, result[i].IdCinema);
            }
        }
    }
}
