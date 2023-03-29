using DataAccess.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccess.Repositories.User
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        string connectionString;

        public UserRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public long AddUser(string login, string password, string role)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@Login", login) ,
                                                             new SqlParameter("@Password", password),
                                                             new SqlParameter("@Role", role)};

            return (long)CreateCommand("sp_InsertUser", new SqlConnection(connectionString), parameters).ExecuteScalar();
        }

        public void UpdateUser(UserModel user)
        {
            SqlParameter[] parameters = new SqlParameter[] {new SqlParameter("@Id", user.ID),
                                                            new SqlParameter("@Login", user.Login),
                                                            new SqlParameter("@Password", user.Password),
                                                            new SqlParameter("@Role", user.Role)};
            CreateCommand("sp_UpdateUser", new SqlConnection(connectionString), parameters).ExecuteScalar();
        }

        public void DeleteUser(long id)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@Id", id) };
            CreateCommand("sp_DeleteUser", new SqlConnection(connectionString), parameters).ExecuteScalar();
        }

        public List<UserModel> GetUsers()
        {
            List<UserModel> users = new List<UserModel>();
            var reader = CreateCommand("sp_GetUsers", new SqlConnection(connectionString)).ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    users.Add(new UserModel(reader.GetInt64(0), reader.GetString(1),
                                       reader.GetString(2), reader.GetString(3)));
                }
            }
            reader.Close();
            return users;
        }

        public UserModel GetUser(long id)
        {
            List<UserModel> result = new List<UserModel>();
            SqlParameter parameter = new SqlParameter("@IdUser", id);
            var reader = CreateCommand("sp_GetUser", new SqlConnection(connectionString), parameter).ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result.Add(new UserModel(reader.GetInt64(0), reader.GetString(1),
                                         reader.GetString(2), reader.GetString(3)));
                }
            }

            return result.Single();
        }

        public UserModel GetUserLogin(string login)
        {
            List<UserModel> result = new List<UserModel>();
            SqlParameter parameter = new SqlParameter("@Login", login);
            var reader = CreateCommand("sp_GetUserLogin", new SqlConnection(connectionString), parameter).ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result.Add(new UserModel(reader.GetInt64(0), reader.GetString(1),
                                         reader.GetString(2), reader.GetString(3)));
                }
            }

            return result.FirstOrDefault();
        }
    }
}
