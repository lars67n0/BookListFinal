using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListFinal.Pages.Teachers
{
    public class TeacherCreateModel : PageModel
    {
        private readonly BookApp.Data.BookListAppDbContext _context;

        public TeacherCreateModel(BookApp.Data.BookListAppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BookApp.Data.Teacher Teachers { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Teachers.Add(Teachers);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
