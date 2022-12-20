using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListFinal.Pages.Classes
{
    public class ClassIndexModel : PageModel
    {
        private readonly BookApp.Data.BookListAppDbContext _context;

        public ClassIndexModel(BookApp.Data.BookListAppDbContext context)
        {
            _context = context;
        }

        public IList<BookApp.Data.Class> Classes { get; set; }

        public async Task OnGetAsync()
        {
            Classes = await _context.Classes.ToListAsync();
        }
    }
}
