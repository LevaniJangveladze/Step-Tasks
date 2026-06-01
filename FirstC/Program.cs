using System;

class Program
{
    static void Main()
    {
        string name = "Luka";

        int age = 25;
        byte favoriteNumber = 7;
        long bigNumber = 9000000000;

        double height = 1.82;
        decimal salary = 2500.50m;

        bool isStudent = true;
        char grade = 'A';

        int[] examScores = { 85, 90, 78, 100 };
        
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Age: {age}, Favorite Number: {favoriteNumber}");
        Console.WriteLine($"Big Number: {bigNumber}");
        Console.WriteLine($"Height: {height}m");
        Console.WriteLine($"Salary: {salary}GEL");
        Console.WriteLine($"Is a student? {isStudent}");
    }
}