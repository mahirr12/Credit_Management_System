namespace Credit_Management_System.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow.AddHours(4);
        public DateTime UpdatedTime { get; set; } = DateTime.UtcNow.AddHours(4);
        public bool IsDeleted { get; set; }
    }
}
