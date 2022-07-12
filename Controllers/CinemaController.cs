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

        
    }
}
