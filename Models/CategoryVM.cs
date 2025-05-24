using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Credit_Management_System.Models
{
    public class CategoryVM
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Title { get; set; } = null!;
        public int? ParentCategoryId { get; set; }
        public List<SelectListItem> ParentCategories { get; set; } = [];
        public List<CategoryVM> SubCategories { get; set; } = [];
        public List<ProductVM> Products { get; set; } = [];
    }
}
