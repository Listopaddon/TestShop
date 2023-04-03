using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Repositories.Hall
{
    public class HallRepository : BaseRepository, IHallRepository
    {
        string connectionString;

        public HallRepository(string connectionString) => this.connectionString = connectionString;

        public long AddHall(long idCinema) =>
            Convert.ToInt64(CreateCommand("sp_InsertHall", new SqlConnection(connectionString), new SqlParameter("@IdCinema", idCinema)).ExecuteScalar());

        public void DeleteHall(long idHall) =>
            CreateCommand("sp_DeleteHall", new SqlConnection(connectionString), new SqlParameter("@IdHall", idHall)).ExecuteScalar();

        public List<HallModel> GetHalls()
        {
            List<HallModel> halls = new List<HallModel>();
            var reader = CreateCommand("sp_GetHalls", new SqlConnection(connectionString)).ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    halls.Add(new HallModel(reader.GetInt64(0), reader.GetInt64(1)));
                }
            }
            reader.Close();

            return halls;
        }

        public void UpdateHall(HallModel hall)
        {
            SqlParameter[] parameters = new SqlParameter[]
           {
               new SqlParameter("@IdHall", hall.Id),
               new SqlParameter("@IdCinema", hall.IdCinema)
           };
            CreateCommand("sp_UpdateHall", new SqlConnection(connectionString), parameters).ExecuteScalar();
        }

        public HallModel GetHall(long idHall)
        {
            var reader = CreateCommand("sp_GetHall", new SqlConnection(connectionString),
                                       new SqlParameter("@IdHall", idHall)).ExecuteReader();
            HallModel hallDto = null;

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    hallDto = new HallModel(reader.GetInt64(0), reader.GetInt64(1));
                }
            }
            reader.Close();

            return hallDto;
        }

        public List<HallModel> GetFKCinema(long idCinema)
        {
            List<HallModel> hallDtos = new List<HallModel>();
            var reader = CreateCommand("sp_GetHallFKCinema", new SqlConnection(connectionString),
                                        new SqlParameter("IdCinema", idCinema)).ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    hallDtos.Add(new HallModel(reader.GetInt64(0), reader.GetInt64(1)));
                }
            }
            reader.Close();

            return hallDtos;
        }

        public List<HallModel> GetHallByIdMovie(long idMovie, long idCinema)
        {
            SqlParameter[] parameters = new SqlParameter[] {new SqlParameter("@IdMovie", idMovie),
                                                            new SqlParameter("@IdCinema",idCinema) };
            var reader = CreateCommand("sp_GetHallByIdMovie", new SqlConnection(connectionString), parameters).ExecuteReader();
            List<HallModel> hallResult = new List<HallModel>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    hallResult.Add(new HallModel(reader.GetInt64(0), reader.GetInt64(1)));
                }
            }
            reader.Close();

            return hallResult;
        }

        public List<HallModel> GetHallByIdCinema(long idCinema)
        {
            SqlParameter parameter = new SqlParameter("@IdCinema", idCinema);
            List<HallModel> resultHall = new List<HallModel>();
            var reader = CreateCommand("sp_GetHallByIdCinema", new SqlConnection(connectionString), parameter).ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    resultHall.Add(new HallModel(reader.GetInt64(0), reader.GetInt64(1)));
                }
            }
            reader.Close();

            return resultHall;
        }
    }
}
