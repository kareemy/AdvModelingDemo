using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvModelingDemo.Pages
{
    public class DeleteReviewModel : PageModel
    {
        private readonly MovieContext _context; // Database context
        private readonly ILogger _logger; // Logging object

        // Model Constructor. Used to bring in _context and logger from Dependency Injection
        public DeleteReviewModel(MovieContext context, ILogger<DeleteReviewModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        // Drop down list of all the Movie Reviews
        public SelectList Reviews {get; set;} = default!;

        // ReviewId to delete. We bind this property because the user will select it in our form and submit it.
        [BindProperty]
        [Display(Name = "Review")]
        public int? ReviewId {get; set;}

        public IActionResult OnGet(int? id)
        {
            // Get all the reviews to populate our SelectList drop down
            // Use an anonymous type because we want a new variable that shows the Movie Title and Review score
            var reviewsWithTitles = _context.Reviews.Include(r => r.Movie).Select(r => new {
                ID = r.ReviewId,
                Display = $"{r.Movie!.Title}: {r.Score} out of 5"
            });
            _logger.LogInformation($"DeleteReview OnGet() called. ReviewId = '{ReviewId}'. id = '{id}'");

            // Populate SelectList. This variable is brought into the Razor Page with the asp-items tag helper
            Reviews = new SelectList(reviewsWithTitles.ToList(), "ID", "Display", id);
            return Page();
        }

        public IActionResult OnPost()
        {
            _logger.LogInformation($"DeleteReview OnPost() called. ReviewId = '{ReviewId}'.");

            if (ReviewId == null)
            {
                return NotFound();
            }
            // Find the review in the database
            Review r = _context.Reviews.Find(ReviewId)!;

            if (r != null)
            {
                _context.Reviews.Remove(r); // Delete the review
                _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}