namespace Credit_Management_System.Entities
{
    public class Loan:BaseEntity
    {
        public string CustomerId { get; set; } = null!;
        public Customer Customer { get; set; } = null!;

        public string EmployeeId { get; set; } = null!;
        public Employee Employee { get; set; } = null!;

        public DateTime IssueDate { get; set; }
        public LoanDetail? LoanDetail { get; set; }

        public ICollection<LoanItem>? LoanItems { get; set; }
        public ICollection<Payment>? Payments { get; set; }
    }
}
