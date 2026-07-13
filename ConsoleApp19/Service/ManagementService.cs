using ConsoleApp19.Models;

namespace ConsoleApp19.Service;

internal class ManagementService
{
    private List<Course> _courses = new();
    private List<Student> _students = new();
    
    public void ShowCourses()
    {
        foreach (var course in _courses)
        {
            Console.WriteLine($"ID: {course.Id}, name: {course.Name}, desc: {course.Description}");
        }
    }

    public void ShowStudents()
    {
        foreach (var student in _students)
        {
            Console.WriteLine($"ID: {student.Id}, name: {student.Name}, email: {student.Email}, courseId: {student.CourseId}");
        }
    }

    public void CreateCourse()
    {
        Console.Write("Enter Course Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Course Description: ");
        string description = Console.ReadLine();

        Course course = new Course()
        {
            Name = name,
            Description = description,
        };

        _courses.Add(course);
        Console.WriteLine("Course Created");
    }

    public void CreateStudent()
    {
        Console.Write("Enter Student Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Student Email: ");
        string email = Console.ReadLine();

        Student student = new Student()
        {
            Name = name,
            Email = email,
        };

        _students.Add(student);
        Console.WriteLine("Student Created");
    }

    public void AddStudentToCourse()
    {
        Console.Write("Enter Student Id: ");
        int id = int.Parse(Console.ReadLine());
        
        Student? student = _students.FirstOrDefault(s => s.Id == id);

        if (student == null)
        {
            throw new Exception("Student not found");
        }
        
        Console.Write("Enter Student Course Id: ");
        int courseId = int.Parse(Console.ReadLine());
        
        Course? course = _courses.FirstOrDefault(c => c.Id == courseId);

        if (course == null)
        {
            throw new Exception("Course not found");
        }
        
        student.CourseId = course.Id;
        Console.WriteLine($"{student.Name} added to Course {course.Name}");
    }

    public void ShowCoursesWithStudents()
    {
        var result = _courses.GroupJoin(
            _students,
            c => c.Id,
            s => s.CourseId,
            (c, s) => new
            {
                CourseName = c.Name,
                Students = s
            }
        );

        foreach (var item in result)
        {
            Console.WriteLine($"Course: {item.CourseName}");

            foreach (var student in item.Students)
            {
                Console.WriteLine($"    ID: {student.Id}, name: {student.Name}, email: {student.Email}");
            }
            Console.WriteLine("");
        }
    }
    
}