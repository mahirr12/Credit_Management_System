using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Credit_Management_System.Entities
{
    public class Category:BaseEntity
    {
        [Required, StringLength(50)]
        public string Title { get; set; } = null!;

        public int? ParentCategoryId{ get; set; }
        [ForeignKey(nameof(ParentCategoryId)) ]
        public Category? ParentCategory{ get; set; }

        public ICollection<Category> SubCategories { get; set; } = new List<Category>();

        public ICollection<Product>? Products{ get; set; }
    }
}
