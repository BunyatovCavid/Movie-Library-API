using System;

namespace Movie_Library_API.Dtos
{
    public class MovieDto
    {
        public string Title { get; set; }
        public int Release_year { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
    }
}
