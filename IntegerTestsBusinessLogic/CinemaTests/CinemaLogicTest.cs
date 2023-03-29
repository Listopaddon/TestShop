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

namespace IntegerTestsBusinessLogic.Cinema
{
    [TestClass]
    public class CinemaLogicTest
    {
        CinemaLogic cinemaLogic;
        string connectionString = ConnectionString.connectionStringFake;

        [TestInitialize]
        public void Initialize()
        {
            cinemaLogic = new CinemaLogic(new CinemaRepository(connectionString),
                                          new HallLogic(new HallRepository(connectionString),
                                                        new AreaLogic(new AreaRepository(connectionString),
                                                                      new RowLogic(new RowRepository(connectionString),
                                                                      new PlaceLogic(new PlaceRepository(connectionString),
                                                                                     new PlaceSessionLogic(new PlaceSessionRepository(connectionString))))),
                                                        new SessionLogic(new SessionRepository(connectionString),
                                                                         new PlaceSessionLogic(new PlaceSessionRepository(connectionString)))));
        }

        [TestMethod]
        public void AddCinemaTest()
        {
            long result = cinemaLogic.AddCinema("Lenin", "jpg");
            long expected = cinemaLogic.GetCinema(result).Id;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetCinemasTest()
        {
            List<CinemaModel> expected = cinemaLogic.GetCinemas();
            expected.Add(cinemaLogic.GetCinema(cinemaLogic.AddCinema("Vaselenskiy", "jpg")));

            List<CinemaModel> result = cinemaLogic.GetCinemas();

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].Name, result[i].Name);
                Assert.AreEqual(expected[i].Picture, result[i].Picture);
            }
        }

        [TestMethod]
        public void DeleteCinemaTest()
        {
            long id = cinemaLogic.AddCinema("test delete", "jpg"); ;
            cinemaLogic.DeleteCinema(id);
            Assert.IsNull(cinemaLogic.GetCinema(id));
        }

        [TestMethod]
        public void UpdateCinemaTest()
        {
            CinemaModel expected = new CinemaModel(2, "testUpdate", "jpg");
            cinemaLogic.UpdateCinema(expected);
            CinemaModel result = cinemaLogic.GetCinema(2);

            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.Name, result.Name);
            Assert.AreEqual(expected.Picture, result.Picture);
        }

        [TestMethod]
        public void GetCinema()
        {
            CinemaModel expected = new CinemaModel(3, "Мир", "jpg");
            CinemaModel result = cinemaLogic.GetCinema(3);

            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.Name, result.Name);
            Assert.AreEqual(expected.Picture, result.Picture);
        }

        [TestMethod]
        public void GetIdCinemaByFilmFromSession()
        {
            List<CinemaModel> expected = new List<CinemaModel>()
            {
                new CinemaModel(1, "Октябрь", "jpg")
            };

            List<CinemaModel> result = cinemaLogic.GetIdCinemaByFilmFromSession(1);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].Name, result[i].Name);
                Assert.AreEqual(expected[i].Picture, result[i].Picture);
            }


        }
    }
}
