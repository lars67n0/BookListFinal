using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListFinal.Pages.Courses
{
    public class CourseDeleteModel : PageModel
    {
        private readonly BookApp.Data.BookListAppDbContext _context;

        public CourseDeleteModel(BookApp.Data.BookListAppDbContext context)
        {
            _context = context;
        }

        // Proctecting Agaist Overposting tror jeg


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Courses = await _context.Courses.FirstOrDefaultAsync(m => m.Id == id);

            if (Courses == null)
            {
                return NotFound();
            }
            return Page();
        }

        [BindProperty]
        public BookApp.Data.Course Courses { get; set; }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Courses = await _context.Courses.FindAsync(id);

            if (Courses != null)
            {
                _context.Courses.Remove(Courses);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
