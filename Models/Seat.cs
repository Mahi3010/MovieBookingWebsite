using System;
using System.Collections.Generic;
using System.Text;

namespace MovieBookingApp.Models
{
    public class Seat
    {
        public int Id { get; set; } //PK
        public int ScreentId { get; set; } //FK
        public string SeatNumber { get; set; }
        public string SeatType = "Regular"; //VIP

        public Screen? Screen { get; set; }

        public ICollection<BookingDetail>? BookingDetails { get; set; }

    }
}
