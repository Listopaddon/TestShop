using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess.Repositories.Hall
{
    public interface IHallRepository
    {
        public long AddHall(long idCinema);
        public List<HallModel> GetHalls();
        public void DeleteHall(long idHall);
        public void UpdateHall(HallModel hall);
        public HallModel GetHall(long idHall);
        public List<HallModel> GetFKCinema(long idCinema);
        public List<HallModel> GetHallByIdMovie(long idMovie, long idCinema);
        public List<HallModel> GetHallByIdCinema(long idCinema);
    }
}
