using A1PL3Y_HFT2023241.Logic.Interfaces;
using A1PL3Y_HFT2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1PL3Y_HFT2023241.Logic
{
    public class StudentLogic : IStudentLogic
    {
        A1PL3Y_HFT2023241.Repository.IRepository<StudentModel> repo;

        public StudentLogic(Repository.IRepository<StudentModel> repo)
        {
            this.repo = repo;
        }

        public void Create(StudentModel item)
        {
            if (item.FirstName.Length < 3 || item.LastName.Length < 3)
            {
                throw new ArgumentException("Unreal name!");
            }
            this.repo.Create(item);
        }
        public StudentModel Read(int id)
        {
            var cour = this.repo.Read(id);
            if (cour == null)
            {
                throw new ArgumentException("Student not exists!");
            }
            return cour;
        }
        public IQueryable<StudentModel> ReadAll()
        {
            return this.repo.ReadAll();
        }
        public void Update(StudentModel item)
        {
            this.repo.Update(item);
        }
        public void Delete(int id)
        {
            this.repo.Delete(id);
        }
    }
}
