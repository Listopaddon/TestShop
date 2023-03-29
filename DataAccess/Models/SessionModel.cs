using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class SessionModel
    {
        long id;
        long idMovie;
        long idHall;
        decimal price;

        public SessionModel() { }

        public SessionModel(long id, long idMovie, long idHall, decimal price)
        {
            this.id = id;
            this.idMovie = idMovie;
            this.idHall = idHall;
            this.price = price;
        }

        public long Id
        { get { return id; } }

        public long IdMovie
        { get { return idMovie; } }

        public long IdHall
        { get { return idHall; } }

        public decimal Price
        { get { return price; } }

    }
}
