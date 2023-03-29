namespace Web.Models
{
    public class SessionUI
    {
        long id;
        long idMovie;
        long idHall;
        decimal price;

        public SessionUI(long id, long idMovie, long idHall, decimal price)
        {
            this.id = id;
            this.idMovie = idMovie;
            this.idHall = idHall;
            this.price = price;
        }

        public long Id
        { get { return id; } }

        public long IdMovie
        { get { return idMovie; } }

        public long IdHall
        { get { return idHall; } }

        public decimal Price
        { get { return price; } }

    }
}
