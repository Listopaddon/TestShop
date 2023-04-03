namespace DataAccess.Models
{
    public class CinemaModel
    {
        long id;
        string name;
        string picture;

        public CinemaModel(long id, string name, string picture)
        {
            this.id = id;
            this.name = name;
            this.picture = picture;
        }

        public long Id { get { return id; } }

        public string Name { get { return name; } }

        public string Picture { get { return picture; } }
    }
}
