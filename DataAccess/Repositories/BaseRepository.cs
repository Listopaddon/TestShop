using System;
using System.Data.SqlClient;

namespace DataAccess.Repositories
{
    public class BaseRepository
    {
        public SqlCommand CreateCommand(string sqlExpression, SqlConnection connection, 
                                        params SqlParameter[] parameters)
        {
            connection.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            foreach (SqlParameter param in parameters)
            {
                command.Parameters.Add(param);
            }

            return command;
        }
    }
}
