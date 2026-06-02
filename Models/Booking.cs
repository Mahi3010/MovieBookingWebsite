
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieBookingApp.Models
{
    public class Booking
    {
        public int Id { get; set; } //PK
        public int UserId { get; set; } //FK
        public int ShowId { get; set; } //FK
        public decimal TotalAmount { get; set; }
        public DateTime BookingTime { get; set; } = DateTime.Now;

        public User? User { get; set; }

        public Show? Show { get; set; }

        public ICollection<BookingDetail>? BookingDetails { get; set; }
    }
}
