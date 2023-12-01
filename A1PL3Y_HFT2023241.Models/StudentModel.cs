using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace A1PL3Y_HFT2023241.Models
{
    public class StudentModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Year { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<EnrollmentModel> Enrollments { get; set; }
        public StudentModel()
        {
            Enrollments = new HashSet<EnrollmentModel>();
        }
    }
}
