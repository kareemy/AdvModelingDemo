using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HW6.Models
{
    public class Review
    {
        // Primary Key for Review entity class
        // Can either be "ID" or "ReviewID"
        public int ID {get; set;}

        [Range(1,5)]
        [Required]
        public int Score {get; set;}

        [Display(Name = "Movie")]
        [Required]
        public int MovieId {get; set;} // Foreign Key linking Review to Movie
        public Movie Movie {get; set;} // Navigation Property
    }
}