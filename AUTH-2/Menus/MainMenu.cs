using AUTH.Common;
using AUTH.Services;

namespace AUTH.Menus
{
    internal class MainMenu
    {
        public static void Start()
        {
            Database db = new Database();

            UserServices userServices = new UserServices(db);
            CartServices cartServices = new CartServices(db);
            ProductServices productServices = new ProductServices(db);
            CategoryServices categoryServices = new CategoryServices(db);

            bool isOpen = true;

            while (isOpen)
            {
                Console.WriteLine("1. user menu");

                if (Auth.IsAuthorized())
                {
                    Console.WriteLine("2. cart menu");
                    Console.WriteLine("3. product menu");
                    Console.WriteLine("4. category menu");
                }

                Console.WriteLine("x. exit");

                Console.Write("Enter key: ");
                string key = Console.ReadLine();

                try
                {
                    switch (key)
                    {
                        case "1":
                            Console.Clear();
                            UserMenu.Start(userServices);
                            break;
                        case "2":
                            Auth.GetUser();
                            Console.Clear();
                            CartMenu.Start(cartServices);
                            break;
                        case "3":
                            Auth.GetUser();
                            Console.Clear();
                            ProductMenu.Start(productServices);
                            break;
                        case "4":
                            Auth.GetUser();
                            Console.Clear();
                            CategoryMenu.Start(categoryServices);
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
