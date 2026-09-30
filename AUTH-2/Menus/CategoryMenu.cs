using AUTH.Common;
using AUTH.Services;

namespace AUTH.Menus
{
    internal class CategoryMenu
    {
        public static void Start(CategoryServices service)
        {
            bool isOpen = true;

            while (isOpen)
            {
                if (Auth.HasRole(Enums.USER_ROLES.ADMIN))
                {
                    Console.WriteLine("1. create category");
                    Console.WriteLine("2. delete category");
                    Console.WriteLine("3. update category");
                }

                Console.WriteLine("4. show categories");
                Console.WriteLine("5. show categories with products");
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
                            service.ShowWithProducts();
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
