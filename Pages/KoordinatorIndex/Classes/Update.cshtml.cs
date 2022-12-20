using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListFinal.Pages.Classes
{
    public class ClassUpdateModel : PageModel
    {
        private readonly BookApp.Data.BookListAppDbContext _context;

        public ClassUpdateModel(BookApp.Data.BookListAppDbContext context)
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

            Classes = await _context.Classes.FirstOrDefaultAsync(m => m.Id == id);

            if (Classes == null)
            {
                return NotFound();
            }
            return Page();
        }

        [BindProperty]
        public BookApp.Data.Class Classes { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Classes).State = EntityState.Modified;

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
