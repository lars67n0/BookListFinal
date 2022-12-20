using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListFinal.Pages.Courses
{
    public class CoursesIndexModel : PageModel
    {
        private readonly BookApp.Data.BookListAppDbContext _context;

        public CoursesIndexModel(BookApp.Data.BookListAppDbContext context)
        {
            _context = context;
        }

        public IList<BookApp.Data.Course> Courses { get; set; }

        public async Task OnGetAsync()
        {
            Courses = await _context.Courses.ToListAsync();
        }
    }
}
