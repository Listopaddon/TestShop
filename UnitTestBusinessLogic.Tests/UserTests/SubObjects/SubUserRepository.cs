using DataAccess.Models;
using DataAccess.Repositories.User;
using System.Collections.Generic;

namespace UnitTestBusinessLogic.Tests.UserTests.SubObjects
{
    public class SubUserRepository : IUserRepository
    {
        List<UserModel> users;

        public SubUserRepository(List<UserModel> users)
        {
            this.users = users;
        }

        public long AddUser(string login, string password, string role)
        {
            long id = users.Count;
            users.Add(new UserModel(id, login, password, role));
            return id;
        }

        public void DeleteUser(long id)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].ID == id)
                {
                    users.Remove(users[i]);
                    break;
                }
            }
        }

        public UserModel GetUser(long id)
        {
            UserModel result = null;

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].ID == id)
                {
                    result = users[i];
                }
            }

            return result;
        }

        public List<UserModel> GetUsers()
        {
            return users;
        }

        public void UpdateUser(UserModel user)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].ID == user.ID)
                {
                    users[i] = user;
                    break;
                }
            }
        }
    }
}
