using System.Collections.Generic;

namespace Movie_Library_API.Domain.Entities
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
