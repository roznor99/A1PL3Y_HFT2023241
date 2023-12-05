using A1PL3Y_HFT2023241.Models;
using ConsoleTools;
using System;
using System.Collections.Generic;

namespace A1PL3Y_HFT2023241.Client
{
    internal class Program
    {
        static RestService rest;

        static void Create(string entity)
        {
            if (entity == "Student")
            {
                Console.Write("Enter Student FirstName: ");
                string fname = Console.ReadLine();
                Console.Write("Enter Student LastName: ");
                string lname = Console.ReadLine();
                Console.Write("Year of Enrollment: ");
                int year = int.Parse(Console.ReadLine());
                rest.Post(new StudentModel() { FirstName = fname, LastName = lname, Year = year }, "Student");
            }
            if (entity == "Enrollment")
            {
                Console.Write("Enter Student's id: ");
                int sid = int.Parse(Console.ReadLine());
                Console.Write("Enter Courses's id: ");
                int cid = int.Parse(Console.ReadLine());
                Console.Write("Enter Enrollment Grade: ");
                int grade = int.Parse(Console.ReadLine());
                rest.Post(new EnrollmentModel() { Grade = grade, StudentID = sid, CourseID = cid }, "Enrollment");
            }
            if (entity == "Course")
            {
                Console.Write("Enter Subject Title: ");
                string title = Console.ReadLine();
                Console.Write("Subject's credit: ");
                int credit = int.Parse(Console.ReadLine());
                rest.Post(new CourseModel() { Credits = credit, Title = title }, "Course");
            }
        }
        static void List(string entity)
        {
            if (entity == "Student")
            {
                List<StudentModel> students = rest.Get<StudentModel>("Student");
                foreach (var item in students)
                {
                    Console.WriteLine(item.ID + ": " + item.FirstName + " " + item.LastName);
                }
            }
            if (entity == "Enrollment")
            {
                List<EnrollmentModel> enroll = rest.Get<EnrollmentModel>("Enrollment");
                foreach (var item in enroll)
                {
                    Console.WriteLine("ID: " + item.EnrollmentID + "\t Student: " + item.Student.FirstName + " " + item.Student.LastName + " \t Grade: " + item.Grade + " \t Subject: " + item.Course.Title);
                }
            }
            if (entity == "Course")
            {
                List<CourseModel> cour = rest.Get<CourseModel>("Course");
                foreach (var item in cour)
                {
                    Console.WriteLine("ID: " + item.CourseID + "\t Credit: " + item.Credits + "\t Subject: " + item.Title);
                }
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "Student")
            {
                Console.Write("Enter Student's id to update: ");
                int id = int.Parse(Console.ReadLine());
                StudentModel one = rest.Get<StudentModel>(id, "Student");
                Console.Write($"New First Name [old: {one.FirstName}]: ");
                string fname = Console.ReadLine();
                Console.Write($"New Last Name [old: {one.LastName}]: ");
                string lname = Console.ReadLine();
                Console.Write($"New Year [old: {one.Year}]: ");
                int year = int.Parse(Console.ReadLine());
                one.FirstName = fname;
                one.LastName = lname;
                one.Year = year;
                rest.Put(one, "Student");
            }
            if (entity == "Enrollment")
            {
                Console.Write("Enter Enrollment's id to update: ");
                int id = int.Parse(Console.ReadLine());
                EnrollmentModel one = rest.Get<EnrollmentModel>(id, "Enrollment");
                Console.Write($"New StudentID Name [old: {one.StudentID}]: ");
                int sid = int.Parse(Console.ReadLine());
                Console.Write($"New CourseID [old: {one.CourseID}]: ");
                int cid = int.Parse(Console.ReadLine());
                Console.Write($"New Grade [old: {one.Grade}]: ");
                int grade = int.Parse(Console.ReadLine());
                one.StudentID = sid;
                one.Grade = grade;
                one.CourseID = cid;
                rest.Put(one, "Enrollment");
            }
            if (entity == "Course")
            {
                Console.Write("Enter Course's id to update: ");
                int id = int.Parse(Console.ReadLine());
                CourseModel one = rest.Get<CourseModel>(id, "Course");
                Console.Write($"New Title for Subject [old: {one.Title}]: ");
                string title = Console.ReadLine();
                Console.Write($"New Credit for Title [old: {one.Credits}]: ");
                int credit = int.Parse(Console.ReadLine());
                one.Title = title;
                one.Credits = credit;
                rest.Put(one, "Course");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Student")
            {
                Console.Write("Enter Student's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "Student");
            }
            if (entity == "Enrollment")
            {
                Console.Write("Enter Enrollment's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "Enrollment");
            }
            if (entity == "Course")
            {
                Console.Write("Enter Course's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "Course");
            }
        }
        static void GoodStudentToBadStudent(string entity)
        {
            List<EnrollmentModel.StudentsInfo> enroll = rest.Get<EnrollmentModel.StudentsInfo>("EnrollStat/GoodStudentToBadStudent");
            foreach (var item in enroll)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }
        static void SubjectPassAVG(string entity)
        {
            List<EnrollmentModel.TitleInfo> enroll = rest.Get<EnrollmentModel.TitleInfo>("EnrollStat/SubjectPassAVG");

            foreach (var item in enroll)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }
        static void SubjectCount(string entity)
        {
            List<EnrollmentModel.SubjectInfo> enroll = rest.Get<EnrollmentModel.SubjectInfo>("EnrollStat/SubjectCount");
            foreach (var item in enroll)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }
        static void YearAVGs(string entity)
        {

            List<EnrollmentModel.YearInfo> enroll = rest.Get<EnrollmentModel.YearInfo>("EnrollStat/YearAVGs");
            foreach (var item in enroll)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }
        static void CreditValuePerSubjects(string entity)
        {
            List<CourseModel.HowManyInfo> enroll = rest.Get<CourseModel.HowManyInfo>("CourStat/CreditValuePerSubjects");
            foreach (var item in enroll)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:52423/", "Course");
            rest = new RestService("http://localhost:52423/", "Enrollment");
            rest = new RestService("http://localhost:52423/", "Student");
            rest = new RestService("http://localhost:52423/", "EnrollStat/GoodStudentToBadStudent");
            rest = new RestService("http://localhost:52423/", "EnrollStat/SubjectPassAVG");
            rest = new RestService("http://localhost:52423/", "EnrollStat/SubjectCount");
            rest = new RestService("http://localhost:52423/", "EnrollStat/YearAVGs");
            rest = new RestService("http://localhost:52423/", "CourStat/CreditValuePerSubjects");

            var courseSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Course"))
                .Add("Create", () => Create("Course"))
                .Add("Delete", () => Delete("Course"))
                .Add("Update", () => Update("Course"))
                .Add("CreditValuePerSubjects", () => CreditValuePerSubjects("CourStat/CreditValuePerSubjects"))
                .Add("Exit", ConsoleMenu.Close);

            var enrollmentSubMenu = new ConsoleMenu(args, level: 1)
               .Add("List", () => List("Enrollment"))
               .Add("Create", () => Create("Enrollment"))
               .Add("Delete", () => Delete("Enrollment"))
               .Add("Update", () => Update("Enrollment"))
               .Add("GoodStudentToBadStudent", () => GoodStudentToBadStudent("EnrollStat/GoodStudentToBadStudent"))
               .Add("SubjectPassAVG", () => SubjectPassAVG("EnrollStat/SubjectPassAVG"))
               .Add("SubjectCount", () => SubjectCount("EnrollStat/SubjectCount"))
               .Add("YearAVGs", () => YearAVGs("EnrollStat/YearAVGs"))
               .Add("Exit", ConsoleMenu.Close);

            var studentSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Student"))
                .Add("Create", () => Create("Student"))
                .Add("Delete", () => Delete("Student"))
                .Add("Update", () => Update("Student"))
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Courses", () => courseSubMenu.Show())
                .Add("Enrollments", () => enrollmentSubMenu.Show())
                .Add("Students", () => studentSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);
            menu.Show();
        }
    }
}
