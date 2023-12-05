using A1PL3Y_HFT2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1PL3Y_HFT2023241.Repository.ModelReps
{
    public class CourseRepository : Repository<CourseModel>, IRepository<CourseModel>
    {
        public CourseRepository(ProjectDbContext Ctx) : base(Ctx)
        {
        }

        public override CourseModel Read(int id)
        {
            return ctx.CourseModels.FirstOrDefault(t => t.CourseID == id);
        }

        public override void Update(CourseModel item)
        {
            throw new NotImplementedException();
        }
    }
}
