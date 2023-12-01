using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace A1PL3Y_HFT2023241.Models
{
    public class CourseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseID { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        public int Credits { get; set; }


        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<EnrollmentModel> Enrollments { get; set; }
        public CourseModel()
        {
            Enrollments = new HashSet<EnrollmentModel>();
        }
    }
}
