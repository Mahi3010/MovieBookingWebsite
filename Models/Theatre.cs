using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text;

namespace MovieBookingApp.Models
{
    public class Theatre
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;

        public ICollection<Screen>? Screens { get; set; }
    }
}
