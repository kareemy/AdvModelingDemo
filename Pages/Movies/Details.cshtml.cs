using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HW6.Models;

namespace HW6.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly HW6.Models.MovieContext _context;

        public DetailsModel(HW6.Models.MovieContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; }
        [BindProperty]
        public int ReviewIdToDelete {get; set;}

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie.Include(m => m.Reviews).FirstOrDefaultAsync(m => m.MovieID == id);

            if (Movie == null)
            {
                return NotFound();
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
            Review Review = _context.Review.FirstOrDefault(r => r.ID == ReviewIdToDelete);
            
            if (Review != null)
            {
                _context.Remove(Review); // Delete the review
                _context.SaveChanges();
            }

            Movie = _context.Movie.Include(m => m.Reviews).FirstOrDefault(m => m.MovieID == id);

            return Page();
        }        
    }
}
