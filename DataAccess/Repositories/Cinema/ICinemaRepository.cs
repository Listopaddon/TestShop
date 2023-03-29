using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess.Repositories.Cinema
{
    public interface ICinemaRepository
    {
        public long AddCinema(string name, string picture);
        public List<CinemaModel> GetCinemas();
        public void DeleteCinema(long id);
        public void UpdateCinema(CinemaModel cinema);

        public CinemaModel GetCinema(long id);
        public List<CinemaModel> GetIdCinemaByFilmFromSession(long idMovie);

    }
}
