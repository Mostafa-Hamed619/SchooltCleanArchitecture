using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Data.Entities
{
    public class StudentSubject
    {
        [Key]
        public int StudSubId { get; set; }

        public int StudId { get; set; }

        [ForeignKey("StudId")]
        public virtual Student Students { get; set; }

        public int SubId { get; set; }

        [ForeignKey("SubId")]
        public virtual Subject Subjects { get; set; }
    }
}
