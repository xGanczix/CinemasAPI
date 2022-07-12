using CinemasAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CinemasAPI.Controllers
{
    [Route("api/cinema")]
    public class CinemaController : ControllerBase
    {
        private readonly CinemaDbContext _dbContext;
        public CinemaController(CinemaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cinema>> GetAll()
        {
            var cinemas = _dbContext
                .Cinemas
                .ToList();

            return Ok(cinemas); 
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

            return Ok(cinemas);
        }
    }
}
