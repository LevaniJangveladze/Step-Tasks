namespace ConsoleApp8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            bool hasStarted = false;


            while (true)
            {
                if (!hasStarted)
                {
                    string xInput = GetText("Enter x: ");
                    if (xInput == "C")
                    {
                        Console.WriteLine("Cleared! x = 0");
                        continue;
                    }

                    x = int.Parse(xInput);
                    hasStarted = true;
                    continue;
                }

                string oop = GetText("Enter opperation");

                if (oop == "C")
                {
                    x = 0;
                    hasStarted = false;
                    Console.WriteLine("Cleared! x = 0");
                    continue;
                }

                string yInput = GetText("Enter Y: ");
                if (yInput == "C")
                {
                    x = 0;
                    hasStarted = false;
                    Console.WriteLine("Cleared! x = 0");
                    continue;
                }

                int y = int.Parse(yInput);


                try
                {
                    int result = Calculate(x, y, oop);
                    Console.WriteLine($"= {result}");
                    x = result;
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


        static int Calculate(int x, int y, string oop)
        {
            if (oop == "+")
            {
                return x + y;
            }
            else if (oop == "-")
            {
                return x - y;
            }
            else if (oop == "*")
            {
                return x * y;
            }
            else if (oop == "/")

            {
                if (y == 0)
                {
                    throw new Exception("Divide by zero");
                }

                return x / y;
            }
            else if (oop == "%")
            {
                if (y == 0)
                {
                    throw new Exception("Divide by zero");
                }

                return x % y;
            }
            else
            {
                throw new Exception("Invalid operation.");
            }
        }
    }
}