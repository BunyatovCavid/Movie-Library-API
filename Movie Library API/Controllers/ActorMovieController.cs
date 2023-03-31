using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movie_Library_API.Domain.Entities;
using Movie_Library_API.Dtos;
using Movie_Library_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Library_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActorMovieController : ControllerBase
    {
        IActorMovie ActorMovie;

        public ActorMovieController(IActorMovie movie)
        {
            ActorMovie = movie;
        }

        [HttpGet]
        public async Task<Movie> GetMoviieByTitle([FromQuery] string title, [FromQuery] string actorname)
        {
            var data = await ActorMovie.GetMoviieByTitleActor(title,actorname);
            return data;
        }

        [HttpGet("{id}")]
        public async Task<ICollection<Actor>> GetActorById([FromQuery] int id)
        {
            var data = await ActorMovie.GetActorByMovieId(id);
            return data;
        }
        [HttpPost]
        public async Task<Movie> PostMovieActor([FromQuery] ActorMovieDto actorMovieDto)
        {
            var data = await ActorMovie.PostActorToMovie(actorMovieDto);
            return data;
        }

        [HttpDelete]
        public async Task<string> DeleteMovie([FromQuery] int id)
        {
            var data = await ActorMovie.DeleteActorsByIdFromMovie(id);
            return data;
        }


    }
}
