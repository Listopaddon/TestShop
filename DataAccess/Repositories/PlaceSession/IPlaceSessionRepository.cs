using DataAccess.Models;
using System;
using System.Collections.Generic;

namespace DataAccess.Repositories.PlaceSession
{
    public interface IPlaceSessionRepository
    {
        public long AddPlaceSession(long idPlaces, long idSession, long idUser, StatePlace state, DateTime dateModified);
        public void DeletePlaceSession(long id);
        public void UpdatePlaceSession(PlaceSessionModel placeSession);
        public List<PlaceSessionModel> GetPlaceSessions();
        public List<PlaceSessionModel> GetPlaceSessionFKPlaces(long idPlace);
        public List<PlaceSessionModel> GetPlaceSessionFKSession(long idSession);
        public List<PlaceSessionModel> GetPlaceSessionFKUser(long idUser);
        public PlaceSessionModel GetPlaceSession(long id);
        public void DeleteIdPlaceFromPlaceSession(long idPlace);
        public void DeleteIdSessionFromPlaceSession(long idSession);
        public void DeleteIdUserFromPlaceSession(long idUser);

    }
}
