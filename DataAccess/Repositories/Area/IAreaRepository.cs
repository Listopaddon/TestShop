using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess.Repositories.Area
{
    public interface IAreaRepository
    {
        public long AddArea(long idHall);
        public void DeleteArea(long idArea);
        public void UpdateArea(AreaModel area);
        public List<AreaModel> GetAreas();
        public List<AreaModel> GetFKHall(long idHall);
        public AreaModel GetArea(long idArea);
        public void DeleteIdHallFromArea(long idHall);
    }
}
