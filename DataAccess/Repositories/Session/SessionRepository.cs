using DataAccess.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Repositories.Session
{
    public class SessionRepository : BaseRepository, ISessionRepository
    {
        string connectionString;

        public SessionRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public long AddSession(long idMovie, long idHall, decimal price)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdMovie", idMovie),
                new SqlParameter("@IdHall", idHall),
                new SqlParameter("@Price", price)
            };

            return (long)CreateCommand("sp_InsertSession", new SqlConnection(connectionString), parameters).ExecuteScalar();
        }

        public void DeleteSession(long id)
        {

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", id)
            };

            CreateCommand("sp_DeleteSession", new SqlConnection(connectionString), parameters).ExecuteScalar();
        }

        public void UpdateSession(SessionModel session)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
               new SqlParameter("@Id", session.Id),
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
                reader.Close();
            }
            return sessions;
        }

        public SessionModel GetSession(long id)
        {
            SqlParameter parameter = new SqlParameter("@Id", id);
            SessionModel session = null;

            var reader = CreateCommand("sp_GetSession", new SqlConnection(connectionString), parameter).ExecuteReader();
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
            SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("IdHall", idHall)
                };

            List<SessionModel> sessions = new List<SessionModel>();
            var reader = CreateCommand("sp_GetSessionFkHall", new SqlConnection(connectionString), parameters).ExecuteReader();

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

        public void DeleteIdHallFromSession(long idHall)
        {
            CreateCommand("sp_DeleteIdHallFromSession", new SqlConnection(connectionString),
                          new SqlParameter("@IdHall", idHall)).ExecuteScalar();
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
    }
}
