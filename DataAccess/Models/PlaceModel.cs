namespace DataAccess.Models
{
    public class PlaceModel
    {
        long id;
        long idRow;
        int numberPlace;
        PlaceSessionModel placeSession;

        public PlaceModel(long id, long idRow, int numberPlace)
        {
            this.id = id;
            this.idRow = idRow;
            this.numberPlace = numberPlace;
        }

        public long Id { get { return id; } }

        public long IdRow { get { return idRow; } }

        public int NumberPlace { get { return numberPlace; } }

        public PlaceSessionModel PlaceSession { get { return placeSession; } }

        public void SetPlaceSession(PlaceSessionModel placeSession) => this.placeSession = placeSession;
    }
}
