using ConsoleApp11.Models;
namespace ConsoleApp11.Services
{
    internal class GameServices
    {
        private List<Game> _games = new();

        public void Create()
        {
            Console.WriteLine("Enter name");
            string name = Console.ReadLine();
            
            Console.WriteLine("Enter genre");
            string genre = Console.ReadLine();
            
            Console.WriteLine("Enter price");
            decimal price = decimal.Parse(Console.ReadLine());

            Game game = new Game()
            {
                Name = name,
                Genre = genre,
                Price = price
            };
            _games.Add(game);
            Console.WriteLine("Game created");
        }

        public void Delete()
        {
            Console.WriteLine("Enter ID");
            int id = int.Parse(Console.ReadLine());

            Game? game = _games.FirstOrDefault(g => g.Id == id);
            if (game == null)
            {
                throw new Exception("Game not found");
            }
            _games.Remove(game);
        }

        public void Update()
        {
            Console.WriteLine("Enter ID");
            int id = int.Parse(Console.ReadLine());
            
            Game? game = _games.FirstOrDefault(g => g.Id == id);
            if (game == null)
            {
                throw new Exception("Game not found");
            }
            
            Console.WriteLine("Enter new name");
            string newname = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newname))
            {
                game.Name = newname;
            }
            
            Console.WriteLine("Enter new genre");
            string genre = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(genre))
            {
                game.Genre = genre;
            }
            
            Console.Write("Enter new price: ");
            string price = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(price))
            {
                game.Price = decimal.Parse(price);  
            }
            
            Console.WriteLine("Game updated");
        }

        public void Show()
        {
            foreach (var game in _games)
            {
              game.ShowInfo();
            }
        }

        public void FilterByPrice()
        {
            Console.WriteLine("Enter max price");
            decimal maxprice = decimal.Parse(Console.ReadLine());
            
            List<Game> filtered = _games.Where(g => g.Price < maxprice).ToList();
            foreach (var game in filtered)
            {
                game.ShowInfo();
            }
        }

        public void Search()
        {
            Console.WriteLine("Enter name");
            string name = Console.ReadLine();

            List<Game> searched = _games.Where(g => g.Name.Contains(name)).ToList();
            foreach (var game in searched)
            {
                game.ShowInfo();
            }
        }
    }

}
