using BusinessLogic.LogicBusiness.PlaceSession;
using BusinessLogic.LogicBusiness.Session;
using DataAccess.Models;
using DataAccess.Repositories;
using DataAccess.Repositories.PlaceSession;
using DataAccess.Repositories.Session;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace IntegerTestsBusinessLogic.SessionTests
{

    [TestClass]
    public class SessionLogicTests
    {
        SessionLogic sLogic;
        string connectionString = ConnectionString.connectionStringFake;

        [TestInitialize]
        public void Initialize()
        {
            sLogic = new SessionLogic(new SessionRepository(connectionString),
                                      new PlaceSessionLogic(new PlaceSessionRepository(connectionString))); 
        }

        [TestMethod]
        public void AddSessionTest()
        {
            long result = sLogic.AddSession(2, 3, 1200);
            long expected = sLogic.GetSession(result).Id;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DeleteSessionTest()
        {
            long id = sLogic.AddSession(2, 3, 1200);
            sLogic.DeleteSession(id);
            SessionModel result = sLogic.GetSession(id);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void UpdateSessionTest()
        {
            long id = sLogic.AddSession(2, 3, 1200);
            SessionModel expected = new SessionModel(id, 3, 3, 5000);
            sLogic.UpdateSession(expected);
            SessionModel result = sLogic.GetSession(id);

            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.IdHall, result.IdHall);
            Assert.AreEqual(expected.IdMovie, result.IdMovie);
            Assert.AreEqual(expected.Price, result.Price);
        }

        [TestMethod]
        public void GetSessionsTest()
        {
            List<SessionModel> expected = sLogic.GetSessions();
            expected.Add(sLogic.GetSession(sLogic.AddSession(3, 3, 100)));

            List<SessionModel> result = sLogic.GetSessions();

            for (int i = 0; i < result.Count; i++)
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
            long id = sLogic.AddSession(2, 3, 1200);
            SessionModel expected = new SessionModel(id, 2, 3, 1200);
            SessionModel result = sLogic.GetSession(id);

            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.IdHall, result.IdHall);
            Assert.AreEqual(expected.IdMovie, result.IdMovie);
            Assert.AreEqual(expected.Price, result.Price);
        }

        [TestMethod]
        public void GetFKHallTest()
        {
            long id = 3;
            List<SessionModel> expected = sLogic.GetFkHall(id);
            expected.Add(sLogic.GetSession(sLogic.AddSession(2, 3, 400)));

            List<SessionModel> result = sLogic.GetFkHall(id);

            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].IdHall, result[i].IdHall);
                Assert.AreEqual(expected[i].IdMovie, result[i].IdMovie);
                Assert.AreEqual(expected[i].Price, result[i].Price);
            }
        }

        [TestMethod]
        public void DeleteFKSessionsTest()
        {
            int expected = 0;
            long id = 2;
            List<SessionModel> result = sLogic.GetFkHall(id);
            sLogic.DeleteFKSessions(result);
            result = sLogic.GetFkHall(id);

            Assert.AreEqual(expected, result.Count);

        }
    }
}
