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
         
        public string TitleSort { get; set; }
        public string AuthorSort { get; set; }
        public string BookCategorySort { get; set; }
        public string DateSort { get; set; }
        public string RatingSort { get; set; }

        public IndexModel(DemoLibWorld.DataLayer.BookDBContext context)
        {
            _context = context;
        }

        public IList<BookEntity> BookEntity { get;set; } = default!;

        public async Task OnGetAsync(string sortOrder)
        {
            if (_context.BoookCollectoins != null)
            {
                TitleSort = sortOrder == "title_asc_sort" ? "title_desc_sort" : "title_asc_sort";
                AuthorSort = sortOrder == "author_asc_sort" ? "author_desc_sort" : "author_asc_sort";
                BookCategorySort = sortOrder == "bookcategory_asc_sort" ? "bookcategory_desc_sort" : "bookcategory_asc_sort";
                RatingSort = sortOrder == "rating_asc_sort" ? "rating_desc_sort" : "rating_asc_sort";
                DateSort = sortOrder == "Date" ? "date_desc_" : "Date";


                BookEntity = await _context.BoookCollectoins.ToListAsync();

                foreach (var item in BookEntity)
                {
                    item.BookCategories = await _context.BookCategories.FirstOrDefaultAsync(x
                        => x.BookCategoryId == item.BookCategoryId);
                }

                switch(sortOrder)
                {
                    case "title_asc_sort":
                        BookEntity = BookEntity.OrderBy(s => s.Title).ToList();
                        break;
                    case "title_desc_sort":
                        BookEntity = BookEntity.OrderByDescending(s => s.Title).ToList();
                        break;
                    case "author_asc_sort":
                        BookEntity = BookEntity.OrderBy(s => s.Authorname).ToList();
                        break;
                    case "author_desc_sort":
                        BookEntity = BookEntity.OrderByDescending(s => s.Authorname).ToList();
                        break;

                    default:
                        BookEntity = BookEntity.OrderBy(s => s.Title).ToList();
                        break;
                }
            }
        }
    }
}
