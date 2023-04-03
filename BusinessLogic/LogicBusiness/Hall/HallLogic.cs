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

        public long AddHall(long idCinema) => hallRepository.AddHall(idCinema);

        public List<HallModel> GetHalls() => hallRepository.GetHalls();
      
        public void UpdateHall(HallModel hall) => hallRepository.UpdateHall(hall);

        public List<HallModel> GetFKCinema(long idCinema) => hallRepository.GetFKCinema(idCinema);

        public HallModel GetHall(long idHall) => hallRepository.GetHall(idHall);

        public List<HallModel> GetHallByIdMovie(long idMovie, long idCinema) => hallRepository.GetHallByIdMovie(idMovie, idCinema);

        public List<HallModel> GetHallByIdCinema(long idCinema) => hallRepository.GetHallByIdCinema(idCinema);

        public void DeleteHall(long idHall)
        {
            areaLogic.DeleteIdHallFromArea(idHall);
            List<SessionModel> sessions = sessionLogic.GetFkHall(idHall);
            for (int i = 0; i < sessions.Count; i++)
            {
                sessionLogic.DeleteSession(sessions[i].Id);
            }
            hallRepository.DeleteHall(idHall);
        }
    }
}
