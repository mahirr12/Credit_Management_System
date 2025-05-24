using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Credit_Management_System.Models
{
    public class ProductVM
    {
        public int Id { get; set; }

        [Required, StringLength(150)]
        [RegularExpression(@".*\S+.*", ErrorMessage = "This field cannot be empty.")]
        public string Name { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Display(Name = "Category")]
        [Required]
        public int CategoryId { get; set; }
        public List<SelectListItem> Categories { get; set; } = null!;

        [Required]
        [DataType(DataType.Upload)]
        public IFormFile? Image { get; set; }

        public string ImageUrl { get; set; } = null!;
    }
}
