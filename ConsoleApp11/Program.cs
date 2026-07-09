using ConsoleApp11.Services;

namespace ConsoleApp11
{
    internal class Program
    {
        static void Main(string[] args)
        {
           GameServices service = new GameServices();
           while (true)
           {
               Console.WriteLine("1.Create");
               Console.WriteLine("2.Delete");
               Console.WriteLine("3.Update");
               Console.WriteLine("4.Show");
               Console.WriteLine("5.Filter by price");
               Console.WriteLine("6.Search");
               
               Console.WriteLine("Enter key: ");
               string key = Console.ReadLine();

               try
               {
                   if (key == "1")
                   {
                       service.Create();
                   }
                   else if (key == "2")
                   {
                       service.Delete();
                   }
                   else if (key == "3")
                   {
                       service.Update();
                   }
                   else if (key == "4")
                   {
                       service.Show();
                   }else if (key == "5")
                   {
                       service.FilterByPrice();
                   }
                   else if (key == "6")
                   {
                       service.Search();
                   }
                   else
                   {
                       throw new Exception("Invalid key");
                   }
                  }
               catch (Exception e)
               {
                   Console.ForegroundColor = ConsoleColor.Red;
                   Console.WriteLine($"ERROR: {e.Message}");
                   Console.ResetColor();
               }
           }
        }
    }
}
