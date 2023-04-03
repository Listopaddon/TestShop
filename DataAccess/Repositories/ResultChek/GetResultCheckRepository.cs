using DataAccess.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Repositories.ResultChek
{
    public class GetResultCheckRepository : BaseRepository, IGetResultCheckRepository
    {
        string connectionString;
        public GetResultCheckRepository(string connectionString) => this.connectionString = connectionString;

        public List<Check> GetCheck(long idUser)
        {
            List<Check> checks = new List<Check>();
            var reader = CreateCommand("sp_GetResultCheck", new SqlConnection(connectionString), new SqlParameter("@idUser", idUser)).ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    checks.Add(new Check(reader.GetInt64(0), reader.GetString(1), reader.GetDateTime(2), reader.GetInt32(3),
                                         reader.GetInt64(4), reader.GetString(5), reader.GetDecimal(6)));
                }
            }
            reader.Close();

            return checks;
        }
    }
}
