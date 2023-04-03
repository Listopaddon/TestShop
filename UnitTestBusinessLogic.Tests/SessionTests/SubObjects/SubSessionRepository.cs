using DataAccess.Models;
using DataAccess.Repositories.Session;
using System.Collections.Generic;

namespace UnitTestBusinessLogic.Tests.SessionTests.SubObjects
{
    public class SubSessionRepository : ISessionRepository
    {
        List<SessionModel> sessions;
        List<MovieModel> movies;

        public SubSessionRepository(List<SessionModel> sessions)
        {
            this.sessions = sessions;
        }

        public long AddSession(long idMovie, long idArea, decimal price)
        {
            long id = sessions.Count;
            sessions.Add(new SessionModel(id, idMovie, idArea, price));
            return id;
        }

        public void DeleteIdHallFromSession(long idHall)
        {
            for (int i = 0; i < sessions.Count; i++)
            {
                if (sessions[i].IdHall == idHall)
                {
                    sessions.Remove(sessions[i]);
                    i = -1;
                }
            }
        }

        public void DeleteSession(long id)
        {
            for (int i = 0; i < sessions.Count; i++)
            {
                if (sessions[i].Id == id)
                {
                    sessions.Remove(sessions[i]);
                }
            }
        }

        public List<MovieSessionModel> GetAllSessionsAndMovies()
        {
            List<MovieSessionModel> result = new List<MovieSessionModel>();

            for (int i = 0; i < sessions.Count; i++)
            {
                result.Add(new MovieSessionModel(movies[i].Id, movies[i].Name, movies[i].Discription, movies[i].Time,
                                                 sessions[i].Id, sessions[i].IdHall, sessions[i].Price));
            }

            return result;
        }

        public List<SessionModel> GetFkHall(long idHall)
        {
            List<SessionModel> result = new List<SessionModel>();

            for (int i = 0; i < sessions.Count; i++)
            {
                if (sessions[i].IdHall == idHall)
                {
                    result.Add(sessions[i]);
                }
            }

            return result;
        }

        public SessionModel GetSession(long id)
        {
            for (int i = 0; i < sessions.Count; i++)
            {
                if (sessions[i].Id == id)
                {
                    return sessions[i];
                }
            }

            return null;
        }

        public List<SessionModel> GetSessions()
        {
            return sessions;
        }

        public List<SessionModel> GetSessionsByMovie(long idMovie)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateSession(SessionModel session)
        {
            for (int i = 0; i < sessions.Count; i++)
            {
                if (sessions[i].Id == session.Id)
                {
                    sessions[i] = session;
                    break;
                }
            }
        }
    }
}
