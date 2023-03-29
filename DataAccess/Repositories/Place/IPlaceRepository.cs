using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess.Repositories.Place
{
    public interface IPlaceRepository
    {
        public long AddPlace(long idRow, int numberPlace);
        public void DeletePlace(long id);
        public void UpdatePlace(PlaceModel place);
        public List<PlaceModel> GetPlaces();
        public List<PlaceModel> GetFkRow(long idRow);
        public PlaceModel GetPlace(long id);
        public void DeleteIdRowFromPlace(long idRow);
    }
}
