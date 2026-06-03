class Student
{
    public string Name = "";
    public int Age;
    public int Score;

    public void PrintInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Age: {Age}");
        Console.WriteLine($"Score: {Score}");
    }
    
    

    public void GradeInfo()
    {
        if (Score >= 90)
        {
            Console.WriteLine($"{Name} is an excellent student");
        }
        else if (Score >= 70)
        {
            Console.WriteLine($"{Name} is a good student");
        }
        else
        {
            Console.WriteLine($"{Name} is a bad student");
        }
    }
}

class Car
{
    public string Brand = "";
    public string Model = "";
    public int Year;

    public void PrintInfo()
    {   
       
        Console.WriteLine($"Brand: {Brand}");
        Console.WriteLine($"Model: {Model}");
        Console.WriteLine($"Year: {Year}");
        
    }

    public Car(string brand, string model, int year)
    {
        Brand = brand;
        Model = model;
        Year = year;
    }
    
    public Car() { }
}

class Program
{
    static void Main(string[] args)
    {
        Student student1 = new Student();
        
        student1.Name = "Levani";
        student1.Age = 26;
        student1.Score = 100;
        
        
        student1.PrintInfo();
        student1.GradeInfo();

        Car car1 = new Car();
        Car car2 = new Car("Mercedes", "GLE", 2025);
        Car car3 = new Car { Brand = "Maseratti", Model = "Levante", Year = 2025 };
        
        car1.Brand = "BMW";
        car1.Model = "X5M";
        car1.Year = 2026;
        Console.WriteLine("Levan's car below");
        car1.PrintInfo();
        Console.WriteLine("Levan's second car below");
        car2.PrintInfo();
        Console.WriteLine("Levan's third car below");
        car3.PrintInfo();
        
    }
}