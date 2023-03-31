using Microsoft.AspNetCore.Mvc;
using Movie_Library_API.Domain.Entities;
using Movie_Library_API.Dtos;
using Movie_Library_API.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movie_Library_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActorController : ControllerBase
    {
        IActor _actor;
        public ActorController(IActor actor)
        {
            _actor = actor;
        }

        [HttpGet]
        public async Task<List<Actor>> GetActor()
        {
            var data = await _actor.GetActors();
            return data;
        }

        [HttpGet("{id}")]
        public async Task<Actor> GetActorById([FromQuery] int id)
        {
            var data = await _actor.GetActorByid(id);
            return data;
        }
        [HttpPost]
        public async Task<Actor> PostActor([FromQuery] ActorDto actorDto)
        {
            var data = await _actor.PostActor(actorDto);
            return data;
        }
        [HttpPut]
        public async Task<Actor> PutActor([FromQuery] int id, [FromQuery] ActorDto actorDto)
        {
            var data = await _actor.PutActor(id, actorDto);
            return data;
        }
        [HttpDelete]
        public async Task<string> DeleteActor([FromQuery] int id)
        {
            var data = await _actor.DeleteActor(id);
            return data;
        }
    }
}
