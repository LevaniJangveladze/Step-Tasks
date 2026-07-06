namespace ConsoleApp12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new();

            while (true)
            {
                Console.WriteLine("1. Create car");
                Console.WriteLine("2. Delete car");
                Console.WriteLine("3. Update car");
                Console.WriteLine("4. Show cars");
                
                Console.Write("Enter key: ");
                string key = Console.ReadLine();

                try
                {
                    if (key == "1")
                    {
                        Car car = new Car();
                        car.Create();
                        cars.Add(car);
                        Console.WriteLine("Car created.");
                    }
                    else if (key == "2")
                    {
                        Console.Write("Enter model: ");
                        string model = Console.ReadLine();

                        Car? found = null;
                        foreach (var item in cars)
                        {
                            if (item.Model == model)
                            {
                                found = item;
                            }
                        }

                        if (found == null)
                        {
                            throw new Exception("No such car.");
                        }

                        cars.Remove(found);
                        Console.WriteLine("Car deleted.");
                    }
                    else if (key == "3")
                    {
                        Console.Write("Enter model: ");
                        string model = Console.ReadLine();

                        Car? found = null;
                        foreach (var item in cars)
                        {
                            if (item.Model == model)
                            {
                                found = item;
                            }
                        }

                        if (found == null)
                        {
                            throw new Exception("No such car.");
                        }
                        
                        Console.Write("Enter new model (leave blank to keep): ");
                        string newModel = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(newModel))
                        {
                            found.SetModel(newModel);
                        }
                        
                        Console.Write("Enter new brand (leave blank to keep): ");
                        string newBrand = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(newBrand))
                        {
                            found.SetBrand(newBrand);
                        }
                        
                        Console.Write("Enter new price (leave blank to keep): ");
                        string newPrice = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(newPrice))
                        {
                            found.SetPrice(decimal.Parse(newPrice));
                        }
                    }
                    
                    else if (key == "4")
                    {
                        foreach (var item in cars)
                        {
                            item.ShowInfo();
                        }
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

    internal class Car
    {
         public string Brand { get;  private set; }
         public string Model { get;  private set; }
         public decimal Price { get; private set; }

         public void SetBrand(string brand)
         {
             if (string.IsNullOrWhiteSpace(brand))
             {
                 throw new Exception("brand is required.");
             }

             if (brand.Length <=1)
             {
                 throw new Exception("brand must be longer than 1 character.");
             }
             
             Brand = brand;
         }

         public void SetModel(string model)
         {
             if (string.IsNullOrWhiteSpace(model))
             {
                 throw new Exception("model is required.");
             }

             if (model.Length <= 1)
             {
                 throw new Exception("model must be longer than 1 character.");
             }
             Model = model;
         }

         public void SetPrice(decimal price)
         {
             if (price <= 0)
             {
                 throw new Exception("price must be greater than 0.");
             }
             Price = price;
         }

         public void Create()
         {
             Console.Write("Enter the brand: ");
             string brand = Console.ReadLine();
             SetBrand(brand);
             
             Console.Write("Enter the model: ");
             string model = Console.ReadLine();
             SetModel(model);
             
             
             Console.Write("Enter the price: ");
             string price = Console.ReadLine();
             SetPrice(decimal.Parse(price));
         }

         public void ShowInfo()
         {
             Console.WriteLine($"Brand: {Brand}");
             Console.WriteLine($"Model: {Model}");
             Console.WriteLine($"Price: ${Price}");
             Console.WriteLine("");
         }
    }
}
