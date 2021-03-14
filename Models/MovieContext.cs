using Microsoft.EntityFrameworkCore;

namespace HW6.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext (DbContextOptions<MovieContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie {get; set;}
        public DbSet<Review> Review {get; set;}
    }
}