using Microsoft.EntityFrameworkCore;

namespace RazorPagesMovie.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext (DbContextOptions<MovieContext> options)
            : base (options)
            {
            }
        
        public DbSet<Movie> Movies {get; set;} = default!;
        public DbSet<Review> Reviews {get; set;} = default!;
    }
}