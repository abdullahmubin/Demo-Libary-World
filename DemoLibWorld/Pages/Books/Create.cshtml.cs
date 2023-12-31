﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DemoLibWorld.DataLayer;
using DemoLibWorld.Entity;

namespace DemoLibWorld.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly DemoLibWorld.DataLayer.BookDBContext _context;
        public List<SelectListItem> GetBookCategories { get; set; }

        public CreateModel(DemoLibWorld.DataLayer.BookDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var test = _context.BookCategories;
            GetBookCategories = _context.BookCategories.Select(i => new SelectListItem
            {
                Text = i.BookCategoryName,
                Value = i.BookCategoryId.ToString()
            }).ToList();
            return Page();
        }

        [BindProperty]
        public BookEntity BookEntity { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.BoookCollectoins == null || BookEntity == null)
            {
                return Page();
            }

            _context.BoookCollectoins.Add(BookEntity);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
