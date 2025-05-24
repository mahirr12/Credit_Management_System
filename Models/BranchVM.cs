using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Credit_Management_System.Models
{
    public class BranchVM
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        [RegularExpression(@".*\S+.*", ErrorMessage = "Name cannot be empty.")]
        public string Name { get; set; } = null!;

        [Display(Name = "Merchant")]
        [Required]
        public int MerchantId { get; set; }
        public List<SelectListItem> Merchants { get; set; } = [];
        public List<string> EmployeeIds { get; set; } = [];
    }
}
