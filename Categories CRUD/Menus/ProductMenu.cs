using ConsoleApp12.Common;
using ConsoleApp12.Services;

namespace ConsoleApp12.Menus
{
    internal class ProductMenu
    {
        public static void Start(ProductServices service)
        {
            bool isOpen = true;

            while (isOpen)
            {
                Console.WriteLine("1. create product");
                Console.WriteLine("2. delete product");
                Console.WriteLine("3. update product");
                Console.WriteLine("4. show products");
                Console.WriteLine("5. search products");
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