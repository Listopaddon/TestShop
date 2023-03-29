using DataAccess.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Repositories.Row
{
    public class RowRepository : BaseRepository, IRowRepository
    {
        string connectionString;

        public RowRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public long AddRow(long numberRow, long idArea)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@NumberRow", numberRow),
                new SqlParameter("@IdArea", idArea)
            };

            return (long)CreateCommand("sp_InsertRow", new SqlConnection(connectionString), parameters).ExecuteScalar();
        }

        public void DeleteFkAreas(long idArea)
        {
            SqlParameter parameter = new SqlParameter("@IdArea", idArea);
            CreateCommand("sp_DeleteFKAreasFromRow", new SqlConnection(connectionString), parameter).ExecuteScalar();
        }

        public void DeleteRow(long id)
        {
            SqlParameter parameter = new SqlParameter("@IdRow", id);
            CreateCommand("sp_DeleteRow", new SqlConnection(connectionString), parameter).ExecuteScalar();
        }

        public List<RowModel> GetAreaFromRow(long idArea)
        {
            SqlParameter parameter = new SqlParameter("@IdArea", idArea);
            List<RowModel> rows = new List<RowModel>();

            var reader = CreateCommand("sp_GetIdAreasFromRow", new SqlConnection(connectionString), parameter).ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    rows.Add(new RowModel(reader.GetInt64(0), reader.GetInt64(1), reader.GetInt64(2)));
                }
            }
            reader.Close();

            return rows;
        }

        public RowModel GetRow(long id)
        {
            SqlParameter parameter = new SqlParameter("@IdRow", id);
            RowModel row = null;

            var reader = CreateCommand("sp_GetRow", new SqlConnection(connectionString), parameter).ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    row = new RowModel(reader.GetInt64(0), reader.GetInt64(1), reader.GetInt64(2));
                }
            }
            reader.Close();

            return row;
        }

        public List<RowModel> GetRows()
        {
            List<RowModel> rows = new List<RowModel>();

            var reader = CreateCommand("sp_GetRows", new SqlConnection(connectionString)).ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    rows.Add(new RowModel(reader.GetInt64(0), reader.GetInt64(1), reader.GetInt64(2)));
                }
            }
            reader.Close();

            return rows;
        }

        public void UpdateRow(RowModel row)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", row.Id),
                new SqlParameter("@NumberRow", row.NumberRow),
                new SqlParameter("@IdArea", row.IdArea)
            };

            CreateCommand("sp_UpdateRow", new SqlConnection(connectionString), parameters).ExecuteScalar();
        }
    }
}
