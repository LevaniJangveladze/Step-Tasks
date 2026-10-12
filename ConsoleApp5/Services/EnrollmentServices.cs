using ConsoleApp5.Data;
using ConsoleApp5.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp5.Services
{
    internal class EnrollmentServices
    {
        private readonly DataContext _db;

        public EnrollmentServices(DataContext db)
        {
            _db = db;
        }

        public void Create()
        {
            // show courses to amdin and select one
            var courses = _db.Courses.ToList();
            courses.ForEach(c => c.Show());

            Console.Write("Enter course id: ");
            int courseId = int.Parse(Console.ReadLine()!);

            var course = _db.Courses.Find(courseId);
            if (course == null) throw new Exception("course not found.");

            // show students to amdin and select one
            var students = _db.Students.ToList();
            students.ForEach(s => s.Show());

            Console.Write("Enter student id: ");
            int studentId = int.Parse(Console.ReadLine()!);

            var student = _db.Students.Find(studentId);

            if (student == null) throw new Exception("student not found.");
            if (course.Deadline < DateTime.Now)
                throw new Exception("registration deadline has passsed.");
            
            int existingEnrollments = _db.Enrollments.Count(e => e.CourseId == course.Id);
            if (existingEnrollments >= course.Capacity) throw new Exception("course is full.");
            bool alreadyEnrolled = _db.Enrollments.Any(e => e.CourseId == course.Id && e.StudentId == student.Id);
            if(alreadyEnrolled) throw new Exception("student is already enrolled in this course.");

            // create enrollment
            var enrollment = new Enrollment
            {
                CourseId = courseId,
                StudentId = studentId,
            };

            _db.Enrollments.Add(enrollment);
            _db.SaveChanges();
        }
        
        public void Show()
        {
            var enrollments = _db.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .ToList();

            foreach (var e in enrollments)
                Console.WriteLine($"{e.Student.Fullname} — {e.Course.Name} — registered {e.RegisteredAt:d}");
        }
    }
}
