using AutoMapper;
using CinemasAPI.Entities;
using CinemasAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CinemasAPI.Controllers
{
    [Route("api/cinema")]
    public class CinemaController : ControllerBase
    {
        private readonly CinemaDbContext _dbContext;
        private readonly IMapper _mapper;
        public CinemaController(CinemaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CinemaClient>> GetAll()
        {
            var cinemas = _dbContext
                .Cinemas
                .ToList();

            var cinemasClient = _mapper.Map<List<CinemaClient>>(cinemas);

            return Ok(cinemasClient); 
        }

        [HttpGet("{id}")]
        public ActionResult<Cinema> Get([FromRoute] int id)
        {
            var cinemas = _dbContext
                .Cinemas
                .FirstOrDefault(c => c.Id == id);

            if (cinemas is null)
            {
                return NotFound();
            }

            var cinemasClient = _mapper.Map<CinemaClient>(cinemas);

            return Ok(cinemasClient);
        }
    }
}
