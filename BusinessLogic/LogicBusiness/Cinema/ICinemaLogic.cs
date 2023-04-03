﻿using DataAccess.Models;
using System.Collections.Generic;

namespace BusinessLogic.LogicBusiness.Cinema
{
    public interface ICinemaLogic
    {
        public long AddCinema(string name, string picture);
        public List<CinemaModel> GetCinemas();
        public void DeleteCinema(long idCinema);
        public void UpdateCinema(CinemaModel cinema);
        public CinemaModel GetCinema(long idCinema);
        public List<CinemaModel> GetIdCinemaByFilmFromSession(long idMovie);
    }
}
