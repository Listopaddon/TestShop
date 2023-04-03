namespace Web.Models
{
    public class LogIn
    {
        string redirectURL;

        public LogIn(string redirectURL) => this.redirectURL = redirectURL;

        public string RedirectURL { get { return redirectURL; } }
    }
}
