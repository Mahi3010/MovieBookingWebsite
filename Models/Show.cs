using System;
using System.Collections.Generic;
using System.Text;

namespace MovieBookingApp.Models
{
    public class Show
    {
        public int Id { get; set; } //PK
        public int MovieID { get; set; } //FK
        public int ScreenId { get; set; } //FK
        public DateTime ShowTime { get; set; }
        public decimal Price { get; set; }

        //public int theatreId;

        public Movie? Movie { get; set; }
        public Screen? Screen { get; set; }

        public ICollection<Booking>? Bookings { get; set; }

    }
}
