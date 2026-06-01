namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Console.Write("Enter the first number:");
           int a = int.Parse(Console.ReadLine());
           
           Console.Write("Enter the second number: ");
           int b = int.Parse(Console.ReadLine());
           
           Console.WriteLine($"{a} + {b} = {a + b}");
           Console.WriteLine($"{a} - {b} = {a - b}");
           Console.WriteLine($"{a} * {b} = {a * b}");
           
           Console.WriteLine($"{a} / {b} = {(double)a / b}");
           
           Console.WriteLine($"{a} % {b} = {a % b}");
        }
    }
}
