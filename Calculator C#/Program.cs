namespace ConsoleApp8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int x = GetNumber("Enter X");
                int y = GetNumber("Enter Y");
                string oop = GetText("Enter opperation");

                try
                {
                    Calculate(x, y, oop);
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: {e.Message}");
                    Console.ResetColor();
                }
            }
        }

        static int GetNumber(string msg)
        {
            string number = GetText(msg);

            return int.Parse(number);
        }

        static string GetText(string msg)
        {
            Console.Write($"{msg}: ");
            string text = Console.ReadLine();

            return text;
        }

        static void Calculate(int x, int y, string oop)
        {
            if (oop == "+")
            {
                Console.WriteLine($"{x} + {y} = {x + y}");
            }
            else if (oop == "-")
            {
                Console.WriteLine($"{x} - {y} = {x - y}");
            }
            else if (oop == "*")
            {
                Console.WriteLine($"{x} * {y} = {x * y}");
            }
            else if (oop == "/")

            {
                if (y == 0)
                {
                    throw new Exception("Divide by zero");
                }

                Console.WriteLine($"{x} / {y} = {x / y}");
            }
            else if (oop == "%")
            {
                if (y == 0)
                {
                    throw new Exception("Divide by zero");
                }

                Console.WriteLine($"{x} % {y} = {x % y}");
            }
            else
            {
                Console.WriteLine("Invalid format.");
            }
        }


       
    }
}