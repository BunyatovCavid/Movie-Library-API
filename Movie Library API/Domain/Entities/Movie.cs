using System;
using System.Collections.Generic;

namespace Movie_Library_API.Domain.Entities
{
    public class Movie
    {
        public Movie()
        {
            Actors = new HashSet<Actor>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public int Release_year { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }

        public ICollection<Actor> Actors { get; set; }
    }
}
