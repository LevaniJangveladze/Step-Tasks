using ConsoleApp5.Data;
using ConsoleApp5.Services;

var db = new DataContext();

var studentServices = new StudentServices(db);
var courseServices = new CourseServices(db);
var enrollmentServices = new EnrollmentServices(db);

bool isOpen = true;

while (isOpen)
{
    Console.WriteLine("1. create student");
    Console.WriteLine("2. create course");
    Console.WriteLine("3. create enrollment");
    Console.WriteLine("4. show enrollments");4
        
    Console.WriteLine("x. exit");
    
    Console.Write("Enter key: ");
    string key = Console.ReadLine();

    try
    {
        switch (key)
        {
            case "1":
                studentServices.Create();
                break;
            case "2":
                courseServices.Create();
                break;
            case "3":
                enrollmentServices.Create();
                break;
            case "4" :
                enrollmentServices.Show();
                break;
            case "x":
                isOpen = false;
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"ERROR: {ex.Message}");
    }
}