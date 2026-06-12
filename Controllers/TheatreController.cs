using Microsoft.AspNetCore.Mvc;
using MovieBookingAPI.Data;
using MovieBookingAPI.DTOs;
using MovieBookingApp.Models;

namespace MovieBookingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TheatreController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TheatreController(AppDbContext context)
        {
            _context = context;
        }
        //to add theatre's
        [HttpPost]
        public IActionResult AddTheatre(CreateTheatreDTO dto)
        {
            var theatre = new Theatre
            {
                Name = dto.Name,
                Location = dto.Location
            };
            _context.Theatres.Add(theatre);
            _context.SaveChanges();
            return Ok(theatre);
        }

        [HttpGet]
        public IActionResult GetTheatres()
        {
            var theatres = _context.Theatres.ToList();
            return Ok(theatres);
        }

        [HttpGet("{id}")]
        public IActionResult GetTheatreById(int id)
        {
            var theatre = _context.Theatres.FirstOrDefault(x => x.Id == id);
            if (theatre == null)
            {
                return NotFound("Theatre not found");
            }
            return Ok(theatre);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTheatre(int id,CreateTheatreDTO dto)
        {
            var theatre = _context.Theatres.FirstOrDefault(x=>x.Id == id);
            if(theatre == null)
            {
                return NotFound("Theatre not found");
            }

            theatre.Name = dto.Name;
            theatre.Location = dto.Location;

            _context.SaveChanges();
            return Ok(theatre);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTheatre(int id)
        {
            var theatre = _context.Theatres.FirstOrDefault(m=>m.Id == id);
            if(theatre == null)
            {
                return NotFound("Theatre does not exist");
            }
            _context.Theatres.Remove(theatre);

            _context.SaveChanges();

            return Ok("Theatre deleted successfully");
        }
    }
}
