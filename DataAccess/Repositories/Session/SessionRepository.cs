using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Repositories.Session
{
    public class SessionRepository : BaseRepository, ISessionRepository
    {
        string connectionString;

        public SessionRepository(string connectionString) => this.connectionString = connectionString;

        public long AddSession(long idMovie, long idHall, decimal price)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdMovie", idMovie),
                new SqlParameter("@IdHall", idHall),
                new SqlParameter("@Price", price)
            };

            return Convert.ToInt64(CreateCommand("sp_InsertSession", new SqlConnection(connectionString), parameters).ExecuteScalar());
        }

        public void DeleteSession(long id) =>
            CreateCommand("sp_DeleteSession", new SqlConnection(connectionString), new SqlParameter("@Id", id)).ExecuteScalar();

        public void DeleteIdHallFromSession(long idHall) =>
            CreateCommand("sp_DeleteIdHallFromSession", new SqlConnection(connectionString), new SqlParameter("@IdHall", idHall)).ExecuteScalar();

        public void UpdateSession(SessionModel session)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
               new SqlParameter("@IdSession", session.Id),
               new SqlParameter("@IdMovie", session.IdMovie),
               new SqlParameter("@IdHall", session.IdHall),
               new SqlParameter("@Price", session.Price)
            };
            CreateCommand("sp_UpdateSession", new SqlConnection(connectionString), parameters).ExecuteScalar();
        }

        public List<SessionModel> GetSessions()
        {
            List<SessionModel> sessions = new List<SessionModel>();
            var reader = CreateCommand("sp_GetSessions", new SqlConnection(connectionString)).ExecuteReader();
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        sessions.Add(new SessionModel(reader.GetInt64(0), reader.GetInt64(1), reader.GetInt64(2), reader.GetDecimal(3)));
                    }
                }
            }
            reader.Close();

            return sessions;
        }

        public SessionModel GetSession(long idSession)
        {
            SessionModel session = null;
            var reader = CreateCommand("sp_GetSession", new SqlConnection(connectionString), new SqlParameter("@IdSession", idSession)).ExecuteReader();
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        session = new SessionModel(reader.GetInt64(0), reader.GetInt64(1),
                                                     reader.GetInt64(2), reader.GetDecimal(3));
                    }
                }
                reader.Close();
            }

            return session;
        }

        public List<SessionModel> GetFkHall(long idHall)
        {
            List<SessionModel> sessions = new List<SessionModel>();
            var reader = CreateCommand("sp_GetSessionFkHall", new SqlConnection(connectionString), new SqlParameter("IdHall", idHall)).ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    sessions.Add(new SessionModel(reader.GetInt64(0), reader.GetInt64(1),
                                                reader.GetInt64(2), reader.GetDecimal(3)));
                }
            }
            reader.Close();

            return sessions;
        }      

        public List<MovieSessionModel> GetAllSessionsAndMovies()
        {
            List<MovieSessionModel> models = new List<MovieSessionModel>();
            var reader = CreateCommand("sp_GetAllSessionsAndMovies", new SqlConnection(connectionString)).ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    models.Add(new MovieSessionModel(reader.GetInt64(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3),
                                                     reader.GetInt64(4), reader.GetInt64(5), reader.GetDecimal(6)));
                }
            }
            reader.Close();
            return models;
        }

        public List<SessionModel> GetSessionsByMovie(long idMovie)
        {
            List<SessionModel> sessions = new List<SessionModel>();
            var reader = CreateCommand("sp_GetSessionByMovie", new SqlConnection(connectionString), new SqlParameter("@IdMovie", idMovie)).ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    sessions.Add(new SessionModel(reader.GetInt64(0), reader.GetInt64(1), reader.GetInt64(2), reader.GetDecimal(3)));
                }
            }
            reader.Close();

            return sessions;
        }
    }
}
