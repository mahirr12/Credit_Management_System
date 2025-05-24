using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Credit_Management_System.Models
{
    public class EmployeeVM
    {
        public string Id { get; set; } = String.Empty;

        [Required]
        [Display(Name = "First Name")]
        [RegularExpression(@".*\S+.*", ErrorMessage = "Name cannot be empty.")]
        public string Name { get; set; } = null!;
        [Required]
        [Display(Name = "Last Name")]
        [RegularExpression(@".*\S+.*", ErrorMessage = "Last Name cannot be empty.")]
        public string LastName { get; set; } = null!;

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string? Email { get; set; } 

        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        [RegularExpression(@"^(?=.*\d).+$", ErrorMessage = "Password must contain at least one digit.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = null!;

        public int? BranchId { get; set; }
        public List<SelectListItem> Branches { get; set; } = [];
        public List<int> LoanIds { get; set; } = [];
    }
}
