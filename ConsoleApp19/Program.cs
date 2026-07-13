using System.Security.Cryptography.X509Certificates;
using ConsoleApp19.Models;
using ConsoleApp19.Service;

namespace ConsoleApp19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ManagementService service = new ManagementService();
            
            while (true)
            {   Console.Clear();
                Console.WriteLine("1. Create course");
                Console.WriteLine("2. Create student");
                Console.WriteLine("3. Show courses");
                Console.WriteLine("4. Show students");
                Console.WriteLine("5. Add student to course");
                Console.WriteLine("6. Show courses with students");
                
                Console.Write("Enter key: ");  
                string key =Console.ReadLine();

                try
                {
                    if (key == "1")
                    {
                        service.CreateCourse();
                    }
                    else if (key == "2")
                    {
                        service.CreateStudent();
                    }else if (key == "3")
                    {
                        service.ShowCourses();
                    }else if (key == "4")
                    {
                        service.ShowStudents();
                    }else if (key == "5")
                    {
                        service.AddStudentToCourse();
                    }
                    else if (key == "6")
                    {
                        service.ShowCoursesWithStudents();
                    }
                    else
                    {
                        throw new Exception("Invalid input");
                    }
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                  
                }
                
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey(); 
            }
        }
        
    }
}
