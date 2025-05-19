using System.ComponentModel.DataAnnotations;

namespace Credit_Management_System.Models
{
    public class MerchantVM
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; } = null!;
        public List<int> BranchIds { get; set; } = [];
    }
}
