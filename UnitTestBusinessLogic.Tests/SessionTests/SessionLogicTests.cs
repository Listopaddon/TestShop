using BusinessLogic.LogicBusiness.Hall;
using BusinessLogic.LogicBusiness.Session;
using DataAccess.Models;
using DataAccess.Repositories.Hall;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using UnitTestBusinessLogic.Tests.PlaceSessionTests.SubObjects;
using UnitTestBusinessLogic.Tests.SessionTests.SubObjects;

namespace UnitTestBusinessLogic.Tests.SessionTests
{
    [TestClass]
    public class SessionLogicTests
    {
        SessionLogic sessionLogic;

        [TestInitialize]
        public void Initialize()
        {
            List<SessionModel> sessions = new List<SessionModel>
            {
                new SessionModel(0,1,4,4),
                new SessionModel(1,1,2,3),
                new SessionModel(2,2,2,4),
                new SessionModel(3,3,1,5),
                new SessionModel(4,1,3,4),
                new SessionModel(5,4,2,6)
            };
            sessionLogic = new SessionLogic(new SubSessionRepository(sessions), new SubPlaceSessionLogic());
        }

        [TestMethod]
        public void AddSessiontest()=> Assert.AreEqual(6, sessionLogic.AddSession(2, 2, 2));

        [TestMethod]
        public void DeleteSessionTest()
        {
            //Arrange
            SessionModel result = null;
            long id = 3;
            List<SessionModel> sessions = sessionLogic.GetSessions();

            //Act
            sessionLogic.DeleteSession(id);
            for (int i = 0; i < sessions.Count; i++)
            {
                if (sessions[i].Id == id)
                {
                    result = sessions[i];
                    break;
                }
            }

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetFkHallTest()
        {
            //Arrange
            List<SessionModel> expected = new List<SessionModel>
            {
                new SessionModel(1,1,2,3),
                new SessionModel(2,2,2,4),
                new SessionModel(5,4,2,6)
            };

            //Act
            List<SessionModel> result = sessionLogic.GetFkHall(2);

            //Assert
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].IdHall, result[i].IdHall);
                Assert.AreEqual(expected[i].IdMovie, result[i].IdMovie);
                Assert.AreEqual(expected[i].Price, result[i].Price);
            }
        }

        [TestMethod]
        public void GetSessionTest()
        {
            //Arrange
            SessionModel expected = new SessionModel(3, 3, 1, 5);

            //Act
            SessionModel result = sessionLogic.GetSession(3);

            //Assert
            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.IdHall, result.IdHall);
            Assert.AreEqual(expected.IdMovie, result.IdMovie);
            Assert.AreEqual(expected.Price, result.Price);
        }

        [TestMethod]
        public void GetSessionsTest()
        {
            //Arrange
            List<SessionModel> expected = new List<SessionModel>
            {
                new SessionModel(0,1,4,4),
                new SessionModel(1,1,2,3),
                new SessionModel(2,2,2,4),
                new SessionModel(3,3,1,5),
                new SessionModel(4,1,3,4),
                new SessionModel(5,4,2,6)
            };

            //Act
            List<SessionModel> result = sessionLogic.GetSessions();

            //Assert
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].IdHall, result[i].IdHall);
                Assert.AreEqual(expected[i].IdMovie, result[i].IdMovie);
                Assert.AreEqual(expected[i].Price, result[i].Price);
            }

        }

        [TestMethod]
        public void UpdateSessionTest()
        {
            //Arrange
            SessionModel expected = new SessionModel(3, 10, 10, 10);
            sessionLogic.UpdateSession(expected);

            //Act
            List<SessionModel> sessions = sessionLogic.GetSessions();

            //Assert
            Assert.AreEqual(expected.Id, sessions[3].Id);
            Assert.AreEqual(expected.IdHall, sessions[3].IdHall);
            Assert.AreEqual(expected.IdMovie, sessions[3].IdMovie);
            Assert.AreEqual(expected.Price, sessions[3].Price);

        }

        [TestMethod]
        public void DeleteFKSessionsTest()
        {
            //Arrange
            long id = 2;
            List<SessionModel> expected = new List<SessionModel>();

            //Act
            sessionLogic.DeleteIdHallFromSession(id);
            expected = sessionLogic.GetFkHall(id);

            //Assert
            Assert.AreEqual(0, expected.Count);
        }
    }
}
