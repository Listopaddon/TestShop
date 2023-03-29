
using System.Data;

namespace Web.Models
{
    public class CinemaUI
    {
        long id;
        string name;
        string picture;
        long idSession;

        public CinemaUI(long id, string name, string picture, long idSession)
        {
            this.id = id;
            this.name = name;
            this.picture = picture;
            this.idSession = idSession;
        }

        public CinemaUI(long id, string name, string picture)
        {
            this.id = id;
            this.name = name;
            this.picture = picture;
        }

        public long Id
        { get { return id; } }

        public string Name
        { get { return name; } }

        public string Picture
        { get { return picture; } }

        public long IdSession
        { get { return idSession; } }
    }
}
