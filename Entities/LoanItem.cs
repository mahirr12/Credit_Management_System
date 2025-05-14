using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Credit_Management_System.Entities
{
    [PrimaryKey(nameof(LoanId), nameof(ProductId))]
    public class LoanItem
    {
        public int LoanId { get; set; }
        public Loan Loan { get; set; } = null!;

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public int Quantity { get; set; }
    }
}
