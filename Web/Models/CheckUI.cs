using System;

namespace Web.Models
{
    public class CheckUI
    {
        long idPlaceSession;
        string nameMovie;
        DateTime timeSession;
        int numberPlace;
        long numberRow;
        string nameCinema;
        decimal price;

        public CheckUI(long idPlaceSession, string nameMovie, DateTime timeSession, int numberPlace,
                      long numberRow, string nameCinema, decimal price)
        {
            this.idPlaceSession = idPlaceSession;
            this.nameMovie = nameMovie;
            this.timeSession = timeSession;
            this.numberPlace = numberPlace;
            this.numberRow = numberRow;
            this.nameCinema = nameCinema;
            this.price = price;
        }

        public long IdPlaceSession { get { return idPlaceSession; } }
        public string NameMovie { get { return nameMovie; } }
        public DateTime TimeSession { get { return timeSession; } }
        public int NumberPlace { get { return numberPlace; } }
        public long NumberRow { get { return numberRow; } }
        public string NameCinema { get { return nameCinema; } }
        public decimal Price { get { return price; } }

    }
}
