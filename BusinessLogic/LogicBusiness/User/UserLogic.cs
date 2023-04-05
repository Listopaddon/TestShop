using BusinessLogic.LogicBusiness.PlaceSession;
using DataAccess.Models;
using DataAccess.Repositories.User;
using System.Collections.Generic;

namespace BusinessLogic.LogicBusiness.User
{
    public class UserLogic : IUserLogic
    {
        IUserRepository userRepository;
        IPlaceSessionLogic placeSessionLogic;

        public UserLogic(IUserRepository userRepository, IPlaceSessionLogic placeSessionLogic)
        {
            this.placeSessionLogic = placeSessionLogic;
            this.userRepository = userRepository;
        }

        public long AddUser(string login, string password, string role) => userRepository.AddUser(login, password, role);

        public void UpdateUser(UserModel user) => userRepository.UpdateUser(user);

        public void DeleteUser(long idUser)
        {
            placeSessionLogic.DeleteIdUserFromPlaceSession(idUser);
            userRepository.DeleteUser(idUser);
        }

        public List<UserModel> GetUsers() => userRepository.GetUsers();

        public UserModel GetUser(long idUser) => userRepository.GetUser(idUser);

        public UserModel GetUserLogin(string login) => userRepository.GetUserLogin(login);

        public bool IsValidLogin(string login) => GetUserLogin(login) == null;

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
    }
}
