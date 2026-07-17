using ConsoleApp12.Common;
using ConsoleApp12.Services;

namespace ConsoleApp12.Menus
{
    internal class StudentMenu
    {
        public static void Start(StudentServices service)
        {
            while (true)
            {
                Console.WriteLine("1. create student");
                Console.WriteLine("2. delete student");
                Console.WriteLine("3. update student");
                Console.WriteLine("4. show students");
                Console.WriteLine("5. filter students");
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
