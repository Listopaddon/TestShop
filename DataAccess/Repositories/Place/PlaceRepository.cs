using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Repositories.Place
{
    public class PlaceRepository : BaseRepository, IPlaceRepository
    {
        string connectionString;

        public PlaceRepository(string connectionString) => this.connectionString = connectionString;

        public long AddPlace(long idRow, int numberPlace)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdRow", idRow),
                new SqlParameter("@NumberPlace", numberPlace)
            };

            return Convert.ToInt64(CreateCommand("sp_InsertPlaces", new SqlConnection(connectionString), parameters).ExecuteScalar());
        }

        public void DeletePlace(long idPlace) =>
            CreateCommand("sp_DeletePlace", new SqlConnection(connectionString), new SqlParameter("@IdPlace", idPlace)).ExecuteScalar();

        public void DeleteIdRowFromPlace(long idRow)
        {
            CreateCommand("sp_DeleteIdRowFromPlace", new SqlConnection(connectionString),
                          new SqlParameter("@IdRow", idRow)).ExecuteScalar();
        }

        public void UpdatePlace(PlaceModel place)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdPlace", place.Id),
                new SqlParameter("@IdRow", place.IdRow),
                new SqlParameter("@NumberPlace", place.NumberPlace)
            };
            CreateCommand("sp_UpdatePlace", new SqlConnection(connectionString), parameters).ExecuteScalar();
        }

        public List<PlaceModel> GetPlaces()
        {
            List<PlaceModel> places = new List<PlaceModel>();
            var reader = CreateCommand("sp_GetPlaces", new SqlConnection(connectionString)).ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    places.Add(new PlaceModel(reader.GetInt64(0), reader.GetInt64(1), reader.GetInt32(2)));
                }
            }
            reader.Close();

            return places;
        }

        public List<PlaceModel> GetFkRow(long idRow)
        {
            List<PlaceModel> places = new List<PlaceModel>();
            var reader = CreateCommand("sp_GetPlacesFKRow", new SqlConnection(connectionString), new SqlParameter("@IdRow", idRow)).ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    places.Add(new PlaceModel(reader.GetInt64(0), reader.GetInt64(1),
                                            reader.GetInt32(2)));
                }
            }
            reader.Close();

            return places;
        }

        public PlaceModel GetPlace(long idPlace)
        {
            PlaceModel result = null;
            var reader = CreateCommand("sp_GetPlace", new SqlConnection(connectionString), new SqlParameter("@IdPlace", idPlace)).ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result = new PlaceModel(reader.GetInt64(0), reader.GetInt64(1),
                                          reader.GetInt32(2));
                }
            }

            return result;
        }
    }
}
