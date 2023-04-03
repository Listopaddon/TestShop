using System;

namespace Web.Models
{
    public class MovieUI
    {
        long id;
        string name;
        string discription;
        DateTime time;

        public MovieUI(long id, string name, string discription, DateTime time)
        {
            this.id = id;
            this.name = name;
            this.discription = discription;
            this.time = time;
        }

        public long Id { get { return id; } }

        public string Name { get { return name; } }

        public string Discription { get { return discription; } }

        public DateTime Time { get { return time; } }
    }
}
