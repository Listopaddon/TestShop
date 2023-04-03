using DataAccess.Models;
using System.Collections.Generic;

namespace BusinessLogic.LogicBusiness.Hall
{
    public interface IHallLogic
    {
        public long AddHall(long idCinema);
        public List<HallModel> GetHalls();
        public void DeleteHall(long idHall);
        public void UpdateHall(HallModel hall);
        public List<HallModel> GetFKCinema(long idCinema);
        public HallModel GetHall(long idHall);
        public List<HallModel> GetHallByIdMovie(long idMovie, long idCinema);
        public List<HallModel> GetHallByIdCinema(long idCinema);

    }
}
