namespace BankAPP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount[] accounts = new BankAccount[10];
            int count = 0;


            while (true)
            {
                Console.WriteLine("1. create new account");
                Console.WriteLine("2. add balance");
                Console.WriteLine("3. show my account");

                Console.Write("Enter key: ");
                string key = Console.ReadLine();

                if (key == "1")
                {
                    Console.Clear();

                    Console.Write("Enter owner name: ");
                    string name = Console.ReadLine();
                    accounts[count] = new BankAccount(name);
                    count++;
                    Console.WriteLine("account created successfully");
                }
                else if (key == "2")
                {
                    Console.Clear();
                    Console.Write("Enter owner name: ");
                    string name = Console.ReadLine();

                    BankAccount? found = null;
                    for (int i = 0; i < count; i++)
                    {
                        if (accounts[i].Owner == name)
                        {
                            found = accounts[i];
                        }
                    }

                    if (found == null)
                    {
                        Console.WriteLine("account not found.");
                    }

                    else
                    {
                        Console.Write("Enter balance: ");
                        double balance = double.Parse(Console.ReadLine());
                        found.AddBalance(balance);
                        Console.WriteLine("account balance updated successfully");
                    }
                }
                else if (key == "3")
                {
                    Console.Clear();
                    for (int i = 0; i < count; i++)
                    {
                        accounts[i].ShowInfo();
                    }
                }
            }
        }
    }

    internal class BankAccount
    {
        public string Owner { get; set; }
        public double Balance { get; private set; } = 0;

        public BankAccount(string owner)
        {
            if (owner.Length > 2)
            {
                Owner = owner;
            }
            else
            {
                Console.WriteLine("invalid owner name.");
            }
        }

        public void AddBalance(double balance)
        {
            if (balance >= 0)
            {
                Balance += balance;
            }
            else
            {
                Console.WriteLine("balance must be greater then 0.");
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Owner} - balance: {Balance}");
        }
    }
}