using DataAccess.Models;
using DataAccess.Repositories.Movie;
using System;
using System.Collections.Generic;

namespace UnitTestBusinessLogic.Tests.MovieTests.SubObjects
{
    public class SubMovieRepository : IMovieRepository
    {
        List<MovieModel> movies;
        List<HallModel> halls;

        public SubMovieRepository(List<MovieModel> movies)
        {
            this.movies = movies;
            halls = new List<HallModel>()
            {
                new HallModel(0,1),
                new HallModel(1,1),
                new HallModel(2,3),
            };

        }

        public long AddMovie(string name, string discription, DateTime time)
        {
            long id = movies.Count;
            movies.Add(new MovieModel(id, name, discription, time));
            return id;
        }

        public void DeleteMovie(long id)
        {
            for (int i = 0; i < movies.Count; i++)
            {
                if (movies[i].Id == id)
                {
                    movies.Remove(movies[i]);
                    break;
                }
            }
        }

        public MovieModel GetMovie(long id)
        {
            MovieModel result = null;
            for (int i = 0; i < movies.Count; i++)
            {
                if (movies[i].Id == id)
                {
                    result = movies[i];
                }
            }
            return result;
        }

        public List<MovieModel> GetMovies()
        {
            return movies;
        }

        public List<MovieSessionModel> GetAllMovieForThisCinema(long idCinema)
        {
            //List<MovieSessionModel> result = new List<MovieSessionModel>();

            //for (int i = 0; i < halls.Count; i++)
            //{
            //    if (halls[i].IdCinema == idCinema)
            //    {
            //        result.Add(new MovieSessionModel(0, "Create Movie", "Discription", new DateTime()));
            //    }
            //}

            //return result;

            return null;
        }

        public void UpdateMovie(MovieModel movie)
        {
            for (int i = 0; i < movies.Count; i++)
            {
                if (movies[i].Id == movie.Id)
                {
                    movies[i] = movie;
                    break;
                }
            }

        }

        public List<MovieModel> GetAllCinemaForMovie(string name)
        {
            List<MovieModel> result = new List<MovieModel>();

            for (int i = 0; i < movies.Count; i++)
            {
                if (movies[i].Name == name)
                {
                    result.Add(movies[i]);
                }
            }

            return result;
        }

        public List<MovieModel> GetAllMoviesForName()
        {
            List<MovieModel> result = new List<MovieModel>();

            for (int i = 0; i < movies.Count; i++)
            {
                for (int j = i + 1; j < movies.Count; j++)
                {
                    if (movies[i].Name != movies[j].Name)
                    {
                        result.Add(movies[i]);
                        break;
                    }
                    
                }
            }

            return result;
        }

    }
}
