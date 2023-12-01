using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1PL3Y_HFT2023241.Models
{
    public class EnrollmentModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public int Grade { get; set; }
        [NotMapped]
        public virtual CourseModel Course { get; set; }
        [NotMapped]
        public virtual StudentModel Student { get; set; }
    }
}
