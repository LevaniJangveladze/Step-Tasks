using ConsoleApp12.Common;
using ConsoleApp12.Services;

namespace ConsoleApp12.Menus
{
    internal class CategoryMenu
    {
        public static void Start(CategoryServices service)
        {
            bool isOpen = true;

            while (isOpen)
            {
                Console.WriteLine("1. create category");
                Console.WriteLine("2. delete category");
                Console.WriteLine("3. update category");
                Console.WriteLine("4. show categories");
                Console.WriteLine("5. search categories");
                Console.WriteLine("6. add product to category");
                Console.WriteLine("7. remove product from category");
                Console.WriteLine("8. show categories with products");
                Console.WriteLine("x. exit");

                Console.Write("Enter key: ");
                string key = Console.ReadLine();

                try
                {
                    switch (key)
                    {
                        case "1": Console.Clear(); service.Create(); break;
                        case "2": Console.Clear(); service.Delete(); break;
                        case "3": Console.Clear(); service.Update(); break;
                        case "4": Console.Clear(); service.Show(); break;
                        case "5": Console.Clear(); service.Search(); break;
                        case "6": Console.Clear(); service.AddProduct(); break;
                        case "7": Console.Clear(); service.RemoveProduct(); break;
                        case "8": Console.Clear(); service.ShowCategoriesWithProducts(); break;
                        case "x": Console.Clear(); isOpen = false; break;
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