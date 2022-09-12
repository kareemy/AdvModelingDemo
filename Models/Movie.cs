using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        
        [StringLength(30)]
        [Required]
        public string Genre { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        public List<Review> Reviews {get; set;} = new List<Review>(); // Navigation Property. One movie can have many reviews    
    }
}