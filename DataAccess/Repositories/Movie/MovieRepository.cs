using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Repositories.Movie
{
    public class MovieRepository : BaseRepository, IMovieRepository
    {
        string connectionString;

        public MovieRepository(string connectionString) => this.connectionString = connectionString;

        public long AddMovie(string name, string discription, DateTime time)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Name", name),
                new SqlParameter("@Discription", discription),
                new SqlParameter("@Time", time)
            };

            return Convert.ToInt64(CreateCommand("sp_InsertMovie", new SqlConnection(connectionString), parameters).ExecuteScalar());
        }

        public void DeleteMovie(long idMovie) =>
            CreateCommand("sp_DeleteMovie", new SqlConnection(connectionString), new SqlParameter("@IdMovie", idMovie)).ExecuteScalar();

        public void UpdateMovie(MovieModel movie)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
               new SqlParameter("@IdMovie", movie.Id),
                new SqlParameter("@Name", movie.Name),
                new SqlParameter("@Discription", movie.Discription),
                new SqlParameter("@Time", movie.Time)
            };

            CreateCommand("sp_UpdateMovie", new SqlConnection(connectionString), parameters).ExecuteScalar();
        }

        public List<MovieModel> GetMovies()
        {
            List<MovieModel> movies = new List<MovieModel>();
            var reader = CreateCommand("sp_GetMovies", new SqlConnection(connectionString)).ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    movies.Add(new MovieModel(reader.GetInt64(0), reader.GetString(1),
                                            reader.GetString(2), reader.GetDateTime(3)));
                }
            }
            reader.Close();

            return movies;
        }

        public MovieModel GetMovie(long idMovie)
        {
            MovieModel result = null;
            SqlParameter parameter = new SqlParameter("@IdMovie", idMovie);
            var reader = CreateCommand("sp_GetMovie", new SqlConnection(connectionString), parameter).ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result = new MovieModel(reader.GetInt64(0), reader.GetString(1),
                                          reader.GetString(2), reader.GetDateTime(3));
                }
            }
            reader.Close();

            return result;
        }

        public List<MovieSessionModel> GetAllMovieForThisCinema(long idCinema)
        {
            List<MovieSessionModel> movies = new List<MovieSessionModel>();
            SqlParameter parameter = new SqlParameter("@IdCinema", idCinema);
            var reader = CreateCommand("sp_GetAllMovieForThisCinema", new SqlConnection(connectionString), parameter).ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    movies.Add(new MovieSessionModel(reader.GetInt64(0), reader.GetString(1), reader.GetString(2),
                                                     reader.GetDateTime(3), reader.GetInt64(4), reader.GetInt64(5), reader.GetDecimal(6)));
                }
            }
            reader.Close();

            return movies;
        }

    }
}

