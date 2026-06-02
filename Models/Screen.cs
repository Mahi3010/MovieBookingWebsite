using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieBookingApp.Models
{
    public class Screen
    {
        public int Id { get; set; } // primary key
        [Required]
        public int TheatreId { get; set; }  //Foreign key (one theatre = multiple screens)
        public int ScreenNumber { get; set; }
        public int screensize { get; set; }
        public int TotalSeats { get; set; }
        public Theatre? Theatre { get; set; }

        public ICollection<Seat>? Seats { get; set; }
        public ICollection<Show>? Shows { get; set; }
    }
}
