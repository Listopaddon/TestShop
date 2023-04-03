using BusinessLogic.LogicBusiness.Hall;
using DataAccess.Models;
using System.Collections.Generic;

namespace UnitTestBusinessLogic.Tests.HallTests.SubObjects
{
    public class SubHallLogic : IHallLogic
    {
        public long AddHall(long idCinema) => 0;

        public void DeleteHall(long id) { }

        public void DeleteHallFKCinema(List<HallModel> hallDtos) { }

        public List<HallModel> GetFKCinema(long id) => new List<HallModel>();

        public HallModel GetHall(long id) => new HallModel();

        public List<HallModel> GetHallByIdCinema(long idCinema) => null;

        public List<HallModel> GetHallByIdMovie(long idMovie) => null;

        public List<HallModel> GetHallByIdMovie(long idMovie, long idCinema) => new List<HallModel>();

        public List<HallModel> GetHalls() => new List<HallModel>();

        public void UpdateHall(HallModel hall) { }
    }
}
