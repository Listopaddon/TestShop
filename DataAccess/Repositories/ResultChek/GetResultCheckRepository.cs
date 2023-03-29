using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.ResultChek
{
    public class GetResultCheckRepository : BaseRepository, IGetResultCheckRepository
    {
        string connectionString;
        public GetResultCheckRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Check> GetCheck(long idUser)
        {
            SqlParameter parameter = new SqlParameter("@idUser", idUser);
            List<Check> checks = new List<Check>();

            var reader = CreateCommand("sp_GetResultCheck", new SqlConnection(connectionString),parameter).ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    checks.Add(new Check(reader.GetString(0), reader.GetDateTime(1), reader.GetInt32(2),
                                         reader.GetInt64(3), reader.GetString(4),reader.GetDecimal(5)));
                }
            }
            reader.Close();

            return checks;
        }
    }
}
