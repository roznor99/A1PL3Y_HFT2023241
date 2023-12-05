using A1PL3Y_HFT2023241.Logic.Interfaces;
using A1PL3Y_HFT2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static A1PL3Y_HFT2023241.Models.CourseModel;

namespace A1PL3Y_HFT2023241.Logic
{
    public class CourseLogic : ICourseLogic
    {
        A1PL3Y_HFT2023241.Repository.IRepository<CourseModel> repo;

        public CourseLogic(Repository.IRepository<CourseModel> repo)
        {
            this.repo = repo;
        }

        public void Create(CourseModel item)
        {
            if (item.Title.Length < 3)
            {
                throw new ArgumentException("Title too short!");
            }
            this.repo.Create(item);
        }
        public CourseModel Read(int id)
        {
            var cour = this.repo.Read(id);
            if (cour == null)
            {
                throw new ArgumentException("Course not exists");
            }
            return cour;
        }
        public IQueryable<CourseModel> ReadAll()
        {
            return this.repo.ReadAll();
        }
        public void Update(CourseModel item)
        {
            this.repo.Update(item);
        }
        public void Delete(int id)
        {
            this.repo.Delete(id);
        }
        // 05 - Hw many subjects with a specific credit
        
        public IEnumerable<HowManyInfo> CreditValuePerSubjects()
        {
            return from x in this.repo.ReadAll()
                   group x by x.Credits into g
                   orderby g.Count() ascending
                   select new HowManyInfo()
                   {
                       CreditValue = g.Key,
                       SubjectQuantity = g.Count()
                   };
        }
    }
}
