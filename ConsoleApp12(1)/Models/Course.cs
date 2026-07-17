using ConsoleApp12.Common;

namespace ConsoleApp12.Models
{
    internal sealed class Course : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        
        public List<Student> Students { get; private set; } = new List<Student>();

        public void AddStudent(Student student)
        {
            if (Students.Any(s => s.Id == student.Id))
                throw new Exception("student already in course");
            Students.Add(student);
        }

        public void RemoveStudent(int studentId)
        {
            Student? student = Students.FirstOrDefault(s => s.Id == studentId);
            if (student == null)
                throw new Exception("student not in course");
            Students.Remove(student);
        }

        private Course(string name, string desc)
        {
            Name = name;
            Description = desc;
        }

        public static Course Create(string name, string desc)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("course name is required");

            if (name.Length <= 2)
                throw new Exception("course name must be greater then 2");

            if (string.IsNullOrWhiteSpace(desc))
                throw new Exception("course description is required");

            if (desc.Length <= 6)
                throw new Exception("course description must be greater then 6");

            return new Course(name, desc);
        }

        public void ShowInfo()
        {
            Console.WriteLine($"ID: {Id}, name: {Name}, description: {Description}");
        }
    }
}
