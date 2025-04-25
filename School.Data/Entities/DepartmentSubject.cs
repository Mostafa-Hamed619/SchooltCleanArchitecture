using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Data.Entities
{
    public class DepartmentSubject
    {
        [Key]
        public int DeptSubId { get; set; }
        
        public int DId { get; set; }

        [ForeignKey("DId")]
        public virtual Department Department { get; set; }

        public int SubId { get; set; }

        [ForeignKey("SubId")]
        public virtual Subject Subjects { get; set; }
    }
}
