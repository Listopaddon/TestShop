namespace DataAccess.Models
{
    public class AreaModel
    {
        long id;
        long idHall;

        public AreaModel(long id, long idHall)
        {
            this.id = id;
            this.idHall = idHall;
        }

        public long Id { get { return id; } }

        public long IdHall { get { return idHall; } }

    }
}
