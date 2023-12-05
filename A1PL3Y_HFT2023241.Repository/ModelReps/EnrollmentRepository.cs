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
        public override EnrollmentModel Read(int id)
        {
            return ctx.EnrollmentModels.FirstOrDefault(t => t.EnrollmentID == id);
        }

       
    }
}
