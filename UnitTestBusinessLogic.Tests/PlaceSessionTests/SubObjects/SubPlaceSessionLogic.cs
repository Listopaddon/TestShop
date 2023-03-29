using BusinessLogic.LogicBusiness.PlaceSession;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestBusinessLogic.Tests.PlaceSessionTests.SubObjects
{
    public class SubPlaceSessionLogic : IPlaceSessionLogic
    {
        public long AddPlaceSession(long idPlaces, long idSession, long idUser, StatePlace state)
        {
            return new PlaceSessionModel().ID;
        }

        public void DeleteIdPlaceFromPlaceSession(long idPlace) { }

        public void DeleteIdSessionFromPlaceSession(long idSession) { }

        public void DeleteIdUserFromPlaceSession(long idUser) { }

        public void DeletePlaceSession(long id) { }

        public PlaceSessionModel GetPlaceSession(long id)
        {
            return null;
        }

        public List<PlaceSessionModel> GetPlaceSessionFKPlaces(long idPlace)
        {
            return null;
        }

        public List<PlaceSessionModel> GetPlaceSessionFKSession(long idSession)
        {
            return null;
        }

        public List<PlaceSessionModel> GetPlaceSessionFKUser(long idUser)
        {
            return null;
        }

        public List<PlaceSessionModel> GetPlaceSessions()
        {
            return null;
        }

        public void UpdatePlaceSession(PlaceSessionModel placeSession) { }
    }
}
