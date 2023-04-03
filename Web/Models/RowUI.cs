using System.Collections.Generic;

namespace Web.Models
{
    public class RowUI
    {
        long idRow;
        long numberRow;
        List<PlaceUI> places;

        public RowUI() { }
        public RowUI(long idRow, long numberRow, List<PlaceUI> places)
        {
            this.idRow = idRow;
            this.numberRow = numberRow;
            this.places = places;
        }

        public long IdRow { get { return idRow; } }

        public List<PlaceUI> Places { get { return places; } }

        public long NumberRow { get { return numberRow; } }

    }
}
