using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Mvc;
using MovieBookingAPI.DTOs;
using MovieBookingAPI.Data;
using BCrypt.Net;
using MovieBookingApp.Models;
namespace MovieBookingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost("register")]
        public IActionResult Register (RegisterDTO registerDTO)
        {
            //check if email already exist
            var existingUser = _context.Users
                .FirstOrDefault(u=>u.Email == registerDTO.Email);
            if (existingUser != null)
            {
                return BadRequest("Email already registered!");
            }

            //Hash password
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(registerDTO.Password);

            //Create user object
            var user = new User { 
                Name = registerDTO.Name,
                Email = registerDTO.Email,
                PasswordHash = hashedPassword,
                Role = "User"
            };

            //save to database
            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok("User registered successfully");
        }
        [HttpPost("login")]

        public IActionResult Login (LoginDTO loginDTO)
        {
            return Ok("Login API Working");
        }
    }
}
