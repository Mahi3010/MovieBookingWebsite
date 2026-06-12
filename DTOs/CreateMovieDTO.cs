namespace MovieBookingAPI.DTOs
{
    public class CreateMovieDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;

        public int Duration { get; set; }
        public string Language { get; set; }= string.Empty;
        public DateTime ReleaseDate { get; set; }

        public string PosterUrl { get; set; } = string.Empty;
    }
}
