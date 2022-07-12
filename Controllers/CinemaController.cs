using AutoMapper;
using CinemasAPI.Entities;
using CinemasAPI.Models;
using CinemasAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CinemasAPI.Controllers
{
    [Route("api/cinema")]
    public class CinemaController : ControllerBase
    {
        private readonly ICinemaService _cinemaService;
        public CinemaController(ICinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateCinemaClient client, [FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isUpdated = _cinemaService.Update(id, client);
            if(!isUpdated)
            {
                return NotFound();
            }

            return  Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _cinemaService.Delete(id);

            if(isDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult CreateCinema([FromBody] CreateCinemaClient client)
        {
            var id = _cinemaService.Create(client);

            return Created($"/api/cinema/{id}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<CinemaClient>> GetAll()
        {
            var cinemasClient = _cinemaService.GetAll();

            return Ok(cinemasClient); 
        }

        [HttpGet("{id}")]
        public ActionResult<Cinema> Get([FromRoute] int id)
        {
            var cinemas = _cinemaService.GetById(id);

            if (cinemas is null)
            {
                return NotFound();
            }

            return Ok(cinemas);
        }
    }
}
