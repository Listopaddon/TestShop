using DataAccess.Models;
using DataAccess.Repositories.Area;
using System.Collections.Generic;

namespace UnitTestBusinessLogic.Tests
{
    public class SubAreaRepository : IAreaRepository
    {
        public List<AreaModel> areas;

        public SubAreaRepository(List<AreaModel> areas)
        {
            this.areas = areas;
        }

        public long AddArea(long idHall)
        {
            long id = areas.Count;
            areas.Add(new AreaModel(id, idHall));
            return id;
        }

        public void DeleteArea(long id)
        {
            for (int i = 0; i < areas.Count; i++)
            {
                if (areas[i].Id == id)
                {
                    areas.Remove(areas[i]);
                    break;
                }
            }
        }

        public void DeleteIdHallFromArea(long idHall)
        {
            for (int i = 0; i < areas.Count; i++)
            {
                if (areas[i].IdHall == idHall)
                {
                    areas.Remove(areas[i]);
                    i = -1;
                }
            }
        }

        public AreaModel GetArea(long id)
        {
            AreaModel area = null;

            for (int i = 0; i < areas.Count; i++)
            {
                if (areas[i].Id == id)
                {
                    area = areas[i];
                    break;
                }
            }

            return area;
        }

        public List<AreaModel> GetAreas() => areas;

        public List<AreaModel> GetFKHall(long idHall)
        {
            List<AreaModel> fkKeys = new List<AreaModel>();

            for (int i = 0; i < areas.Count; i++)
            {
                if (areas[i].IdHall == idHall)
                {
                    fkKeys.Add(areas[i]);
                }
            }

            return fkKeys;
        }

        public void UpdateArea(AreaModel area)
        {
            for (int i = 0; i < areas.Count; i++)
            {
                if (areas[i].Id == area.Id)
                {
                    areas[i] = area;
                    break;
                }
            }
        }
    }
}
