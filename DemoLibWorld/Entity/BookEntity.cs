using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoLibWorld.Entity
{
    public class BookEntity
    {
        [Key]
        public int BookId { get; set; }

        [Display(Name ="Title")]
        [Required(ErrorMessage ="Please enter title name. Its required.")]
        [StringLength(50, MinimumLength =3, ErrorMessage ="Title name is too short. Please enter valid title name.")]
        public string Title { get; set; }

        [Display(Name = "Author Name")]
        public string Authorname { get; set; }


        [DataType(DataType.Date)]
        [DataValidation(ErrorMessage ="Release date should be less than current date.")]
        public DateTime Releasedate { get; set; }


        [Required(ErrorMessage ="Rating is required.")]
        [Range(1,5, ErrorMessage ="Rating range between 1 to 5 only")]
        public string Rating { get; set; }

        [Display(Name ="Category")]
        public int? BookCategoryId { get; set; }

        [ForeignKey("BookCategoryId")]
        public virtual BookCategory? BookCategories { get; set; }

    }

    public class DataValidation: ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            DateTime todayDate = Convert.ToDateTime(value);

            return todayDate <= DateTime.Now;
        }
    }
}
