using BusinessLogic.LogicBusiness.Row;
using DataAccess.Models;
using DataAccess.Repositories.Area;
using System.Collections.Generic;

namespace BusinessLogic.LogicBusiness.Area
{
    public class AreaLogic : IAreaLogic
    {
        IAreaRepository areaRepository;
        IRowLogic rowLogic;

        public AreaLogic(IAreaRepository areaRepository, IRowLogic rowLogic)
        {
            this.areaRepository = areaRepository;
            this.rowLogic = rowLogic;
        }

        public long AddArea(long idHall)
        {
            long id = areaRepository.AddArea(idHall);
            return id;
        }

        public void DeleteArea(long id)
        {
            rowLogic.DeleteFkAreas(id);
            areaRepository.DeleteArea(id);
        }

        public void UpdateArea(AreaModel area)
        {
            areaRepository.UpdateArea(area);
        }

        public List<AreaModel> GetAreas()
        {
            return areaRepository.GetAreas();
        }

        public List<AreaModel> GetFKHall(long idHall)
        {
            return areaRepository.GetFKHall(idHall);

        }

        public AreaModel GetArea(long id)
        {
            return areaRepository.GetArea(id);
        }

        public void DeleteIdHallFromArea(long idHall)
        {
            List<AreaModel> areas = GetFKHall(idHall);

            for (int i = 0; i < areas.Count; i++)
            {
                rowLogic.DeleteFkAreas(areas[i].Id);
            }

            for (int i = 0; i < areas.Count; i++)
            {
                areaRepository.DeleteIdHallFromArea(areas[i].Id);
            }
        }
    }
}
