using ConsoleApp12.Services;
using ConsoleApp12.Common;
using ConsoleApp12.Menus;

namespace ConsoleApp12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database db = new Database();

            CourseServices courseServices = new CourseServices(db);
            StudentServices studentServices = new StudentServices(db);

            MainMenu.Start(courseServices, studentServices);
        }
    }
}
