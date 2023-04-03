using BusinessLogic.LogicBusiness.Area;
using DataAccess.Models;
using System.Collections.Generic;

namespace UnitTestBusinessLogic.Tests.AreaTests.SubObjects
{
    public class SubAreaLogic : IAreaLogic
    {
        public long AddArea(long idHall) => 0;

        public long AddArea(long idHall, int quantityRows, int quantityPlacesInRow) => 0;


        public void DeleteArea(long id) { }

        public void DeleteIdHallFromArea(long idHall) { }

        public AreaModel GetArea(long id) => null;

        public List<AreaModel> GetAreas() => null;
        public List<AreaModel> GetFKHall(long idHall) => null;
        public void UpdateArea(AreaModel area) { }
    }
}
