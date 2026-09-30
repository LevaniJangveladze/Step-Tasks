using AUTH.Common;
using AUTH.Services;

namespace AUTH.Menus
{
    internal class UserMenu
    {
        public static void Start(UserServices service)
        {
            bool isOpen = true;

            while (isOpen)
            {
                if (!Auth.IsAuthorized())
                {
                    Console.WriteLine("1. register");
                    Console.WriteLine("2. login");
                }
                else
                {
                    Console.WriteLine("3. logout");
                    Console.WriteLine("4. show profile");
                    Console.WriteLine("5. chnage role as admin");
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
                            service.Register();
                            break;
                        case "2":
                            Console.Clear();
                            service.Login();
                            break;
                        case "3":
                            Console.Clear();
                            service.Logout();
                            break;
                        case "4":
                            Console.Clear();
                            service.ShowProfile();
                            break;
                        case "5":
                            Console.Clear();
                            service.MakeAdmin();
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
