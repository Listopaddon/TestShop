using DataAccess.Models;
using System.Collections.Generic;

namespace Web.Models
{
    public class RowUI
    {
        long numberRow;
        List<PlaceUI> places;

        public RowUI() { }
        public RowUI(long numberRow, List<PlaceUI> places)
        {
            this.numberRow = numberRow;
            this.places = places;
        }

        public List<PlaceUI> Places
        { get { return places; } }


        public long NumberRow
        { get { return numberRow; } }

    }
}
