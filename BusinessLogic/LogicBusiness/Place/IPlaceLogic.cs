﻿using DataAccess.Models;
using System.Collections.Generic;

namespace BusinessLogic.LogicBusiness.Place
{
    public interface IPlaceLogic
    {
        public long AddPlace(long idRow, int numberPlace);
        public void DeletePlace(long idPlace);
        public void UpdatePlace(PlaceModel place);
        public List<PlaceModel> GetPlaces();
        public List<PlaceModel> GetFkRow(long idRow);
        public PlaceModel GetPlace(long idPlace);
        public void DeleteIdRowFromPlace(long idRow);
        public List<PlaceModel> GetPlacesBySession(long idRow, long idSession);
    }
}
