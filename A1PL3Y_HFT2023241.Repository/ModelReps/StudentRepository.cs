using A1PL3Y_HFT2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1PL3Y_HFT2023241.Repository.ModelReps
{
    public class StudentRepository : Repository<StudentModel>, IRepository<StudentModel>
    {
        public StudentRepository(ProjectDbContext Ctx) : base(Ctx)
        {
        }

        public override StudentModel Read(int id)
        {
            return ctx.StudentModels.FirstOrDefault(t => t.ID == id);
        }

        public override void Update(StudentModel item)
        {
            var old = Read(item.ID);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
