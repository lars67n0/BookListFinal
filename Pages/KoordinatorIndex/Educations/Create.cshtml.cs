using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListFinal.Pages.Educations
{
    public class EducationCreateModel : PageModel
    {
        private readonly BookApp.Data.BookListAppDbContext _context;

        public EducationCreateModel(BookApp.Data.BookListAppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BookApp.Data.Education Educations { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Educations.Add(Educations);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
