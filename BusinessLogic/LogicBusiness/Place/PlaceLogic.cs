using BusinessLogic.LogicBusiness.PlaceSession;
using DataAccess.Models;
using DataAccess.Repositories.Place;
using System.Collections.Generic;

namespace BusinessLogic.LogicBusiness.Place
{
    public class PlaceLogic : IPlaceLogic
    {
        IPlaceRepository placeRepository;
        IPlaceSessionLogic placeSessionLogic;

        public PlaceLogic(IPlaceRepository placeRepository, IPlaceSessionLogic placeSessionLogic)
        {
            this.placeRepository = placeRepository;
            this.placeSessionLogic = placeSessionLogic;
        }

        public long AddPlace(long idRow, int numberPlace)
        {
            return placeRepository.AddPlace(idRow, numberPlace);
        }
        public void DeletePlace(long id)
        {
            placeRepository.DeletePlace(id);
        }
        public void UpdatePlace(PlaceModel place)
        {
            placeRepository.UpdatePlace(place);
        }
        public List<PlaceModel> GetPlaces()
        {
            return placeRepository.GetPlaces();
        }
        public List<PlaceModel> GetFkRow(long idRow)
        {
            return placeRepository.GetFkRow(idRow);
        }
        public PlaceModel GetPlace(long id)
        {
            return placeRepository.GetPlace(id);
        }
        public void DeleteIdRowFromPlace(long idRow)
        {
            List<PlaceModel> places = placeRepository.GetFkRow(idRow);

            for (int i = 0; i < places.Count; i++)
            {
                placeSessionLogic.DeleteIdPlaceFromPlaceSession(places[i].Id);
            }

            for (int i = 0; i < places.Count; i++)
            {
                placeRepository.DeletePlace(places[i].Id);
            }

        }
        public List<PlaceModel> GetPlacesBySession(long idRow, long idSession)
        {
            List<PlaceSessionModel> placeSessions = placeSessionLogic.GetPlaceSessionFKSession(idSession);
            List<PlaceModel> places = GetFkRow(idRow);

            for (int i = 0; i < placeSessions.Count; i++)
            {
                for (int j = 0; j < places.Count; j++)
                {
                    if (placeSessions[i].IdPlaces == places[j].Id)
                    {
                        places[j].SetPlaceSession(placeSessions[i]);
                        break;
                    }
                }
            }

            return places;
        }
    }
}
