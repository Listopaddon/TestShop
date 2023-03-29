using System;

namespace DataAccess.Models
{
    public class MovieSessionModelUI
    {
        long idMovie;
        string name;
        string discription;
        DateTime time;
        long idSession;
        long idHall;
        decimal price;

        public MovieSessionModelUI(long idMovie, string name, string discription,
                                 DateTime time, long idSession, long idHall, decimal price)
        {
            this.idMovie = idMovie;
            this.name = name;
            this.discription = discription;
            this.time = time;
            this.idSession = idSession;
            this.idHall = idHall;
            this.price = price;
        }

        public long IdMovie { get { return idMovie; } }
        public string Name { get { return name; } }
        public string Discription { get { return discription; } }
        public DateTime Time { get { return time; } }
        public long IdSession { get { return idSession; } }
        public long IdHall { get { return idHall; } }
        public decimal Price { get { return price; } }
    }
}
