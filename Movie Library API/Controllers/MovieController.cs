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
    public class MovieController : ControllerBase
    {
        IMovie _Movie;
        public MovieController(IMovie movie)
        {
            _Movie = movie;
        }

        [HttpGet]
        public async Task<List<Movie>> GetMovie()
        {
            var data = await _Movie.GetMovies();
            return data;
        }

        [HttpGet("{id}")]
        public async Task<Movie> GetMovieById([FromQuery] int id)
        {
            var data = await _Movie.GetMovieByid(id);
            return data;
        }
        [HttpPost]
        public async Task<Movie> PostMovie([FromQuery] MovieDto MovieDto)
        {
            var data = await _Movie.PostMovie(MovieDto);
            return data;
        }
        [HttpPut]
        public async Task<Movie> PutMovie([FromQuery] int id, [FromQuery] MovieDto MovieDto)
        {
            var data = await _Movie.PutMovie(id, MovieDto);
            return data;
        }
        [HttpDelete]
        public async Task<string> DeleteMovie([FromQuery] int id)
        {
            var data = await _Movie.DeleteMovie(id);
            return data;
        }

    }
}
