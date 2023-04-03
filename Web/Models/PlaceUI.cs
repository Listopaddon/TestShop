namespace Web.Models
{
    public class PlaceUI
    {
        long id;
        long idRow;
        int numberPlace;
        PlaceSessionUI placeSession;

        public PlaceUI(long id, long idRow, int numberPlace, PlaceSessionUI placeSession)
        {
            this.id = id;
            this.idRow = idRow;
            this.numberPlace = numberPlace;
            this.placeSession = placeSession;
        }

        public long Id { get { return id; } }

        public long IdRow { get { return idRow; } }

        public int NumberPlace { get { return numberPlace; } }

        public PlaceSessionUI PlaceSession { get { return placeSession; } }
    }
}
