using System;
using System.Collections.Generic;
using System.Text;

namespace MovieBookingApp.Models
{
    public class BookingDetail
    {
        public int Id { get; set; }  //PK
        public int BookingId { get; set; }  //FK
        public int SeatId { get; set; } //FK

        public Booking? Booking { get; set; }

        public Seat? Seat { get; set; }
    }
}
