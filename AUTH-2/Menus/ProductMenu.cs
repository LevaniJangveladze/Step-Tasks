using AUTH.Common;
using AUTH.Services;

namespace AUTH.Menus
{
    internal class ProductMenu
    {
        public static void Start(ProductServices service)
        {
            bool isOpen = true;

            while (isOpen)
            {
                if (Auth.HasRole(Enums.USER_ROLES.ADMIN))
                {
                    Console.WriteLine("1. create product");
                    Console.WriteLine("2. delete product");
                    Console.WriteLine("3. update product");
                }

                Console.WriteLine("4. show products");
                Console.WriteLine("5. search products");
                Console.WriteLine("6. filter products by price");
                Console.WriteLine("7. filter products by category");
                Console.WriteLine("x. exit");

                Console.Write("Enter key: ");
                string key = Console.ReadLine();

                try
                {
                    switch (key)
                    {
                        case "1":
                            Auth.IsAdmin();
                            Console.Clear();
                            service.Create();
                            break;
                        case "2":
                            Auth.IsAdmin();
                            Console.Clear();
                            service.Delete();
                            break;
                        case "3":
                            Auth.IsAdmin();
                            Console.Clear();
                            service.Update();
                            break;
                        case "4":
                            Console.Clear();
                            service.Show();
                            break;
                        case "5":
                            Console.Clear();
                            service.Search();
                            break;
                        case "6":
                            Console.Clear();
                            service.FilterByPrice();
                            break;
                        case "7":
                            Console.Clear();
                            service.FilterByCategoryId();
                            break;
                        case "x":
                            Console.Clear();
                            isOpen = false;
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
