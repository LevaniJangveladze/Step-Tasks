namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            while (true)
            {
                Console.WriteLine("1. Create");
                Console.WriteLine("2. Delete");
                Console.WriteLine("3. Update");
                Console.WriteLine("4. Show all cars");
                Console.Write("Enter key: ");
                string key = Console.ReadLine();

                try
                {
                    if (key == "1")
                    {
                        Console.Clear();
                        Console.Write("Enter car brand: ");
                        string brand = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(brand)) throw new Exception("Brand is required");


                        Console.Write("Enter car model: ");
                        string model = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(model)) throw new Exception("Model is required");


                        Console.Write("Enter car year: ");
                        int year = int.Parse(Console.ReadLine());

                        Car car = new Car()
                        {
                            Brand = brand,
                            Model = model,
                            Year = year
                        };

                        cars.Add(car);
                        Console.WriteLine("Car added");
                    }
                    else if (key == "2")
                    {
                        Console.Clear();
                        Console.Write("Enter car ID: ");
                        int id = int.Parse(Console.ReadLine());

                        Car? foundedCar = null;

                        foreach (var car in cars)
                        {
                            if (car.Id == id)
                            {
                                foundedCar = car;
                            }
                        }

                        if (foundedCar == null)
                        {
                            throw new Exception("Car not found");
                        }

                        cars.Remove(foundedCar);
                        Console.WriteLine("Car deleted");
                    }
                    else if (key == "3")
                    {
                        Console.Clear();
                        Console.Write("Enter car ID: ");
                        int id = int.Parse(Console.ReadLine());

                        Car? foundedCar = null;

                        foreach (var car in cars)
                        {
                            if (car.Id == id)
                            {
                                foundedCar = car;
                            }
                        }

                        if (foundedCar == null)
                        {
                            throw new Exception("Car not found");
                        }


                        Console.WriteLine("Enter new brand (leave blank to keep): ");
                        string brand = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(brand))
                        {
                            foundedCar.Brand = brand;
                        }

                        Console.WriteLine("Enter new model (leave blank to keep): ");
                        string model = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(model))
                        {
                            foundedCar.Model = model;
                        }

                        Console.WriteLine("Enter updated year (leave blank to keep): ");
                        string yearInput = (Console.ReadLine());
                        if (!string.IsNullOrWhiteSpace(yearInput))
                        {
                            foundedCar.Year = int.Parse(yearInput);
                        }

                        Console.WriteLine("Car updated");
                    }


                    else if (key == "4")
                    {
                        Console.Clear();

                        foreach (var car in cars)
                        {
                            Console.WriteLine($"{car.Id} {car.Brand} {car.Model} {car.Year}");
                        }
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

    internal class Car
    {
        private static int _counter = 1;

        public int Id { get; private set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public Car()
        {
            Id = _counter++;
        }
    }
}