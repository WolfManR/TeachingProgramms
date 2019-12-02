using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrganizationEF.Models
{
    [Table("Employee")]
    public partial class Employee:EntityBase
    {
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [NotMapped]
        public string FullName => FirstName + " " + LastName;
        public int? DepartmentId { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        public virtual Department Department { get; set; }
    }
}
