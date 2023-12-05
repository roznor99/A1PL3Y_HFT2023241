using A1PL3Y_HFT2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1PL3Y_HFT2023241.Logic.Interfaces
{
    public interface IEnrollmentLogic
    {
        void Create(EnrollmentModel item);       
        EnrollmentModel Read(int id);
        IQueryable<EnrollmentModel> ReadAll();       
        void Update(EnrollmentModel item);       
        void Delete(int id);
    }
}
