using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieBookingApp.Models
{
    public class Movie
    {
        public int Id { get; set; } // primary key
        [Required]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int Duration { get; set; } 
        public string Language { get; set; } = string.Empty;
        public string Genre { get; set; } = String.Empty;
        public DateTime ReleaseDate { get; set; }

        public string? PosterUrl { get; set; }
        public ICollection<Show>? Shows { get; set; }
    }
}
