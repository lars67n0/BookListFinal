using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListFinal.Pages.Classes
{
    public class ClassCreateModel : PageModel
    {
        private readonly BookApp.Data.BookListAppDbContext _context;

        public ClassCreateModel(BookApp.Data.BookListAppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
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
            _context.Classes.Add(Classes);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }


}
