using Movie_Library_API.Domain.Entities;
using Movie_Library_API.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movie_Library_API.Interfaces
{
    public interface IActorMovie
    {
        public Task<ICollection<Actor>> GetActorByMovieId(int id);
        public Task<Movie> GetMoviieByTitleActor(string title, string actorname);
        public Task<Movie> PostActorToMovie(ActorMovieDto actorMovieDto);
        public Task<string> DeleteActorsByIdFromMovie(int id);

    }
}
