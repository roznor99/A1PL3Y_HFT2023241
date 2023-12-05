using A1PL3Y_HFT2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1PL3Y_HFT2023241.Logic.Interfaces
{
    public interface ICourseLogic
    {
        void Create(CourseModel item);
        CourseModel Read(int id);
        IQueryable<CourseModel> ReadAll();
        void Update(CourseModel item);        
        void Delete(int id);
        IEnumerable<CourseModel.HowManyInfo> CreditValuePerSubjects();
    }
}
