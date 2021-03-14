using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using HW6.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HW6.Pages
{
    public class AddReviewModel : PageModel
    {
        private readonly ILogger<AddReviewModel> _logger;
        private readonly MovieContext _context; // Movie Database context
        [BindProperty]
        public Review Review {get; set;}
        public SelectList MoviesDropDown {get; set;}

        public AddReviewModel(MovieContext context, ILogger<AddReviewModel> logger)
        {
            // Bring in Database context and logger using dependency injection
            _context = context;
            _logger = logger;
        }

        public void OnGet()
        {
            MoviesDropDown = new SelectList(_context.Movie.ToList(), "MovieID", "Title");
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Review.Add(Review);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}