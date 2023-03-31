using Movie_Library_API.Domain.Entities;
using Movie_Library_API.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movie_Library_API.Interfaces
{
    public interface IMovie
    {
        public Task<List<Movie>> GetMovies();
        public Task<Movie> GetMovieByid(int id);
        public Task<Movie> PostMovie(MovieDto movieDto);
        public Task<Movie> PutMovie(int id, MovieDto movieDto);
        public Task<string> DeleteMovie(int id);
    }
}
