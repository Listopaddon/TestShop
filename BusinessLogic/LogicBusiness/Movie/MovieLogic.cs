using BusinessLogic.LogicBusiness.Session;
using DataAccess.Models;
using DataAccess.Repositories.Movie;
using System;
using System.Collections.Generic;

namespace BusinessLogic.LogicBusiness.Movie
{
    public class MovieLogic : IMovieLogic
    {
        IMovieRepository movieRepository;
        ISessionLogic sessionLogic;
        public MovieLogic(IMovieRepository movieRepository, ISessionLogic sessionLogic)
        {
            this.movieRepository = movieRepository;
            this.sessionLogic = sessionLogic;
        }

        public long AddMovie(string name, string discription, DateTime time) => movieRepository.AddMovie(name, discription, time);

        public void UpdateMovie(MovieModel movie) => movieRepository.UpdateMovie(movie);

        public List<MovieModel> GetMovies() => movieRepository.GetMovies();

        public MovieModel GetMovie(long idMovie) => movieRepository.GetMovie(idMovie);

        public List<MovieSessionModel> GetMoviesWithCinema(long idCinema) => movieRepository.GetAllMovieForThisCinema(idCinema);

        public void DeleteMovie(long idMovie)
        {
            List<SessionModel> sessions = sessionLogic.GetSessionsByMovie(idMovie);
            for (int i = 0; i < sessions.Count; i++)
            {
                sessionLogic.DeleteSession(sessions[i].Id);
            }

            movieRepository.DeleteMovie(idMovie);
        }

    }
}
