using System.Collections.Generic;
using DataAccess.Repositories.Session;
using DataAccess.Models;
using BusinessLogic.LogicBusiness.PlaceSession;

namespace BusinessLogic.LogicBusiness.Session
{
    public class SessionLogic : ISessionLogic
    {
        ISessionRepository sessionRepository;
        IPlaceSessionLogic placeSessionLogic;

        public SessionLogic(ISessionRepository sessionRepository, IPlaceSessionLogic placeSessionLogic)
        {
            this.sessionRepository = sessionRepository;
            this.placeSessionLogic = placeSessionLogic;
        }

        public long AddSession(long idMovie, long idHall, decimal price) => sessionRepository.AddSession(idMovie, idHall, price);

        public void DeleteIdHallFromSession(long idHall) => sessionRepository.DeleteIdHallFromSession(idHall);

        public List<MovieSessionModel> GetAllSessionsAndMovies() => sessionRepository.GetAllSessionsAndMovies();

        public List<SessionModel> GetSessionsByMovie(long idMovie) => sessionRepository.GetSessionsByMovie(idMovie);

        public void UpdateSession(SessionModel session) => sessionRepository.UpdateSession(session);

        public List<SessionModel> GetSessions() => sessionRepository.GetSessions();

        public SessionModel GetSession(long id) => sessionRepository.GetSession(id);

        public List<SessionModel> GetFkHall(long idHall) => sessionRepository.GetFkHall(idHall);

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

        public void DeleteSession(long id)
        {
            placeSessionLogic.DeleteIdSessionFromPlaceSession(id);
            sessionRepository.DeleteSession(id);
        }


    }
}
