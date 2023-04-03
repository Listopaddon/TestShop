using BusinessLogic.LogicBusiness.PlaceSession;
using DataAccess.Models;
using DataAccess.Repositories;
using DataAccess.Repositories.PlaceSession;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IntegerTestsBusinessLogic.PlaceSessionTests
{
    [TestClass]
    public class PlaceSessionLogicTests
    {
        PlaceSessionLogic psLogic;
        string connectionString = ConnectionString.connectionStringFake;

        [TestInitialize]
        public void Initialize()
        {
            psLogic = new PlaceSessionLogic(new PlaceSessionRepository(connectionString));
        }

        [TestMethod]
        public void AddPlaceSessionTest()
        {
            long result = psLogic.AddPlaceSession(3, 3, 3, StatePlace.Book);
            long expected = psLogic.GetPlaceSession(result).Id;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DeletePlaceSessionTest()
        {
            long id = psLogic.AddPlaceSession(3, 3, 3, StatePlace.Book);
            psLogic.DeletePlaceSession(id);
            Assert.IsNull(psLogic.GetPlaceSession(id));
        }

        [TestMethod]
        public void UpdatePlaceSessionTest()
        {
            long id = psLogic.AddPlaceSession(3, 4, 3, StatePlace.Book);
            PlaceSessionModel expected = new PlaceSessionModel(id, 3, 3, 3, new DateTime(20, 00), StatePlace.Book);
            psLogic.UpdatePlaceSession(expected);
            PlaceSessionModel result = psLogic.GetPlaceSession(id);

            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.IdPlaces, result.IdPlaces);
            Assert.AreEqual(expected.IdSession, result.IdSession);
            Assert.AreEqual(expected.IdUsers, result.IdUsers);
            Assert.AreEqual(expected.DateModified, result.DateModified);
            Assert.AreEqual(expected.State, result.State);
        }

        [TestMethod]
        public void GetPlaceSessionTest()
        {
            long id = psLogic.AddPlaceSession(3, 4, 3, StatePlace.Book);
            PlaceSessionModel expected = new PlaceSessionModel(id, 3, 4, 3, new DateTime(20,00),StatePlace.Book);
            PlaceSessionModel result = psLogic.GetPlaceSession(id);

            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.IdPlaces, result.IdPlaces);
            Assert.AreEqual(expected.IdSession, result.IdSession);
            Assert.AreEqual(expected.IdUsers, result.IdUsers);
            Assert.AreEqual(expected.DateModified, result.DateModified);
            Assert.AreEqual(expected.State, result.State);
        }

        [TestMethod]
        public void GetPlaceSessionsTest()
        {
            List<PlaceSessionModel> expected = psLogic.GetPlaceSessions();
            expected.Add(psLogic.GetPlaceSession(psLogic.AddPlaceSession(3, 3, 3,StatePlace.Book)));

            List<PlaceSessionModel> result = psLogic.GetPlaceSessions();

            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].IdPlaces, result[i].IdPlaces);
                Assert.AreEqual(expected[i].IdSession, result[i].IdSession);
                Assert.AreEqual(expected[i].IdUsers, result[i].IdUsers);
                Assert.AreEqual(expected[i].DateModified, result[i].DateModified);
                Assert.AreEqual(expected[i].State, result[i].State);
            }
        }

        [TestMethod]
        public void GetPlaceSessionFKPlacesTest()
        {
            long id = 3;
            List<PlaceSessionModel> expected = psLogic.GetPlaceSessionFKPlaces(id);
            expected.Add(psLogic.GetPlaceSession(psLogic.AddPlaceSession(1, 1, 4, StatePlace.Book)));
            expected.Add(psLogic.GetPlaceSession(psLogic.AddPlaceSession(1, 3, 4, StatePlace.Book)));
            expected.Add(psLogic.GetPlaceSession(psLogic.AddPlaceSession(1, 1, 3, StatePlace.Book)));

            List<PlaceSessionModel> result = psLogic.GetPlaceSessionFKPlaces(id);

            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].IdPlaces, result[i].IdPlaces);
                Assert.AreEqual(expected[i].IdSession, result[i].IdSession);
                Assert.AreEqual(expected[i].IdUsers, result[i].IdUsers);
                Assert.AreEqual(expected[i].DateModified, result[i].DateModified);
                Assert.AreEqual(expected[i].State, result[i].State);
            }
        }

        [TestMethod]
        public void GetPlaceSessionFKSessionTest()
        {
            long id = 3;
            List<PlaceSessionModel> expected = psLogic.GetPlaceSessionFKSession(id);
            expected.Add(psLogic.GetPlaceSession(psLogic.AddPlaceSession(3, 3, 3, StatePlace.Book)));
            expected.Add(psLogic.GetPlaceSession(psLogic.AddPlaceSession(1, 3, 4, StatePlace.Book)));
            expected.Add(psLogic.GetPlaceSession(psLogic.AddPlaceSession(3, 3, 3, StatePlace.Book)));

            List<PlaceSessionModel> result = psLogic.GetPlaceSessionFKSession(id);

            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].IdPlaces, result[i].IdPlaces);
                Assert.AreEqual(expected[i].IdSession, result[i].IdSession);
                Assert.AreEqual(expected[i].IdUsers, result[i].IdUsers);
                Assert.AreEqual(expected[i].DateModified, result[i].DateModified);
                Assert.AreEqual(expected[i].State, result[i].State);
            }
        }

        [TestMethod]
        public void GetPlaceSessionFKUserTest()
        {
            long id = 3;
            List<PlaceSessionModel> expected = psLogic.GetPlaceSessionFKUser(id);
            expected.Add(psLogic.GetPlaceSession(psLogic.AddPlaceSession(3, 1, 3, StatePlace.Book)));
            expected.Add(psLogic.GetPlaceSession(psLogic.AddPlaceSession(3, 3, 3, StatePlace.Book)));
            expected.Add(psLogic.GetPlaceSession(psLogic.AddPlaceSession(1, 3, 3, StatePlace.Book)));

            List<PlaceSessionModel> result = psLogic.GetPlaceSessionFKUser(id);

            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].IdPlaces, result[i].IdPlaces);
                Assert.AreEqual(expected[i].IdSession, result[i].IdSession);
                Assert.AreEqual(expected[i].IdUsers, result[i].IdUsers);
                Assert.AreEqual(expected[i].DateModified, result[i].DateModified);
                Assert.AreEqual(expected[i].State, result[i].State);
            }
        }

        [TestMethod]
        public void DeleteIdPlaceFromPlaceSession()
        {
            psLogic.DeleteIdPlaceFromPlaceSession(3);
            List<PlaceSessionModel> result = psLogic.GetPlaceSessionFKPlaces(3);

            Assert.AreEqual(result.Count, 0);
        }

        [TestMethod]
        public void DeleteIdSessionFromPlaceSession()
        {
            psLogic.DeleteIdSessionFromPlaceSession(3);
            List<PlaceSessionModel> result = psLogic.GetPlaceSessionFKSession(3);

            Assert.AreEqual(result.Count, 0);
        }

        [TestMethod]
        public void DeleteIdUserFromPlaceSession()
        {
            psLogic.DeleteIdUserFromPlaceSession(3);
            List<PlaceSessionModel> result = psLogic.GetPlaceSessionFKUser(3);

            Assert.AreEqual(result.Count, 0);
        }
    }
}
