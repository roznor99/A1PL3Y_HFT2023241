﻿using A1PL3Y_HFT2023241.Logic.Interfaces;
using A1PL3Y_HFT2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static A1PL3Y_HFT2023241.Models.EnrollmentModel;

namespace A1PL3Y_HFT2023241.Logic
{
    public class EnrollmentLogic : IEnrollmentLogic
    {
        A1PL3Y_HFT2023241.Repository.IRepository<EnrollmentModel> repo;

        public EnrollmentLogic(Repository.IRepository<EnrollmentModel> repo)
        {
            this.repo = repo;
        }
        public void Create(EnrollmentModel item)
        {
            if (item.Grade == 0)
            {
                throw new ArgumentException("Grade cannot be Zero");
            }
            else
            {
                this.repo.Create(item);
            }
        }
        public EnrollmentModel Read(int id)
        {
            var enroll = this.repo.Read(id);
            if (enroll == null)
            {
                throw new ArgumentException("Enrollment not exists");
            }
            return enroll;
        }
        public IQueryable<EnrollmentModel> ReadAll()
        {
            return this.repo.ReadAll();
        }
        public void Update(EnrollmentModel item)
        {
            this.repo.Update(item);
        }
        public void Delete(int id)
        {
            this.repo.Delete(id);
        }
        // 01 - Students ordered by avggrade
        public IEnumerable<StudentsInfo> GoodStudentToBadStudent()
        {
            var a = from x in this.repo.ReadAll()
                    group x by x.Student.FirstName into g
                    orderby g.Average(t => t.Grade) descending
                    select new StudentsInfo()
                    {
                        FirstName = g.Key,
                        GradeAvg = g.Average(t => t.Grade)
                    };
            return a;
        }

        // 02 - Passe subject passed with this avg grade
        public IEnumerable<TitleInfo> SubjectPassAVG()
        {
            return from x in this.repo.ReadAll()
                   group x by x.Course.Title into g
                   select new TitleInfo()
                   {
                       TitleName = g.Key,
                       AvgGrades = g.Average(t => t.Grade)
                   };
        }


        // 03 - A subjects counted by name
        public IEnumerable<SubjectInfo> SubjectCount()
        {
            return from x in this.repo.ReadAll()
                   group x by x.Course.Title into g
                   select new SubjectInfo()
                   {
                       SubjectName = g.Key,
                       SubjectCount = g.Count()
                   };
        }



        // 04 - avarages by year
        public IEnumerable<YearInfo> YearAVGs()
        {
            return from x in this.repo.ReadAll()
                   group x by x.Student.Year into g
                   select new YearInfo()
                   {
                       YearID = g.Key,
                       GradeAVG = g.Average(t => t.Grade)
                   };
        }
    }
}
