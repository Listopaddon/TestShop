using DataAccess.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Repositories.Place
{
    public class PlaceRepository : BaseRepository, IPlaceRepository
    {
        string connectionString;

        public PlaceRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public long AddPlace(long idRow, int numberPlace)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdRow", idRow),
                new SqlParameter("@NumberPlace", numberPlace)
            };

            return (long)CreateCommand("sp_InsertPlaces", new SqlConnection(connectionString), parameters).ExecuteScalar();
        }

        public void DeletePlace(long id)
        {
            CreateCommand("sp_DeletePlaces", new SqlConnection(connectionString),
                           new SqlParameter("@Id", id)).ExecuteScalar();
        }

        public void DeleteIdRowFromPlace(long idRow)
        {
            CreateCommand("sp_DeleteIdRowFromPlace", new SqlConnection(connectionString),
                          new SqlParameter("@IdRow", idRow)).ExecuteScalar();
        }

        public void UpdatePlace(PlaceModel place)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", place.Id),
                new SqlParameter("@IdRow", place.IdRow),
                new SqlParameter("@NumberPlace", place.NumberPlace)
            };

            CreateCommand("sp_UpdatePlaces", new SqlConnection(connectionString), parameters).ExecuteScalar();
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
            SqlParameter[] idAreas = new SqlParameter[]
                {
                    new SqlParameter("@IdRow", idRow)
                };
            List<PlaceModel> places = new List<PlaceModel>();
            var reader = CreateCommand("sp_GetPlaceFKRow", new SqlConnection(connectionString), idAreas).ExecuteReader();

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

        public PlaceModel GetPlace(long id)
        {
            PlaceModel result = null;
            SqlParameter parameter = new SqlParameter("@IdPlace", id);
            var reader = CreateCommand("sp_GetPlace", new SqlConnection(connectionString), parameter).ExecuteReader();

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
