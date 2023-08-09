﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoLibWorld.DataLayer;
using DemoLibWorld.Entity;

namespace DemoLibWorld.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly DemoLibWorld.DataLayer.BookDBContext _context;
        public List<SelectListItem> GetBookCategories { get; set; }

        public EditModel(DemoLibWorld.DataLayer.BookDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BookEntity BookEntity { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BoookCollectoins == null)
            {
                return NotFound();
            }

            var test = _context.BookCategories;
            GetBookCategories = _context.BookCategories.Select(i => new SelectListItem
            {
                Text = i.BookCategoryName,
                Value = i.BookCategoryId.ToString()
            }).ToList();

            var bookentity =  await _context.BoookCollectoins.FirstOrDefaultAsync(m => m.BookId == id);

            bookentity.BookCategories = await _context.BookCategories.FirstOrDefaultAsync(x =>
            x.BookCategoryId == bookentity.BookCategoryId
            );

            if (bookentity == null)
            {
                return NotFound();
            }
            BookEntity = bookentity;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BookEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookEntityExists(BookEntity.BookId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookEntityExists(int id)
        {
          return (_context.BoookCollectoins?.Any(e => e.BookId == id)).GetValueOrDefault();
        }
    }
}
