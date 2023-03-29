using DataAccess.Models;
using DataAccess.Repositories.Place;
using System.Collections.Generic;

namespace UnitTestBusinessLogic.Tests.PlaceTests.SubObjects
{
    public class SubPlaceRepository : IPlaceRepository
    {
        List<PlaceModel> places;

        public SubPlaceRepository(List<PlaceModel> places)
        {
            this.places = places;
        }

        public long AddPlace(long idRow, int numberPlace)
        {
            long id = places.Count;
            places.Add(new PlaceModel(id, idRow, numberPlace));
            return id;
        }

        public void DeletePlace(long id)
        {
            for (int i = 0; i < places.Count; i++)
            {
                if (places[i].Id == id)
                {
                    places.Remove(places[i]);
                    break;
                }
            }
        }

        public List<PlaceModel> GetFkRow(long idRow)
        {
            List<PlaceModel> result = new List<PlaceModel>();

            for (int i = 0; i < places.Count; i++)
            {
                if (places[i].IdRow == idRow)
                {
                    result.Add(places[i]);
                }
            }

            return result;
        }

        public List<PlaceModel> GetPlaces()
        {
            return places;
        }

        public void UpdatePlace(PlaceModel place)
        {
            for (int i = 0; i < places.Count; i++)
            {
                if (places[i].Id == place.Id)
                {
                    places[i] = place;
                    break;
                }
            }
        }

        public PlaceModel GetPlace(long id)
        {
            PlaceModel result = null;

            for (int i = 0; i < places.Count; i++)
            {
                if (places[i].Id == id)
                {
                    result = places[i];
                }
            }

            return result;
        }

        public void DeleteIdRowFromPlace(long idRow)
        {
            for (int i = 0; i < places.Count; i++)
            {
                if (places[i].IdRow == idRow)
                {
                    places.Remove(places[i]);
                    i = -1;
                }
            }
        }
    }
}
