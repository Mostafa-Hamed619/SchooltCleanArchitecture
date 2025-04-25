using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Data.Entities
{
    public partial class Department
    {
        public Department()
        {
            Students = new HashSet<Student>();
            Deparments = new HashSet<DepartmentSubject>();
        }

        [Key]
        public int DId { get; set; }

        [StringLength(500)]
        public string DName { get; set; }

        [InverseProperty("Departments")]
        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<DepartmentSubject> Deparments { get; set; }
    }
}
