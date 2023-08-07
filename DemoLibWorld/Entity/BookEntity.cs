using System.ComponentModel.DataAnnotations;

namespace DemoLibWorld.Entity
{
    public class BookEntity
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Authorname { get; set; }
        public DateTime Releasedate { get; set; }
        public string Rating { get; set; }
    }
}
