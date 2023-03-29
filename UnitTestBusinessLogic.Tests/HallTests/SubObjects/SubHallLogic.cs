using BusinessLogic.LogicBusiness.Hall;
using DataAccess.Models;
using System.Collections.Generic;

namespace UnitTestBusinessLogic.Tests.HallTests.SubObjects
{
    public class SubHallLogic : IHallLogic
    {
        public long AddHall(long idCinema) 
        {
            return new HallModel().Id;
        }

        public void DeleteHall(long id) { }

        public void DeleteHallFKCinema(List<HallModel> hallDtos) { }

        public List<HallModel> GetFKCinema(long id)
        {
            return new List<HallModel>();
        }

        public HallModel GetHall(long id)
        {
            return new HallModel();
        }

        public List<HallModel> GetHallByIdCinema(long idCinema)
        {
            return null;
        }

        public List<HallModel> GetHallByIdMovie(long idMovie)
        {
            return null;
        }

        public List<HallModel> GetHalls()
        {
            return new List<HallModel>();
        }

        public void UpdateHall(HallModel hall) { }
    }
}
