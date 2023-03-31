using AutoMapper;
using Movie_Library_API.Domain.Entities;
using Movie_Library_API.Dtos;
using System.Runtime.InteropServices;

namespace Movie_Library_API
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<ActorDto, Actor>();
            CreateMap<MovieDto, Movie>();
            CreateMap<Movie, Movie>();
        }
    }
}
