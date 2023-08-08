using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DemoLibWorld.DataLayer;
using DemoLibWorld.Entity;

namespace DemoLibWorld.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly DemoLibWorld.DataLayer.BookDBContext _context;

        public IndexModel(DemoLibWorld.DataLayer.BookDBContext context)
        {
            _context = context;
        }

        public IList<BookEntity> BookEntity { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.BoookCollectoins != null)
            {
                BookEntity = await _context.BoookCollectoins.ToListAsync();
            }
        }
    }
}
