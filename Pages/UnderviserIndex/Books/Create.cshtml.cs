using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookApp.Data;

namespace BookListFinal.Pages.Teachers
{
    public class CreateModel : PageModel
    {
        private readonly BookApp.Data.BookListAppDbContext _context;

        public CreateModel(BookApp.Data.BookListAppDbContext context)
        {
            _context = context;
        }

       
        [BindProperty]
        public BookApp.Data.Book Books { get; set; }

        public SelectList Classes { get; set; }
        
        
        public IActionResult OnGet()
        {
            Classes = new SelectList(_context.Classes.ToList(), "Id", "ClassName");
            return Page();
        }

        
        

        
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
