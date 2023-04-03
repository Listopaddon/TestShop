using DataAccess.Models;
using System.Collections.Generic;

namespace BusinessLogic.LogicBusiness.Area
{
    public interface IAreaLogic
    {
        public long AddArea(long idHall);
        public long AddArea(long idHall, int quantityRows, int quantityPlacesInRow);
        public void DeleteArea(long idArea);
        public void UpdateArea(AreaModel area);
        public List<AreaModel> GetAreas();
        public List<AreaModel> GetFKHall(long idHall);
        public AreaModel GetArea(long idArea);
        public void DeleteIdHallFromArea(long idHall);
    }
}
