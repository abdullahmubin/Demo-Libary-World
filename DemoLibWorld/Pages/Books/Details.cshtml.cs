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
    public class DetailsModel : PageModel
    {
        private readonly DemoLibWorld.DataLayer.BookDBContext _context;

        public DetailsModel(DemoLibWorld.DataLayer.BookDBContext context)
        {
            _context = context;
        }

      public BookEntity BookEntity { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BoookCollectoins == null)
            {
                return NotFound();
            }

            var bookentity = await _context.BoookCollectoins.FirstOrDefaultAsync(m => m.BookId == id);
            if (bookentity == null)
            {
                return NotFound();
            }
            else 
            {
                BookEntity = bookentity;
            }
            return Page();
        }
    }
}
