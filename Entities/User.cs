using Microsoft.AspNetCore.Identity;

namespace Credit_Management_System.Entities
{
    public abstract class User : IdentityUser
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow.AddHours(4);
        public DateTime? UpdatedTime { get; set; } = DateTime.UtcNow.AddHours(4);
        public bool IsDeleted { get; set; }
    }
}
