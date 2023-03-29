using BusinessLogic.LogicBusiness.PlaceSession;
using DataAccess.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestBusinessLogic.Tests.PlaceSessionTests
{
    [TestClass]
    public class PlaceSessionLogicTests
    {
        PlaceSessionLogic placeSessionLogic;

        [TestInitialize]
        public void Initialize()
        {
            List<PlaceSessionModel> placeSession = new List<PlaceSessionModel>
            {
                new PlaceSessionModel(0,3,40,5,new DateTime(20,00),StatePlace.Buy),
                new PlaceSessionModel(1,32,41,15,new DateTime(20,00),StatePlace.Buy),
                new PlaceSessionModel(2,3,30,25,new DateTime(20,00),StatePlace.Buy),
                new PlaceSessionModel(3,3,43,15,new DateTime(20,00),StatePlace.Buy),
                new PlaceSessionModel(4,35,40,45,new DateTime(20,00),StatePlace.Buy),
                new PlaceSessionModel(5,36,14,15,new DateTime(20,00),StatePlace.Buy)
            };

            placeSessionLogic = new PlaceSessionLogic(new SubPlaceSessionRepository(placeSession));
        }

        [TestMethod]
        public void AddPlaceSessionTest()
        {
            Assert.AreEqual(6, placeSessionLogic.AddPlaceSession(1, 1, 1, StatePlace.Buy));
        }

        [TestMethod]
        public void DeletePlaceSessionTest()
        {
            PlaceSessionModel result = null;
            long id = 2;
            List<PlaceSessionModel> places = placeSessionLogic.GetPlaceSessions();
            placeSessionLogic.DeletePlaceSession(id);

            for (int i = 0; i < places.Count; i++)
            {
                if (places[i].ID == id)
                {
                    result = places[i];
                    break;
                }
            }

            Assert.IsNull(result);
        }

        [TestMethod]
        public void UpdatePlaceSessionTest()
        {
            PlaceSessionModel expected = new PlaceSessionModel(2, 1, 1, 1, new DateTime(20, 00), StatePlace.Buy);
            placeSessionLogic.UpdatePlaceSession(expected);
            List<PlaceSessionModel> places = placeSessionLogic.GetPlaceSessions();

            Assert.AreEqual(expected.ID, places[2].ID);
            Assert.AreEqual(expected.IdPlaces, places[2].IdPlaces);
            Assert.AreEqual(expected.IdSession, places[2].IdSession);
            Assert.AreEqual(expected.IdUsers, places[2].IdUsers);
            Assert.AreEqual(expected.State, places[2].State);
            Assert.AreEqual(expected.DateModified, places[2].DateModified);
        }

        [TestMethod]
        public void GetPlaceSessionsTest()
        {
            List<PlaceSessionModel> expected = new List<PlaceSessionModel>
            {
                new PlaceSessionModel(0,3,40,5,new DateTime(20, 00), StatePlace.Buy),
                new PlaceSessionModel(1,32,41,15,new DateTime(20, 00), StatePlace.Buy),
                new PlaceSessionModel(2,3,30,25,new DateTime(20, 00), StatePlace.Buy),
                new PlaceSessionModel(3,3,43,15,new DateTime(20, 00), StatePlace.Buy),
                new PlaceSessionModel(4,35,40,45,new DateTime(20, 00), StatePlace.Buy),
                new PlaceSessionModel(5,36,14,15,new DateTime(20, 00), StatePlace.Buy)
            };
            List<PlaceSessionModel> result = placeSessionLogic.GetPlaceSessions();

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].ID, result[i].ID);
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
            List<PlaceSessionModel> expected = new List<PlaceSessionModel>
            {
                new PlaceSessionModel(1,32,41,15,new DateTime(20, 00), StatePlace.Buy),
                new PlaceSessionModel(3,3,43,15,new DateTime(20, 00), StatePlace.Buy),
                new PlaceSessionModel(5,36,14,15,new DateTime(20, 00), StatePlace.Buy)
            };
            long id = 15;
            List<PlaceSessionModel> result = placeSessionLogic.GetPlaceSessionFKUser(id);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].ID, result[i].ID);
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
            List<PlaceSessionModel> expected = new List<PlaceSessionModel>
            {
                new PlaceSessionModel(0,3,40,5,new DateTime(20, 00), StatePlace.Buy),
                new PlaceSessionModel(4,35,40,45,new DateTime(20, 00), StatePlace.Buy)
            };
            long id = 40;
            List<PlaceSessionModel> result = placeSessionLogic.GetPlaceSessionFKSession(id);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].ID, result[i].ID);
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
            List<PlaceSessionModel> expected = new List<PlaceSessionModel>
            {
                new PlaceSessionModel(0,3,40,5,new DateTime(20, 00), StatePlace.Buy),
                new PlaceSessionModel(2,3,30,25,new DateTime(20, 00), StatePlace.Buy),
                new PlaceSessionModel(3,3,43,15,new DateTime(20, 00), StatePlace.Buy)
            };
            long id = 3;
            List<PlaceSessionModel> result = placeSessionLogic.GetPlaceSessionFKPlaces(id);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].ID, result[i].ID);
                Assert.AreEqual(expected[i].IdPlaces, result[i].IdPlaces);
                Assert.AreEqual(expected[i].IdSession, result[i].IdSession);
                Assert.AreEqual(expected[i].IdUsers, result[i].IdUsers);
                Assert.AreEqual(expected[i].DateModified, result[i].DateModified);
                Assert.AreEqual(expected[i].State, result[i].State);
            }
        }

        [TestMethod]
        public void GetPlaceSessionTest()
        {
            PlaceSessionModel expected = new PlaceSessionModel(2, 3, 30, 25, new DateTime(20, 00), StatePlace.Buy);
            PlaceSessionModel result = placeSessionLogic.GetPlaceSession(2);

            Assert.AreEqual(expected.ID, result.ID);
            Assert.AreEqual(expected.IdPlaces, result.IdPlaces);
            Assert.AreEqual(expected.IdSession, result.IdSession);
            Assert.AreEqual(expected.IdUsers, result.IdUsers);
            Assert.AreEqual(expected.DateModified, result.DateModified);
            Assert.AreEqual(expected.State, result.State);
        }

        [TestMethod]
        public void DeleteIdPlaceFromPlaceSession()
        {
            long idPlace = 3;
            List<PlaceSessionModel> result = new List<PlaceSessionModel>();
            List<PlaceSessionModel> placeSessions = placeSessionLogic.GetPlaceSessions();
            placeSessionLogic.DeleteIdPlaceFromPlaceSession(idPlace);

            for (int i = 0; i < placeSessions.Count; i++)
            {
                if (placeSessions[i].IdPlaces == idPlace)
                {
                    result.Add(placeSessions[i]);
                }
            }

            Assert.AreEqual(result.Count, 0);
        }

        [TestMethod]
        public void DeleteIdSessionFromPlaceSession()
        {
            long idSession = 40;
            List<PlaceSessionModel> result = new List<PlaceSessionModel>();
            List<PlaceSessionModel> placeSessions = placeSessionLogic.GetPlaceSessions();
            placeSessionLogic.DeleteIdSessionFromPlaceSession(idSession);

            for (int i = 0; i < placeSessions.Count; i++)
            {
                if (placeSessions[i].IdSession == idSession)
                {
                    result.Add(placeSessions[i]);
                }
            }

            Assert.AreEqual(result.Count, 0);
        }

        [TestMethod]
        public void DeleteIdUserFromPlaceSession()
        {
            long idUser = 15;
            List<PlaceSessionModel> result = new List<PlaceSessionModel>();
            List<PlaceSessionModel> placeSessions = placeSessionLogic.GetPlaceSessions();
            placeSessionLogic.DeleteIdUserFromPlaceSession(idUser);

            for (int i = 0; i < placeSessions.Count; i++)
            {
                if (placeSessions[i].IdUsers == idUser)
                {
                    result.Add(placeSessions[i]);
                }
            }

            Assert.AreEqual(result.Count, 0);
        }
    }
}
