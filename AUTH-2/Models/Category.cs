using AUTH.Common;

namespace AUTH.Models
{
    internal class Category : Entity
    {
        public string Name { get; private set; }

        private Category(string name) => Name = name;

        public static Category Create(string name)
        {
            if (name.Length < 3 || name.Length > 50)
                throw new Exception("category name must be greateer then 2 and lowwer then 50");

            return new Category(name);
        }

        public void ShowInfo()
        {
            Console.WriteLine($"ID: {Id}, name: {Name}");
        }

        public void ChangeName(string name)
        {
            if(name.Length < 3 || name.Length > 50)
                throw new Exception("category name must be greateer then 2 and lower then 50");
            Name = name;
        }
    }
}
