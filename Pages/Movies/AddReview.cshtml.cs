using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdvModelingDemo.Pages
{
    public class AddReviewModel : PageModel
    {
        private readonly ILogger<AddReviewModel> _logger;
        private readonly MovieContext _context;
        [BindProperty]
        public Review Review {get; set;} = default!;
        public SelectList MoviesDropDown {get; set;} = default!;

        public AddReviewModel(MovieContext context, ILogger<AddReviewModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void OnGet()
        {
            MoviesDropDown = new SelectList(_context.Movies.ToList(), "MovieId", "Title");
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Reviews.Add(Review);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
