using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess.Repositories.User
{
    public interface IUserRepository
    {
        public long AddUser(string login, string password, string role);
        public void UpdateUser(UserModel user);
        public void DeleteUser(long idUser);
        public List<UserModel> GetUsers();
        public UserModel GetUser(long idUser);
        public UserModel GetUserLogin(string login);
    }
}
