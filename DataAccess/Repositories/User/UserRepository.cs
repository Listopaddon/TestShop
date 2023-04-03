using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccess.Repositories.User
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        string connectionString;

        public UserRepository(string connectionString) => this.connectionString = connectionString;

        public long AddUser(string login, string password, string role)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@Login", login) ,
                                                             new SqlParameter("@Password", password),
                                                             new SqlParameter("@Role", role)};

            return Convert.ToInt64(CreateCommand("sp_InsertUser", new SqlConnection(connectionString), parameters).ExecuteScalar());
        }

        public void UpdateUser(UserModel user)
        {
            SqlParameter[] parameters = new SqlParameter[] {new SqlParameter("@IdUser", user.Id),
                                                            new SqlParameter("@Login", user.Login),
                                                            new SqlParameter("@Password", user.Password),
                                                            new SqlParameter("@Role", user.Role)};
            CreateCommand("sp_UpdateUser", new SqlConnection(connectionString), parameters).ExecuteScalar();
        }

        public void DeleteUser(long idUser) =>
            CreateCommand("sp_DeleteUser", new SqlConnection(connectionString), new SqlParameter("@IdUser", idUser)).ExecuteScalar();

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

        public UserModel GetUser(long idUser)
        {
            List<UserModel> result = new List<UserModel>();
            var reader = CreateCommand("sp_GetUser", new SqlConnection(connectionString), new SqlParameter("@IdUser", idUser)).ExecuteReader();

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
            var reader = CreateCommand("sp_GetUserLogin", new SqlConnection(connectionString), new SqlParameter("@Login", login)).ExecuteReader();

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
