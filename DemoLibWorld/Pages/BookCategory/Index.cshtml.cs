using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DemoLibWorld.DataLayer;
using DemoLibWorld.Entity;

namespace DemoLibWorld.Pages.BookCategory
{
    public class IndexModel : PageModel
    {
        private readonly DemoLibWorld.DataLayer.BookDBContext _context;

        public IndexModel(DemoLibWorld.DataLayer.BookDBContext context)
        {
            _context = context;
        }

        public IList<DemoLibWorld.Entity.BookCategory> BookCategory { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.BookCategories != null)
            {
                BookCategory = await _context.BookCategories.ToListAsync();
            }
        }
    }
}
