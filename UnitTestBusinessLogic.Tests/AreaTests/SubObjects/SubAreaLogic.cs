using BusinessLogic.LogicBusiness.Area;
using DataAccess.Models;
using System.Collections.Generic;

namespace UnitTestBusinessLogic.Tests.AreaTests.SubObjects
{
    public class SubAreaLogic : IAreaLogic
    {
        public long AddArea(long idHall) { return 0; }

        public void DeleteArea(long id) { }

        public void DeleteIdHallFromArea(long idHall) { }

        public AreaModel GetArea(long id) { return null; }

        public List<AreaModel> GetAreas() { return null; }
        public List<AreaModel> GetFKHall(long idHall) { return null; }
        public void UpdateArea(AreaModel area) { }
    }
}
