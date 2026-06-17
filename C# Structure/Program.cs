using ConsoleApp10.Helpers;
using ConsoleApp10.Services;

namespace ConsoleApp10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database db = new Database();

            StudentServices studentServicesObj = new StudentServices(db);
            CourseServices courseServicesObj = new CourseServices(db);

            while (true)
            {
                Console.WriteLine("1. create student");
                Console.WriteLine("2. delete student");
                Console.WriteLine("3. update student");
                Console.WriteLine("4. show students");
                Console.WriteLine("5. create course");
                Console.WriteLine("6. delete course");
                Console.WriteLine("7. update course");
                Console.WriteLine("8. show courses");
                Console.WriteLine("9. show courses with students");
                Console.WriteLine("10. register student on course");

                Console.Write("Enter key: ");
                string key = Console.ReadLine();

                try
                {
                    if (key == "1")
                    {
                        Console.Clear();
                        studentServicesObj.CreateStudent();
                    }
                    else if (key == "2")
                    {
                        Console.Clear();
                        studentServicesObj.DeleteStudent();
                    }
                    else if (key == "3")
                    {
                        Console.Clear();
                        studentServicesObj.UpdateStudent();
                    }
                    else if (key == "4")
                    {
                        Console.Clear();
                        studentServicesObj.ShowStudents();
                    }
                    else if (key == "5")
                    {
                        Console.Clear();
                        courseServicesObj.CreateCourse();
                    }
                    else if (key == "6")
                    {
                        Console.Clear();
                        courseServicesObj.DeleteCourse();
                    }
                    else if (key == "7")
                    {
                        Console.Clear();
                        courseServicesObj.UpdateCourse();
                    }
                    else if (key == "8")
                    {
                        Console.Clear();
                        courseServicesObj.ShowCourses();
                    }
                    else if (key == "9")
                    {
                        Console.Clear();
                        courseServicesObj.ShowCoursesWithStudents();
                    }
                    else if (key == "10")
                    {
                        Console.Clear();
                        courseServicesObj.RegisterStudentOnCourse();
                    }
                    else
                    {
                        throw new Exception("invalid key.");
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"ERROR: {ex.Message}");
                    Console.ResetColor();
                }
            }
        }
    }
}