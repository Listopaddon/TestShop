using BusinessLogic.LogicBusiness.Place;
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
        IPlaceLogic placeLogic;

        public AreaLogic(IAreaRepository areaRepository, IRowLogic rowLogic, IPlaceLogic placeLogic)
        {
            this.areaRepository = areaRepository;
            this.rowLogic = rowLogic;
            this.placeLogic = placeLogic;
        }
        public void UpdateArea(AreaModel area) => areaRepository.UpdateArea(area);

        public List<AreaModel> GetAreas() => areaRepository.GetAreas();

        public List<AreaModel> GetFKHall(long idHall) => areaRepository.GetFKHall(idHall);

        public AreaModel GetArea(long idArea) => areaRepository.GetArea(idArea);

        public long AddArea(long idHall) => areaRepository.AddArea(idHall);

        public long AddArea(long idHall, int quantityRows, int quantityPlacesInRow)
        {
            long idArea = AddArea(idHall);

            for (int i = 0; i < quantityRows; i++)
            {
                long idRow = rowLogic.AddRow(i + 1, idArea);
                for (int j = 0; j < quantityPlacesInRow; j++)
                {
                    placeLogic.AddPlace(idRow, j + 1);
                }
            }

            return idArea;
        }

        public void DeleteArea(long idArea)
        {
            rowLogic.DeleteFkAreas(idArea);
            areaRepository.DeleteArea(idArea);
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
