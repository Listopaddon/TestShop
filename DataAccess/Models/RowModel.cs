namespace DataAccess.Models
{
    public class RowModel
    {
        long id;
        long numberRow;
        long idArea;

        public RowModel() { }

        public RowModel(long id, long numberRow, long idArea)
        {
            this.id = id;
            this.numberRow = numberRow;
            this.idArea = idArea;
        }

        public long Id { get { return id; } }

        public long NumberRow { get { return numberRow; } }

        public long IdArea { get { return idArea; } }
    }
}
