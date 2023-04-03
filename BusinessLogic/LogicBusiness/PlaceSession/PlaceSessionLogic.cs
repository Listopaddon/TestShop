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

        public long AddPlaceSession(long idPlaces, long idSession, long idUser, StatePlace state) =>
                                placeSessionRepository.AddPlaceSession(idPlaces, idSession, idUser, state, DateTime.Now);

        public void DeletePlaceSession(long idPlaceSession) => placeSessionRepository.DeletePlaceSession(idPlaceSession);

        public void UpdatePlaceSession(PlaceSessionModel placeSession) => placeSessionRepository.UpdatePlaceSession(placeSession);


        public List<PlaceSessionModel> GetPlaceSessions() => placeSessionRepository.GetPlaceSessions();

        public List<PlaceSessionModel> GetPlaceSessionFKPlaces(long idPlace) => placeSessionRepository.GetPlaceSessionFKPlaces(idPlace);

        public List<PlaceSessionModel> GetPlaceSessionFKSession(long idSession) => placeSessionRepository.GetPlaceSessionFKSession(idSession);

        public List<PlaceSessionModel> GetPlaceSessionFKUser(long idUser) => placeSessionRepository.GetPlaceSessionFKUser(idUser);

        public PlaceSessionModel GetPlaceSession(long idPlaceSession) => placeSessionRepository.GetPlaceSession(idPlaceSession);

        public void DeleteIdSessionFromPlaceSession(long idSession) => placeSessionRepository.DeleteIdSessionFromPlaceSession(idSession);

        public void DeleteIdUserFromPlaceSession(long idUser) => placeSessionRepository.DeleteIdUserFromPlaceSession(idUser);

        public void DeleteIdPlaceFromPlaceSession(long idPlace)
        {
            List<PlaceSessionModel> placeSessions = placeSessionRepository.GetPlaceSessionFKPlaces(idPlace);
            for (int i = 0; i < placeSessions.Count; i++)
            {
                placeSessionRepository.DeleteIdPlaceFromPlaceSession(placeSessions[i].IdPlaces);
            }
        }
    }
}
