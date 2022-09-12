using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models
{
    public class Review
    {
        // Primary Key for Review entity class
        public int ReviewId {get; set;}

        [Range(1,5)]
        [Required]
        public int Score {get; set;}

        [Display(Name = "Movie")]
        [Required]
        public int MovieId {get; set;} // Foreign Key linking Review to Movie
        public Movie? Movie {get; set;}// Navigation Property
    }
}
