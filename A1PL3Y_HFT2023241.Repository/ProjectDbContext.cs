using A1PL3Y_HFT2023241.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace A1PL3Y_HFT2023241.Repository
{
    public class ProjectDbContext :DbContext
    {
        public DbSet<CourseModel> CourseModels { get; set; }
        public DbSet<EnrollmentModel> EnrollmentModels { get; set; }
        public DbSet<StudentModel> StudentModels { get; set; }

        public ProjectDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("db").UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

    }
}
