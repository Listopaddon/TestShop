using BusinessLogic.LogicBusiness.Area;
using BusinessLogic.LogicBusiness.Session;
using DataAccess.Models;
using DataAccess.Repositories.Hall;
using System.Collections.Generic;

namespace BusinessLogic.LogicBusiness.Hall
{
    public class HallLogic : IHallLogic
    {
        IHallRepository hallRepository;
        IAreaLogic areaLogic;
        ISessionLogic sessionLogic;

        public HallLogic(IHallRepository hallRepository, IAreaLogic areaLogic, ISessionLogic sessionLogic)
        {
            this.hallRepository = hallRepository;
            this.areaLogic = areaLogic;
            this.sessionLogic = sessionLogic;
        }

        public long AddHall(long idCinema)
        {
            long id = hallRepository.AddHall(idCinema);
            return id;
        }
        public List<HallModel> GetHalls()
        {
            return hallRepository.GetHalls();
        }
        public void DeleteHall(long id)
        {
            areaLogic.DeleteIdHallFromArea(id);
            List<SessionModel> sessions = sessionLogic.GetFkHall(id);
            for (int i = 0; i < sessions.Count; i++)
            {
                sessionLogic.DeleteSession(sessions[i].Id);
            }
            hallRepository.DeleteHall(id);
        }
        public void UpdateHall(HallModel hall)
        {
            hallRepository.UpdateHall(hall);
        }

        public List<HallModel> GetFKCinema(long idCinema)
        {
            return hallRepository.GetFKCinema(idCinema);
        }

        public HallModel GetHall(long id)
        {
            return hallRepository.GetHall(id);
        }

        public List<HallModel> GetHallByIdMovie(long idMovie,long idCinema)
        {
            return hallRepository.GetHallByIdMovie(idMovie,idCinema);
        }

        public List<HallModel> GetHallByIdCinema(long idCinema)
        {
            return hallRepository.GetHallByIdCinema(idCinema);
        }
    }
}
