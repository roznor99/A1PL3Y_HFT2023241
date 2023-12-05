using A1PL3Y_HFT2023241.Logic;
using A1PL3Y_HFT2023241.Models;
using A1PL3Y_HFT2023241.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace A1PL3Y_HFT2023241.Test
{
    [TestFixture]
    public class LogicTester
    {
        EnrollmentLogic enrollmentLogic;
        Mock<IRepository<EnrollmentModel>> mockEnrollRepo;

        StudentLogic studentLogic;
        Mock<IRepository<StudentModel>> mockStudRepo;

        CourseLogic courseLogic;
        Mock<IRepository<CourseModel>> mockCourRepo;

        [SetUp]
        public void Init()
        {
            List<EnrollmentModel> enroll = new List<EnrollmentModel>(){
                new EnrollmentModel(){ EnrollmentID = 1, CourseID = 1, StudentID = 1, Grade = 2 },
                new EnrollmentModel(){ EnrollmentID = 2, CourseID = 1, StudentID = 2, Grade = 2 },
                new EnrollmentModel(){ EnrollmentID = 3, CourseID = 2, StudentID = 2, Grade = 3 },
                new EnrollmentModel(){ EnrollmentID = 4, CourseID = 3, StudentID = 2, Grade = 5 }
            };

            List<StudentModel> stud = new List<StudentModel>(){
                new StudentModel() {ID = 1, LastName = "Smith", FirstName = "Alex", Year = 2019, Enrollments = enroll },
                new StudentModel() { ID = 2, LastName = "Wilson", FirstName = "Frederic", Year = 2020, Enrollments = enroll}
            };

            List<CourseModel> cour = new List<CourseModel>(){
                new CourseModel(){CourseID = 1, Title = "Környezet tudatosság", Credits = 1, Enrollments = enroll},
                new CourseModel(){CourseID = 2, Title = "Jazz kultúr történet", Credits = 3, Enrollments = enroll},
                new CourseModel(){CourseID = 3, Title = "Robotika", Credits = 5, Enrollments = enroll },
            };


            mockEnrollRepo = new Mock<IRepository<EnrollmentModel>>();
            mockEnrollRepo.Setup(m => m.ReadAll()).Returns(new List<EnrollmentModel>()
            {
                new EnrollmentModel(){ EnrollmentID = 1, CourseID = 1, StudentID = 1, Grade = 2, Student = stud[0], Course = cour[0] },
                new EnrollmentModel(){ EnrollmentID = 2, CourseID = 1, StudentID = 2, Grade = 1, Student = stud[1], Course = cour[0] },
                new EnrollmentModel(){ EnrollmentID = 3, CourseID = 2, StudentID = 2, Grade = 3, Student = stud[1], Course = cour[1] },
                new EnrollmentModel(){ EnrollmentID = 4, CourseID = 3, StudentID = 2, Grade = 5, Student = stud[1], Course = cour[2] }
            }.AsQueryable());
            enrollmentLogic = new EnrollmentLogic(mockEnrollRepo.Object);


            mockStudRepo = new Mock<IRepository<StudentModel>>();
            mockStudRepo.Setup(m => m.ReadAll()).Returns(new List<StudentModel>()
            {
                stud[0],
                stud[1]
            }.AsQueryable());
            studentLogic = new StudentLogic(mockStudRepo.Object);


            mockCourRepo = new Mock<IRepository<CourseModel>>();
            mockCourRepo.Setup(m => m.ReadAll()).Returns(new List<CourseModel>()
            {
                cour[0],
                cour[1],
                cour[2]
            }.AsQueryable());
            courseLogic = new CourseLogic(mockCourRepo.Object);
        }
        [Test]
        public void CreateEnrollmentWithCorrectGrade()
        {
            var newEnrollment = new EnrollmentModel() { CourseID = 2, StudentID = 1, Grade = 5 };
            //ACT
            enrollmentLogic.Create(newEnrollment);
            //ASSERT
            mockEnrollRepo.Verify(r => r.Create(newEnrollment), Times.Once());

        }
        [Test]
        public void CreateStudentWithCorrectName()
        {
            var newStudent = new StudentModel() { LastName = "Woods", FirstName = "Hank", Year = 2022 };
            
            studentLogic.Create(newStudent);         

            mockStudRepo.Verify(r => r.Create(newStudent), Times.Once());

        }
        [Test]
        public void CreateStudentWithInCorrectname()
        {
            var newStudent = new StudentModel() { LastName = "Woods", FirstName = "Bo", Year = 2022 };
            try
            {

                studentLogic.Create(newStudent);
            }
            catch
            {


            }
                mockStudRepo.Verify(r => r.Create(newStudent), Times.Never());
            
        }
        [Test]
        public void CreateCourseWithCorrectTitle()
        {
            var newCourse = new CourseModel() { Title = "AUDIT", Credits = 4 };
            
            courseLogic.Create(newCourse);
            

            mockCourRepo.Verify(r => r.Create(newCourse), Times.Once());
        }
        [Test]
        public void CreateCourseWithInCorrectTitle()
        {
            var newCourse = new CourseModel() { Title = "A", Credits = 4 };
            try
            {
                courseLogic.Create(newCourse);
            }
            catch
            {

            }
           
            mockCourRepo.Verify(r => r.Create(newCourse), Times.Never());
        }

    }
}
