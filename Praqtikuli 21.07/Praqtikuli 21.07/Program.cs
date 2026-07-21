using Praqtikuli_21._07.Database;
using Praqtikuli_21._07.Menu;
using Praqtikuli_21._07.Services;

namespace Praqtikuli_21._07;

class Program
{
    static void Main(string[] args)
    {
        DataContext db = DataContext.Create();
        MovieService movieService = new MovieService(db);
        MovieMenu.Start(movieService);
    }
}