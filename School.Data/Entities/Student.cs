using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace School.Data.Entities
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(11)]
        public string Phone { get; set; }

        public int? DId { get; set; }

        [ForeignKey("DId")]
        [InverseProperty("Students")]
        public virtual Department Departments { get; set; }
    }
}
