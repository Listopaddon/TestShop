using DataAccess.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Repositories.Cinema
{
    public class CinemaRepository : BaseRepository, ICinemaRepository
    {
        string connectionString;

        public CinemaRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public long AddCinema(string name, string picture)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Name", name),
                new SqlParameter("@Picture", picture)
            };

            return (long)CreateCommand("sp_InsertCinema", new SqlConnection(connectionString), parameters).ExecuteScalar();
        }

        public List<CinemaModel> GetCinemas()
        {
            List<CinemaModel> cinemas = new List<CinemaModel>();
            var reader = CreateCommand("sp_GetCinemas", new SqlConnection(connectionString)).ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    cinemas.Add(new CinemaModel(reader.GetInt64(0), reader.GetString(1), reader.GetString(2)));
                }
            }
            reader.Close();
            return cinemas;
        }

        public void DeleteCinema(long id)
        {
            SqlParameter parameter = new SqlParameter("@Id", id);

            CreateCommand("sp_DeleteCinema", new SqlConnection(connectionString), parameter).ExecuteScalar();
        }

        public void UpdateCinema(CinemaModel cinema)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", cinema.Id),
                new SqlParameter("@Name", cinema.Name),
                new SqlParameter("@Picture", cinema.Picture)
            };

            CreateCommand("sp_UpdateCinema", new SqlConnection(connectionString), parameters).ExecuteScalar();
        }

        public CinemaModel GetCinema(long id)
        {
            SqlParameter parameter = new SqlParameter("IdCinema", id);
            var reader = CreateCommand("sp_GetCinema", new SqlConnection(connectionString), parameter).ExecuteReader();
            CinemaModel result = null;

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result = new CinemaModel(reader.GetInt64(0), reader.GetString(1), reader.GetString(2));
                }
            }
            reader.Close();
            return result;
        }

        public List<CinemaModel> GetIdCinemaByFilmFromSession(long idMovie)
        {
            List<CinemaModel> result = new List<CinemaModel>();
            SqlParameter parameter = new SqlParameter("@IdMovie", idMovie);
            var reader = CreateCommand("sp_GetIdCinemaByFilmFromSession", new SqlConnection(connectionString), parameter).ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result.Add(new CinemaModel(reader.GetInt64(0), reader.GetString(1), reader.GetString(2)));
                }
            }
            reader.Close();

            return result;
        }
    }
}
