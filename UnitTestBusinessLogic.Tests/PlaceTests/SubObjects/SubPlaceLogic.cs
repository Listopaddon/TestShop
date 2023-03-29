using BusinessLogic.LogicBusiness.Place;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestBusinessLogic.Tests.PlaceTests.SubObjects
{
    public class SubPlaceLogic : IPlaceLogic
    {
        public long AddPlace(long idRow, int numberPlace)
        {
            return 0;
        }

        public void DeleteFKPlace(List<PlaceModel> placeDtos) { }

        public void DeletePlace(long id) { }

        public List<PlaceModel> GetFkRow(long idRow)
        {
            return new List<PlaceModel>();
        }

        public List<PlaceModel> GetPlaces()
        {
            return new List<PlaceModel>();
        }

        public PlaceModel GetPlace(long id)
        {
            return null;
        }

        public void UpdatePlace(PlaceModel place) { }

        public void DeleteIdRowFromPlace(long idRow) { }

        public List<PlaceModel> GetPlacesBySession(long idRow, long idSession)
        {
            return new List<PlaceModel>(); ;
        }
    }
}
