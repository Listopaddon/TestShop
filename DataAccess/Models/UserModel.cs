using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class UserModel
    {
        long id;
        string login;
        string password;
        string role;

        public UserModel(long id, string login, string password, string role)
        {
            this.id = id;
            this.login = login;
            this.password = password;
            this.role = role;
        }

        public long ID
        { get { return id; } }

        public string Login
        { get { return login; } }

        public string Password
        { get { return password; } }

        public string Role
        { get { return role; } }

        public void ClearPassword()
        {
            password = string.Empty;
        }

    }
}
