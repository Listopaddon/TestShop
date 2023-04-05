using BusinessLogic.LogicBusiness.Cinema;
using DataAccess.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using UnitTestBusinessLogic.Tests.HallTests.SubObjects;

namespace UnitTestBusinessLogic.Tests.CinemaTests
{
    [TestClass]
    public class CinemaLogicTests
    {
        CinemaLogic cinemaLogic;

        [TestInitialize]

        [TestMethod]
        public void Initialize()
        {
            List<CinemaModel> cinemas = new List<CinemaModel>
            {
                new CinemaModel(0,"October","pic"),
                new CinemaModel(1,"Kalinino","pic"),
                new CinemaModel(2,"Mir","pic"),
                new CinemaModel(3,"Ostrov","pic"),
                new CinemaModel(4,"Pushkino","pic"),
                new CinemaModel(5,"Tolstogo","pic")
            };
            cinemaLogic = new CinemaLogic(new SubCinemaRepository(cinemas), new SubHallLogic());
        }

        [TestMethod]
        public void AddCinemaTest() => Assert.AreEqual(6, cinemaLogic.AddCinema("Lemontov", "pic"));

        [TestMethod]
        public void DeleteCinemaTest()
        {
            //Arrange
            long id = 4;
            CinemaModel result = null;
            List<CinemaModel> cinemaDtos = cinemaLogic.GetCinemas();

            //Act
            cinemaLogic.DeleteCinema(id);
            for (int i = 0; i < cinemaDtos.Count; i++)
            {
                if (cinemaDtos[i].Id == id)
                {
                    result = cinemaDtos[i];
                    break;
                }
            }

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetCinemasTest()
        {
            //Arrange
            List<CinemaModel> expected = new List<CinemaModel>
            {
                new CinemaModel(0,"October","pic"),
                new CinemaModel(1,"Kalinino","pic"),
                new CinemaModel(2,"Mir","pic"),
                new CinemaModel(3,"Ostrov","pic"),
                new CinemaModel(4,"Pushkino","pic"),
                new CinemaModel(5,"Tolstogo","pic")
            };

            //Act
            List<CinemaModel> result = cinemaLogic.GetCinemas();

            //Assert
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].Name, result[i].Name);
                Assert.AreEqual(expected[i].Picture, result[i].Picture);
            }
        }

        [TestMethod]
        public void UpdateCinemaTest()
        {
            //Arrange
            List<CinemaModel> cinemas = cinemaLogic.GetCinemas();
            CinemaModel expected = new CinemaModel(2, "Replace", "pic");

            //Act
            cinemaLogic.UpdateCinema(new CinemaModel(2, "Replace", "pic"));

            //Assert
            Assert.AreEqual(expected.Id, cinemas[2].Id);
            Assert.AreEqual(expected.Name, cinemas[2].Name);
            Assert.AreEqual(expected.Picture, cinemas[2].Picture);
        }

        [TestMethod]
        public void GetIdCinemaByFilmFromSessionTest()
        {
            //Arrange
            List<CinemaModel> expected = new List<CinemaModel>()
            {
                new CinemaModel(2,"Mir","pic")
            };

            //Act
            List<CinemaModel> result = cinemaLogic.GetIdCinemaByFilmFromSession(1);

            //Assert
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].Name, result[i].Name);
                Assert.AreEqual(expected[i].Picture, result[i].Picture);
            }
        }
    }
}
