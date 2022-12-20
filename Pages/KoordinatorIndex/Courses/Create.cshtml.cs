using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListFinal.Pages.Courses
{
    public class CourseCreateModel : PageModel
    {
        private readonly BookApp.Data.BookListAppDbContext _context;

        public CourseCreateModel(BookApp.Data.BookListAppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BookApp.Data.Course Courses { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Courses.Add(Courses);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
