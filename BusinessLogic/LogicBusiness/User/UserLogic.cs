using BCrypt.Net;
using DataAccess.Models;
using DataAccess.Repositories.User;
using System.Collections.Generic;

namespace BusinessLogic.LogicBusiness.User
{
    public class UserLogic : IUserLogic
    {
        IUserRepository userRepository;

        public UserLogic(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public long AddUser(string login, string password, string role)
        {
            return userRepository.AddUser(login, password, role);
        }

        public void UpdateUser(UserModel user)
        {
            userRepository.UpdateUser(user);
        }

        public void DeleteUser(long id)
        {
            userRepository.DeleteUser(id);
        }

        public List<UserModel> GetUsers()
        {
            return userRepository.GetUsers();
        }

        public UserModel GetUser(long id)
        {
            return userRepository.GetUser(id);
        }

        public bool IsValidLogin(string login)
        {
            return GetUserLogin(login) == null;
        }

        public UserModel LogIn(string login, string password)
        {
            UserModel user = GetUserLogin(login);
            if (user == null)
            {
                return null;
            }
            if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return null;
            }
            user.ClearPassword();

            return user;
        }

        public void Registration(string login, string password)
        {
            var passHash = BCrypt.Net.BCrypt.HashPassword(password);
            AddUser(login, passHash, "user");
        }

        public UserModel GetUserLogin(string login)
        {
            return userRepository.GetUserLogin(login);
        }
    }
}
