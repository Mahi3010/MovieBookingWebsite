using Microsoft.AspNetCore.Mvc;
using MovieBookingAPI.Data;
using MovieBookingAPI.DTOs;
using MovieBookingApp.Models;
namespace MovieBookingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        //_context - this is AppDbContext object

        private readonly AppDbContext _context;

        public MovieController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddMovie(CreateMovieDTO dto) {
            var movie = new Movie
            {
                Title = dto.Title,
                Description = dto.Description,
                Genre = dto.Genre,
                Duration = dto.Duration,
                Language = dto.Language,
                ReleaseDate = dto.ReleaseDate,
                PosterUrl = dto.PosterUrl

            };
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return Ok(movie);
        }
        [HttpGet]
        public IActionResult GetMovies()
        {
            var movies = _context.Movies.ToList();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m=>m.Id == id);

            if(movie == null)
            {
                return NotFound("Movie not found");
            }

            return Ok(movie);
        }

        //Update Movie
        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, CreateMovieDTO dto)
        {
            var movie = _context.Movies.FirstOrDefault(m=>m.Id == id);

            if(movie == null)
            {
                return NotFound("Movie does not exit");
            }
            movie.Title = dto.Title;
            movie.Description = dto.Description;
            movie.Genre = dto.Genre;
            movie.Duration = dto.Duration;
            movie.ReleaseDate = dto.ReleaseDate;
            movie.Language = dto.Language;
            movie.PosterUrl = dto.PosterUrl;

            _context.SaveChanges();
            return Ok(movie);
        }

        //Delete Movie
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
            if( movie == null)
            {
                return NotFound("Movie does not exist");
            }

            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return Ok("Movie deleted Successfully");

        }
    }
}
