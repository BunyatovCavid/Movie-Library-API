using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Movie_Library_API.Domain;
using Movie_Library_API.Domain.Entities;
using Movie_Library_API.Dtos;
using Movie_Library_API.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Library_API.Services
{
    public class ActorMovieService : IActorMovie
    {
        CinemaContex cc;
        IMapper _mapper;
        public ActorMovieService(IMapper mapper)
        {
            cc = new();
            _mapper = mapper;
        }
        public async Task<ICollection<Actor>> GetActorByMovieId(int id)
        {
            try
            {
                var data = await cc.Movies.Include(m => m.Actors).FirstOrDefaultAsync(m => m.Id == id);
                var return_data = data.Actors;
                return return_data;
            }
            catch (Exception ex)
            {
                var log = ex.Message;
                var log_inner = ex.InnerException;
                return null;
            }
        }

        public async Task<Movie> GetMoviieByTitleActor(string title, string actorname)
        {
            try
            {
                var data = await cc.Movies.Include(m => m.Actors).FirstOrDefaultAsync(m => m.Title == title);
                var data_2 = data.Actors.FirstOrDefault(a => a.Name == actorname);
                if (data != null && data_2 != null)
                {
                    return data;
                }
                else return null;
            }
            catch (Exception ex)
            {
                var log = ex.Message;
                var log_inner = ex.InnerException;
                return null;
            }
        }

        public async Task<Movie> PostActorToMovie(ActorMovieDto actorMovieDto)
        {
            try
            {
                var data = await cc.Movies.Include(m => m.Actors).FirstOrDefaultAsync(
                     m => m.Title == actorMovieDto.MovieTitle &&
                      m.Release_year == actorMovieDto.MovieRelease_year &&
                      m.Genre == actorMovieDto.MovieGenre &&
                      m.Director == actorMovieDto.MovieDirector);

                var data_2 = await cc.Actors.SingleOrDefaultAsync(a=>a.Name==actorMovieDto.ActorName);
                if(data!=null&&data_2!=null) data.Actors.Add(data_2);
                else
                {
                    data.Actors.Add(new Actor { Name =actorMovieDto.ActorName});
                }
                await cc.SaveChangesAsync();
                var return_value = await cc.Movies.Include(m => m.Actors).OrderByDescending(m => m.Id)
                    .FirstOrDefaultAsync(m => m.Title == actorMovieDto.MovieTitle);
                return return_value;
            }
            catch (Exception ex)
            {
                var log = ex.Message;
                var log_inner = ex.InnerException;
                return null;
            }
        }

        public async Task<string> DeleteActorsByIdFromMovie(int id)
        {
            try
            {
                var data = await cc.Movies.Include(m => m.Actors).FirstOrDefaultAsync(m => m.Id
                == id);
                
                if (data != null)
                {
                    foreach (var item in data.Actors)
                    {
                        data.Actors.Remove(item);
                    }
                    await cc.SaveChangesAsync();
                    return "Succesful";
                }
                else return "This id is not registered";
            }
            catch (Exception ex)
            {
                var log = ex.Message;
                var log_inner = ex.InnerException;
                return "Failed";
            }
        }
    }
}
