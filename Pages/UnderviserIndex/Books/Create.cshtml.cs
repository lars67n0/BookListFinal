using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListFinal.Pages.Teachers
{
    public class CreateModel : PageModel
    {
        private readonly BookApp.Data.BookListAppDbContext _context;

        public CreateModel(BookApp.Data.BookListAppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BookApp.Data.Book Books { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Books.Add(Books);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
