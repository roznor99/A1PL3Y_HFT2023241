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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EnrollmentModel>(t => t
                .HasOne(t => t.Course)
                .WithMany(e => e.Enrollments)
                .HasForeignKey(t => t.CourseID)
                .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<EnrollmentModel>(t => t
                .HasOne(t => t.Student)
                .WithMany(e => e.Enrollments)
                .HasForeignKey(t => t.StudentID)
                .OnDelete(DeleteBehavior.Cascade));

            var cours = new CourseModel[]
            {
                new CourseModel(){CourseID = 1, Title = "Környezet tudatosság", Credits = 3},
                new CourseModel(){CourseID = 2, Title = "Jazz kultúr történet", Credits = 2},
                new CourseModel(){CourseID = 3, Title = "Robotika", Credits = 5},
                new CourseModel(){CourseID = 4, Title = "Mikroökonómia", Credits = 3},
                new CourseModel(){CourseID = 5, Title = "Makroökonómia", Credits = 3},
                new CourseModel(){CourseID = 6, Title = "Szakmai Angol B", Credits = 2},
                new CourseModel(){CourseID = 7, Title = "Analízis", Credits = 6},
                new CourseModel(){CourseID = 8, Title = "Jazz kultúr történet 2", Credits = 2},
                new CourseModel(){CourseID = 9, Title = "Testnevelés I.", Credits = 0},
                new CourseModel(){CourseID = 10, Title = "Projectmunka", Credits = 4},
                new CourseModel(){CourseID = 11, Title = "Statisztikai elemzések", Credits = 4}
            };
            var enroll = new EnrollmentModel[]
            {
                new EnrollmentModel(){ EnrollmentID = 1, CourseID = 1, StudentID = 1, Grade = 4},
                new EnrollmentModel(){ EnrollmentID = 2, CourseID = 1, StudentID = 2, Grade = 2},
                new EnrollmentModel(){ EnrollmentID = 3, CourseID = 1, StudentID = 5, Grade = 3},
                new EnrollmentModel(){ EnrollmentID = 4, CourseID = 2, StudentID = 3, Grade = 5},
                new EnrollmentModel(){ EnrollmentID = 5, CourseID = 2, StudentID = 4, Grade = 5},
                new EnrollmentModel(){ EnrollmentID = 6, CourseID = 3, StudentID = 1, Grade = 5},
                new EnrollmentModel(){ EnrollmentID = 7, CourseID = 3, StudentID = 4, Grade = 2},
                new EnrollmentModel(){ EnrollmentID = 8, CourseID = 4, StudentID = 2, Grade = 1},
                new EnrollmentModel(){ EnrollmentID = 9, CourseID = 5, StudentID = 5, Grade = 1},
                new EnrollmentModel(){ EnrollmentID = 10, CourseID = 6, StudentID = 5, Grade = 5},
                new EnrollmentModel(){ EnrollmentID = 11, CourseID = 7, StudentID = 1, Grade = 5},
                new EnrollmentModel(){ EnrollmentID = 12, CourseID = 8, StudentID = 2, Grade = 3},
                new EnrollmentModel(){ EnrollmentID = 13, CourseID = 8, StudentID = 3, Grade = 2},
                new EnrollmentModel(){ EnrollmentID = 14, CourseID = 9, StudentID = 1, Grade = 2},
                new EnrollmentModel(){ EnrollmentID = 15, CourseID = 9, StudentID = 5, Grade = 3},
                new EnrollmentModel(){ EnrollmentID = 16, CourseID = 9, StudentID = 4, Grade = 3},
                new EnrollmentModel(){ EnrollmentID = 17, CourseID = 10, StudentID = 5, Grade = 4},
                new EnrollmentModel(){ EnrollmentID = 18, CourseID = 10, StudentID = 4, Grade = 4},
                new EnrollmentModel(){ EnrollmentID = 19, CourseID = 10, StudentID = 3, Grade = 2},
                new EnrollmentModel(){ EnrollmentID = 20, CourseID = 10, StudentID = 2, Grade = 5},
            };

            var stud = new StudentModel[]
            {
                new StudentModel(){ID = 1, LastName ="Smith", FirstName="Alex", Year = 2019},
                new StudentModel(){ID = 2, LastName ="Wilson", FirstName="Fred", Year = 2020},
                new StudentModel(){ID = 3, LastName ="Brown", FirstName="Tyson", Year = 2022},
                new StudentModel(){ID = 4, LastName ="Moore", FirstName="Sophia", Year = 2019},
                new StudentModel(){ID = 5, LastName ="Lopez", FirstName="Amelia", Year = 2021},
            };

            modelBuilder.Entity<CourseModel>().HasData(cours);
            modelBuilder.Entity<EnrollmentModel>().HasData(enroll);
            modelBuilder.Entity<StudentModel>().HasData(stud);

            base.OnModelCreating(modelBuilder);
        }

    }
}
