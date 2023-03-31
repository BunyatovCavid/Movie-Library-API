using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Movie_Library_API.Domain;
using Movie_Library_API.Domain.Entities;
using Movie_Library_API.Dtos;
using Movie_Library_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;

namespace Movie_Library_API.Services
{
    public class MovieService : IMovie
    {
        CinemaContex cc;
        IMapper _mapper;
        public MovieService(IMapper mapper)
        {
            cc = new();
            _mapper = mapper;
        }
        public async Task<Movie> GetMovieByid(int id)
        {
            try
            {
                var data = await cc.Movies.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
                return data;
            }
            catch (Exception ex)
            {
                var log = ex.Message;
                var log_inner = ex.InnerException;
                return null;
            }
        }

        public async Task<List<Movie>> GetMovies()
        {
            try
            {
                var data = await cc.Movies.AsNoTracking().ToListAsync();
                return data;
            }
            catch(Exception ex)
            {
                var log = ex.Message;
                var log_inner = ex.InnerException;
                return null;
            }
        }

        public async Task<Movie> PostMovie(MovieDto movieDto)
        {
            try
            {
                var new_post = _mapper.Map<Movie>(movieDto);
                await cc.Movies.AddAsync(new_post);
                await cc.SaveChangesAsync();
                var return_value = await cc.Movies.OrderByDescending(m => m.Id).FirstOrDefaultAsync(m => m.Title == new_post.Title);
                return return_value;
            }
            catch (Exception ex)
            {
                var log = ex.Message;
                var log_inner = ex.InnerException;
                return null;
            }
        }

        public async Task<Movie> PutMovie(int id, MovieDto movieDto)
        {
            try
            {
                var data = await cc.Movies.FirstOrDefaultAsync(m => m.Id == id);
                if (data != null)
                {
                    var return_value = _mapper.Map(movieDto, data);
                    await cc.SaveChangesAsync();
                    return return_value;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                var log = ex.Message;
                var log_inner = ex.InnerException;
                return null;
            }
        }
        public async Task<string> DeleteMovie(int id)
        {
            try
            {
                var data = await cc.Movies.FirstOrDefaultAsync(m => m.Id == id);
                if (data != null)
                {
                    cc.Movies.Remove(data);
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
