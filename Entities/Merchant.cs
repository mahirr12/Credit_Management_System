using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Credit_Management_System.Entities
{
    public class Merchant : BaseEntity
    {
        [Required, StringLength(50)]
        public string Name { get; set; } = null!;

        public ICollection<Branch> Branches { get; set; } = [];
    }
}
