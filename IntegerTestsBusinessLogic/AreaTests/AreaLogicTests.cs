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

namespace IntegerTestsBusinessLogic.AreaTests
{
    [TestClass]
    public class AreaLogicTests
    {
        AreaLogic areaLogic;
        RowLogic rowLogic;
        PlaceLogic placeLogic;
        HallLogic hallLogic;
        CinemaLogic cinemaLogic;
        SessionLogic sessionLogic;
        PlaceSessionLogic placeSessionLogic;
        string connectionString = ConnectionString.connectionStringFake;
        long idCinema;
        long idHall;
        long idArea;

        [TestInitialize]
        public void Initializide()
        {
            placeLogic = new PlaceLogic(new PlaceRepository(connectionString), new PlaceSessionLogic(new PlaceSessionRepository(connectionString)));
            rowLogic = new RowLogic(new RowRepository(connectionString), placeLogic);
            areaLogic = new AreaLogic(new AreaRepository(connectionString), rowLogic, placeLogic);
            placeSessionLogic = new PlaceSessionLogic(new PlaceSessionRepository(connectionString));
            sessionLogic = new SessionLogic(new SessionRepository(connectionString), placeSessionLogic);
            hallLogic = new HallLogic(new HallRepository(connectionString), areaLogic, sessionLogic);
            cinemaLogic = new CinemaLogic(new CinemaRepository(connectionString), hallLogic);

            idCinema = cinemaLogic.AddCinema("TestCinemaByUpdate", "img");
            idHall = hallLogic.AddHall(idCinema);
            idArea = areaLogic.AddArea(idHall);
        }

        [TestMethod]
        public void AddAreaTest()
        {
            //Act
            long result = areaLogic.AddArea(idHall);
            long expected = areaLogic.GetArea(result).Id;

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DeleteAreaTest()
        {
            //Arrange            
            long id = areaLogic.AddArea(idHall);

            //Act
            areaLogic.DeleteArea(id);

            //Assert
            Assert.IsNull(areaLogic.GetArea(id));
        }

        [TestMethod]
        public void UpdateAreaTest()
        {
            //Arrange
            long idHallForUpdate = hallLogic.AddHall(cinemaLogic.AddCinema("TestCinemaByUpdateIsTrue", "img"));
            AreaModel expected = new AreaModel(idArea, idHallForUpdate);

            //Act
            areaLogic.UpdateArea(new AreaModel(idArea, idHallForUpdate));
            AreaModel result = areaLogic.GetArea(idArea);

            //Assert
            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.IdHall, result.IdHall);
        }

        [TestMethod]
        public void GetAreasTest()
        {
            //Arrange
            List<AreaModel> expected = areaLogic.GetAreas();
            expected.Add(areaLogic.GetArea(areaLogic.AddArea(idHall)));
            expected.Add(areaLogic.GetArea(areaLogic.AddArea(idHall)));

            //Act
            List<AreaModel> result = areaLogic.GetAreas();

            //Assert
            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].IdHall, result[i].IdHall);
            }
        }

        [TestMethod]
        public void GetFKHallTest()
        {
            //Arrange
            List<AreaModel> expected = areaLogic.GetFKHall(idHall);
            expected.Add(areaLogic.GetArea(areaLogic.AddArea(idHall)));
            expected.Add(areaLogic.GetArea(areaLogic.AddArea(idHall)));
            expected.Add(areaLogic.GetArea(areaLogic.AddArea(idHall)));

            //Act
            List<AreaModel> result = areaLogic.GetFKHall(idHall);

            //Assert
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].IdHall, result[i].IdHall);
            }
        }

        [TestMethod]
        public void GetAreaTest()
        {
            //Arrange
            AreaModel expected = new AreaModel(idArea, idHall);

            //Act
            AreaModel result = areaLogic.GetArea(idArea);

            //Assert
            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.IdHall, result.IdHall);
        }

        [TestMethod]
        public void DeleteIdHallFromArea()
        {
            //Arrange
            List<AreaModel> expected = new List<AreaModel>();
            areaLogic.AddArea(idHall);
            areaLogic.AddArea(idHall);

            //Act
            areaLogic.DeleteIdHallFromArea(idHall);
            List<AreaModel> areas = areaLogic.GetFKHall(idHall);
            for (int i = 0; i < areas.Count; i++)
            {
                if (areas[i].IdHall == idHall)
                {
                    expected.Add(areas[i]);
                }
            }

            //Assert
            Assert.AreEqual(expected.Count, 0);
        }
    }
}
