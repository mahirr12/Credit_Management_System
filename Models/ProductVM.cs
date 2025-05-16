using System.ComponentModel.DataAnnotations;

namespace Credit_Management_System.Models
{
    public class ProductVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public IFormFile? Image { get; set; }

        public string? ImageUrl { get; set; }
    }
}
