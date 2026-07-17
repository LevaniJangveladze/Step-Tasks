using ConsoleApp12.Common;

namespace ConsoleApp12.Models
{
    internal sealed class Category : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        private Category(string name, string desc)
        {
            Name = name;
            Description = desc;
        }

        public static Category Create(string name, string desc)
        {
            ValidateName(name);
            ValidateDesc(desc);
            return new Category(name, desc);
        }

        public void SetName(string name)
        {
            ValidateName(name);
            Name = name;
        }

        public void SetDescription(string desc)
        {
            ValidateDesc(desc);
            Description = desc;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"ID: {Id}, name: {Name}, description: {Description}");
        }

        private static void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("category name is required");
            if (name.Length <= 2)
                throw new Exception("category name must be greater then 2");
        }

        private static void ValidateDesc(string desc)
        {
            if (string.IsNullOrWhiteSpace(desc))
                throw new Exception("category description is required");
            if (desc.Length <= 6)
                throw new Exception("category description must be greater then 6");
        }
    }
}