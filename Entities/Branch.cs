using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Credit_Management_System.Entities
{
    public class Branch : BaseEntity
    {
        [Required, StringLength(50)]
        public string Name { get; set; } = null!;

        public int MerchantId { get; set; }
        public Merchant Merchant { get; set; } = null!;

        public ICollection<Employee> Employees { get; set; } = new Collection<Employee>();
    }
}
