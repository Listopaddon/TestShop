using DataAccess.Models;
using DataAccess.Repositories.Movie;
using System;
using System.Collections.Generic;

namespace BusinessLogic.LogicBusiness.Movie
{
    public class MovieLogic : IMovieLogic
    {
        IMovieRepository movieRepository;
        public MovieLogic(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public long AddMovie(string name, string discription, DateTime time)
        {
            return movieRepository.AddMovie(name, discription, time);
        }
        public void DeleteMovie(long id)
        {
            movieRepository.DeleteMovie(id);
        }
        public void UpdateMovie(MovieModel movie)
        {
            movieRepository.UpdateMovie(movie);
        }
        public List <MovieModel> GetMovies()
        {
            return movieRepository.GetMovies();
        }

        public MovieModel GetMovie(long id)
        {
            return movieRepository.GetMovie(id);
        }

        public List<MovieSessionModel> GetMoviesWithCinema(long idCinema)
        {
            return movieRepository.GetAllMovieForThisCinema(idCinema);
        }

    }
}
