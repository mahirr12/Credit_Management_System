namespace Credit_Management_System.Entities
{
    public class Employee : User
    {
        public int BranchId { get; set; }
        public Branch? Branch { get; set; }
    }
}
