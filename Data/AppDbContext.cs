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

        public DbSet<User> Users { get; set; } = null!;

        public DbSet<Movie> Movies { get; set; } = null!;

        public DbSet<Theatre> Theatres { get; set; } = null!;

        public DbSet<Screen> Screens { get; set; } = null!;

        public DbSet<Show> Shows { get; set; } = null!;

        public DbSet<Seat> Seats { get; set; } = null!;

        public DbSet<Booking> Bookings { get; set; } = null!;

        public DbSet<BookingDetail> BookingDetails { get; set; } = null!;
    }
}