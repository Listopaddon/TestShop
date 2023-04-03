using DataAccess.Models;
using DataAccess.Repositories.Hall;
using System.Collections.Generic;

namespace UnitTestBusinessLogic.Tests.HallTests.SubObjects
{
    public class SubHallRepository : IHallRepository
    {
        List<HallModel> halls;
        List<SessionModel> sessions;

        public SubHallRepository(List<HallModel> halls)
        {
            this.halls = halls;
            sessions = new List<SessionModel>()
            {
                new SessionModel(0,1,1,200),
                new SessionModel(1,2,2,100)
            };
        }

        public long AddHall(long idCinema)
        {
            long id = halls.Count;
            halls.Add(new HallModel(id, idCinema));
            return id;

        }

        public void DeleteHall(long id)
        {
            for (int i = 0; i < halls.Count; i++)
            {
                if (halls[i].Id == id)
                {
                    halls.Remove(halls[i]);
                    break;
                }
            }
        }

        public List<HallModel> GetFKCinema(long idCinema)
        {
            List<HallModel> result = new List<HallModel>();
            for (int i = 0; i < halls.Count; i++)
            {
                if (halls[i].IdCinema == idCinema)
                {
                    result.Add(halls[i]);
                }
            }

            return result;
        }

        public HallModel GetHall(long id)
        {
            HallModel result = null;
            for (int i = 0; i < halls.Count; i++)
            {
                if (halls[i].Id == id)
                {
                    result = halls[i];
                    break;
                }
            }

            return result;
        }

        public List<HallModel> GetHallByIdCinema(long idCinema)
        {
            List<HallModel> result = new List<HallModel>();
            for (int i = 0; i < halls.Count; i++)
            {
                if (halls[i].IdCinema == idCinema)
                {
                    result.Add(halls[i]);
                }
            }

            return result;
        }

        public List<HallModel> GetHallByIdMovie(long idMovie, long idCinema)
        {
            List<HallModel> result = new List<HallModel>();

            for (int i = 0; i < halls.Count; i++)
            {
                for(int j=0;j<sessions.Count;j++)
                {
                    if (idCinema == halls[i].IdCinema && sessions[j].IdHall == halls[i].Id && sessions[j].IdMovie == idMovie)
                    {
                        result.Add(halls[i]);
                    }
                }                
            }

            return result;
        }

        public List<HallModel> GetHalls() => halls;

        public void UpdateHall(HallModel hall)
        {
            for (int i = 0; i < halls.Count; i++)
            {
                if (halls[i].Id == hall.Id)
                {
                    halls[i] = hall;
                    break;
                }
            }
        }
    }
}
