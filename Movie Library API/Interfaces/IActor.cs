using Movie_Library_API.Domain.Entities;
using Movie_Library_API.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movie_Library_API.Interfaces
{
    public interface IActor
    {
        public Task<List<Actor>> GetActors();
        public Task<Actor> GetActorByid(int id);
        public Task<Actor> PostActor(ActorDto actorDto);
        public Task<Actor> PutActor(int id, ActorDto actorDto);
        public Task<string> DeleteActor(int id);
    }
}
