using System.ComponentModel.DataAnnotations;

namespace Credit_Management_System.Entities
{
    public class Customer : User
    {
        [Required]
        public ICollection<Loan> Loans { get; set; } = [];
    }
}
