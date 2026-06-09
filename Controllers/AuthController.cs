using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Mvc;
using MovieBookingAPI.DTOs;
using MovieBookingAPI.Data;
using BCrypt.Net;
using MovieBookingApp.Models;
using MovieBookingAPI.Helpers;
namespace MovieBookingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        private readonly JwtService _jwtService;
        public AuthController(AppDbContext context,JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
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
            // find user by email
            var  user = _context.Users
                .FirstOrDefault(u=>u.Email == loginDTO.Email);

            if(user == null)
            {
                return Unauthorized("Invalid Email or Password");
            }

            //Verify password

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(
                loginDTO.Password,
                user.PasswordHash);

            if (!isPasswordValid)
            {
                return Unauthorized("Invalid Email or Password");
            }

            //generate JWT Token
            string token = _jwtService.GenerateToken(user);

            return Ok( new
             {
                Message = "Login Successful",
                Token = token
            });
        }
    }
}
