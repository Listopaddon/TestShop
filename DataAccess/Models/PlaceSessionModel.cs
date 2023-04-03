using System;

namespace DataAccess.Models
{
    public class PlaceSessionModel
    {
        long id;
        long idPlaces;
        long idSession;
        long idUsers;
        DateTime dateModified;
        StatePlace state;

        public PlaceSessionModel() { }
        public PlaceSessionModel(long id, long idPlaces, long idSession,
                                 long idUsers, DateTime dateModified, StatePlace state)
        {
            this.id = id;
            this.idPlaces = idPlaces;
            this.idSession = idSession;
            this.idUsers = idUsers;
            this.state = state;
            this.dateModified = dateModified;
        }

        public long Id { get { return id; } }

        public long IdPlaces { get { return idPlaces; } }

        public long IdSession { get { return idSession; } }

        public long IdUsers { get { return idUsers; } }

        public StatePlace State { get { return state; } }

        public DateTime DateModified { get { return dateModified; } }

    }
}
