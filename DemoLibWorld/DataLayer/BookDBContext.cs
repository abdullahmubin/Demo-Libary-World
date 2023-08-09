using DemoLibWorld.Entity;
using Microsoft.EntityFrameworkCore;

namespace DemoLibWorld.DataLayer
{
    public class BookDBContext : DbContext
    {
        public BookDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BookEntity> BoookCollectoins { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
    }
}
