using BusinessLogic.LogicBusiness.Place;
using DataAccess.Models;
using System.Collections.Generic;

namespace UnitTestBusinessLogic.Tests.PlaceTests.SubObjects
{
    public class SubPlaceLogic : IPlaceLogic
    {
        public long AddPlace(long idRow, int numberPlace) => 0;

        public void DeleteFKPlace(List<PlaceModel> placeDtos) { }

        public void DeletePlace(long id) { }

        public List<PlaceModel> GetFkRow(long idRow) => new List<PlaceModel>();

        public List<PlaceModel> GetPlaces() => new List<PlaceModel>();

        public PlaceModel GetPlace(long id) => null;

        public void UpdatePlace(PlaceModel place) { }

        public void DeleteIdRowFromPlace(long idRow) { }

        public List<PlaceModel> GetPlacesBySession(long idRow, long idSession) => new List<PlaceModel>();
    }
}
