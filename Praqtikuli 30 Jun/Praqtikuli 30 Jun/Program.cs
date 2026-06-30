using Praqtikuli_30_Jun.Services;

namespace Praqtikuli_30_Jun;

class Program
{
    static void Main(string[] args)
    {
       ProductService service = new ProductService();
       while (true)
       {
           Console.WriteLine("1. Create");
           Console.WriteLine("2. Delete");
           Console.WriteLine("3. Update");
           Console.WriteLine("4. Show");
           
           Console.Write("Enter key: ");
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
               }else if (key == "3")
               {
                   service.Update();
               }else if (key == "4")
               {
                   service.Show();
               }
               else
               {
                   throw new Exception("Invalid key");
               }
           }
           catch (Exception e)
           {
               Console.ForegroundColor = ConsoleColor.Red;
               Console.WriteLine($"Error: {e.Message}");
               Console.ResetColor();
           }
       }
    }
}