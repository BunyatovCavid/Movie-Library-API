namespace Movie_Library_API.Dtos
{
    public class ActorMovieDto
    {
        public string ActorName { get; set; }

        public string MovieTitle { get; set; }
        public int MovieRelease_year { get; set; }
        public string MovieGenre { get; set; }
        public string MovieDirector { get; set; }
    }
}
