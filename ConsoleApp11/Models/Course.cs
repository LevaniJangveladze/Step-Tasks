namespace ConsoleApp11.Models
{
    internal class Game
    {
        private static int _counter = 1;
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Genre { get ; set ; }
        public decimal Price { get ; set ; }

        public void ShowInfo()
        {
            Console.WriteLine($"ID: {Id}, name: {Name}, genre: {Genre}, price: {Price}");
        }

        public Game()
        {
            Id = _counter++;
        }
    }
}
