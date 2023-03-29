using DataAccess.Models;
using System;
using System.Collections.Generic;

namespace BusinessLogic.LogicBusiness.Movie
{
    public interface IMovieLogic
    {
        public long AddMovie(string name, string discription, DateTime time);
        public void DeleteMovie(long id);
        public void UpdateMovie(MovieModel movie);
        public List<MovieModel> GetMovies();
        public MovieModel GetMovie(long id);
        public List<MovieSessionModel> GetMoviesWithCinema(long idCinema);
    }
}
