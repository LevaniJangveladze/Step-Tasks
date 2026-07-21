using Praqtikuli_21._07.Database;

namespace Praqtikuli_21._07.Services;

public sealed class MovieService
{
    private readonly DataContext _db;
    
    public MovieService(DataContext db) => _db = db;
    
    public void Create() { }
    public void Delete() { }
    public void Update() { }
    public void Show() { }
    public void Search() { }
    public void Filter() { }
}