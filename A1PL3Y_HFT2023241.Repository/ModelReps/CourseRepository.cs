﻿using A1PL3Y_HFT2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1PL3Y_HFT2023241.Repository.ModelReps
{
    public class CourseRepository : Repository<CourseModel>, IRepository<CourseModel>
    {
        public override CourseModel Read(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(CourseModel item)
        {
            throw new NotImplementedException();
        }
    }
}
