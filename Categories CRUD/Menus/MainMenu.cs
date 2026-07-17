using ConsoleApp12.Common;
using ConsoleApp12.Services;

namespace ConsoleApp12.Menus
{
    internal class MainMenu
    {
        public static void Start()
        {
            Database db = new Database();

            CategoryServices categoryServices = new CategoryServices(db);
            ProductServices productServices = new ProductServices(db);

            while (true)
            {
                Console.WriteLine("1. category menu");
                Console.WriteLine("2. product menu");
                Console.WriteLine("x. exit");

                Console.Write("Enter key: ");
                string key = Console.ReadLine();

                try
                {
                    switch (key)
                    {
                        case "1": Console.Clear(); CategoryMenu.Start(categoryServices); break;
                        case "2": Console.Clear(); ProductMenu.Start(productServices); break;
                        case "x": Console.Clear(); return;
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