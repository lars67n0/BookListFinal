using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListFinal.Pages.Teachers
{
    public class TeacherDeleteModel : PageModel
    {
        private readonly BookApp.Data.BookListAppDbContext _context;

        public TeacherDeleteModel(BookApp.Data.BookListAppDbContext context)
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

            Teachers = await _context.Teachers.FirstOrDefaultAsync(m => m.Id == id);

            if (Teachers == null)
            {
                return NotFound();
            }
            return Page();
        }

        [BindProperty]
        public BookApp.Data.Teacher Teachers { get; set; }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Teachers = await _context.Teachers.FindAsync(id);

            if (Teachers != null)
            {
                _context.Teachers.Remove(Teachers);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
