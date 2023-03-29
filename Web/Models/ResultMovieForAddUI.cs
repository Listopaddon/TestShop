using System;

namespace Web.Models
{
    public class ResultMovieForAddUI
    {
        long idHall;
        string nameMovie;
        string discriptionMovie;
        string nameCinema;
        DateTime timeMovie;

        public ResultMovieForAddUI(long idHall, string nameMovie,
                                 string discriptionMovie, string nameCinema, DateTime timeMovie)
        {
            this.idHall = idHall;
            this.nameMovie = nameMovie;
            this.discriptionMovie = discriptionMovie;
            this.nameCinema = nameCinema;
            this.timeMovie = timeMovie;
        }

        public long IdHall { get { return idHall; } }
        public string NameMovie { get { return nameMovie; } }
        public string DiscriptionMovie { get { return discriptionMovie; } }
        public string NameCinema { get { return nameCinema; } }
        public DateTime TimeMovie { get { return timeMovie; } }
    }
}
