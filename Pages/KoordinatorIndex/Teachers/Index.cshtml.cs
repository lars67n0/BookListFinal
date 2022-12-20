using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListFinal.Pages.Teachers
{
    public class TeacherIndexModel : PageModel
    {
        
            private readonly BookApp.Data.BookListAppDbContext _context;

            public TeacherIndexModel(BookApp.Data.BookListAppDbContext context)
            {
                _context = context;
            }

            public IList<BookApp.Data.Teacher> Teachers { get; set; }

            public async Task OnGetAsync()
            {
                Teachers = await _context.Teachers.ToListAsync();
            }

        
    }
}
