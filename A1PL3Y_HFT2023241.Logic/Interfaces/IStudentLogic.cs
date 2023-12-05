using A1PL3Y_HFT2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1PL3Y_HFT2023241.Logic.Interfaces
{
    public interface IStudentLogic
    {
        void Create(StudentModel item);
        StudentModel Read(int id);
        IQueryable<StudentModel> ReadAll();
        void Update(StudentModel item);
        void Delete(int id);
    }
}
