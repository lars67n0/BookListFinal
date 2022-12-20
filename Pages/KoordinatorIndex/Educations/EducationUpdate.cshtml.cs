using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListFinal.Pages.Educations
{
    public class EducationUpdateModel : PageModel
    {
        private readonly BookApp.Data.BookListAppDbContext _context;

        public EducationUpdateModel(BookApp.Data.BookListAppDbContext context)
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

            Educations = await _context.Educations.FirstOrDefaultAsync(m => m.Id == id);

            if (Educations == null)
            {
                return NotFound();
            }
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

            _context.Attach(Educations).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            return RedirectToPage("./Index");
        }

    }
}

