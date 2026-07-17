using ConsoleApp12.Common;
using ConsoleApp12.Services;

namespace ConsoleApp12.Menus
{
    internal class CourseMenu
    {
        public static void Start(CourseServices service)
        {
            while (true)
            {
                Console.WriteLine("1. create course");
                Console.WriteLine("2. delete course");
                Console.WriteLine("3. update course");
                Console.WriteLine("4. show courses");
                Console.WriteLine("5. filter courses");
                Console.WriteLine("6. add student to course");
                Console.WriteLine("7. remove student from course");
                Console.WriteLine("x. exit");

                Console.Write("Enter key: ");
                string key = Console.ReadLine();

                try
                {
                    switch (key)
                    {
                        case "1":
                            Console.Clear();
                            service.Create();
                            break;
                        case "2":
                            Console.Clear();
                            service.Delete();
                            break;
                        case "3":
                            Console.Clear();
                            service.Update();
                            break;
                        case "4":
                            Console.Clear();
                            service.Show();
                            break;
                        case "5":
                            Console.Clear();
                            service.Filter();
                            break;
                        case "6":
                            Console.Clear();
                            service.AddStudent();
                            break;
                        case "7":
                            Console.Clear();
                            service.RemoveStudent();
                            break;
                        case "x":
                            Console.Clear();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Result.Error(ex.Message);
                }
            }
        }
    }
}
