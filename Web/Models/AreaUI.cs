namespace Web.Models
{
    public class AreaUI
    {
        long id;
        long idHall;

        public AreaUI(long id, long idHall)
        {
            this.id = id;
            this.idHall = idHall;
        }

        public long Id
        { get { return id; } }

        public long IdHall
        { get { return idHall; } }
    }
}
