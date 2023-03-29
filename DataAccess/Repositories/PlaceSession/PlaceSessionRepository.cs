using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Repositories.PlaceSession
{
    public class PlaceSessionRepository : BaseRepository, IPlaceSessionRepository
    {
        string connectionString;

        public PlaceSessionRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public long AddPlaceSession(long idPlaces, long idSession, long idUser, StatePlace state, DateTime dateModified)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdPlace", idPlaces),
                new SqlParameter("@IdSession", idSession),
                new SqlParameter("@IdUser", idUser),
                new SqlParameter("@DateModified", dateModified),
                new SqlParameter("@State",state)
            };

            return (long)CreateCommand("sp_InsertPlaceSession", new SqlConnection(connectionString), parameters).ExecuteScalar();
        }

        public void DeletePlaceSession(long id)
        {
            CreateCommand("sp_DeletePlaceSession", new SqlConnection(connectionString),
                           new SqlParameter("@Id", id)).ExecuteScalar();
        }

        public void UpdatePlaceSession(PlaceSessionModel placeSession)
        {
            SqlParameter[] parameters = new SqlParameter[]
           {
                new SqlParameter("@Id", placeSession.ID),
                new SqlParameter("@IdPlaces", placeSession.IdPlaces),
                new SqlParameter("@IdSession", placeSession.IdSession),
                new SqlParameter("@IdUsers", placeSession.IdUsers),
                new SqlParameter("@DateModified", placeSession.DateModified)
           };
            CreateCommand("sp_UpdatePlaceSession", new SqlConnection(connectionString), parameters).ExecuteScalar();
        }

        public List<PlaceSessionModel> GetPlaceSessions()
        {
            var reader = CreateCommand("sp_GetPlaceSessions", new SqlConnection(connectionString)).ExecuteReader();
            List<PlaceSessionModel> placeSessions = new List<PlaceSessionModel>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    placeSessions.Add(new PlaceSessionModel(reader.GetInt64(0), reader.GetInt64(1),
                                                                 reader.GetInt64(2), reader.GetInt64(3), reader.GetDateTime(4),
                                                                 (StatePlace)reader.GetInt32(5)));
                }
            }
            reader.Close();
            return placeSessions;
        }

        public List<PlaceSessionModel> GetPlaceSessionFKPlaces(long idPlace)
        {
            List<PlaceSessionModel> placeSessionDtos = new List<PlaceSessionModel>();
            var reader = CreateCommand("sp_GetPlaceSessionFKPlaces", new SqlConnection(connectionString),
                                        new SqlParameter("@IdPlace", idPlace)).ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    placeSessionDtos.Add(new PlaceSessionModel(reader.GetInt64(0), reader.GetInt64(1),
                                                                 reader.GetInt64(2), reader.GetInt64(3), reader.GetDateTime(4),
                                                                 (StatePlace)reader.GetInt32(5)));
                }
            }
            reader.Close();
            return placeSessionDtos;
        }

        public List<PlaceSessionModel> GetPlaceSessionFKSession(long idSession)
        {
            List<PlaceSessionModel> placeSessionDtos = new List<PlaceSessionModel>();
            var reader = CreateCommand("sp_GetPlaceSessionFKSession", new SqlConnection(connectionString),
                                        new SqlParameter("@IdSession", idSession)).ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    placeSessionDtos.Add(new PlaceSessionModel(reader.GetInt64(0), reader.GetInt64(1),
                                                                 reader.GetInt64(2), reader.GetInt64(3), reader.GetDateTime(4), 
                                                                 (StatePlace)reader.GetInt32(5)));
                }
            }
            reader.Close();
            return placeSessionDtos;
        }

        public List<PlaceSessionModel> GetPlaceSessionFKUser(long idUser)
        {
            List<PlaceSessionModel> placeSessionDtos = new List<PlaceSessionModel>();
            var reader = CreateCommand("sp_GetPlaceSessionFKUser", new SqlConnection(connectionString),
                                        new SqlParameter("@IdUser", idUser)).ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    placeSessionDtos.Add(new PlaceSessionModel(reader.GetInt64(0), reader.GetInt64(1),
                                                                 reader.GetInt64(2), reader.GetInt64(3), reader.GetDateTime(4),
                                                                 (StatePlace)reader.GetInt32(5)));
                }
            }
            reader.Close();
            return placeSessionDtos;
        }

        public PlaceSessionModel GetPlaceSession(long id)
        {
            PlaceSessionModel result = null;

            SqlParameter parameter = new SqlParameter("@IdPlaceSession", id);

            var reader = CreateCommand("sp_GetPlaceSession",
                                       new SqlConnection(connectionString),
                                       parameter).ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result = new PlaceSessionModel(reader.GetInt64(0), reader.GetInt64(1),
                                                   reader.GetInt64(2), reader.GetInt64(3), reader.GetDateTime(4),
                                                   (StatePlace)reader.GetInt32(5));
                }
            }
            reader.Close();
            return result;
        }

        public void DeleteIdPlaceFromPlaceSession(long idPlace)
        {
            CreateCommand("sp_DeleteIdPlaceFromPlaceSession", new SqlConnection(connectionString),
                          new SqlParameter("@IdPlace", idPlace)).ExecuteScalar();
        }

        public void DeleteIdSessionFromPlaceSession(long idSession)
        {
            CreateCommand("sp_DeleteIdSessionFromPlaceSession", new SqlConnection(connectionString),
                          new SqlParameter("@IdSession", idSession)).ExecuteScalar();
        }

        public void DeleteIdUserFromPlaceSession(long idUser)
        {
            CreateCommand("sp_DeleteIdUserFromPlaceSession", new SqlConnection(connectionString),
                          new SqlParameter("@IdUser", idUser)).ExecuteScalar();
        }

    }
}
