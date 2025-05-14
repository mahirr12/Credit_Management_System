namespace Credit_Management_System.Entities
{
    public class Loan:BaseEntity
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;

        public DateTime IssueDate { get; set; }
        public LoanDetail? LoanDetail { get; set; }

        public ICollection<LoanItem>? LoanItems { get; set; }
        public ICollection<Payment>? Payments { get; set; }
    }
}
