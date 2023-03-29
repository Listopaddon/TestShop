using DataAccess.Models;
using System.Collections.Generic;

namespace BusinessLogic.LogicBusiness.Area
{
    public interface IAreaLogic
    {
        public long AddArea(long idHall);
        public void DeleteArea(long id);
        public void UpdateArea(AreaModel area);
        public List<AreaModel> GetAreas();
        public List<AreaModel> GetFKHall(long idHall);
        public AreaModel GetArea(long id);
        public void DeleteIdHallFromArea(long idHall);
    }
}
