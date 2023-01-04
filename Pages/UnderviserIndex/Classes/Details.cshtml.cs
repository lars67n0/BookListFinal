using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookApp.Data;
namespace BookListFinal.Pages.UnderviserIndex.Classes
{
    public class DetailsModel : PageModel
    {
        private readonly BookApp.Data.BookListAppDbContext _context;

        public DetailsModel(BookApp.Data.BookListAppDbContext context)
        {
            _context = context;
        }

        

        //public SelectList Classes { get; set; }


        //public async Task OnGetAsync()

        //{


        //    Books = await _context.Books.ToListAsync();
        //    Classes = new SelectList(_context.Classes.ToList(), "Id", "ClassName");
        //}


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Books = await _context.Books.FirstOrDefaultAsync(m => m.ClassId == id);
                
            

            if (Books == null)
            {
                return NotFound();
            }
            return Page();
        }

        [BindProperty]
        public BookApp.Data.Book Books { get; set; }
        public BookApp.Data.Class Classes { get; set; }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Books = await _context.Books.FindAsync(id);

            if (Books != null)
            {
                return Page();
            }

            return RedirectToPage("./Index");
        }




    }
}
