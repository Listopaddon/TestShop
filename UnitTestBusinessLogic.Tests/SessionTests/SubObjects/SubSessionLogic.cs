using BusinessLogic.LogicBusiness.Session;
using DataAccess.Models;
using System.Collections.Generic;

namespace UnitTestBusinessLogic.Tests.SessionTests.SubObjects
{
    internal class SubSessionLogic : ISessionLogic
    {
        public long AddSession(long idMovie, long idArea, decimal price) => 0;

        public void DeleteIdHallFromSession(long idHall) { }

        public void DeleteSession(long id) { }

        public List<MovieSessionModel> GetAllSessionsAndMovies() => new List<MovieSessionModel>();

        public List<SessionModel> GetFkHall(long idHall) => new List<SessionModel>();

        public SessionModel GetSession(long id) => new SessionModel();

        public List<SessionModel> GetSessions() => new List<SessionModel>();

        public List<SessionModel> GetSessionsByMovie(long idMovie) => new List<SessionModel>();

        public void UpdateSession(SessionModel session) { }
    }
}
