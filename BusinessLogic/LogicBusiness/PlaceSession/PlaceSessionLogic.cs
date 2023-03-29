using DataAccess.Models;
using DataAccess.Repositories.PlaceSession;
using System;
using System.Collections.Generic;

namespace BusinessLogic.LogicBusiness.PlaceSession
{
    public class PlaceSessionLogic : IPlaceSessionLogic
    {
        IPlaceSessionRepository placeSessionRepository;

        public PlaceSessionLogic(IPlaceSessionRepository placeSessionRepository)
        {
            this.placeSessionRepository = placeSessionRepository;
        }

        public long AddPlaceSession(long idPlaces, long idSession, long idUser, StatePlace state)
        {
            return placeSessionRepository.AddPlaceSession(idPlaces, idSession, idUser, state, DateTime.Now);
        }

        public void DeletePlaceSession(long id)
        {
            placeSessionRepository.DeletePlaceSession(id);
        }

        public void UpdatePlaceSession(PlaceSessionModel placeSession)
        {
            placeSessionRepository.UpdatePlaceSession(placeSession);
        }

        public List<PlaceSessionModel> GetPlaceSessions()
        {
            return placeSessionRepository.GetPlaceSessions();
        }

        public List<PlaceSessionModel> GetPlaceSessionFKPlaces(long idPlace)
        {
            return placeSessionRepository.GetPlaceSessionFKPlaces(idPlace);
        }

        public List<PlaceSessionModel> GetPlaceSessionFKSession(long idSession)
        {
            return placeSessionRepository.GetPlaceSessionFKSession(idSession);
        }

        public List<PlaceSessionModel> GetPlaceSessionFKUser(long idUser)
        {
            return placeSessionRepository.GetPlaceSessionFKUser(idUser);
        }

        public PlaceSessionModel GetPlaceSession(long id)
        {
            return placeSessionRepository.GetPlaceSession(id);
        }

        public void DeleteIdPlaceFromPlaceSession(long idPlace)
        {
            List<PlaceSessionModel> placeSessions = placeSessionRepository.GetPlaceSessionFKPlaces(idPlace);
            for (int i = 0; i < placeSessions.Count; i++)
            {
                placeSessionRepository.DeleteIdPlaceFromPlaceSession(placeSessions[i].IdPlaces);
            }

        }

        public void DeleteIdSessionFromPlaceSession(long idSession)
        {
            placeSessionRepository.DeleteIdSessionFromPlaceSession(idSession);
        }

        public void DeleteIdUserFromPlaceSession(long idUser)
        {
            placeSessionRepository.DeleteIdUserFromPlaceSession(idUser);
        }
    }
}
