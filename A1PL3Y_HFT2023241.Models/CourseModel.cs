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
        public class HowManyInfo
        {
            public int CreditValue { get; set; }
            public double? SubjectQuantity { get; set; }
            public override bool Equals(object obj)
            {
                HowManyInfo b = obj as HowManyInfo;
                if (b == null)
                {
                    return false;
                }
                else
                {
                    return this.CreditValue == b.CreditValue &&
                           this.SubjectQuantity == b.SubjectQuantity;
                }

            }

            public override int GetHashCode()
            {
                return HashCode.Combine(this.CreditValue, this.SubjectQuantity);
            }
            public override string ToString()
            {
                return "There is " + this.SubjectQuantity + " subject with " + this.CreditValue + " credit!";
            }
        }
    }
}
