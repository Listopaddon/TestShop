using BusinessLogic.LogicBusiness.PlaceSession;
using DataAccess.Models;
using System.Collections.Generic;

namespace UnitTestBusinessLogic.Tests.PlaceSessionTests.SubObjects
{
    public class SubPlaceSessionLogic : IPlaceSessionLogic
    {
        public long AddPlaceSession(long idPlaces, long idSession, long idUser, StatePlace state) => 0;

        public void DeleteIdPlaceFromPlaceSession(long idPlace) { }

        public void DeleteIdSessionFromPlaceSession(long idSession) { }

        public void DeleteIdUserFromPlaceSession(long idUser) { }

        public void DeletePlaceSession(long id) { }

        public PlaceSessionModel GetPlaceSession(long id) => null;

        public List<PlaceSessionModel> GetPlaceSessionFKPlaces(long idPlace) => null;

        public List<PlaceSessionModel> GetPlaceSessionFKSession(long idSession) => null;

        public List<PlaceSessionModel> GetPlaceSessionFKUser(long idUser) => null;

        public List<PlaceSessionModel> GetPlaceSessions() => null;

        public void UpdatePlaceSession(PlaceSessionModel placeSession) { }
    }
}
