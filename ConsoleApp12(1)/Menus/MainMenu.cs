using ConsoleApp12.Common;
using ConsoleApp12.Services;

namespace ConsoleApp12.Menus
{
    internal class MainMenu
    {
        public static void Start(CourseServices course, StudentServices student)
        {
            while (true)
            {
                Console.WriteLine("1. course menu");
                Console.WriteLine("2. student menu");
                Console.WriteLine("x. exit");

                Console.Write("Enter key: ");
                string key = Console.ReadLine();

                try
                {
                    switch (key)
                    {
                        case "1":
                            Console.Clear();
                            CourseMenu.Start(course);
                            break;
                        case "2":
                            Console.Clear();
                            StudentMenu.Start(student);
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
