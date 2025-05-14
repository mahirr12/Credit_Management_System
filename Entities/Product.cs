using System.ComponentModel.DataAnnotations;

namespace Credit_Management_System.Entities
{
    public class Product : BaseEntity
    {
        [Required, StringLength(150)]
        public string Name { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public ICollection<LoanItem>? LoanItems { get; set; }
    }
}
