namespace StudentLinq;

public class StudentService
{
    private readonly List<Student> _students;

    public StudentService(List<Student> students)
    {
        _students = students;
    }

    public List<Student> GetByFaculty(string faculty)
    {
        return _students.Where(s => s.Faculty == faculty).ToList();
    }
    
    public List<Student> GetTopStudents(double minGrade)
    {
        return _students.Where(s => s.Grade >= minGrade)
            .OrderByDescending(s => s.Grade)
            .ToList();
    }

    public double GetAverageGrade()
    {
        if (_students.Count == 0) return 0;
        return _students.Average(s => s.Grade);
    }
    
    public int CountByFaculty(string faculty)
    {
        return _students.Count(s => s.Faculty == faculty);
    }
    
    public Student? FindById(int id)
    {
        return _students.FirstOrDefault(s => s.Id == id);
    }
}