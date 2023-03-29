﻿using DataAccess.Models;
using System.Collections.Generic;

namespace BusinessLogic.LogicBusiness.Session
{
    public interface ISessionLogic
    {
        public long AddSession(long idMovie, long idHall, decimal price);
        public void DeleteSession(long id);
        public void UpdateSession(SessionModel session);
        public List<SessionModel> GetSessions();
        public List<SessionModel> GetFkHall(long idArea);
        public SessionModel GetSession(long id);
        public void DeleteIdHallFromSession(long idHall);
        public List<MovieSessionModel> GetAllSessionsAndMovies();
    }
}