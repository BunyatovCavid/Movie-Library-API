using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Movie_Library_API.Domain;
using Movie_Library_API.Domain.Entities;
using Movie_Library_API.Dtos;
using Movie_Library_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Library_API.Services
{
    public class ActorService : IActor
    {
        CinemaContex cc;
        IMapper _mapper;
        public ActorService(IMapper mapper)
        {
            cc = new();
            _mapper = mapper;
        }
        public async Task<Actor> GetActorByid(int id)
        {
            try
            {
                var data = await cc.Actors.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
                return data;
            }
            catch (Exception ex)
            {
                var log = ex.Message;
                var log_inner = ex.InnerException;
                return null;
            }
        }

        public async Task<List<Actor>> GetActors()
        {
            try
            {
                var data = await cc.Actors.AsNoTracking().ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                var log = ex.Message;
                var log_inner = ex.InnerException;
                return null;
            }
        }

        public async  Task<Actor> PostActor(ActorDto actorDto)
        {
            try
            {
                var new_post = _mapper.Map<Actor>(actorDto);
                await cc.Actors.AddAsync(new_post);
                await cc.SaveChangesAsync();
                var return_value = await cc.Actors.OrderByDescending(a => a.Id).FirstOrDefaultAsync(a=>a.Name==new_post.Name);
                return return_value;
            }
            catch (Exception ex)
            {
                var log = ex.Message;
                var log_inner = ex.InnerException;
                return null;
            }
        }

        public async  Task<Actor> PutActor(int id, ActorDto actorDto)
        {
            try
            {
                var data = await cc.Actors.FirstOrDefaultAsync(a => a.Id == id);
                if (data != null)
                {
                    var return_value = _mapper.Map(actorDto, data);
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
        public async Task<string> DeleteActor(int id)
        {
            try
            {
                var data = await cc.Actors.FirstOrDefaultAsync(a => a.Id == id);
                if (data != null)
                {
                    cc.Actors.Remove(data);
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
