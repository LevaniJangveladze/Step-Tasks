using ConsoleApp10.Helpers;
using ConsoleApp10.Models;

namespace ConsoleApp10.Services
{
    internal class CourseServices
    {
        private Database _db;

        public CourseServices(Database db)
        {
            _db = db;
        }

        public void CreateCourse()
        {
            Console.Write("Enter course name: ");
            string name = Console.ReadLine();

            Console.Write("Enter course min age: ");
            int minAge = int.Parse(Console.ReadLine());

            Course course = new Course()
            {
                Name = name,
                MinAge = minAge
            };

            _db.Courses.Add(course);

            Console.WriteLine("course created successfully.");
        }

        public void DeleteCourse()
        {
            Console.Write("Enter course id: ");
            int id = int.Parse(Console.ReadLine());

            Course? selectedCourse = null;
            foreach (var course in _db.Courses)
            {
                if (course.Id == id)
                {
                    selectedCourse = course;
                }
            }

            if (selectedCourse == null)
            {
                throw new Exception("course not found.");
            }

            _db.Courses.Remove(selectedCourse);
            Console.WriteLine("course deleted successfully.");
        }

        public void UpdateCourse()
        {
            Console.Write("Enter course id: ");
            int id = int.Parse(Console.ReadLine());

            Course? selectedCourse = null;
            foreach (var course in _db.Courses)
            {
                if (course.Id == id)
                {
                    selectedCourse = course;
                }
            }

            if (selectedCourse == null)
            {
                throw new Exception("course not found.");
            }

            Console.Write("Enter course name to change: ");
            string name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
            {
                selectedCourse.Name = name;
            }

            Console.Write("Enter course minimal age to change: ");
            string ageInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(ageInput))
            {
                selectedCourse.MinAge = int.Parse(ageInput);
            }
            Console.WriteLine("course updated successfully.");
        }

        public void ShowCourses()
        {
            foreach (var item in _db.Courses)
            {
                Console.WriteLine($"COURSE: {item.Name}, min age: {item.MinAge}");
            }
        }

        public void ShowCoursesWithStudents()
        {
            foreach (var course in _db.Courses)
            {
                Console.WriteLine($"COURSE ID: {course.Id}, name: {course.Name}, min age: {course.MinAge}");

                foreach (var student in course.Students)
                {
                    Console.WriteLine(
                        $"     STUDENT ID: {student.Id}, name: {student.FullName}, email: {student.Email}, age: {student.Age}");
                }

                Console.WriteLine("");
            }
        }

        public void RegisterStudentOnCourse()
        {
            Console.Write("Enter student id: ");
            int studentId = int.Parse(Console.ReadLine());

            Student? selectedStudent = null;

            foreach (var student in _db.Students)
            {
                if (student.Id == studentId)
                {
                    selectedStudent = student;
                }
            }

            if (selectedStudent == null)
            {
                throw new Exception("student not found.");
            }

            Console.Write("Enter course id: ");
            int courseId = int.Parse(Console.ReadLine());

            Course? selectedCourse = null;

            foreach (var course in _db.Courses)
            {
                if (course.Id == courseId)
                {
                    selectedCourse = course;
                }
            }

            if (selectedCourse == null)
            {
                throw new Exception("course not found.");
            }

            if (selectedStudent.Age < selectedCourse.MinAge)
            {
                throw new Exception($"STUDENT AGE {selectedStudent.Age} < COURSE AGE {selectedCourse.MinAge}");
            }

            foreach (var item in selectedCourse.Students)
            {
                if (selectedStudent.Id == item.Id)
                {
                    throw new Exception("student already registerd on course");
                }
            }

            selectedCourse.Students.Add(selectedStudent);
            Console.WriteLine(
                $"student: {selectedStudent.FullName} register on course: {selectedCourse.Name} successfully.");
        }
    }
}