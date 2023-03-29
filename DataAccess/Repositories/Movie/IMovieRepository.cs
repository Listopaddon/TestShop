using DataAccess.Models;
using System;
using System.Collections.Generic;

namespace DataAccess.Repositories.Movie
{
    public interface IMovieRepository
    {
        public long AddMovie(string name, string discription, DateTime time);
        public void DeleteMovie(long id);
        public void UpdateMovie(MovieModel movie);
        public List<MovieModel> GetMovies();
        public MovieModel GetMovie(long id);
        public List<MovieSessionModel> GetAllMovieForThisCinema(long idCinema);
    }
}
