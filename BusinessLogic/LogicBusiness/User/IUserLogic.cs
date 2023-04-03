using DataAccess.Models;
using System.Collections.Generic;

namespace BusinessLogic.LogicBusiness.User
{
    public interface IUserLogic
    {
        public long AddUser(string login, string password, string role);
        public void UpdateUser(UserModel user);
        public void DeleteUser(long idUser);
        public List<UserModel> GetUsers();
        public UserModel GetUser(long idUser);
        public UserModel GetUserLogin(string login);
        public bool IsValidLogin(string login);
        public void Registration(string login, string password);
        public UserModel LogIn(string login, string password);
    }
}
