using Credit_Management_System.Enums;
using System.ComponentModel.DataAnnotations;

namespace Credit_Management_System.Entities
{
    public class LoanDetail
    {
        [Key]
        public int LoanId { get; set; }
        public Loan Loan { get; set; } = null!;

        public Decimal TotalAmount { get; set; }
        public Decimal RemainingAmount { get; set; }

        public LoanStatus Status{ get; set; }
    }
}
