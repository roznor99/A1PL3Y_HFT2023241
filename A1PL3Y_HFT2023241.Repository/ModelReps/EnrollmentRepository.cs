using A1PL3Y_HFT2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1PL3Y_HFT2023241.Repository.ModelReps
{
    public class EnrollmentRepository : Repository<EnrollmentModel>, IRepository<EnrollmentModel>
    {
        public EnrollmentRepository(ProjectDbContext Ctx) : base(Ctx)
        {
        }

        public override EnrollmentModel Read(int id)
        {
            return ctx.EnrollmentModels.FirstOrDefault(t => t.EnrollmentID == id);
        }

        public override void Update(EnrollmentModel item)
        {
            var old = Read(item.EnrollmentID);
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
