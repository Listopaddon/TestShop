using System.Collections.Generic;
using DataAccess.Repositories.Session;
using DataAccess.Models;
using BusinessLogic.LogicBusiness.PlaceSession;

namespace BusinessLogic.LogicBusiness.Session
{
    public class SessionLogic : ISessionLogic
    {
        ISessionRepository session;
        IPlaceSessionLogic placeSessionLogic;

        public SessionLogic(ISessionRepository session, IPlaceSessionLogic placeSessionLogic)
        {
            this.session = session;
            this.placeSessionLogic = placeSessionLogic;
        }

        public long AddSession(long idMovie, long idHall, decimal price)
        {
            return session.AddSession(idMovie, idHall, price);
        }

        public void DeleteSession(long id)
        {
            placeSessionLogic.DeleteIdSessionFromPlaceSession(id);
            session.DeleteSession(id);
        }

        public void UpdateSession(SessionModel session)
        {
            this.session.UpdateSession(session);
        }

        public List<SessionModel> GetSessions()
        {
            return session.GetSessions();
        }

        public SessionModel GetSession(long id)
        {
            return session.GetSession(id);
        }

        public List<SessionModel> GetFkHall(long idHall)
        {
            return session.GetFkHall(idHall);
        }

        public void DeleteFKSessions(List<SessionModel> sessionDtos)
        {
            if (sessionDtos.Count != 0)
            {
                for (int i = 0; i < sessionDtos.Count; i++)
                {
                    DeleteSession(sessionDtos[i].Id);
                }
            }
        }

        public void DeleteIdHallFromSession(long idHall)
        {
            session.DeleteIdHallFromSession(idHall);
        }

        public List<MovieSessionModel> GetAllSessionsAndMovies()
        {
            return session.GetAllSessionsAndMovies();
        }
    }
}
