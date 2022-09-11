using AutoMapper;
using CinemasAPI.Entities;
using CinemasAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CinemasAPI.Services
{
    public interface ICinemaService
    {
        CinemaClient GetById(int id);
        IEnumerable<CinemaClient> GetAll();
        int Create(CreateCinemaClient client);
        bool Delete(int id);
        bool Update(int id, UpdateCinemaClient client);
    }

    public class CinemaService : ICinemaService
    {
        private readonly CinemaDbContext _dbContext;
        private readonly IMapper _mapper;
        public CinemaService(CinemaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        public CinemaClient GetById(int id)
        {
            var cinemas = _dbContext
                .Cinemas
                .Include(c => c.Address)
                .Include(c => c.Films)
                .FirstOrDefault(c => c.Id == id);

            if(cinemas is null)
            {
                return null;
            }

            var result = _mapper.Map<CinemaClient>(cinemas);
            return result;
        }

        public IEnumerable<CinemaClient> GetAll()
        {
            var cinemas = _dbContext
                .Cinemas
                .Include(c => c.Address)
                .Include(c => c.Films)
                .ToList();

            var cinemasClient = _mapper.Map<List<CinemaClient>>(cinemas);

            return cinemasClient;
        }

        public int Create(CreateCinemaClient client)
        {
            var cinema = _mapper.Map<Cinema>(client);
            _dbContext.Cinemas.Add(cinema);
            _dbContext.SaveChanges();

            return cinema.Id;
        }

        public bool Delete(int id)
        {
            var cinemas = _dbContext
                .Cinemas
                .FirstOrDefault(c => c.Id == id);

            if(cinemas is null)
            {
                return false;
            }

            _dbContext.Cinemas.Remove(cinemas);
            _dbContext.SaveChanges();

            return true;
        }

        public bool Update(int id, UpdateCinemaClient client)
        {
            var cinemas = _dbContext
                .Cinemas
                .FirstOrDefault(c => c.Id ==id);

            if(cinemas is null)
            {
                return false;
            }

            cinemas.Name = client.Name;
            cinemas.IsOpen  = client.IsOpen;
            cinemas.ContactEmail = client.ContactEmail;

            _dbContext.SaveChanges();

            return true;
        }
    }
}
