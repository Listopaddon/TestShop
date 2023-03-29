namespace Web.Models
{
    public class HallUI
    {
        long id;
        long idCinema;

        public HallUI(long id, long idCinema)
        {
            this.id = id;
            this.idCinema = idCinema;
        }

        public long Id
        { get { return id; } }

        public long IdCinema
        { get { return idCinema; } }
    }
}
