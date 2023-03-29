using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class MovieModel
    {
        long id;
        string name;
        string discription;
        DateTime time;

        public MovieModel(long id, string name, string discription, DateTime time)
        {
            this.id = id;
            this.name = name;
            this.discription = discription;
            this.time = time;
        }

        public long Id
        { get { return id; } }

        public string Name
        { get { return name; } }

        public string Discription
        { get { return discription; } }

        public DateTime Time
        { get { return time; } }
        
    }
}
