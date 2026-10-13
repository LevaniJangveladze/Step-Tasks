using StudentLinq;

namespace StudentLinq.Tests;

public class StudentServiceTests
{
    private List<Student> GetSampleStudents()
    {
        return new List<Student>
        {
            new Student { Id = 1, Name = "Levani", Age = 26, Grade = 9.5, Faculty = "IT" },
            new Student { Id = 2, Name = "Nino",   Age = 22, Grade = 7.0, Faculty = "IT" },
            new Student { Id = 3, Name = "Giorgi", Age = 24, Grade = 8.5, Faculty = "Law" },
        };
    }

    [Fact]
    public void GetByFaculty_ReturnsOnlyMatchingStudents()
    {
        var service = new StudentService(GetSampleStudents());

        var result = service.GetByFaculty("IT");

        Assert.Equal(2, result.Count);
        Assert.All(result, s => Assert.Equal("IT", s.Faculty));
    }

    [Fact]
    public void GetByFaculty_ReturnsEmpty_WhenFacultyDoesNotExist()
    {
        var service = new StudentService(GetSampleStudents());

        var result = service.GetByFaculty("Medicine");

        Assert.Empty(result);
    }

    [Fact]
    public void GetTopStudents_ReturnsStudentsSortedByGradeDescending()
    {
        var service = new StudentService(GetSampleStudents());

        var result = service.GetTopStudents(8.0);

        Assert.Equal(2, result.Count);
        Assert.Equal("Levani", result[0].Name);
        Assert.Equal("Giorgi", result[1].Name);
    }

    [Fact]
    public void GetAverageGrade_ReturnsCorrectAverage()
    {
        var service = new StudentService(GetSampleStudents());

        var result = service.GetAverageGrade();

        Assert.Equal(8.33, result, 2);
    }

    [Fact]
    public void GetAverageGrade_ReturnsZero_WhenNoStudents()
    {
        var service = new StudentService(new List<Student>());

        var result = service.GetAverageGrade();

        Assert.Equal(0, result);
    }

    [Fact]
    public void FindById_ReturnsStudent_WhenIdExists()
    {
        var service = new StudentService(GetSampleStudents());

        var result = service.FindById(2);

        Assert.NotNull(result);
        Assert.Equal("Nino", result.Name);
    }

    [Fact]
    public void FindById_ReturnsNull_WhenIdDoesNotExist()
    {
        var service = new StudentService(GetSampleStudents());

        var result = service.FindById(99);

        Assert.Null(result);
    }

    [Fact]
    public void CountByFaculty_ReturnsCorrectCount()
    {
        var service = new StudentService(GetSampleStudents());

        Assert.Equal(2, service.CountByFaculty("IT"));
        Assert.Equal(1, service.CountByFaculty("Law"));
        Assert.Equal(0, service.CountByFaculty("Medicine"));
    }
}