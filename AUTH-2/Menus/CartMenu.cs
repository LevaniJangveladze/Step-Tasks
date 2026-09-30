using AUTH.Common;
using AUTH.Services;

namespace AUTH.Menus
{
    internal class CartMenu
    {
        public static void Start(CartServices service)
        {
            bool isOpen = true;

            while (isOpen)
            {
                Console.WriteLine("1. add to cart");
                Console.WriteLine("2. remove from cart");
                Console.WriteLine("3. update quantity");
                Console.WriteLine("4. show my cart");
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
