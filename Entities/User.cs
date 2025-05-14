using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Credit_Management_System.Entities
{
    public abstract class User : IdentityUser
    {
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow.AddHours(4);
        public DateTime? UpdatedTime { get; set; } = DateTime.UtcNow.AddHours(4);
        public bool IsDeleted { get; set; }
    }
}
