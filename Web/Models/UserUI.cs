namespace Web.Models
{
    public class UserUI
    {
        long id;
        string login;
        string password;
        string role;

        public UserUI(long id, string login, string password, string role)
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

    }
}
