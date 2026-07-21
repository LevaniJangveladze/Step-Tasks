using Praqtikuli_21._07.Services;

namespace Praqtikuli_21._07.Menu;

public static class MovieMenu
{
    public static void Start(MovieService service)
    {
        while (true)
        {
            Console.WriteLine("1. create movie");
            Console.WriteLine("2. delete movie");
            Console.WriteLine("3. update movie");
            Console.WriteLine("4. show movies");
            Console.WriteLine("5. search movies");
            Console.WriteLine("6. filter movies");
            Console.WriteLine("x. exit");
            
            Console.Write("Enter key: ");
            string key = Console.ReadLine();

            switch (key)
            {
                case "1": service.Create(); break;
                case "2": service.Delete(); break;
                case "3": service.Update(); break;
                case "4": service.Show(); break;
                case "5": service.Search(); break;
                case "6": service.Filter(); break;
                case "x": return;
            }
        }
    }
}