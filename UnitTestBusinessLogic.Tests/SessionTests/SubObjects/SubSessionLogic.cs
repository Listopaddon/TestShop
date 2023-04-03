using BusinessLogic.LogicBusiness.Session;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestBusinessLogic.Tests.SessionTests.SubObjects
{
    internal class SubSessionLogic : ISessionLogic
    {
        public long AddSession(long idMovie, long idArea, decimal price)
        {
            return new SessionModel().Id;
        }

        public void DeleteIdHallFromSession(long idHall) { }

        public void DeleteSession(long id) { }

        public List<MovieSessionModel> GetAllSessionsAndMovies()
        {
            return new List<MovieSessionModel>();
        }

        public List<SessionModel> GetFkHall(long idHall)
        {
            return new List<SessionModel>();
        }

        public SessionModel GetSession(long id)
        {
            return new SessionModel();
        }

        public List<SessionModel> GetSessions()
        {
            return new List<SessionModel>();
        }

        public List<SessionModel> GetSessionsByMovie(long idMovie)
        {
            throw new NotImplementedException();
        }

        public void UpdateSession(SessionModel session) { }
    }
}
