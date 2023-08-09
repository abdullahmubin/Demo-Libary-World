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
    public class DeleteModel : PageModel
    {
        private readonly DemoLibWorld.DataLayer.BookDBContext _context;

        public DeleteModel(DemoLibWorld.DataLayer.BookDBContext context)
        {
            _context = context;
        }

        [BindProperty]
      public DemoLibWorld.Entity.BookCategory BookCategory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BookCategories == null)
            {
                return NotFound();
            }

            var bookcategory = await _context.BookCategories.FirstOrDefaultAsync(m => m.BookCategoryId == id);

            if (bookcategory == null)
            {
                return NotFound();
            }
            else 
            {
                BookCategory = bookcategory;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.BookCategories == null)
            {
                return NotFound();
            }
            var bookcategory = await _context.BookCategories.FindAsync(id);

            if (bookcategory != null)
            {
                BookCategory = bookcategory;
                _context.BookCategories.Remove(BookCategory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
