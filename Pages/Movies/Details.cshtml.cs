using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace AdvModelingDemo.Pages_Movies
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesMovie.Models.MovieContext _context;

        public DetailsModel(RazorPagesMovie.Models.MovieContext context)
        {
            _context = context;
        }

      public Movie Movie { get; set; } = default!; 

      [BindProperty]
      public int ReviewIdToDelete {get; set;}

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies.Include(m => m.Reviews).FirstOrDefaultAsync(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }
            else 
            {
                Movie = movie;
            }
            return Page();
        }

        public IActionResult OnPostDeleteReview(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Find the review in the database
            var Review = _context.Reviews.FirstOrDefault(r => r.ReviewId == ReviewIdToDelete);
            
            if (Review != null)
            {
                _context.Remove(Review); // Delete the review
                _context.SaveChanges();
            }

            Movie = _context.Movies.Include(m => m.Reviews).First(m => m.MovieId == id);

            return Page();
        }   
    }
}
