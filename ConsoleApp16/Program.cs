using ConsoleApp16.Services;

namespace ConsoleApp16
{
    internal class Program
    {
        static void Main(string[] args)
        {
         GameServices services = new GameServices();
         services.Start();
        }
    }
}
