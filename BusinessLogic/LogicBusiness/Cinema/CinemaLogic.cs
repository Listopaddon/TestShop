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

        public long AddCinema(string name, string picture) => cinemaRepository.AddCinema(name, picture);

        public List<CinemaModel> GetCinemas() => cinemaRepository.GetCinemas();

        public void UpdateCinema(CinemaModel cinema) => cinemaRepository.UpdateCinema(cinema);

        public CinemaModel GetCinema(long idCinema) => cinemaRepository.GetCinema(idCinema);

        public List<CinemaModel> GetIdCinemaByFilmFromSession(long idMovie) => cinemaRepository.GetIdCinemaByFilmFromSession(idMovie);

        public void DeleteCinema(long idCinema)
        {
            List<HallModel> halls = hallLogic.GetFKCinema(idCinema);
            for (int i = 0; i < halls.Count; i++)
            {
                hallLogic.DeleteHall(halls[i].Id);
            }
            cinemaRepository.DeleteCinema(idCinema);
        }
    }
}
