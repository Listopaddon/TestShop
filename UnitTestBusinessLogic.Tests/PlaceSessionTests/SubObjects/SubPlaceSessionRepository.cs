using DataAccess.Models;
using DataAccess.Repositories.PlaceSession;
using System;
using System.Collections.Generic;

namespace UnitTestBusinessLogic.Tests.PlaceSessionTests
{
    public class SubPlaceSessionRepository : IPlaceSessionRepository
    {
        List<PlaceSessionModel> placeSessions;

        public SubPlaceSessionRepository(List<PlaceSessionModel> placeSessions)
        {
            this.placeSessions = placeSessions;
        }

        public long AddPlaceSession(long idPlaces, long idSession, long idUser, StatePlace state, DateTime dateTime)
        {
            long id = placeSessions.Count;
            placeSessions.Add(new PlaceSessionModel(id, idPlaces, idSession, idUser,dateTime,state));
            return id;
        }

        public void DeleteIdPlaceFromPlaceSession(long idPlace)
        {
            for (int i = 0; i < placeSessions.Count; i++)
            {
                if (placeSessions[i].IdPlaces == idPlace)
                {
                    placeSessions.Remove(placeSessions[i]);
                    i = -1;
                }
            }
        }

        public void DeleteIdSessionFromPlaceSession(long idSession)
        {
            for (int i = 0; i < placeSessions.Count; i++)
            {
                if (placeSessions[i].IdSession == idSession)
                {
                    placeSessions.Remove(placeSessions[i]);
                    i = -1;
                }
            }
        }

        public void DeleteIdUserFromPlaceSession(long idUser)
        {
            for (int i = 0; i < placeSessions.Count; i++)
            {
                if (placeSessions[i].IdUsers == idUser)
                {
                    placeSessions.Remove(placeSessions[i]);
                    i = -1;
                }
            }
        }

        public void DeletePlaceSession(long id)
        {
            for (int i = 0; i < placeSessions.Count; i++)
            {
                if (placeSessions[i].Id == id)
                {
                    placeSessions.Remove(placeSessions[i]);
                    break;
                }
            }
        }

        public PlaceSessionModel GetPlaceSession(long id)
        {
            PlaceSessionModel result = null;

            for (int i = 0; i < placeSessions.Count; i++)
            {
                if (placeSessions[i].Id == id)
                {
                    result = placeSessions[i];
                }
            }
            return result;
        }

        public List<PlaceSessionModel> GetPlaceSessionFKPlaces(long idPlace)
        {
            List<PlaceSessionModel> result = new List<PlaceSessionModel>();

            for (int i = 0; i < placeSessions.Count; i++)
            {
                if (placeSessions[i].IdPlaces == idPlace)
                {
                    result.Add(placeSessions[i]);
                }
            }

            return result;
        }

        public List<PlaceSessionModel> GetPlaceSessionFKSession(long idSession)
        {
            List<PlaceSessionModel> result = new List<PlaceSessionModel>();

            for (int i = 0; i < placeSessions.Count; i++)
            {
                if (placeSessions[i].IdSession == idSession)
                {
                    result.Add(placeSessions[i]);
                }
            }
            return result;
        }

        public List<PlaceSessionModel> GetPlaceSessionFKUser(long idUser)
        {
            List<PlaceSessionModel> result = new List<PlaceSessionModel>();

            for (int i = 0; i < placeSessions.Count; i++)
            {
                if (placeSessions[i].IdUsers == idUser)
                {
                    result.Add(placeSessions[i]);
                }
            }

            return result;
        }

        public List<PlaceSessionModel> GetPlaceSessions()
        {
            return placeSessions;
        }

        public void UpdatePlaceSession(PlaceSessionModel placeSession)
        {
            for (int i = 0; i < placeSessions.Count; i++)
            {
                if (placeSessions[i].Id == placeSession.Id)
                {
                    placeSessions[i] = placeSession;
                }
            }
        }
    }
}
