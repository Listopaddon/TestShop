using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Repositories.Area
{
    public class AreaRepository : BaseRepository, IAreaRepository
    {
        string connectionString;

        public AreaRepository(string connectionString) => this.connectionString = connectionString;

        public long AddArea(long idHall) =>
            Convert.ToInt64(CreateCommand("sp_InsertArea", new SqlConnection(connectionString), new SqlParameter("@IdHall", idHall)).ExecuteScalar());

        public void DeleteArea(long idArea) =>
            CreateCommand("sp_DeleteArea", new SqlConnection(connectionString), new SqlParameter("@IdArea", idArea)).ExecuteScalar();

        public void DeleteIdHallFromArea(long idArea) =>
            CreateCommand("sp_DeleteIdHallFromArea", new SqlConnection(connectionString), new SqlParameter("@IdArea", idArea)).ExecuteScalar();

        public void UpdateArea(AreaModel area)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
               new SqlParameter("@IdArea", area.Id),
               new SqlParameter("@IdHall", area.IdHall)
            };
            CreateCommand("sp_UpdateArea", new SqlConnection(connectionString), parameters).ExecuteScalar();
        }

        public List<AreaModel> GetAreas()
        {
            List<AreaModel> areas = new List<AreaModel>();
            var reader = CreateCommand("sp_GetAreas", new SqlConnection(connectionString)).ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    areas.Add(new AreaModel(reader.GetInt64(0), reader.GetInt64(1)));
                }
            }
            reader.Close();

            return areas;
        }

        public List<AreaModel> GetFKHall(long idHall)
        {
            SqlParameter sqlParameter = new SqlParameter("@IdHall", idHall);
            List<AreaModel> areas = new List<AreaModel>();
            var reader = CreateCommand("sp_GetAreaFKHall", new SqlConnection(connectionString), sqlParameter).ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    areas.Add(new AreaModel(reader.GetInt64(0), reader.GetInt64(1)));
                }
            }
            reader.Close();

            return areas;
        }

        public AreaModel GetArea(long idArea)
        {
            SqlParameter parameter = new SqlParameter("@IdArea", idArea);
            var reader = CreateCommand("sp_GetArea", new SqlConnection(connectionString), parameter).ExecuteReader();
            AreaModel area = null;

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    area = new AreaModel(reader.GetInt64(0), reader.GetInt64(1));
                }
            }
            reader.Close();

            return area;
        }
    }
}
