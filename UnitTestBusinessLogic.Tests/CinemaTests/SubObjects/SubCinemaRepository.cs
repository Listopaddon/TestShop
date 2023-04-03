using DataAccess.Models;
using DataAccess.Repositories.Cinema;
using System.Collections.Generic;

namespace UnitTestBusinessLogic.Tests.CinemaTests
{
    public class SubCinemaRepository : ICinemaRepository
    {
        List<CinemaModel> cinemas;
        List<SessionModel> session;
        List<HallModel> halls;

        public SubCinemaRepository(List<CinemaModel> cinemas)
        {
            this.cinemas = cinemas;
            this.session = new List<SessionModel>()
            {
                new SessionModel(0,1,1,200),
                new SessionModel(1,2,2,100)
            };

            halls = new List<HallModel>()
            {
                new HallModel(1,1),
                new HallModel(2,2),
                new HallModel(3,1)
            };


        }

        public long AddCinema(string name, string picture)
        {
            long id = cinemas.Count;
            cinemas.Add(new CinemaModel(id, name, picture));
            return id;
        }

        public void DeleteCinema(long id)
        {
            for (int i = 0; i < cinemas.Count; i++)
            {
                if (cinemas[i].Id == id)
                {
                    cinemas.Remove(cinemas[i]);
                    break;
                }
            }
        }

        public CinemaModel GetCinema(long id)
        {
            CinemaModel result = null;
            for (int i = 0; i < cinemas.Count; i++)
            {
                if (cinemas[i].Id == id)
                {
                    result = cinemas[i];
                }
            }
            return result;
        }

        public List<CinemaModel> GetCinemas() => cinemas;

        public List<CinemaModel> GetIdCinemaByFilmFromSession(long idMovie)
        {
            List<CinemaModel> cinemasResult = new List<CinemaModel>();
            List<HallModel> halls = new List<HallModel>();

            for (int i = 0; i < session.Count; i++)
            {
                if (session[i].IdMovie == idMovie)
                {
                    halls.Add(this.halls[(int)session[i].IdHall]);
                }
            }

            for (int i = 0; i < halls.Count; i++)
            {
                cinemasResult.Add(GetCinema(halls[i].IdCinema));
            }

            return cinemasResult;
        }

        public void UpdateCinema(CinemaModel cinema)
        {
            for (int i = 0; i < cinemas.Count; i++)
            {
                if (cinemas[i].Id == cinema.Id)
                {
                    cinemas[i] = cinema;
                    break;
                }
            }
        }
    }
}
