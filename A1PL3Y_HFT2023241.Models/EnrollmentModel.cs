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
        public class StudentsInfo
        {
            public string FirstName { get; set; }
            public double? GradeAvg { get; set; }

            public override bool Equals(object obj)
            {
                StudentsInfo b = obj as StudentsInfo;
                if (b == null)
                {
                    return false;
                }
                else
                {
                    return this.FirstName == b.FirstName &&
                           this.GradeAvg == b.GradeAvg;
                }

            }

            public override int GetHashCode()
            {
                return HashCode.Combine(this.FirstName, this.GradeAvg);
            }
            public override string ToString()
            {
                return this.FirstName + "'s avarage is: " + this.GradeAvg;
            }
        }
        public class TitleInfo
        {
            public string TitleName { get; set; }
            public double? AvgGrades { get; set; }

            public override bool Equals(object obj)
            {
                TitleInfo b = obj as TitleInfo;
                if (b == null)
                {
                    return false;
                }
                else
                {
                    return this.TitleName == b.TitleName &&
                           this.AvgGrades == b.AvgGrades;
                }

            }

            public override int GetHashCode()
            {
                return HashCode.Combine(this.TitleName, this.AvgGrades);
            }
            public override string ToString()
            {
                return "In the '" + this.TitleName + "' subject, students graduate with the following average: " + this.AvgGrades;
            }
        }
        public class SubjectInfo
        {
            public string SubjectName { get; set; }
            public int SubjectCount { get; set; }

            public override bool Equals(object obj)
            {
                SubjectInfo b = obj as SubjectInfo;
                if (b == null)
                {
                    return false;
                }
                else
                {
                    return this.SubjectName == b.SubjectName &&
                           this.SubjectCount == b.SubjectCount;
                }

            }

            public override int GetHashCode()
            {
                return HashCode.Combine(this.SubjectName, this.SubjectCount);
            }
            public override string ToString()
            {
                return "In the database, " + this.SubjectCount + " student completed the '" + this.SubjectName + "' subject!";
            }
        }
    }
}
