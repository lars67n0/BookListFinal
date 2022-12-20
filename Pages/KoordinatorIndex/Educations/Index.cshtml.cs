using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListFinal.Pages.Educations
{
    public class EducationsIndexModel : PageModel
    {
        private readonly BookApp.Data.BookListAppDbContext _context;

        public EducationsIndexModel(BookApp.Data.BookListAppDbContext context)
        {
            _context = context;
        }

        public IList<BookApp.Data.Education> Educations { get; set; }

        public async Task OnGetAsync()
        {
            Educations = await _context.Educations.ToListAsync();
        }
    }
}
