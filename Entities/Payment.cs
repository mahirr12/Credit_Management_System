using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Credit_Management_System.Entities
{
    public class Payment : BaseEntity
    {
        [Required]
        public int LoanId { get; set; }
        public Loan Loan { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public Decimal Amount { get; set; }
    }
}
