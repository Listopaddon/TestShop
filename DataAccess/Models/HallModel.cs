using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class HallModel
    {
        long id;
        long idCinema;

        public HallModel() { }

        public HallModel(long id, long idCinema)
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
