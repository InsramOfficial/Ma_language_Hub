using MALanguageHub.Data;
using MALanguageHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MALanguageHub.Pages
{
    public class AddStudentReviewModel : PageModel
    {
        private readonly MALHdbcontext db;
        private readonly IWebHostEnvironment env;
        public StudentReviews StudentReviews { get; set; }

        public AddStudentReviewModel(MALHdbcontext _db, IWebHostEnvironment _env)
        {
            db = _db;
            env = _env;

        }
        public IActionResult OnPost(StudentReviews StudentReviews)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                db.tbl_studentreviews.Add(StudentReviews);
                db.SaveChanges();
                TempData["SuccessMessage"] = "Review Added Successfully";
            }
            return RedirectToPage("AddStudentReview");
        }
    }
}
