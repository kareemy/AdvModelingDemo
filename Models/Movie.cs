using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace HW6.Models
{
    public class Movie
    {
        public int MovieID {get; set;}

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title {get; set;}

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate {get; set;}

        [StringLength(30)]
        [Required]
        public string Genre {get; set;}

        [Range(1,100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price {get; set;}

        [StringLength(5)]
        [Required]
        public string Rating {get; set;}

        public List<Review> Reviews {get; set;} // Navigation Property. One movie can have many reviews        
    }
}