using Microsoft.EntityFrameworkCore;
using MovieBookingApp.Models;

namespace MovieBookingAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null;

        public DbSet<Movie> Movies { get; set; } = null;

        public DbSet<Theatre> Theatres { get; set; }

        public DbSet<Screen> Screens { get; set; }

        public DbSet<Show> Shows { get; set; }

        public DbSet<Seat> Seats { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<BookingDetail> BookingDetails { get; set; }
    }
}