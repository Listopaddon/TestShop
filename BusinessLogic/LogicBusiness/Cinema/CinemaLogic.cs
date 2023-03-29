using BusinessLogic.LogicBusiness.Hall;
using DataAccess.Models;
using DataAccess.Repositories.Cinema;
using System.Collections.Generic;

namespace BusinessLogic.LogicBusiness.Cinema
{
    public class CinemaLogic : ICinemaLogic
    {
        ICinemaRepository cinemaRepository;
        IHallLogic hallLogic;

        public CinemaLogic(ICinemaRepository cinemaRepository, IHallLogic hallLogic)
        {
            this.cinemaRepository = cinemaRepository;
            this.hallLogic = hallLogic;
        }

        public long AddCinema(string name, string picture)
        {
            long id = cinemaRepository.AddCinema(name, picture);
            return id;
        }
        public List<CinemaModel> GetCinemas()
        {
            return cinemaRepository.GetCinemas();
        }
        public void DeleteCinema(long id)
        {
            List<HallModel> halls = hallLogic.GetFKCinema(id);
            for (int i = 0; i < halls.Count; i++)
            {
                hallLogic.DeleteHall(halls[i].Id);
            }
            cinemaRepository.DeleteCinema(id);
        }
        public void UpdateCinema(CinemaModel cinema)
        {
            cinemaRepository.UpdateCinema(cinema);
        }

        public CinemaModel GetCinema(long id)
        {
            return cinemaRepository.GetCinema(id);
        }

        public List<CinemaModel> GetIdCinemaByFilmFromSession(long idMovie)
        {
            return cinemaRepository.GetIdCinemaByFilmFromSession(idMovie);
        }
    }
}
